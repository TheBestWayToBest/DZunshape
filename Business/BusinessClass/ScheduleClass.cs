using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Modle;
using System.Data.SqlClient;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Data.Common;
using System.Transactions;

namespace Business.BusinessClass
{
    public class ScheduleClass : ValidationClass
    {
        /// <summary>
        /// 订单接收
        /// </summary>
        public ScheduleClass() //根据车组
        {
            //获取  V_SALE_ORDER_HEAD  订单中间表主视图  V_SALE_ORDER_LINE  订单中间表明细视图
            CreateTime = DateTime.Now;
        }
        /// <summary>
        /// SortNum 序列
        /// </summary>
        const string Str_Sortnum_SEQUENCE = "select ZOOMTELDZ.S_PRODUCE_SORTNUM.NEXTVAL from dual ";


        #region 订单接收 从数据源 到 ORDER表和ORDERLINE表中

        /// <summary>
        /// 获取未接收的车组
        /// </summary>
        /// <returns></returns>
        public Response<List<MainOrder>> GetRegionInfo(DateTime nowDate)
        {
            Response<List<MainOrder>> rm = new Response<List<MainOrder>>();
            using (DZEntities en = new DZEntities())
            {
                List<MainOrder> mainOrder = new List<MainOrder>();//订单主表
                var T_SALE_ORDER_HEAD = (from item in en.T_SALE_ORDER_HEAD where item.ORDERDATE == nowDate select item).ToList();//获取主表
                var ReadyRegion = (from item in en.T_PRODUCE_ORDER select item).GroupBy(a => a.REGIONCODE).Select(a => new { RouteCode = a.Key }).ToList(); ;//获取已经接收的车组
                var HeadGroup = T_SALE_ORDER_HEAD.GroupBy(a => a.ROUTECODE).Select(a => new { RouteCode = a.Key }).ToList();//获取主表单个车组
                var exp = HeadGroup.Except(ReadyRegion).OrderBy(z => z.RouteCode);//未排程的车组

                int index = 0;
                foreach (var item in exp)
                {
                    MainOrder mo = new MainOrder();
                    index++;
                    mo.RowNum = index;
                    mo.RegionCode = item.RouteCode;
                    mo.OrderCount = T_SALE_ORDER_HEAD.Where(a => a.ROUTECODE == item.RouteCode).Count();//订单户数
                    mo.OrderNum = T_SALE_ORDER_HEAD.Where(a => a.ROUTECODE == item.RouteCode).Sum(a => a.TOTALQTY) ?? 0;//订单数量
                    mainOrder.Add(mo);
                }
                if (mainOrder.Any())
                {
                    rm.IsSuccess = true;
                    rm.MessageText = "数据查询成功";
                    rm.Content = mainOrder;
                    return rm;

                }
                else
                {
                    rm.IsSuccess = false;
                    rm.MessageText = "【" + nowDate.ToShortDateString() + "】暂无可接收的订单数据，请先进行营销数据同步！";
                    return rm;
                }


            }

        }
        DateTime CreateTime;
        /// <summary>
        /// 根据车组接收
        /// </summary>
        /// <param name="regioncode">车组</param>
        /// <returns></returns>
        public Response ReceiveSaleOrderToOrder(DateTime nowDate, string regioncode, decimal maxSyncseq)
        {
            // V_SALE_ORDER_HEAD  订单中间表主视图 
            Response re = new Response("车组接收异常：未能成功接收，检查车组号是否正确" + regioncode);
            StringBuilder sb = new StringBuilder();
            using (DZEntities en = new DZEntities())
            {

                en.T_PRODUCE_ORDER.Max(aa => aa.SYNSEQ);
                var valDate = ValiDataTime(nowDate);//验证时间
                if (!valDate.IsSuccess)
                {
                    return valDate;
                }
                var valBatch = ValiBatchCode();//验证批次  
                if (valBatch.IsSuccess)
                {
                    //var V_SALE_ORDER_HEAD =  //获取订单主表 根据车组

                    var V_SALE_ORDER_HEAD = (from item in en.T_SALE_ORDER_HEAD where item.ROUTECODE == regioncode && item.ORDERDATE == nowDate orderby item.DELIVERYSEQ select item).ToList();
                    if (V_SALE_ORDER_HEAD.Any())//如果包含数据
                    {
                        decimal index = 0;
                        foreach (var order in V_SALE_ORDER_HEAD)//一个车组 
                        {
                            index++;
                            T_PRODUCE_ORDER t_produce_order = new T_PRODUCE_ORDER();//单个订单
                            //字段的赋值 
                            t_produce_order.BILLCODE = order.ORDERNO;
                            t_produce_order.COMPANYCODE = "";//公司编码
                            t_produce_order.COMPANYNAME = ""; //公司名称
                            t_produce_order.BATCHCODE = valBatch.ResultObject.ToString();
                            t_produce_order.SYNSEQ = maxSyncseq;//批次号
                            t_produce_order.ORDERQUANTITY = order.TOTALQTY;
                            t_produce_order.ORDERMONEY = order.TOTALAMOUNT;
                            t_produce_order.CUSTOMERCODE = order.CUSTOMER_ID;
                            t_produce_order.CUSTOMERNAME = order.CUSTOMER_NAME;
                            t_produce_order.ADDRESS = order.CONTACTADDRESS;
                            t_produce_order.TELEPHONE = order.CONTACTPHONE;
                            t_produce_order.CONTACT = order.CONTACT;
                            t_produce_order.PRIORITY = index;//送货顺序（数据源未提供）
                            t_produce_order.REGIONCODE = order.ROUTECODE;
                            t_produce_order.TASKBOXIES = "";
                            t_produce_order.TASKNUMBERS = "";
                            t_produce_order.STATE = "新增";
                            t_produce_order.UNSTATE = "新增";
                            t_produce_order.DEVSEQ = order.DELIVERYSEQ;//原始送货顺序
                            t_produce_order.CREATETIME = CreateTime;
                            t_produce_order.ORDERDATE = order.ORDERDATE;
                            t_produce_order.SELATASKNUM = 1000;
                            t_produce_order.PAYMENTFLAG = order.PAYMENTFLAG;
                            var reDetail = ReceiveSaleLineToOrderLine(order.ORDERNO);//接收单个订单的条烟明细

                            if (reDetail.IsSuccess)//如果这个这个订单的明细接收无异常
                            {
                                en.T_PRODUCE_ORDER.AddObject(t_produce_order);//添加一个订单 
                                en.SaveChanges();
                            }
                            else//跳出循环
                            {
                                sb.AppendLine(reDetail.MessageText);
                                re.MessageText += sb.ToString();
                                re.IsSuccess = false;
                                return re;
                            }
                        }
                        re.IsSuccess = true;
                        re.MessageText = regioncode + "车组接收成功！";
                        return re;
                    }
                    else
                    {
                        re.IsSuccess = false;
                        re.MessageText = "未找到该车组：" + regioncode;
                        return re;

                    }
                }
                else
                {
                    return valBatch;

                }





            }
        }

        /// <summary>
        /// 接收订单明细 根据订单
        /// </summary>
        /// <returns></returns>
        private Response ReceiveSaleLineToOrderLine(string billcode)
        {
            Response re = new Response("接收订单明细异常：未能成功接收，订单号：" + billcode);
            StringBuilder sb = new StringBuilder();
            using (DZEntities en = new DZEntities())
            {
                //var V_SALE_ORDER_LINE =  //根据订单号 获取订单明细
                var V_SALE_ORDER_LINE = (from item in en.T_SALE_ORDER_LINE where item.ORDERNO == billcode select item).ToList();
                if (V_SALE_ORDER_LINE.Any())
                {
                    foreach (var detail in V_SALE_ORDER_LINE)
                    {
                        T_PRODUCE_ORDERLINE t_produce_orderline = new T_PRODUCE_ORDERLINE();
                        t_produce_orderline.BILLCODE = detail.ORDERNO;
                        t_produce_orderline.LINENUM = Guid.NewGuid().GetHashCode();
                        t_produce_orderline.CIGARETTECODE = detail.ITEM_ID;
                        t_produce_orderline.CIGARETTENAME = detail.ITEMNAME;
                        t_produce_orderline.QUANTITY = detail.QTY;
                        t_produce_orderline.PRICE = detail.SALEPRICE;
                        t_produce_orderline.UNIT = "条";
                        t_produce_orderline.MOENY = detail.SALEAMOUNT;
                        t_produce_orderline.MULTIPLE = 1;
                        t_produce_orderline.ALLOWSORT = "非标";
                        en.T_PRODUCE_ORDERLINE.AddObject(t_produce_orderline);//添加置实体集
                    }
                    en.SaveChanges();
                    re.IsSuccess = true;
                    re.MessageText = "接收订单" + billcode + "明细成功";
                    return re;

                }
                else
                {
                    sb.AppendLine("订单号：" + billcode + "未找到任何条烟明细");
                    re.MessageText = sb.ToString();
                    re.IsSuccess = false;
                    return re;
                }

            }

        }
        #endregion

        #region 预排程 从ORDER,ORDERLINE 接收数据至 TASK 和TASKLINE

        /// <summary>
        /// 获取新增的车组
        /// </summary>
        /// <returns></returns>
        public Response<List<TaskInfo>> GetRouteInFO(List<string> regionSort)
        {
            Response<List<TaskInfo>> reList = new Response<List<TaskInfo>>();
            using (DZEntities en = new DZEntities())
            {
                List<TaskInfo> taskList = new List<TaskInfo>();//订单主表
                //var query = (from item in en.T_PRODUCE_ORDER where item.STATE == "新增" select item).ToList();
                var query = (from order in en.T_PRODUCE_ORDER
                             join line in en.T_PRODUCE_ORDERLINE on order.BILLCODE equals line.BILLCODE
                             join item in en.T_WMS_ITEM on line.CIGARETTECODE equals item.ITEMNO
                             where order.UNSTATE == "新增" && item.SHIPTYPE == "1" && item.ROWSTATUS == 10
                             select new { regioncode = order.REGIONCODE, customercode = order.CUSTOMERCODE, qty = line.QUANTITY }
                    //select order
                             ).ToList();
                var query1 = (from order in en.T_PRODUCE_ORDER
                              join line in en.T_PRODUCE_ORDERLINE on order.BILLCODE equals line.BILLCODE
                              join item in en.T_WMS_ITEM on line.CIGARETTECODE equals item.ITEMNO
                              where order.UNSTATE == "新增" && item.SHIPTYPE == "1" && item.ROWSTATUS == 10
                              select order).ToList().Distinct();
                //select order

                var list = (from item in query
                            group item by new { item.regioncode } into g
                            select new { regioncode = g.Key.regioncode, qty = g.Sum(x => x.qty) }).ToList();

                var list1 = (from item in query1
                             group item by new { item.REGIONCODE } into g
                             select new { regioncode = g.Key.REGIONCODE, ct = g.Count() }).ToList();
                var list3 = (from item1 in list
                             join item2 in list1 on item1.regioncode equals item2.regioncode
                             orderby item1.regioncode
                             select new { regioncode = item1.regioncode, ct = item2.ct, qty = item1.qty }).ToList();
                //return null;

                //List<string> region = new List<string>();
                //region = RegionSort.GetRegionSort();
                decimal index = 0;


                for (int j = 0; j < regionSort.Count; j++)
                {
                    foreach (var item in list3)
                    {

                        if (item.regioncode.Contains(regionSort[j]))
                        {

                            TaskInfo taskInfo = new TaskInfo();
                            index++;
                            taskInfo.SYNSEQ = index;
                            taskInfo.REGIONCODE = item.regioncode;
                            taskInfo.QTY = item.qty ?? 0;
                            taskInfo.Count = item.ct;
                            taskList.Insert(Convert.ToInt32(index) - 1, taskInfo);
                            //break;
                        }
                    }
                    //TaskInfo taskInfo = new TaskInfo();
                    //index++;
                    //taskInfo.SYNSEQ = index;
                    //taskInfo.REGIONCODE = item.regioncode;
                    //taskInfo.QTY = item.qty ?? 0;
                    //taskInfo.Count = item.ct;
                    //taskList.Add(taskInfo);
                }

                if (taskList.Any())
                {
                    reList.IsSuccess = true;
                    //reList.MessageText = "找到数据了，在Content里面";
                    reList.Content = taskList;
                    return reList;
                }
                else
                {
                    reList.IsSuccess = false;
                    reList.MessageText = "未找到新增车组！";
                    return reList;
                }

            }

        }
        /// <summary>
        /// 对单个车组进行预排程
        /// </summary>
        /// <param name="regioncode"></param>
        /// <returns></returns>
        /// 

        public Response PreScheduleForSingleOrder(string regioncode)
        {
            Response re = new Response("预排程失败，未找到对应的车组" + regioncode);
            StringBuilder sb = new StringBuilder();
            using (DZEntities en = new DZEntities())
            {
                var valBatch = ValiBatchCode();
                if (!valBatch.IsSuccess)
                {
                    return valBatch;
                }
                //group item by new { item.REGIONCODE } into g
                //            select new { regioncode = g.Key.REGIONCODE, qty = g.Sum(x => x.TASKQUANTITY), count = g.Count() }).To

                var Order = en.T_PRODUCE_ORDER.ToList();
                var Line = en.T_PRODUCE_ORDERLINE.ToList();
                var Item = en.T_WMS_ITEM.ToList();

                var singleOrder = (from order in Order
                                   join line in Line on order.BILLCODE equals line.BILLCODE
                                   join item in Item on line.CIGARETTECODE equals item.ITEMNO
                                   where order.UNSTATE == "新增" && item.SHIPTYPE == "1" && order.REGIONCODE == regioncode
                                   group line by new { order.BILLCODE, order.DEVSEQ } into x
                                   select new { billcode = x.Key, qty = x.Sum(g => g.QUANTITY) }
                               ).ToList().Where(x => x.qty == 1).Select(x => x.billcode).OrderBy(x => x.DEVSEQ).ToList();
                //var t_produce_Order = (from item in en.T_PRODUCE_ORDER where item.REGIONCODE == regioncode select item).ToList();//根据车组查询ORder表中所对应的订单
                var t_produce_Order = (from order in Order
                                       join line in Line on order.BILLCODE equals line.BILLCODE
                                       join item in Item on line.CIGARETTECODE equals item.ITEMNO
                                       where order.UNSTATE == "新增" && item.SHIPTYPE == "1" && order.REGIONCODE == regioncode
                                       orderby order.DEVSEQ
                                       select order).Distinct().OrderBy(x => x.DEVSEQ).ToList();

                //Order.Where(x => x.BILLCODE);
                //var query=(from task in en.T_UN_TASK select task.TASKNUM).Max();

                //取目前车组最大的Tasknum,如果没有,则给默认任务号
                //decimal maxTaskNum = GetMaxTaskNumByRegioncode(regioncode).Content;
                decimal maxTaskNum = GetMaxTaskNumByRegioncode().Content;
                if (maxTaskNum == 0)
                {
                    //无法确定车组号是否是数字组成,不再将车组号编入任务编号中
                    //String max = DateTime.Now.ToString("yyyyMMdd") + regioncode + "000";
                    String max = DateTime.Now.ToString("yyyyMMdd") + "000000";
                    //if (regioncode.Contains("@")) max = DateTime.Now.ToString("yyyyMMdd") + regioncode.Split('@')[0] + "000";
                    //String max = DateTime.Now.ToString("yyyyMMdd") + regioncode + "000";
                    maxTaskNum = Convert.ToDecimal(max);
                }

                //String query = maxTaskNum+regioncode+""
                //if (query != null&&!"".Equals(query)) maxTaskNum = query.ToString();
                //var maxtasknum = (en.T_UN_TASK.Max(a => a.TASKNUM) ?? 0) + 1;
                //(dzEntities.T_PRODUCE_ORDER.Max(a => a.SYNSEQ) ?? 0) + 1;
                if (singleOrder.Any())
                {
                    #region
                    int index = 0, tmpIndex = 0, custSeq = 0;
                    foreach (var g in singleOrder)
                    {
                        T_UN_TASK t_un_task = new T_UN_TASK();

                        var item = t_produce_Order.Where(x => x.BILLCODE == g.BILLCODE).FirstOrDefault();
                        if (item != null)
                        {
                            //字段赋值
                            index++;
                            tmpIndex++;
                            t_un_task.TASKNUM = maxTaskNum + index;
                            t_un_task.LINENUM = "1";
                            t_un_task.EXPORTNUM = "1";
                            if (item.REGIONCODE.Contains("@"))
                            {
                                string str = item.REGIONCODE;
                                t_un_task.REGIONCODE = str.Split('@')[0];
                                t_un_task.REGIONDESC = str.Split('@')[1];
                            }
                            else
                            {
                                t_un_task.REGIONCODE = item.REGIONCODE;
                                t_un_task.REGIONDESC = item.REGIONCODE;
                            }

                            t_un_task.BILLCODE = item.BILLCODE;
                            t_un_task.COMPANYCODE = item.COMPANYCODE;
                            t_un_task.COMPANYNAME = item.COMPANYNAME;
                            t_un_task.BATCHCODE = item.BATCHCODE;
                            t_un_task.SYNSEQ = item.SYNSEQ;
                            t_un_task.CUSTOMERCODE = item.CUSTOMERCODE;
                            t_un_task.CUSTOMERNAME = item.CUSTOMERNAME;
                            t_un_task.ADDRESS = item.ADDRESS;
                            t_un_task.TELEPHONE = item.TELEPHONE;
                            t_un_task.ORDERQUANTITY = item.ORDERQUANTITY;
                            t_un_task.TASKQUANTITY = item.ORDERQUANTITY;
                            custSeq = Convert.ToInt32(item.PRIORITY);//送货顺序  每个车组从1到最后一户
                            t_un_task.PRIORITY = custSeq;
                            t_un_task.TASKBOX = "F";
                            t_un_task.SORTSEQ = index;//户序   单独异型烟户序
                            t_un_task.LABLENUM = "F";
                            t_un_task.PLANTIME = CreateTime;
                            t_un_task.SORTTIME = CreateTime;
                            t_un_task.FINISHTIME = null;
                            t_un_task.STATE = "10";
                            t_un_task.LABELBATCH = 1;
                            t_un_task.PALLETNUM = 1;
                            if (custSeq == tmpIndex)
                            {
                                t_un_task.EXISTRCD = 1;
                            }
                            else
                            {
                                t_un_task.EXISTRCD = 0;
                            }
                            tmpIndex = custSeq;

                            t_un_task.ORDERDATE = item.ORDERDATE;
                            t_un_task.MAINBELT = 1;
                            t_un_task.PACKAGEMACHINE = 1;
                            t_un_task.PAYMENTFLAG = item.PAYMENTFLAG;
                            t_un_task.SORTNUM = en.ExecuteStoreQuery<decimal>(Str_Sortnum_SEQUENCE, null).FirstOrDefault();//SortNum序列 
                            t_un_task.SECSORTNUM = t_un_task.SORTNUM;
                            var psDetail = PreScheduleDetail(en, t_un_task.BILLCODE, t_un_task.TASKNUM);//添加单个订单的条烟明细到TASKLINE
                            if (psDetail.IsSuccess)
                            {
                                en.T_PRODUCE_ORDER.Where(a => a.BILLCODE == t_un_task.BILLCODE).FirstOrDefault
                                    ().UNSTATE = "排程";
                                t_un_task.TASKQUANTITY = Convert.ToDecimal(psDetail.ResultObject ?? 0);
                                en.T_UN_TASK.AddObject(t_un_task);//添加到实体集 

                                en.SaveChanges();
                            }
                            else
                            {
                                return psDetail;
                            }
                        }
                    #endregion
                    }
                    re.IsSuccess = true;
                    re.MessageText = regioncode + "车组预排程成功！";
                    return re;
                }
                else
                {
                    re.IsSuccess = true;
                    re.MessageText = regioncode + "车组没有一条烟订单！";
                    return re;
                }



            }


        }

        public Response PreSchedule(string regioncode)
        {
            Response re = new Response("预排程失败，未找到对应的车组" + regioncode);
            StringBuilder sb = new StringBuilder();
            using (DZEntities en = new DZEntities())
            {

                var valBatch = ValiBatchCode();
                if (!valBatch.IsSuccess)
                {
                    return valBatch;
                }
                //var t_produce_Order = (from item in en.T_PRODUCE_ORDER where item.REGIONCODE == regioncode select item).ToList();//根据车组查询ORder表中所对应的订单
                var t_produce_Order = (from order in en.T_PRODUCE_ORDER
                                       join line in en.T_PRODUCE_ORDERLINE on order.BILLCODE equals line.BILLCODE
                                       join item in en.T_WMS_ITEM on line.CIGARETTECODE equals item.ITEMNO
                                       where order.UNSTATE == "新增" && item.SHIPTYPE == "1" && order.REGIONCODE == regioncode
                                       orderby order.DEVSEQ
                                       select order).Distinct().OrderBy(x => x.DEVSEQ).ToList();
                //var query=(from task in en.T_UN_TASK select task.TASKNUM).Max();

                //取目前车组最大的Tasknum,如果没有,则给默认任务号
                //decimal maxTaskNum = GetMaxTaskNumByRegioncode(regioncode).Content;
                decimal maxTaskNum = GetMaxTaskNumByRegioncode().Content;
                if (maxTaskNum == 0)
                {
                    //无法确定车组号是否是数字组成,不再将车组号编入任务编号中
                    //String max = DateTime.Now.ToString("yyyyMMdd") + regioncode + "000";
                    String max = DateTime.Now.ToString("yyyyMMdd") + "000000";
                    //if (regioncode.Contains("@")) max = DateTime.Now.ToString("yyyyMMdd") + regioncode.Split('@')[0] + "000";
                    //String max = DateTime.Now.ToString("yyyyMMdd") + regioncode + "000";
                    maxTaskNum = Convert.ToDecimal(max);
                }

                //String query = maxTaskNum+regioncode+""
                //if (query != null&&!"".Equals(query)) maxTaskNum = query.ToString();
                //var maxtasknum = (en.T_UN_TASK.Max(a => a.TASKNUM) ?? 0) + 1;
                //(dzEntities.T_PRODUCE_ORDER.Max(a => a.SYNSEQ) ?? 0) + 1;
                if (t_produce_Order.Any())
                {
                    int index = 0, tmpIndex = 0, custSeq = 0;
                    foreach (var item in t_produce_Order)
                    {
                        T_UN_TASK t_un_task = new T_UN_TASK();
                        //字段赋值
                        index++;
                        tmpIndex++;
                        t_un_task.TASKNUM = maxTaskNum + index;
                        t_un_task.LINENUM = "1";
                        t_un_task.EXPORTNUM = "1";
                        if (item.REGIONCODE.Contains("@"))
                        {
                            string str = item.REGIONCODE;
                            t_un_task.REGIONCODE = str.Split('@')[0];
                            t_un_task.REGIONDESC = str.Split('@')[1];
                        }
                        else
                        {
                            t_un_task.REGIONCODE = item.REGIONCODE;
                            t_un_task.REGIONDESC = item.REGIONCODE;
                        }

                        t_un_task.BILLCODE = item.BILLCODE;
                        t_un_task.COMPANYCODE = item.COMPANYCODE;
                        t_un_task.COMPANYNAME = item.COMPANYNAME;
                        t_un_task.BATCHCODE = item.BATCHCODE;
                        t_un_task.SYNSEQ = item.SYNSEQ;
                        t_un_task.CUSTOMERCODE = item.CUSTOMERCODE;
                        t_un_task.CUSTOMERNAME = item.CUSTOMERNAME;
                        t_un_task.ADDRESS = item.ADDRESS;
                        t_un_task.TELEPHONE = item.TELEPHONE;
                        t_un_task.ORDERQUANTITY = item.ORDERQUANTITY;
                        t_un_task.TASKQUANTITY = item.ORDERQUANTITY;
                        custSeq = Convert.ToInt32(item.PRIORITY);//送货顺序  每个车组从1到最后一户
                        t_un_task.PRIORITY = custSeq;
                        t_un_task.TASKBOX = "F";
                        t_un_task.SORTSEQ = index;//户序   单独异型烟户序
                        t_un_task.LABLENUM = "F";
                        t_un_task.PLANTIME = CreateTime;
                        t_un_task.SORTTIME = CreateTime;
                        t_un_task.FINISHTIME = null;
                        t_un_task.STATE = "10";
                        t_un_task.LABELBATCH = 100;
                        t_un_task.PALLETNUM = 1;
                        if (custSeq == tmpIndex)
                        {
                            t_un_task.EXISTRCD = 1;
                        }
                        else
                        {
                            t_un_task.EXISTRCD = 0;
                        }
                        tmpIndex = custSeq;

                        t_un_task.ORDERDATE = item.ORDERDATE;
                        t_un_task.MAINBELT = 1;
                        t_un_task.PACKAGEMACHINE = 1;
                        t_un_task.PAYMENTFLAG = item.PAYMENTFLAG;
                        t_un_task.SORTNUM = en.ExecuteStoreQuery<decimal>(Str_Sortnum_SEQUENCE, null).FirstOrDefault();//SortNum序列 
                        t_un_task.SECSORTNUM = t_un_task.SORTNUM;
                        var psDetail = PreScheduleDetail(en, t_un_task.BILLCODE, t_un_task.TASKNUM);//添加单个订单的条烟明细到TASKLINE
                        if (psDetail.IsSuccess)
                        {
                            en.T_PRODUCE_ORDER.Where(a => a.BILLCODE == t_un_task.BILLCODE).FirstOrDefault
                                ().UNSTATE = "排程";
                            t_un_task.TASKQUANTITY = Convert.ToDecimal(psDetail.ResultObject ?? 0);
                            en.T_UN_TASK.AddObject(t_un_task);//添加到实体集 

                            en.SaveChanges();
                        }
                        else
                        {
                            return psDetail;
                        }
                    }
                    re.IsSuccess = true;
                    re.MessageText = regioncode + "车组预排程成功！";

                    //重新整理车组的户序
                    string para = regioncode.Split('@')[0];
                    var taskList = (from task in en.T_UN_TASK where task.REGIONCODE == para orderby task.SORTNUM select task).ToList();
                    int sortseq = 0;
                    foreach (var item in taskList)
                    {
                        sortseq++;
                        en.T_UN_TASK.Where(a => a.TASKNUM == item.TASKNUM).FirstOrDefault
                                ().SORTSEQ = sortseq;

                        en.SaveChanges();
                    }
                    return re;
                }
                else
                {
                    re.IsSuccess = true;
                    re.MessageText = regioncode + "车组预排程成功！";
                    return re;
                }



            }


        }
        ///<summary>
        /// 添加订单明细（ORDERLINE） 到任务明细（TASKLINE）
        /// </summary>
        /// <param name="en"></param>
        /// <param name="billcode"></param>
        /// <param name="Selatasknum"></param>
        /// <returns></returns>
        private Response PreScheduleDetail(DZEntities en, string billcode, decimal Selatasknum = 0)
        {
            Response re = new Response("未找到订单号：" + billcode + " 条烟明细！");
            var t_produce_ordelrine = (from line in en.T_PRODUCE_ORDERLINE
                                       join item in en.T_WMS_ITEM on line.CIGARETTECODE equals item.ITEMNO
                                       where line.BILLCODE == billcode && item.SHIPTYPE == "1"
                                       select line).ToList();//根据订单号获取该订单的条烟明细
            if (t_produce_ordelrine.Any())
            {
                decimal taskQuantity = 0;
                foreach (var item in t_produce_ordelrine)
                {
                    T_UN_TASKLINE t_un_taskline = new T_UN_TASKLINE();
                    t_un_taskline.TASKNUM = Selatasknum;
                    t_un_taskline.CIGARETTECODE = item.CIGARETTECODE;
                    t_un_taskline.CIGARETTENAME = item.CIGARETTENAME;
                    t_un_taskline.QUANTITY = item.QUANTITY;
                    t_un_taskline.UNIT = item.UNIT;
                    t_un_taskline.PRICE = item.PRICE;
                    t_un_taskline.ALLOWSORT = item.ALLOWSORT;
                    en.T_UN_TASKLINE.AddObject(t_un_taskline);

                    taskQuantity = taskQuantity + t_un_taskline.QUANTITY ?? 0;
                }
                if (en.SaveChanges() > 0)
                {
                    re.ResultObject = taskQuantity;
                    re.IsSuccess = true;
                    return re;
                }
                else
                {
                    re.IsSuccess = false;
                    return re.DefaultResponse;
                }
            }
            else
            {
                return re.DefaultResponse;
            }

        }

        #endregion

        #region 排程 从TASK表和TASKLINE 中 分配任务至 POKE表中

        /// <summary>
        /// 获取任务表的数据
        /// </summary>
        /// <returns></returns>
        public Response<List<TaskInfo>> GetTaskInfo()
        {
            Response<List<TaskInfo>> reList = new Response<List<TaskInfo>>();
            using (DZEntities en = new DZEntities())
            {
                List<TaskInfo> taskList = new List<TaskInfo>();
                var query = (from item in en.T_UN_TASK
                             where item.STATE == "10"
                             group item by new { item.REGIONCODE } into g
                             select new { regioncode = g.Key.REGIONCODE, qty = g.Sum(x => x.TASKQUANTITY), count = g.Count() }).ToList();
                // select new { regioncode = g.Key.regioncode, qty = g.Sum(x => x.qty)  }).ToList();
                decimal index = 0;
                foreach (var item in query)
                {
                    index++;
                    TaskInfo task = new TaskInfo();
                    task.SYNSEQ = index;
                    task.REGIONCODE = item.regioncode;
                    task.Count = item.count;
                    task.QTY = item.qty ?? 0;
                    taskList.Add(task);
                }
                if (taskList.Any())
                {
                    reList.IsSuccess = true;
                    //reList.MessageText = "找到数据了，在Content里面";
                    reList.Content = taskList;
                    return reList;
                }
                else
                {
                    reList.IsSuccess = false;
                    reList.MessageText = "未找到新增车组！";
                    return reList;
                }

                //if (query.Any())
                //{
                //    reList.IsSuccess = true;
                //    reList.MessageText = "找到数据了，在content里面";
                //    reList.Content = query;
                //    return reList;
                //}
                //else
                //{
                //    reList.IsSuccess = false;
                //    reList.MessageText = "未找到需要排程的数据！";
                //    return reList;
                //}


            }


        }

        class MSInfo
        {
            public string cigCode { get; set; }
            public int count { get; set; }
        }
        /// <summary>
        /// 任务数据排程 直接一次性排程Task表中的所有数据
        /// </summary>
        /// <returns></returns>
        public Response SchedulePoke()
        {
            Response re = new Response("数据排程：未找对应的数据！");
            using (DZEntities en = new DZEntities())
            {
                //TransactionOptions transactionOption = new TransactionOptions();
                //transactionOption.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                //using (TransactionScope tran = new TransactionScope(TransactionScopeOption.Required, transactionOption))
                //{
                try
                {
                    //当前通道支持卧式设多通道,立式设多通道,支持立式和卧式联合设置多通道(即品牌同时设置在立式和卧式)
                    var msorttrough = (from item in en.T_PRODUCE_SORTTROUGH
                                       where item.STATE == "10" && (item.GROUPNO == 3 || item.GROUPNO == 2)
                                       group item by new { item.CIGARETTECODE } into g
                                       select new MSInfo { cigCode = g.Key.CIGARETTECODE, count = g.Count() }
                                    ).ToList().Where(x => x.count > 1).Select(x => x.cigCode).ToList();
                    var special_two = (from trough in en.T_PRODUCE_SORTTROUGH

                                       where trough.STATE == "10" && (trough.GROUPNO == 3 || trough.GROUPNO == 2)
                                       orderby trough.CIGARETTECODE, trough.MACHINESEQ
                                       select trough).OrderBy(item => item.MACHINESEQ).ToList();
                    special_two = special_two.Where(x => msorttrough.Contains(x.CIGARETTECODE)).ToList();
                    Dictionary<string, List<ThroughInfo>> special_dic = new Dictionary<string, List<ThroughInfo>>();
                    if (special_two.Any())
                    {
                        foreach (var item in special_two)
                        {
                            //两个卧式
                            string cigcode = item.CIGARETTECODE;
                            ThroughInfo through = new ThroughInfo();
                            if (special_dic.ContainsKey(cigcode))
                            {
                                through.ID = (item.MANTISSA % 5 > 0 ? item.MANTISSA % 5 : 5) ?? 0;
                                through.CigaretteName = item.CIGARETTENAME;
                                through.CigaretteCode = item.CIGARETTECODE;
                                through.ActCount = item.ACTCOUNT ?? 0;
                                through.GroupNo = item.GROUPNO ?? 0;
                                through.ThroughNum = item.TROUGHNUM;
                                through.MachineSeq = item.MACHINESEQ ?? 0;
                                special_dic[cigcode].Add(through);
                            }
                            else
                            {
                                through.ID = (item.MANTISSA % 5 > 0 ? item.MANTISSA % 5 : 5) ?? 0;
                                through.CigaretteName = item.CIGARETTENAME;
                                through.CigaretteCode = item.CIGARETTECODE;
                                through.ActCount = item.ACTCOUNT ?? 0;
                                through.GroupNo = item.GROUPNO ?? 0;
                                through.ThroughNum = item.TROUGHNUM;
                                through.MachineSeq = item.MACHINESEQ ?? 0;
                                List<ThroughInfo> list = new List<ThroughInfo>();
                                list.Add(through);
                                special_dic.Add(through.CigaretteCode, list);
                            }
                        }
                    }
                    //其他正常顺序的异型烟任务
                    var t_un_taskUnionTaskline = (from item in en.T_UN_TASK
                                                  join item2 in en.T_UN_TASKLINE on item.TASKNUM equals item2.TASKNUM
                                                  where item.STATE == "10"
                                                  orderby item.SORTNUM
                                                  select new
                                                  {
                                                      SortNum = item.SORTNUM,
                                                      BillCode = item.BILLCODE,
                                                      CigName = item2.CIGARETTENAME,
                                                      CigCode = item2.CIGARETTECODE,
                                                      Quantity = item2.QUANTITY,
                                                      Status = 0,
                                                      TaskQty = 1,
                                                      TaskNum = item.TASKNUM,
                                                      CustomerCode = item.CUSTOMERCODE,
                                                      SecSortNum = item.SORTNUM,
                                                      Ctype = 1,
                                                      PackageMachine = item.PACKAGEMACHINE,
                                                      LineNum = item.LINENUM
                                                  }).ToList();//任务信息表
                    decimal pokeId = GetMaxPokeId(en).Content;//获取最大POKEID
                    if (t_un_taskUnionTaskline.Any())
                    {
                        //int i = 1;
                        ThroughInfo through = new ThroughInfo();
                        int times = 0;//控制次数
                        foreach (var item in t_un_taskUnionTaskline)
                        {
                            Tool.WriteLog.GetLog().Write(item.TaskNum + "===" + item.CigCode);
                            decimal quantity = item.Quantity ?? 0;
                            decimal qty = quantity;
                            decimal quan = quantity;
                            var list = en.T_PRODUCE_SORTTROUGH.Where(ite => ite.STATE == "10" && ite.CIGARETTECODE == item.CigCode).Select(ite => new ThroughInfo
                            {
                                CigaretteName = ite.CIGARETTENAME,
                                CigaretteCode = ite.CIGARETTECODE,
                                ActCount = ite.ACTCOUNT ?? 0,
                                GroupNo = ite.GROUPNO ?? 0,
                                ThroughNum = ite.TROUGHNUM,
                                MachineSeq = ite.MACHINESEQ ?? 0
                            }).ToList();
                            //多通道的烟 均分
                            if (special_dic.ContainsKey(item.CigCode))
                            {
                                through = special_dic[item.CigCode][0];
                                List<ThroughInfo> list2 = new List<ThroughInfo>();
                                list2 = special_dic[item.CigCode];

                                //根据GroupNo去重查询是否在立式烟仓和卧式烟仓都设有通道
                                int countT = list2.Select(x => x.GroupNo).Distinct().Count();

                                if (list[0].GroupNo == 2 && countT == 1)
                                {
                                    int i = 0;
                                    foreach (var t in list)
                                    {
                                        int count = list2.Count;
                                        if (quantity < count)
                                        {
                                            if (quan > 0)
                                            {
                                                qty = 1;
                                                i++;
                                            }
                                            else
                                            {
                                                qty = 0;
                                                break;
                                            }
                                            quan -= 1;
                                        }
                                        else
                                        {
                                            if (quan % (count - i) != 0)
                                            {
                                                qty = Math.Floor(quantity / count);
                                                quan -= qty;
                                                i++;
                                            }
                                            else
                                            {
                                                qty = quan / (count - i);
                                            }
                                        }
                                        if (qty > 0)
                                        {
                                            T_UN_POKE t_un_poke = new T_UN_POKE();
                                            t_un_poke.POKEID = pokeId++;
                                            t_un_poke.TROUGHNUM = list2[0].ThroughNum;
                                            t_un_poke.POKENUM = qty;
                                            t_un_poke.STATUS = item.Status;
                                            t_un_poke.TASKNUM = item.TaskNum;
                                            t_un_poke.TASKQTY = item.TaskQty;
                                            t_un_poke.PACKAGEMACHINE = item.PackageMachine;
                                            t_un_poke.MACHINESEQ = list2[0].MachineSeq;
                                            t_un_poke.LINENUM = item.LineNum;
                                            t_un_poke.CIGARETTECODE = item.CigCode;
                                            t_un_poke.CUSTOMERCODE = item.CustomerCode;
                                            t_un_poke.SORTNUM = item.SortNum;
                                            t_un_poke.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                            t_un_poke.BILLCODE = item.BillCode;
                                            t_un_poke.CTYPE = list2[0].GroupNo;
                                            t_un_poke.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                            t_un_poke.STORENUM = 0;//暂时无用
                                            t_un_poke.GRIDNUM = 0;//暂时无用
                                            t_un_poke.INVFLAG = null;//库存标志
                                            t_un_poke.SENDSEQ = 0; //暂时无用 
                                            en.T_UN_POKE.AddObject(t_un_poke);
                                        }
                                        var reUp = UpdateTaskState(en, item.TaskNum, 100);
                                        if (!reUp.IsSuccess)
                                        {
                                            return reUp;
                                        }
                                        ThroughInfo tmp = list2[0];
                                        list2.RemoveAt(0);
                                        list2.Insert(count - 1, tmp);
                                        special_dic[item.CigCode] = new List<ThroughInfo>();
                                        special_dic[item.CigCode] = list2;
                                    }
                                }
                                else
                                {
                                    if (countT == 1)
                                    {
                                        foreach (var t in list)
                                        {
                                            if (through.ThroughNum == t.ThroughNum)
                                            {
                                                qty = quantity - quantity % 5;
                                            }
                                            else
                                            {
                                                qty = quantity % 5;
                                            }
                                            if (qty > 0)
                                            {
                                                T_UN_POKE t_un_poke = new T_UN_POKE();
                                                t_un_poke.POKEID = pokeId++;
                                                t_un_poke.TROUGHNUM = t.ThroughNum;
                                                t_un_poke.POKENUM = qty;
                                                t_un_poke.STATUS = item.Status;
                                                t_un_poke.TASKNUM = item.TaskNum;
                                                t_un_poke.TASKQTY = item.TaskQty;
                                                t_un_poke.PACKAGEMACHINE = item.PackageMachine;
                                                t_un_poke.MACHINESEQ = t.MachineSeq;
                                                t_un_poke.LINENUM = item.LineNum;
                                                t_un_poke.CIGARETTECODE = item.CigCode;
                                                t_un_poke.CUSTOMERCODE = item.CustomerCode;
                                                t_un_poke.SORTNUM = item.SortNum;
                                                t_un_poke.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                t_un_poke.BILLCODE = item.BillCode;
                                                t_un_poke.CTYPE = t.GroupNo;
                                                t_un_poke.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                t_un_poke.STORENUM = 0;//暂时无用
                                                t_un_poke.GRIDNUM = 0;//暂时无用
                                                t_un_poke.INVFLAG = null;//库存标志
                                                t_un_poke.SENDSEQ = 0; //暂时无用 
                                                en.T_UN_POKE.AddObject(t_un_poke);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (list.Where(x => x.GroupNo == 2).Count() == 1)
                                        {
                                            if (list2.Count == 2)
                                            {

                                                var troughA = list2.Where(x => x.GroupNo == 3).FirstOrDefault();//通道机通道
                                                var troughB = list2.Where(x => x.GroupNo == 2).FirstOrDefault();//立式烟仓通道
                                                if (quantity > troughA.ID)
                                                {
                                                    if (troughA.ID == 5)
                                                    {
                                                        if (quantity > 5)
                                                        {
                                                            T_UN_POKE t_un_poke = new T_UN_POKE();
                                                            t_un_poke.POKEID = pokeId++;
                                                            t_un_poke.TROUGHNUM = troughA.ThroughNum;
                                                            t_un_poke.POKENUM = quantity - quantity % 5;
                                                            t_un_poke.STATUS = item.Status;
                                                            t_un_poke.TASKNUM = item.TaskNum;
                                                            t_un_poke.TASKQTY = item.TaskQty;
                                                            t_un_poke.PACKAGEMACHINE = item.PackageMachine;
                                                            t_un_poke.MACHINESEQ = troughA.MachineSeq;
                                                            t_un_poke.LINENUM = item.LineNum;
                                                            t_un_poke.CIGARETTECODE = item.CigCode;
                                                            t_un_poke.CUSTOMERCODE = item.CustomerCode;
                                                            t_un_poke.SORTNUM = item.SortNum;
                                                            t_un_poke.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                            t_un_poke.BILLCODE = item.BillCode;
                                                            t_un_poke.CTYPE = troughA.GroupNo;
                                                            t_un_poke.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                            t_un_poke.STORENUM = 0;//暂时无用
                                                            t_un_poke.GRIDNUM = 0;//暂时无用
                                                            t_un_poke.INVFLAG = null;//库存标志
                                                            t_un_poke.SENDSEQ = 0; //暂时无用 
                                                            en.T_UN_POKE.AddObject(t_un_poke);

                                                            T_UN_POKE t_un_pokeB = new T_UN_POKE();
                                                            t_un_pokeB.POKEID = pokeId++;
                                                            t_un_pokeB.TROUGHNUM = troughB.ThroughNum;
                                                            t_un_pokeB.POKENUM = quantity % 5;
                                                            t_un_pokeB.STATUS = item.Status;
                                                            t_un_pokeB.TASKNUM = item.TaskNum;
                                                            t_un_pokeB.TASKQTY = item.TaskQty;
                                                            t_un_pokeB.PACKAGEMACHINE = item.PackageMachine;
                                                            t_un_pokeB.MACHINESEQ = troughB.MachineSeq;
                                                            t_un_pokeB.LINENUM = item.LineNum;
                                                            t_un_pokeB.CIGARETTECODE = item.CigCode;
                                                            t_un_pokeB.CUSTOMERCODE = item.CustomerCode;
                                                            t_un_pokeB.SORTNUM = item.SortNum;
                                                            t_un_pokeB.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                            t_un_pokeB.BILLCODE = item.BillCode;
                                                            t_un_pokeB.CTYPE = troughB.GroupNo;
                                                            t_un_pokeB.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                            t_un_pokeB.STORENUM = 0;//暂时无用
                                                            t_un_pokeB.GRIDNUM = 0;//暂时无用
                                                            t_un_pokeB.INVFLAG = null;//库存标志
                                                            t_un_pokeB.SENDSEQ = 0; //暂时无用 
                                                            if (quantity % 5 > 0)
                                                                en.T_UN_POKE.AddObject(t_un_pokeB);
                                                            troughA.ID = 5;
                                                        }
                                                        else
                                                        {
                                                            T_UN_POKE t_un_poke = new T_UN_POKE();
                                                            t_un_poke.POKEID = pokeId++;
                                                            t_un_poke.TROUGHNUM = troughA.ThroughNum;
                                                            t_un_poke.POKENUM = quantity;
                                                            t_un_poke.STATUS = item.Status;
                                                            t_un_poke.TASKNUM = item.TaskNum;
                                                            t_un_poke.TASKQTY = item.TaskQty;
                                                            t_un_poke.PACKAGEMACHINE = item.PackageMachine;
                                                            t_un_poke.MACHINESEQ = troughA.MachineSeq;
                                                            t_un_poke.LINENUM = item.LineNum;
                                                            t_un_poke.CIGARETTECODE = item.CigCode;
                                                            t_un_poke.CUSTOMERCODE = item.CustomerCode;
                                                            t_un_poke.SORTNUM = item.SortNum;
                                                            t_un_poke.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                            t_un_poke.BILLCODE = item.BillCode;
                                                            t_un_poke.CTYPE = troughA.GroupNo;
                                                            t_un_poke.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                            t_un_poke.STORENUM = 0;//暂时无用
                                                            t_un_poke.GRIDNUM = 0;//暂时无用
                                                            t_un_poke.INVFLAG = null;//库存标志
                                                            t_un_poke.SENDSEQ = 0; //暂时无用 
                                                            en.T_UN_POKE.AddObject(t_un_poke);
                                                            troughA.ID = (troughA.ID - quantity) > 0 ? (troughA.ID - quantity) : 5;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        qty = quantity - troughA.ID;
                                                        if (qty % 5 > 0)
                                                        {
                                                            T_UN_POKE t_un_poke = new T_UN_POKE();
                                                            t_un_poke.POKEID = pokeId++;
                                                            t_un_poke.TROUGHNUM = troughB.ThroughNum;
                                                            t_un_poke.POKENUM = qty % 5;
                                                            t_un_poke.STATUS = item.Status;
                                                            t_un_poke.TASKNUM = item.TaskNum;
                                                            t_un_poke.TASKQTY = item.TaskQty;
                                                            t_un_poke.PACKAGEMACHINE = item.PackageMachine;
                                                            t_un_poke.MACHINESEQ = troughB.MachineSeq;
                                                            t_un_poke.LINENUM = item.LineNum;
                                                            t_un_poke.CIGARETTECODE = item.CigCode;
                                                            t_un_poke.CUSTOMERCODE = item.CustomerCode;
                                                            t_un_poke.SORTNUM = item.SortNum;
                                                            t_un_poke.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                            t_un_poke.BILLCODE = item.BillCode;
                                                            t_un_poke.CTYPE = troughB.GroupNo;
                                                            t_un_poke.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                            t_un_poke.STORENUM = 0;//暂时无用
                                                            t_un_poke.GRIDNUM = 0;//暂时无用
                                                            t_un_poke.INVFLAG = null;//库存标志
                                                            t_un_poke.SENDSEQ = 0; //暂时无用 
                                                            en.T_UN_POKE.AddObject(t_un_poke);
                                                        }
                                                        qty = quantity - qty % 5;
                                                        if (qty > 0)
                                                        {
                                                            T_UN_POKE t_un_poke = new T_UN_POKE();
                                                            t_un_poke.POKEID = pokeId++;
                                                            t_un_poke.TROUGHNUM = troughA.ThroughNum;
                                                            t_un_poke.POKENUM = qty;
                                                            t_un_poke.STATUS = item.Status;
                                                            t_un_poke.TASKNUM = item.TaskNum;
                                                            t_un_poke.TASKQTY = item.TaskQty;
                                                            t_un_poke.PACKAGEMACHINE = item.PackageMachine;
                                                            t_un_poke.MACHINESEQ = troughA.MachineSeq;
                                                            t_un_poke.LINENUM = item.LineNum;
                                                            t_un_poke.CIGARETTECODE = item.CigCode;
                                                            t_un_poke.CUSTOMERCODE = item.CustomerCode;
                                                            t_un_poke.SORTNUM = item.SortNum;
                                                            t_un_poke.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                            t_un_poke.BILLCODE = item.BillCode;
                                                            t_un_poke.CTYPE = troughA.GroupNo;
                                                            t_un_poke.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                            t_un_poke.STORENUM = 0;//暂时无用
                                                            t_un_poke.GRIDNUM = 0;//暂时无用
                                                            t_un_poke.INVFLAG = null;//库存标志
                                                            t_un_poke.SENDSEQ = 0; //暂时无用 
                                                            en.T_UN_POKE.AddObject(t_un_poke);
                                                        }
                                                        troughA.ID = 5;
                                                    }
                                                }
                                                else
                                                {
                                                    T_UN_POKE t_un_poke = new T_UN_POKE();
                                                    t_un_poke.POKEID = pokeId++;
                                                    t_un_poke.TROUGHNUM = troughA.ThroughNum;
                                                    t_un_poke.POKENUM = quantity;
                                                    t_un_poke.STATUS = item.Status;
                                                    t_un_poke.TASKNUM = item.TaskNum;
                                                    t_un_poke.TASKQTY = item.TaskQty;
                                                    t_un_poke.PACKAGEMACHINE = item.PackageMachine;
                                                    t_un_poke.MACHINESEQ = troughA.MachineSeq;
                                                    t_un_poke.LINENUM = item.LineNum;
                                                    t_un_poke.CIGARETTECODE = item.CigCode;
                                                    t_un_poke.CUSTOMERCODE = item.CustomerCode;
                                                    t_un_poke.SORTNUM = item.SortNum;
                                                    t_un_poke.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_poke.BILLCODE = item.BillCode;
                                                    t_un_poke.CTYPE = troughA.GroupNo;
                                                    t_un_poke.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_poke.STORENUM = 0;//暂时无用
                                                    t_un_poke.GRIDNUM = 0;//暂时无用
                                                    t_un_poke.INVFLAG = null;//库存标志
                                                    t_un_poke.SENDSEQ = 0; //暂时无用 
                                                    en.T_UN_POKE.AddObject(t_un_poke);
                                                    troughA.ID = (troughA.ID - quantity) > 0 ? (troughA.ID - quantity) : 5;
                                                }
                                            }
                                            else
                                            {
                                                var troughA = list2.Where(x => x.GroupNo == 3).OrderBy(x => x.MachineSeq).FirstOrDefault();//通道机通道，只拨5的倍数
                                                var troughB = list2.Where(x => x.GroupNo == 3 && x.MachineSeq != troughA.MachineSeq).FirstOrDefault();//通道机通道拨余数
                                                var troughC = list2.Where(x => x.GroupNo == 2).FirstOrDefault();//立式烟仓通道
                                                if (quantity % 5 > troughB.ID)
                                                {
                                                    T_UN_POKE t_un_pokeA = new T_UN_POKE();
                                                    t_un_pokeA.POKEID = pokeId++;
                                                    t_un_pokeA.TROUGHNUM = troughA.ThroughNum;
                                                    t_un_pokeA.POKENUM = quantity - quantity % 5;
                                                    t_un_pokeA.STATUS = item.Status;
                                                    t_un_pokeA.TASKNUM = item.TaskNum;
                                                    t_un_pokeA.TASKQTY = item.TaskQty;
                                                    t_un_pokeA.PACKAGEMACHINE = item.PackageMachine;
                                                    t_un_pokeA.MACHINESEQ = troughA.MachineSeq;
                                                    t_un_pokeA.LINENUM = item.LineNum;
                                                    t_un_pokeA.CIGARETTECODE = item.CigCode;
                                                    t_un_pokeA.CUSTOMERCODE = item.CustomerCode;
                                                    t_un_pokeA.SORTNUM = item.SortNum;
                                                    t_un_pokeA.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_pokeA.BILLCODE = item.BillCode;
                                                    t_un_pokeA.CTYPE = troughA.GroupNo;
                                                    t_un_pokeA.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_pokeA.STORENUM = 0;//暂时无用
                                                    t_un_pokeA.GRIDNUM = 0;//暂时无用
                                                    t_un_pokeA.INVFLAG = null;//库存标志
                                                    t_un_pokeA.SENDSEQ = 0; //暂时无用 
                                                    if (t_un_pokeA.POKENUM > 0)
                                                    {
                                                        en.T_UN_POKE.AddObject(t_un_pokeA);
                                                    }

                                                    T_UN_POKE t_un_pokeB = new T_UN_POKE();
                                                    t_un_pokeB.POKEID = pokeId++;
                                                    t_un_pokeB.TROUGHNUM = troughB.ThroughNum;
                                                    t_un_pokeB.POKENUM = troughB.ID;
                                                    t_un_pokeB.STATUS = item.Status;
                                                    t_un_pokeB.TASKNUM = item.TaskNum;
                                                    t_un_pokeB.TASKQTY = item.TaskQty;
                                                    t_un_pokeB.PACKAGEMACHINE = item.PackageMachine;
                                                    t_un_pokeB.MACHINESEQ = troughB.MachineSeq;
                                                    t_un_pokeB.LINENUM = item.LineNum;
                                                    t_un_pokeB.CIGARETTECODE = item.CigCode;
                                                    t_un_pokeB.CUSTOMERCODE = item.CustomerCode;
                                                    t_un_pokeB.SORTNUM = item.SortNum;
                                                    t_un_pokeB.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_pokeB.BILLCODE = item.BillCode;
                                                    t_un_pokeB.CTYPE = troughB.GroupNo;
                                                    t_un_pokeB.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_pokeB.STORENUM = 0;//暂时无用
                                                    t_un_pokeB.GRIDNUM = 0;//暂时无用
                                                    t_un_pokeB.INVFLAG = null;//库存标志
                                                    t_un_pokeB.SENDSEQ = 0; //暂时无用 
                                                    en.T_UN_POKE.AddObject(t_un_pokeB);

                                                    T_UN_POKE t_un_pokeC = new T_UN_POKE();
                                                    t_un_pokeC.POKEID = pokeId++;
                                                    t_un_pokeC.TROUGHNUM = troughC.ThroughNum;
                                                    t_un_pokeC.POKENUM = quantity % 5 - troughB.ID;
                                                    t_un_pokeC.STATUS = item.Status;
                                                    t_un_pokeC.TASKNUM = item.TaskNum;
                                                    t_un_pokeC.TASKQTY = item.TaskQty;
                                                    t_un_pokeC.PACKAGEMACHINE = item.PackageMachine;
                                                    t_un_pokeC.MACHINESEQ = troughC.MachineSeq;
                                                    t_un_pokeC.LINENUM = item.LineNum;
                                                    t_un_pokeC.CIGARETTECODE = item.CigCode;
                                                    t_un_pokeC.CUSTOMERCODE = item.CustomerCode;
                                                    t_un_pokeC.SORTNUM = item.SortNum;
                                                    t_un_pokeC.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_pokeC.BILLCODE = item.BillCode;
                                                    t_un_pokeC.CTYPE = troughC.GroupNo;
                                                    t_un_pokeC.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_pokeC.STORENUM = 0;//暂时无用
                                                    t_un_pokeC.GRIDNUM = 0;//暂时无用
                                                    t_un_pokeC.INVFLAG = null;//库存标志
                                                    t_un_pokeC.SENDSEQ = 0; //暂时无用 
                                                    en.T_UN_POKE.AddObject(t_un_pokeC);
                                                    troughB.ID = 5;
                                                }
                                                else
                                                {
                                                    T_UN_POKE t_un_pokeA = new T_UN_POKE();
                                                    t_un_pokeA.POKEID = pokeId++;
                                                    t_un_pokeA.TROUGHNUM = troughA.ThroughNum;
                                                    t_un_pokeA.POKENUM = quantity - quantity % 5;
                                                    t_un_pokeA.STATUS = item.Status;
                                                    t_un_pokeA.TASKNUM = item.TaskNum;
                                                    t_un_pokeA.TASKQTY = item.TaskQty;
                                                    t_un_pokeA.PACKAGEMACHINE = item.PackageMachine;
                                                    t_un_pokeA.MACHINESEQ = troughA.MachineSeq;
                                                    t_un_pokeA.LINENUM = item.LineNum;
                                                    t_un_pokeA.CIGARETTECODE = item.CigCode;
                                                    t_un_pokeA.CUSTOMERCODE = item.CustomerCode;
                                                    t_un_pokeA.SORTNUM = item.SortNum;
                                                    t_un_pokeA.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_pokeA.BILLCODE = item.BillCode;
                                                    t_un_pokeA.CTYPE = troughA.GroupNo;
                                                    t_un_pokeA.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_pokeA.STORENUM = 0;//暂时无用
                                                    t_un_pokeA.GRIDNUM = 0;//暂时无用
                                                    t_un_pokeA.INVFLAG = null;//库存标志
                                                    t_un_pokeA.SENDSEQ = 0; //暂时无用 
                                                    if (t_un_pokeA.POKENUM > 0)
                                                    {
                                                        en.T_UN_POKE.AddObject(t_un_pokeA);
                                                    }

                                                    T_UN_POKE t_un_pokeB = new T_UN_POKE();
                                                    t_un_pokeB.POKEID = pokeId++;
                                                    t_un_pokeB.TROUGHNUM = troughB.ThroughNum;
                                                    t_un_pokeB.POKENUM = quantity % 5;
                                                    t_un_pokeB.STATUS = item.Status;
                                                    t_un_pokeB.TASKNUM = item.TaskNum;
                                                    t_un_pokeB.TASKQTY = item.TaskQty;
                                                    t_un_pokeB.PACKAGEMACHINE = item.PackageMachine;
                                                    t_un_pokeB.MACHINESEQ = troughB.MachineSeq;
                                                    t_un_pokeB.LINENUM = item.LineNum;
                                                    t_un_pokeB.CIGARETTECODE = item.CigCode;
                                                    t_un_pokeB.CUSTOMERCODE = item.CustomerCode;
                                                    t_un_pokeB.SORTNUM = item.SortNum;
                                                    t_un_pokeB.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_pokeB.BILLCODE = item.BillCode;
                                                    t_un_pokeB.CTYPE = troughB.GroupNo;
                                                    t_un_pokeB.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_pokeB.STORENUM = 0;//暂时无用
                                                    t_un_pokeB.GRIDNUM = 0;//暂时无用
                                                    t_un_pokeB.INVFLAG = null;//库存标志
                                                    t_un_pokeB.SENDSEQ = 0; //暂时无用 
                                                    en.T_UN_POKE.AddObject(t_un_pokeB);
                                                    troughB.ID = (troughB.ID - quantity % 5) > 0 ? (troughB.ID - quantity % 5) : 5;
                                                }
                                            }
                                        }
                                        else if (list.Where(x => x.GroupNo == 2).Count() == 2)
                                        {
                                            if (list2.Count == 3)
                                            {
                                                var troughA = list2.Where(x => x.GroupNo == 3).FirstOrDefault();//通道机通道
                                                ThroughInfo troughB = new ThroughInfo();
                                                ThroughInfo troughC = new ThroughInfo();
                                                if (times % 2 == 0)
                                                {
                                                    troughB = list2.Where(x => x.GroupNo == 2).OrderBy(x => x.MachineSeq).FirstOrDefault();//立式烟仓通道1
                                                    troughC = list2.Where(x => x.GroupNo == 2 && x.MachineSeq != troughB.MachineSeq).FirstOrDefault();//立式烟仓通道2
                                                }
                                                else 
                                                {
                                                    troughB = list2.Where(x => x.GroupNo == 2).OrderByDescending(x => x.MachineSeq).FirstOrDefault();//立式烟仓通道1
                                                    troughC = list2.Where(x => x.GroupNo == 2 && x.MachineSeq != troughB.MachineSeq).FirstOrDefault();//立式烟仓通道2
                                                }
                                                if (quantity > troughA.ID)
                                                {
                                                    if (troughA.ID == 5)
                                                    {
                                                        if (quantity > 5)
                                                        {
                                                            T_UN_POKE t_un_poke = new T_UN_POKE();
                                                            t_un_poke.POKEID = pokeId++;
                                                            t_un_poke.TROUGHNUM = troughA.ThroughNum;
                                                            t_un_poke.POKENUM = quantity - quantity % 5;
                                                            t_un_poke.STATUS = item.Status;
                                                            t_un_poke.TASKNUM = item.TaskNum;
                                                            t_un_poke.TASKQTY = item.TaskQty;
                                                            t_un_poke.PACKAGEMACHINE = item.PackageMachine;
                                                            t_un_poke.MACHINESEQ = troughA.MachineSeq;
                                                            t_un_poke.LINENUM = item.LineNum;
                                                            t_un_poke.CIGARETTECODE = item.CigCode;
                                                            t_un_poke.CUSTOMERCODE = item.CustomerCode;
                                                            t_un_poke.SORTNUM = item.SortNum;
                                                            t_un_poke.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                            t_un_poke.BILLCODE = item.BillCode;
                                                            t_un_poke.CTYPE = troughA.GroupNo;
                                                            t_un_poke.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                            t_un_poke.STORENUM = 0;//暂时无用
                                                            t_un_poke.GRIDNUM = 0;//暂时无用
                                                            t_un_poke.INVFLAG = null;//库存标志
                                                            t_un_poke.SENDSEQ = 0; //暂时无用 
                                                            en.T_UN_POKE.AddObject(t_un_poke);

                                                            T_UN_POKE t_un_pokeB = new T_UN_POKE();
                                                            t_un_pokeB.POKEID = pokeId++;
                                                            t_un_pokeB.TROUGHNUM = troughB.ThroughNum;
                                                            t_un_pokeB.POKENUM = Math.Ceiling((quantity % 5) / 2);
                                                            t_un_pokeB.STATUS = item.Status;
                                                            t_un_pokeB.TASKNUM = item.TaskNum;
                                                            t_un_pokeB.TASKQTY = item.TaskQty;
                                                            t_un_pokeB.PACKAGEMACHINE = item.PackageMachine;
                                                            t_un_pokeB.MACHINESEQ = troughB.MachineSeq;
                                                            t_un_pokeB.LINENUM = item.LineNum;
                                                            t_un_pokeB.CIGARETTECODE = item.CigCode;
                                                            t_un_pokeB.CUSTOMERCODE = item.CustomerCode;
                                                            t_un_pokeB.SORTNUM = item.SortNum;
                                                            t_un_pokeB.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                            t_un_pokeB.BILLCODE = item.BillCode;
                                                            t_un_pokeB.CTYPE = troughB.GroupNo;
                                                            t_un_pokeB.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                            t_un_pokeB.STORENUM = 0;//暂时无用
                                                            t_un_pokeB.GRIDNUM = 0;//暂时无用
                                                            t_un_pokeB.INVFLAG = null;//库存标志
                                                            t_un_pokeB.SENDSEQ = 0; //暂时无用 
                                                            if (Math.Ceiling((quantity % 5) / 2) > 0)
                                                                en.T_UN_POKE.AddObject(t_un_pokeB);


                                                            T_UN_POKE t_un_pokeC = new T_UN_POKE();
                                                            t_un_pokeC.POKEID = pokeId++;
                                                            t_un_pokeC.TROUGHNUM = troughC.ThroughNum;
                                                            t_un_pokeC.POKENUM = Math.Floor((quantity % 5) / 2);
                                                            t_un_pokeC.STATUS = item.Status;
                                                            t_un_pokeC.TASKNUM = item.TaskNum;
                                                            t_un_pokeC.TASKQTY = item.TaskQty;
                                                            t_un_pokeC.PACKAGEMACHINE = item.PackageMachine;
                                                            t_un_pokeC.MACHINESEQ = troughC.MachineSeq;
                                                            t_un_pokeC.LINENUM = item.LineNum;
                                                            t_un_pokeC.CIGARETTECODE = item.CigCode;
                                                            t_un_pokeC.CUSTOMERCODE = item.CustomerCode;
                                                            t_un_pokeC.SORTNUM = item.SortNum;
                                                            t_un_pokeC.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                            t_un_pokeC.BILLCODE = item.BillCode;
                                                            t_un_pokeC.CTYPE = troughC.GroupNo;
                                                            t_un_pokeC.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                            t_un_pokeC.STORENUM = 0;//暂时无用
                                                            t_un_pokeC.GRIDNUM = 0;//暂时无用
                                                            t_un_pokeC.INVFLAG = null;//库存标志
                                                            t_un_pokeC.SENDSEQ = 0; //暂时无用 
                                                            if (Math.Floor((quantity % 5) / 2) > 0)
                                                                en.T_UN_POKE.AddObject(t_un_pokeC);
                                                            troughA.ID = 5;
                                                            times++;
                                                        }
                                                        else
                                                        {
                                                            T_UN_POKE t_un_poke = new T_UN_POKE();
                                                            t_un_poke.POKEID = pokeId++;
                                                            t_un_poke.TROUGHNUM = troughA.ThroughNum;
                                                            t_un_poke.POKENUM = quantity;
                                                            t_un_poke.STATUS = item.Status;
                                                            t_un_poke.TASKNUM = item.TaskNum;
                                                            t_un_poke.TASKQTY = item.TaskQty;
                                                            t_un_poke.PACKAGEMACHINE = item.PackageMachine;
                                                            t_un_poke.MACHINESEQ = troughA.MachineSeq;
                                                            t_un_poke.LINENUM = item.LineNum;
                                                            t_un_poke.CIGARETTECODE = item.CigCode;
                                                            t_un_poke.CUSTOMERCODE = item.CustomerCode;
                                                            t_un_poke.SORTNUM = item.SortNum;
                                                            t_un_poke.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                            t_un_poke.BILLCODE = item.BillCode;
                                                            t_un_poke.CTYPE = troughA.GroupNo;
                                                            t_un_poke.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                            t_un_poke.STORENUM = 0;//暂时无用
                                                            t_un_poke.GRIDNUM = 0;//暂时无用
                                                            t_un_poke.INVFLAG = null;//库存标志
                                                            t_un_poke.SENDSEQ = 0; //暂时无用 
                                                            en.T_UN_POKE.AddObject(t_un_poke);
                                                            troughA.ID = (troughA.ID - quantity) > 0 ? (troughA.ID - quantity) : 5;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        qty = quantity - troughA.ID;
                                                        if (qty % 5 > 0)
                                                        {
                                                            T_UN_POKE t_un_poke = new T_UN_POKE();
                                                            t_un_poke.POKEID = pokeId++;
                                                            t_un_poke.TROUGHNUM = troughB.ThroughNum;
                                                            t_un_poke.POKENUM = Math.Ceiling((qty % 5) / 2);
                                                            t_un_poke.STATUS = item.Status;
                                                            t_un_poke.TASKNUM = item.TaskNum;
                                                            t_un_poke.TASKQTY = item.TaskQty;
                                                            t_un_poke.PACKAGEMACHINE = item.PackageMachine;
                                                            t_un_poke.MACHINESEQ = troughB.MachineSeq;
                                                            t_un_poke.LINENUM = item.LineNum;
                                                            t_un_poke.CIGARETTECODE = item.CigCode;
                                                            t_un_poke.CUSTOMERCODE = item.CustomerCode;
                                                            t_un_poke.SORTNUM = item.SortNum;
                                                            t_un_poke.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                            t_un_poke.BILLCODE = item.BillCode;
                                                            t_un_poke.CTYPE = troughB.GroupNo;
                                                            t_un_poke.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                            t_un_poke.STORENUM = 0;//暂时无用
                                                            t_un_poke.GRIDNUM = 0;//暂时无用
                                                            t_un_poke.INVFLAG = null;//库存标志
                                                            t_un_poke.SENDSEQ = 0; //暂时无用 
                                                            if (Math.Ceiling((qty % 5) / 2) > 0)
                                                                en.T_UN_POKE.AddObject(t_un_poke);

                                                            T_UN_POKE t_un_pokeC = new T_UN_POKE();
                                                            t_un_pokeC.POKEID = pokeId++;
                                                            t_un_pokeC.TROUGHNUM = troughC.ThroughNum;
                                                            t_un_pokeC.POKENUM = Math.Floor((qty % 5) / 2);
                                                            t_un_pokeC.STATUS = item.Status;
                                                            t_un_pokeC.TASKNUM = item.TaskNum;
                                                            t_un_pokeC.TASKQTY = item.TaskQty;
                                                            t_un_pokeC.PACKAGEMACHINE = item.PackageMachine;
                                                            t_un_pokeC.MACHINESEQ = troughC.MachineSeq;
                                                            t_un_pokeC.LINENUM = item.LineNum;
                                                            t_un_pokeC.CIGARETTECODE = item.CigCode;
                                                            t_un_pokeC.CUSTOMERCODE = item.CustomerCode;
                                                            t_un_pokeC.SORTNUM = item.SortNum;
                                                            t_un_pokeC.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                            t_un_pokeC.BILLCODE = item.BillCode;
                                                            t_un_pokeC.CTYPE = troughC.GroupNo;
                                                            t_un_pokeC.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                            t_un_pokeC.STORENUM = 0;//暂时无用
                                                            t_un_pokeC.GRIDNUM = 0;//暂时无用
                                                            t_un_pokeC.INVFLAG = null;//库存标志
                                                            t_un_pokeC.SENDSEQ = 0; //暂时无用 

                                                            if (Math.Floor((qty % 5) / 2) > 0)
                                                                en.T_UN_POKE.AddObject(t_un_pokeC);
                                                            times++;
                                                        }
                                                        qty = quantity - qty % 5;
                                                        if (qty > 0)
                                                        {
                                                            T_UN_POKE t_un_poke = new T_UN_POKE();
                                                            t_un_poke.POKEID = pokeId++;
                                                            t_un_poke.TROUGHNUM = troughA.ThroughNum;
                                                            t_un_poke.POKENUM = qty;
                                                            t_un_poke.STATUS = item.Status;
                                                            t_un_poke.TASKNUM = item.TaskNum;
                                                            t_un_poke.TASKQTY = item.TaskQty;
                                                            t_un_poke.PACKAGEMACHINE = item.PackageMachine;
                                                            t_un_poke.MACHINESEQ = troughA.MachineSeq;
                                                            t_un_poke.LINENUM = item.LineNum;
                                                            t_un_poke.CIGARETTECODE = item.CigCode;
                                                            t_un_poke.CUSTOMERCODE = item.CustomerCode;
                                                            t_un_poke.SORTNUM = item.SortNum;
                                                            t_un_poke.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                            t_un_poke.BILLCODE = item.BillCode;
                                                            t_un_poke.CTYPE = troughA.GroupNo;
                                                            t_un_poke.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                            t_un_poke.STORENUM = 0;//暂时无用
                                                            t_un_poke.GRIDNUM = 0;//暂时无用
                                                            t_un_poke.INVFLAG = null;//库存标志
                                                            t_un_poke.SENDSEQ = 0; //暂时无用 
                                                            en.T_UN_POKE.AddObject(t_un_poke);
                                                        }
                                                        troughA.ID = 5;
                                                    }
                                                }
                                                else
                                                {
                                                    T_UN_POKE t_un_poke = new T_UN_POKE();
                                                    t_un_poke.POKEID = pokeId++;
                                                    t_un_poke.TROUGHNUM = troughA.ThroughNum;
                                                    t_un_poke.POKENUM = quantity;
                                                    t_un_poke.STATUS = item.Status;
                                                    t_un_poke.TASKNUM = item.TaskNum;
                                                    t_un_poke.TASKQTY = item.TaskQty;
                                                    t_un_poke.PACKAGEMACHINE = item.PackageMachine;
                                                    t_un_poke.MACHINESEQ = troughA.MachineSeq;
                                                    t_un_poke.LINENUM = item.LineNum;
                                                    t_un_poke.CIGARETTECODE = item.CigCode;
                                                    t_un_poke.CUSTOMERCODE = item.CustomerCode;
                                                    t_un_poke.SORTNUM = item.SortNum;
                                                    t_un_poke.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_poke.BILLCODE = item.BillCode;
                                                    t_un_poke.CTYPE = troughA.GroupNo;
                                                    t_un_poke.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_poke.STORENUM = 0;//暂时无用
                                                    t_un_poke.GRIDNUM = 0;//暂时无用
                                                    t_un_poke.INVFLAG = null;//库存标志
                                                    t_un_poke.SENDSEQ = 0; //暂时无用 
                                                    en.T_UN_POKE.AddObject(t_un_poke);
                                                    troughA.ID = (troughA.ID - quantity) > 0 ? (troughA.ID - quantity) : 5;
                                                }
                                            }
                                            else
                                            {
                                                var troughA = list2.Where(x => x.GroupNo == 3).OrderBy(x => x.MachineSeq).FirstOrDefault();//通道机通道，只拨5的倍数
                                                var troughB = list2.Where(x => x.GroupNo == 3 && x.MachineSeq != troughA.MachineSeq).FirstOrDefault();//通道机通道拨余数
                                                ThroughInfo troughC = new ThroughInfo();
                                                ThroughInfo troughD = new ThroughInfo();
                                                if (times % 2 == 0)
                                                {
                                                    troughC = list2.Where(x => x.GroupNo == 2).OrderBy(x => x.MachineSeq).FirstOrDefault();//立式烟仓通道1
                                                    troughD = list2.Where(x => x.GroupNo == 2 && x.MachineSeq != troughC.MachineSeq).FirstOrDefault();
                                                }
                                                else 
                                                {
                                                    troughC = list2.Where(x => x.GroupNo == 2).OrderByDescending(x => x.MachineSeq).FirstOrDefault();//立式烟仓通道1
                                                    troughD = list2.Where(x => x.GroupNo == 2 && x.MachineSeq != troughC.MachineSeq).FirstOrDefault();
                                                }
                                                
                                                if (quantity % 5 > troughB.ID)
                                                {
                                                    T_UN_POKE t_un_pokeA = new T_UN_POKE();
                                                    t_un_pokeA.POKEID = pokeId++;
                                                    t_un_pokeA.TROUGHNUM = troughA.ThroughNum;
                                                    t_un_pokeA.POKENUM = quantity - quantity % 5;
                                                    t_un_pokeA.STATUS = item.Status;
                                                    t_un_pokeA.TASKNUM = item.TaskNum;
                                                    t_un_pokeA.TASKQTY = item.TaskQty;
                                                    t_un_pokeA.PACKAGEMACHINE = item.PackageMachine;
                                                    t_un_pokeA.MACHINESEQ = troughA.MachineSeq;
                                                    t_un_pokeA.LINENUM = item.LineNum;
                                                    t_un_pokeA.CIGARETTECODE = item.CigCode;
                                                    t_un_pokeA.CUSTOMERCODE = item.CustomerCode;
                                                    t_un_pokeA.SORTNUM = item.SortNum;
                                                    t_un_pokeA.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_pokeA.BILLCODE = item.BillCode;
                                                    t_un_pokeA.CTYPE = troughA.GroupNo;
                                                    t_un_pokeA.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_pokeA.STORENUM = 0;//暂时无用
                                                    t_un_pokeA.GRIDNUM = 0;//暂时无用
                                                    t_un_pokeA.INVFLAG = null;//库存标志
                                                    t_un_pokeA.SENDSEQ = 0; //暂时无用 
                                                    if (t_un_pokeA.POKENUM > 0)
                                                    {
                                                        en.T_UN_POKE.AddObject(t_un_pokeA);
                                                    }

                                                    T_UN_POKE t_un_pokeB = new T_UN_POKE();
                                                    t_un_pokeB.POKEID = pokeId++;
                                                    t_un_pokeB.TROUGHNUM = troughB.ThroughNum;
                                                    t_un_pokeB.POKENUM = troughB.ID;
                                                    t_un_pokeB.STATUS = item.Status;
                                                    t_un_pokeB.TASKNUM = item.TaskNum;
                                                    t_un_pokeB.TASKQTY = item.TaskQty;
                                                    t_un_pokeB.PACKAGEMACHINE = item.PackageMachine;
                                                    t_un_pokeB.MACHINESEQ = troughB.MachineSeq;
                                                    t_un_pokeB.LINENUM = item.LineNum;
                                                    t_un_pokeB.CIGARETTECODE = item.CigCode;
                                                    t_un_pokeB.CUSTOMERCODE = item.CustomerCode;
                                                    t_un_pokeB.SORTNUM = item.SortNum;
                                                    t_un_pokeB.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_pokeB.BILLCODE = item.BillCode;
                                                    t_un_pokeB.CTYPE = troughB.GroupNo;
                                                    t_un_pokeB.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_pokeB.STORENUM = 0;//暂时无用
                                                    t_un_pokeB.GRIDNUM = 0;//暂时无用
                                                    t_un_pokeB.INVFLAG = null;//库存标志
                                                    t_un_pokeB.SENDSEQ = 0; //暂时无用 
                                                    en.T_UN_POKE.AddObject(t_un_pokeB);

                                                    T_UN_POKE t_un_pokeC = new T_UN_POKE();
                                                    t_un_pokeC.POKEID = pokeId++;
                                                    t_un_pokeC.TROUGHNUM = troughC.ThroughNum;
                                                    t_un_pokeC.POKENUM = Math.Ceiling((quantity % 5 - troughB.ID) / 2);
                                                    t_un_pokeC.STATUS = item.Status;
                                                    t_un_pokeC.TASKNUM = item.TaskNum;
                                                    t_un_pokeC.TASKQTY = item.TaskQty;
                                                    t_un_pokeC.PACKAGEMACHINE = item.PackageMachine;
                                                    t_un_pokeC.MACHINESEQ = troughC.MachineSeq;
                                                    t_un_pokeC.LINENUM = item.LineNum;
                                                    t_un_pokeC.CIGARETTECODE = item.CigCode;
                                                    t_un_pokeC.CUSTOMERCODE = item.CustomerCode;
                                                    t_un_pokeC.SORTNUM = item.SortNum;
                                                    t_un_pokeC.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_pokeC.BILLCODE = item.BillCode;
                                                    t_un_pokeC.CTYPE = troughC.GroupNo;
                                                    t_un_pokeC.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_pokeC.STORENUM = 0;//暂时无用
                                                    t_un_pokeC.GRIDNUM = 0;//暂时无用
                                                    t_un_pokeC.INVFLAG = null;//库存标志
                                                    t_un_pokeC.SENDSEQ = 0; //暂时无用 
                                                    if (Math.Ceiling((quantity % 5 - troughB.ID) / 2) > 0)
                                                        en.T_UN_POKE.AddObject(t_un_pokeC);

                                                    T_UN_POKE t_un_pokeD = new T_UN_POKE();
                                                    t_un_pokeD.POKEID = pokeId++;
                                                    t_un_pokeD.TROUGHNUM = troughD.ThroughNum;
                                                    t_un_pokeD.POKENUM = Math.Floor((quantity % 5 - troughB.ID) / 2);
                                                    t_un_pokeD.STATUS = item.Status;
                                                    t_un_pokeD.TASKNUM = item.TaskNum;
                                                    t_un_pokeD.TASKQTY = item.TaskQty;
                                                    t_un_pokeD.PACKAGEMACHINE = item.PackageMachine;
                                                    t_un_pokeD.MACHINESEQ = troughD.MachineSeq;
                                                    t_un_pokeD.LINENUM = item.LineNum;
                                                    t_un_pokeD.CIGARETTECODE = item.CigCode;
                                                    t_un_pokeD.CUSTOMERCODE = item.CustomerCode;
                                                    t_un_pokeD.SORTNUM = item.SortNum;
                                                    t_un_pokeD.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_pokeD.BILLCODE = item.BillCode;
                                                    t_un_pokeD.CTYPE = troughD.GroupNo;
                                                    t_un_pokeD.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_pokeD.STORENUM = 0;//暂时无用
                                                    t_un_pokeD.GRIDNUM = 0;//暂时无用
                                                    t_un_pokeD.INVFLAG = null;//库存标志
                                                    t_un_pokeD.SENDSEQ = 0; //暂时无用 
                                                    if (Math.Floor((quantity % 5 - troughB.ID) / 2) > 0)
                                                        en.T_UN_POKE.AddObject(t_un_pokeD);
                                                    troughB.ID = 5;
                                                    times++;
                                                }
                                                else
                                                {
                                                    T_UN_POKE t_un_pokeA = new T_UN_POKE();
                                                    t_un_pokeA.POKEID = pokeId++;
                                                    t_un_pokeA.TROUGHNUM = troughA.ThroughNum;
                                                    t_un_pokeA.POKENUM = quantity - quantity % 5;
                                                    t_un_pokeA.STATUS = item.Status;
                                                    t_un_pokeA.TASKNUM = item.TaskNum;
                                                    t_un_pokeA.TASKQTY = item.TaskQty;
                                                    t_un_pokeA.PACKAGEMACHINE = item.PackageMachine;
                                                    t_un_pokeA.MACHINESEQ = troughA.MachineSeq;
                                                    t_un_pokeA.LINENUM = item.LineNum;
                                                    t_un_pokeA.CIGARETTECODE = item.CigCode;
                                                    t_un_pokeA.CUSTOMERCODE = item.CustomerCode;
                                                    t_un_pokeA.SORTNUM = item.SortNum;
                                                    t_un_pokeA.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_pokeA.BILLCODE = item.BillCode;
                                                    t_un_pokeA.CTYPE = troughA.GroupNo;
                                                    t_un_pokeA.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_pokeA.STORENUM = 0;//暂时无用
                                                    t_un_pokeA.GRIDNUM = 0;//暂时无用
                                                    t_un_pokeA.INVFLAG = null;//库存标志
                                                    t_un_pokeA.SENDSEQ = 0; //暂时无用 
                                                    if (t_un_pokeA.POKENUM > 0)
                                                    {
                                                        en.T_UN_POKE.AddObject(t_un_pokeA);
                                                    }

                                                    T_UN_POKE t_un_pokeB = new T_UN_POKE();
                                                    t_un_pokeB.POKEID = pokeId++;
                                                    t_un_pokeB.TROUGHNUM = troughB.ThroughNum;
                                                    t_un_pokeB.POKENUM = quantity % 5;
                                                    t_un_pokeB.STATUS = item.Status;
                                                    t_un_pokeB.TASKNUM = item.TaskNum;
                                                    t_un_pokeB.TASKQTY = item.TaskQty;
                                                    t_un_pokeB.PACKAGEMACHINE = item.PackageMachine;
                                                    t_un_pokeB.MACHINESEQ = troughB.MachineSeq;
                                                    t_un_pokeB.LINENUM = item.LineNum;
                                                    t_un_pokeB.CIGARETTECODE = item.CigCode;
                                                    t_un_pokeB.CUSTOMERCODE = item.CustomerCode;
                                                    t_un_pokeB.SORTNUM = item.SortNum;
                                                    t_un_pokeB.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_pokeB.BILLCODE = item.BillCode;
                                                    t_un_pokeB.CTYPE = troughB.GroupNo;
                                                    t_un_pokeB.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                                    t_un_pokeB.STORENUM = 0;//暂时无用
                                                    t_un_pokeB.GRIDNUM = 0;//暂时无用
                                                    t_un_pokeB.INVFLAG = null;//库存标志
                                                    t_un_pokeB.SENDSEQ = 0; //暂时无用 
                                                    en.T_UN_POKE.AddObject(t_un_pokeB);
                                                    troughB.ID = (troughB.ID - quantity % 5) > 0 ? (troughB.ID - quantity % 5) : 5;
                                                }
                                            }
                                        }
                                    }
                                    var reUp = UpdateTaskState(en, item.TaskNum, 100);
                                    if (!reUp.IsSuccess)
                                    {
                                        return reUp;
                                    }
                                }
                            }
                            else
                            {
                                if (qty > 0)
                                {
                                    T_UN_POKE t_un_poke = new T_UN_POKE();
                                    t_un_poke.POKEID = pokeId++;
                                    t_un_poke.TROUGHNUM = list[0].ThroughNum;
                                    t_un_poke.POKENUM = qty;
                                    t_un_poke.STATUS = item.Status;
                                    t_un_poke.TASKNUM = item.TaskNum;
                                    t_un_poke.TASKQTY = item.TaskQty;
                                    t_un_poke.PACKAGEMACHINE = item.PackageMachine;
                                    t_un_poke.MACHINESEQ = list[0].MachineSeq;
                                    t_un_poke.LINENUM = item.LineNum;
                                    t_un_poke.CIGARETTECODE = item.CigCode;
                                    t_un_poke.CUSTOMERCODE = item.CustomerCode;
                                    t_un_poke.SORTNUM = item.SortNum;
                                    t_un_poke.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                                    t_un_poke.BILLCODE = item.BillCode;
                                    t_un_poke.CTYPE = list[0].GroupNo;
                                    t_un_poke.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                                    t_un_poke.STORENUM = 0;//暂时无用
                                    t_un_poke.GRIDNUM = 0;//暂时无用
                                    t_un_poke.INVFLAG = null;//库存标志
                                    t_un_poke.SENDSEQ = 0; //暂时无用 
                                    en.T_UN_POKE.AddObject(t_un_poke);
                                }
                                var reUp = UpdateTaskState(en, item.TaskNum, 100);
                                if (!reUp.IsSuccess)
                                {
                                    return reUp;
                                }
                            }
                        }
                        re.IsSuccess = true;
                        re.MessageText = "分拣任务数据生成成功！";
                        //tran.Complete();
                        return re;
                    }
                    else
                    {
                        re.IsSuccess = false;
                        re.MessageText = "暂无可排程的任务信息！";
                        return re;
                    }

                }
                catch
                {
                    re.IsSuccess = false;
                    re.MessageText = "错误！";
                    return re;
                }
                //}
            }
        }


        /// <summary>
        /// 获取POke表最大的POKEID
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public Response<decimal> GetMaxPokeId(DZEntities en)
        {
            Response<decimal> red = new Response<decimal>();
            var maxPokeID = (from item in en.T_UN_POKE select item).ToList();
            if (maxPokeID.Any())
            {
                red.IsSuccess = true;
                red.Content = maxPokeID.Max(a => a.POKEID) + 1;
                return red;
            }
            else//如果不包含任何数据 初始值为0
            {
                red.IsSuccess = true;
                red.Content = 1;
                return red;
            }
        }

        public Response UpdateTaskState(DZEntities en, decimal tasknum, short labelBatch)
        {
            Response re = new Response();
            var query = (from item in en.T_UN_TASK where item.TASKNUM == tasknum select item).ToList();

            if (query.Any())
            {
                query.FirstOrDefault().STATE = "15";
                en.SaveChanges();
                re.IsSuccess = true;
                re.MessageText = tasknum + "任务号，更新完成";
                return re;
            }
            else
            {
                re.IsSuccess = false;
                re.MessageText = tasknum + "任务号，未找到数据";
                return re;

            }
        }

        #endregion


        public static List<PokeInfo> GetAllSchdule()
        {
            using (DZEntities en = new DZEntities())
            {
                List<PokeInfo> list = new List<PokeInfo>();
                var query = en.T_PRODUCE_ORDER.Join(en.T_PRODUCE_ORDERLINE, order => order.BILLCODE, orderline => orderline.BILLCODE, (order, orderline) => new { order, orderline }).
                    GroupBy(item => new { item.order.REGIONCODE, item.orderline.CIGARETTECODE, item.orderline.CIGARETTENAME }).Select(item => new
                    {
                        RegionCode = item.Key.REGIONCODE,
                        CigaretteCode = item.Key.CIGARETTECODE,
                        CigaretteName = item.Key.CIGARETTENAME,
                        QTY = item.Sum(x => x.orderline.QUANTITY)
                    });
                var query2 = en.T_UN_POKE.Join(en.T_UN_TASK, poke => poke.TASKNUM, task => task.TASKNUM, (poke, task) => new { poke, task }).GroupBy(item => new { item.poke.CIGARETTECODE, item.task.REGIONCODE }).
                    Select(item => new { CigaretteCode = item.Key.CIGARETTECODE, PokeNum = item.Sum(x => x.poke.POKENUM), RegionCode = item.Key.REGIONCODE });
                list = (from a in query
                        join b in query2 on new { RegionCode = a.RegionCode, Code = a.CigaretteCode } equals new { RegionCode = b.RegionCode, Code = b.CigaretteCode } into que
                        from c in que.DefaultIfEmpty()
                        select new PokeInfo { RegionCode = a.RegionCode, CigaretteCode = a.CigaretteCode, CigaretteName = a.CigaretteName, QTY = a.QTY ?? 0, PokeNum = c.PokeNum ?? 0 }).ToList();
                return list;
            }
        }

        public Response<decimal> GetSyncseqFromOrderTable()
        {
            using (DZEntities dzEntities = new DZEntities())
            {
                Response<decimal> response = new Response<decimal>();

                response.IsSuccess = true;
                response.Content = (dzEntities.T_PRODUCE_ORDER.Max(a => a.SYNSEQ) ?? 0) + 1;
                List<T_PRODUCE_ORDER> DZList = dzEntities.T_PRODUCE_ORDER.ToList();
                return response;
            }

        }

        #region 导出数据发送到一号工程

        /// <summary>
        /// 获取批次数据
        /// </summary>
        /// <returns></returns>
        public Response<List<TaskInfo>> GetTaskInfoByBatchcode()
        {
            Response<List<TaskInfo>> rm = new Response<List<TaskInfo>>();
            using (DZEntities en = new DZEntities())
            {
                List<TaskInfo> mainOrder = new List<TaskInfo>();//订单主表
                //var query = (from item in en.T_UN_TASK
                //             //where item.STATE == "15"
                //             where item.STATE == "20"
                //             group item by new { item.BATCHCODE, item.SYNSEQ ,item.LINENUM} into g
                //             select new { SYNSEQ = g.Key.SYNSEQ, BATCHCODE = g.Key.BATCHCODE,LINENUM=g.Key.LINENUM, qty = g.Sum(x => x.TASKQUANTITY), count = g.Count() }).ToList();

                var query = (from task in en.T_UN_TASK
                             join poke in en.T_UN_POKE on task.TASKNUM equals poke.TASKNUM
                             join trough in en.T_PRODUCE_SORTTROUGH on poke.TROUGHNUM equals trough.TROUGHNUM
                             where trough.TROUGHTYPE == 10 && (trough.CIGARETTETYPE == 30 || trough.CIGARETTETYPE == 40)
                             && trough.STATE == "10"
                             select new
                             {
                                 x = task,
                                 y = trough,
                                 z = poke
                             }).ToList();
                var query1 = (from item in query
                              group item by new { item.x.SYNSEQ, item.x.BATCHCODE, item.y.LINENUM }
                                  into g
                                  orderby g.Key.SYNSEQ, g.Key.LINENUM
                                  select new
                                  {
                                      g.Key.SYNSEQ,
                                      g.Key.BATCHCODE,
                                      g.Key.LINENUM,
                                      qty = g.Sum(x => x.z.POKENUM),
                                      count = (from ct in g select ct.x.TASKNUM).Distinct().Count()
                                  }).ToList();//count有问题
                int index = 0;
                foreach (var item in query1)
                {
                    TaskInfo mo = new TaskInfo();
                    index++;
                    mo.SYNSEQ = item.SYNSEQ ?? 0;
                    mo.BATCHODE = item.BATCHCODE;
                    mo.QTY = item.qty ?? 0;
                    mo.Count = item.count;//订单户数
                    mo.LINENUM = item.LINENUM;
                    mainOrder.Add(mo);
                }
                if (mainOrder.Any())
                {
                    rm.IsSuccess = true;
                    rm.MessageText = "数据查询成功";
                    rm.Content = mainOrder;
                    return rm;

                }
                else
                {
                    rm.IsSuccess = false;
                    rm.MessageText = "暂未查询到相关的订单数据！";
                    return rm;
                }


            }
        }

        public Response<List<_1stPrjInfo>> Get1stPrjInfo(decimal synSeq, string linenum)
        {
            Response<List<_1stPrjInfo>> infoList = new Response<List<_1stPrjInfo>>();

            using (DZEntities dzEntities = new DZEntities())
            {
                List<_1stPrjInfo> mainList = new List<_1stPrjInfo>();//订单主表
                var query = (from task in dzEntities.T_UN_TASK
                             join poke in dzEntities.T_UN_POKE on task.TASKNUM equals poke.TASKNUM
                             join trough in dzEntities.T_PRODUCE_SORTTROUGH on poke.TROUGHNUM equals trough.TROUGHNUM
                             where trough.TROUGHTYPE == 10 && (trough.CIGARETTETYPE == 30 || trough.CIGARETTETYPE == 40)
                             && trough.STATE == "10" && task.SYNSEQ == synSeq && trough.LINENUM == linenum
                             orderby task.SORTNUM, trough.MACHINESEQ
                             select new
                             {
                                 //custCode=task.CUSTOMERCODE,
                                 //custName=task.CUSTOMERNAME,
                                 //cigCode=trough.CIGARETTECODE,
                                 //cigName=trough.CIGARETTENAME,
                                 //sortNum=task.SORTNUM,
                                 //machineSeq=poke.MACHINESEQ,
                                 //quantity=poke.POKENUM,
                                 //orderDate=String.Format("yyyy-mm-dd",task.ORDERDATE),
                                 //pokeNum=poke.POKENUM,
                                 //regioncode=task.REGIONCODE,
                                 x = task,
                                 y = trough,
                                 z = poke
                             }).ToList();
                foreach (var item in query)
                {
                    _1stPrjInfo info = new _1stPrjInfo();
                    info.machineSeq = item.z.MACHINESEQ ?? 0;
                    info.custCode = item.x.CUSTOMERCODE;
                    info.custName = item.x.CUSTOMERNAME;
                    info.cigCode = item.y.CIGARETTECODE;
                    info.cigName = item.y.CIGARETTENAME;
                    info.sortNum = item.x.SORTNUM ?? 0;
                    info.machineSeq = item.z.MACHINESEQ ?? 0;
                    info.quantity = item.z.POKENUM ?? 0;
                    DateTime orderdate = item.x.ORDERDATE ?? new DateTime();
                    info.orderDate = orderdate.ToShortDateString();
                    info.pokeNum = item.z.POKENUM ?? 0;
                    info.regionCode = item.x.REGIONCODE;
                    info.regionName = item.x.REGIONDESC;

                    mainList.Add(info);
                }
                if (query.Any())
                {
                    infoList.IsSuccess = true;
                    infoList.Content = mainList;
                    infoList.MessageText = "一号工程数据查询成功！";
                }
                else
                {
                    infoList.IsSuccess = false;
                    infoList.MessageText = "暂无未发送的一号工程数据！";
                }
            }

            return infoList;
        }

        #endregion

        #region 分拣进度取数
        public Response<List<TaskInfo>> GetSortingProcess()
        {

            Response<List<TaskInfo>> response = new Response<List<TaskInfo>>();
            using (DZEntities dzEntities = new DZEntities())
            {
                var allList = (from all in dzEntities.T_UN_TASK
                               group all by new { all.REGIONCODE } into x
                               select new { x.Key.REGIONCODE, count = x.Count(), qty = x.Sum(g => g.TASKQUANTITY) }).ToList();
                var finishList = (from finish in dzEntities.T_UN_TASK
                                  where finish.STATE == "30"
                                  group finish by new { finish.REGIONCODE } into x
                                  select new { x.Key.REGIONCODE, finishcount = x.Count(), finishqty = x.Sum(g => g.TASKQUANTITY) }).ToList();
                var resultList = (from all in allList
                                  join finish in finishList on all.REGIONCODE equals finish.REGIONCODE
                                  into tmp
                                  from last in tmp.DefaultIfEmpty()
                                  orderby all.REGIONCODE
                                  select new { x = all, y = last }).ToList();
                List<TaskInfo> taskList = new List<TaskInfo>();
                if (resultList.Any())
                {
                    decimal index = 0;
                    foreach (var item in resultList)
                    {
                        index++;
                        TaskInfo task = new TaskInfo();
                        task.SYNSEQ = index;
                        task.REGIONCODE = item.x.REGIONCODE;
                        task.Count = item.x.count;
                        task.QTY = item.x.qty ?? 0;
                        var obj = item.y;
                        if (obj != null)
                        {
                            task.FinishCount = item.y.finishcount;
                            task.FinishQTY = item.y.finishqty ?? 0;
                        }
                        else
                        {
                            task.FinishCount = 0;
                            task.FinishQTY = 0;
                        }

                        task.FinishCountStr = task.FinishCount + " / " + task.Count;
                        task.FinishQtyStr = task.FinishQTY + " / " + task.QTY;
                        task.Rate = Math.Round((task.FinishQTY / task.QTY * 100), 2) + "%";
                        taskList.Add(task);
                    }
                    if (taskList.Any())
                    {
                        response.IsSuccess = true;
                        response.Content = taskList;
                        response.MessageText = "分拣数据查询成功！";
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.MessageText = "暂无分拣进度数据！";
                    }
                }
            }
            return response;
        }
        #endregion

        public Response<decimal> GetMaxTaskNumByRegioncode(String regioncode = "")
        {
            using (DZEntities dzEntities = new DZEntities())
            {
                Func<T_UN_TASK, bool> code;
                if (regioncode != "")
                {
                    code = x => x.REGIONCODE == regioncode;
                }
                else
                {
                    code = x => true;
                }
                Response<decimal> response = new Response<decimal>();
                response.IsSuccess = true;
                decimal tasknum = 0;
                if (dzEntities.T_UN_TASK.Where(code).Count() > 0)
                {
                    tasknum = dzEntities.T_UN_TASK.Where(code).Max(x => x.TASKNUM);
                }
                response.Content = tasknum;
                List<T_UN_TASK> DZList = dzEntities.T_UN_TASK.ToList();
                return response;
            }

        }

        public Response RemoveHistoryData()
        {
            using (DZEntities dzEntities = new DZEntities())
            {
                Response response = new Response();
                response.IsSuccess = true;

                System.Data.EntityClient.EntityConnection entityConnection = (System.Data.EntityClient.EntityConnection)dzEntities.Connection;
                entityConnection.Open();
                System.Data.Common.DbConnection storeConnection = entityConnection.StoreConnection;
                System.Data.Common.DbCommand cmd = storeConnection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "P_UN_REMOVE";

                OracleParameter[] sqlpara = new OracleParameter[3];
                sqlpara[0] = new OracleParameter("bz", "0");
                sqlpara[1] = new OracleParameter("p_ErrCode", OracleDbType.Varchar2, 30);
                sqlpara[2] = new OracleParameter("p_ErrMsg", OracleDbType.Varchar2, 1000);

                sqlpara[0].Direction = ParameterDirection.Input;
                sqlpara[1].Direction = ParameterDirection.Output;
                sqlpara[2].Direction = ParameterDirection.Output;

                cmd.Parameters.Add(sqlpara[0]);
                cmd.Parameters.Add(sqlpara[1]);
                cmd.Parameters.Add(sqlpara[2]);

                cmd.ExecuteNonQuery();


                if (cmd.Parameters[1].Value.ToString() == "1")
                {
                    response.IsSuccess = true;
                    response.MessageText = cmd.Parameters[2].Value.ToString();
                }
                else
                {
                    response.IsSuccess = false;
                    response.MessageText = cmd.Parameters[2].Value.ToString();
                }
                cmd.Dispose();
                return response;
            }
        }

        public Response SyncOrderDataFromInspur(string orderDateStr)
        {
            using (DZEntities dzEntities = new DZEntities())
            {
                Response response = new Response();
                response.IsSuccess = true;

                System.Data.EntityClient.EntityConnection entityConnection = (System.Data.EntityClient.EntityConnection)dzEntities.Connection;
                entityConnection.Open();
                System.Data.Common.DbConnection storeConnection = entityConnection.StoreConnection;
                System.Data.Common.DbCommand cmd = storeConnection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PSALE_WMS_RECEIVE";

                OracleParameter[] sqlpara = new OracleParameter[3];
                sqlpara[0] = new OracleParameter("p_time", orderDateStr);
                sqlpara[1] = new OracleParameter("p_ErrCode", OracleDbType.Varchar2, 30);
                sqlpara[2] = new OracleParameter("p_ErrMsg", OracleDbType.Varchar2, 1000);

                sqlpara[0].Direction = ParameterDirection.Input;
                sqlpara[1].Direction = ParameterDirection.Output;
                sqlpara[2].Direction = ParameterDirection.Output;

                cmd.Parameters.Add(sqlpara[0]);
                cmd.Parameters.Add(sqlpara[1]);
                cmd.Parameters.Add(sqlpara[2]);

                cmd.ExecuteNonQuery();


                if (cmd.Parameters[1].Value.ToString() == "1")
                {
                    response.IsSuccess = true;
                    response.MessageText = cmd.Parameters[2].Value.ToString();
                }
                else
                {
                    response.IsSuccess = false;
                    response.MessageText = cmd.Parameters[2].Value.ToString();
                }
                cmd.Dispose();
                return response;
            }
        }
    }
}
