using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Modle;
using System.Data.SqlClient;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Data.Common;

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
                    rm.MessageText = "未找到数据";
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

                    var V_SALE_ORDER_HEAD = (from item in en.T_SALE_ORDER_HEAD where item.ROUTECODE == regioncode select item).ToList();
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
        public Response<List<TaskInfo>> GetRouteInFO()
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

                decimal index = 0;
                foreach (var item in list3)
                {
                    TaskInfo taskInfo = new TaskInfo();
                    index++;
                    taskInfo.SYNSEQ = index;
                    taskInfo.REGIONCODE = item.regioncode;
                    taskInfo.QTY = item.qty ?? 0;
                    taskInfo.Count = item.ct;
                    taskList.Add(taskInfo);
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
                                       where order.STATE == "新增" && item.SHIPTYPE == "1" && order.REGIONCODE == regioncode
                                       orderby order.DEVSEQ
                                       select order).Distinct().ToList();
                //var query=(from task in en.T_UN_TASK select task.TASKNUM).Max();

                //取目前车组最大的Tasknum,如果没有,则给默认任务号
                decimal maxTaskNum = GetMaxTaskNumByRegioncode(regioncode).Content;
                if (maxTaskNum == 0)
                {
                    String max = DateTime.Now.ToString("yyyyMMdd") + regioncode + "000";
                    if (regioncode.Contains("@")) max = DateTime.Now.ToString("yyyyMMdd") + regioncode.Split('@')[0] + "000";
                    //String max = DateTime.Now.ToString("yyyyMMdd") + regioncode + "000";
                    maxTaskNum = Convert.ToDecimal(max);
                }

                //String query = maxTaskNum+regioncode+""
                //if (query != null&&!"".Equals(query)) maxTaskNum = query.ToString();
                //var maxtasknum = (en.T_UN_TASK.Max(a => a.TASKNUM) ?? 0) + 1;
                //(dzEntities.T_PRODUCE_ORDER.Max(a => a.SYNSEQ) ?? 0) + 1;
                if (t_produce_Order.Any())
                {
                    int index = 0;
                    foreach (var item in t_produce_Order)
                    {
                        T_UN_TASK t_un_task = new T_UN_TASK();
                        //字段赋值
                        index++;
                        t_un_task.TASKNUM = maxTaskNum + index;
                        t_un_task.LINENUM = "1";
                        t_un_task.EXPORTNUM = "1";
                        if (item.REGIONCODE.Contains("@"))
                        {
                            string str = item.REGIONCODE;
                            t_un_task.REGIONCODE = str.Split('@')[0];
                            t_un_task.REGIONDESC = str.Split('@')[1];
                        }
                        else {
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
                        t_un_task.PRIORITY = Convert.ToInt32(item.PRIORITY);//送货顺序
                        t_un_task.TASKBOX = "F";
                        t_un_task.SORTSEQ = index;//户序
                        t_un_task.LABLENUM = "F";
                        t_un_task.PLANTIME = CreateTime;
                        t_un_task.SORTTIME = CreateTime;
                        t_un_task.FINISHTIME = null;
                        t_un_task.STATE = "10";
                        t_un_task.LABELBATCH = 1;
                        t_un_task.PALLETNUM = 1;
                        t_un_task.EXISTRCD = 1;
                        t_un_task.ORDERDATE = item.ORDERDATE;
                        t_un_task.MAINBELT = 1;
                        t_un_task.PACKAGEMACHINE = 1;
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
                    return re;
                }
                else
                {
                    return re.DefaultResponse;
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


        /// <summary>
        /// 任务数据排程 直接一次性排程Task表中的所有数据
        /// </summary>
        /// <returns></returns>
        public Response SchedulePoke()
        {
            Response re = new Response("数据排程：未找对应的数据！");
            using (DZEntities en = new DZEntities())
            {
                //普通双通
                //var normal_two = (from trough in en.T_PRODUCE_SORTTROUGH where  select trough).ToList();
                //六通道双通
                //var trough1 = (from trough in en.T_PRODUCE_SORTTROUGH
                //               where trough.STATE == "10" && trough.GROUPNO == 3 
                //               select trough).ToList();
                //var trough2 = (from trough in en.T_PRODUCE_SORTTROUGH
                //               where trough.STATE == "10" && trough.GROUPNO == 2
                //               select trough).ToList();
                //var special_two = (from special in trough1
                //                   join normal in trough2 on special.CIGARETTECODE equals normal.CIGARETTECODE
                //                       into tmp
                //                   from last in tmp.DefaultIfEmpty()
                //                   select new { x = special, y = last });
                var special_two = (from trough in en.T_PRODUCE_SORTTROUGH
                                   where trough.STATE == "10" && trough.GROUPNO == 3 && trough.ACTCOUNT == 2
                                   orderby trough.CIGARETTECODE select trough).ToList();
                Dictionary<string, ThroughInfo> special_dic = new Dictionary<string, ThroughInfo>();
                if (special_two.Any())
                {
                    foreach (var item in special_two)
                    {
                        //两个卧式
                        string cigcode = item.CIGARETTECODE;
                        ThroughInfo through = new ThroughInfo();
                        if (special_dic.ContainsKey(cigcode))
                        {
                            through = special_dic[cigcode];
                            through.SecThroughnum = item.TROUGHNUM;
                        }
                        else
                        {
                            through.CigaretteCode = item.CIGARETTECODE;
                            through.ActCount = item.ACTCOUNT ?? 0;
                            through.ThroughNum = item.TROUGHNUM;
                            special_dic.Add(through.CigaretteCode, through);
                        }
                        
                        //卧式带立式 (5+1)
                        //ThroughInfo through = new ThroughInfo();
                        //through.CigaretteCode = item.x.CIGARETTECODE;
                        //through.ActCount = item.x.ACTCOUNT ?? 0;
                        //through.ThroughNum = item.x.TROUGHNUM;
                        //var obj = item.y;
                        //if (through.ActCount == 2 && obj != null)
                        //{
                        //    through.SecThroughnum = item.y.TROUGHNUM;
                        //}
                        //special_dic.Add(through.CigaretteCode, through);
                    }
                }
                var t_un_taskUnionTaskline = (from item in en.T_UN_TASK
                                              join item2 in en.T_UN_TASKLINE on item.TASKNUM equals item2.TASKNUM
                                              join item3 in en.T_PRODUCE_SORTTROUGH on item2.CIGARETTECODE equals item3.CIGARETTECODE
                                              where item3.STATE == "10" && item.STATE == "10"
                                              && (item3.CIGARETTETYPE == 30 || item3.CIGARETTETYPE == 40)
                                              //&& (item3.GROUPNO==2 ||item3.GROUPNO==3)//条件：1 通道必须启用， 车组间排程完毕
                                              orderby item.SORTNUM, item3.MACHINESEQ, item3.TROUGHNUM
                                              select new
                                              {
                                                  SortNum = item.SORTNUM,
                                                  BillCode = item.BILLCODE,
                                                  MachineSeq = item3.MACHINESEQ,
                                                  CigName = item3.CIGARETTENAME,
                                                  CigCode = item3.CIGARETTECODE,
                                                  Quantity = item2.QUANTITY,
                                                  TroughNum = item3.TROUGHNUM,
                                                  Status = 0,
                                                  TaskQty = 1,
                                                  TaskNum = item.TASKNUM,
                                                  CustomerCode = item.CUSTOMERCODE,
                                                  SecSortNum = item.SORTNUM,
                                                  Ctype = 1,
                                                  PackageMachine = item.PACKAGEMACHINE,
                                                  LineNum = item.LINENUM,
                                                  GroupNo = item3.GROUPNO,
                                                  ActCount = item3.ACTCOUNT
                                              }).ToList();//任务信息表
                decimal pokeId = GetMaxPokeId(en).Content;//获取最大POKEID
                if (t_un_taskUnionTaskline.Any())
                {
                    ThroughInfo through=new ThroughInfo();
                    foreach (var item in t_un_taskUnionTaskline)
                    {
                        decimal quantity = item.Quantity ?? 0;
                        decimal qty = quantity;
                        //是否是双通道的烟 均分
                        if (special_dic.ContainsKey(item.CigCode))
                        {
                            through=special_dic[item.CigCode];
                            if (through.ThroughNum == item.TroughNum)
                            {
                                qty = Math.Ceiling(quantity / 2);
                            }
                            else {
                                qty = Math.Floor(quantity / 2);
                            }
                            //判断是五拨还是单拨
                            //五拨和单拨都有
                            //if (item.ActCount == 2)
                            //{
                            //    if (item.GroupNo == 3) len = Math.Ceiling(quantity / 2);
                            //    else len = Math.Floor(quantity / 2);
                            //    //len =  quantity - quantity % 5;

                            //}
                            ////只有五拨
                            //else
                            //{
                            //    //len = quantity % 5;
                            //    len = quantity;
                            //}
                        }
                        //for (int i = 1; i <= len; i++)//根据条烟数量拆分成单条数据
                        if(qty>0){
                            T_UN_POKE t_un_poke = new T_UN_POKE();
                            t_un_poke.POKEID = pokeId++;
                            t_un_poke.TROUGHNUM = item.TroughNum;
                            t_un_poke.POKENUM = qty;
                            t_un_poke.STATUS = item.Status;
                            t_un_poke.TASKNUM = item.TaskNum;
                            t_un_poke.TASKQTY = item.TaskQty;
                            t_un_poke.PACKAGEMACHINE = item.PackageMachine;
                            t_un_poke.MACHINESEQ = item.MachineSeq;
                            t_un_poke.LINENUM = item.LineNum;
                            t_un_poke.CIGARETTECODE = item.CigCode;
                            t_un_poke.CUSTOMERCODE = item.CustomerCode;
                            t_un_poke.SORTNUM = item.SortNum;
                            t_un_poke.SECSORTNUM = item.SortNum;//暂时和SortNum一致
                            t_un_poke.BILLCODE = item.BillCode;
                            //if (item.GroupNo == 3) t_un_poke.CTYPE = 2;
                            //else t_un_poke.CTYPE = 1;
                            t_un_poke.CTYPE = item.GroupNo;
                            t_un_poke.SENDTASKNUM = item.SortNum;//暂时和SortNum一致
                            t_un_poke.STORENUM = 0;//暂时无用
                            t_un_poke.GRIDNUM = 0;//暂时无用
                            t_un_poke.INVFLAG = null;//库存标志
                            t_un_poke.SENDSEQ = 0; //暂时无用 
                            en.T_UN_POKE.AddObject(t_un_poke);
                        }
                        var reUp = UpdateTaskState(en, item.TaskNum);
                        if (!reUp.IsSuccess)
                        {
                            return reUp;
                        }
                    }
                    re.IsSuccess = true;
                    re.MessageText = "任务数据生成成功";
                    return re;
                }
                else
                {
                    return re.DefaultResponse;
                }
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

        public Response UpdateTaskState(DZEntities en, decimal tasknum)
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
                             select  new {
                                 x =task,
                                 y = trough,
                                 z = poke
                             }).ToList();
                var query1 = (from item in query
                              group item by new { item.x.SYNSEQ, item.x.BATCHCODE, item.y.LINENUM } 
                              into g orderby g.Key.SYNSEQ,g.Key.LINENUM
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

        public Response<List<_1stPrjInfo>> Get1stPrjInfo(decimal synSeq,string linenum)
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
                    DateTime orderdate = item.x.ORDERDATE??new DateTime();
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

        public Response<decimal> GetMaxTaskNumByRegioncode(String regioncode)
        {
            using (DZEntities dzEntities = new DZEntities())
            {
                Response<decimal> response = new Response<decimal>();
                response.IsSuccess = true;
                decimal tasknum = 0;
                if (dzEntities.T_UN_TASK.Where(x => x.REGIONCODE == regioncode).Count() > 0)
                {
                    tasknum = dzEntities.T_UN_TASK.Where(x => x.REGIONCODE == regioncode).Max(x => x.TASKNUM);
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
                //OracleParameter[] sqlpara = new OracleParameter[3];
                //sqlpara[0] = new OracleParameter("bz", "0");
                //sqlpara[1] = new OracleParameter("p_ErrCode", OracleDbType.Varchar2, 30);
                //sqlpara[2] = new OracleParameter("p_ErrMsg", OracleDbType.Varchar2, 1000);

                //sqlpara[0].Direction = ParameterDirection.Input;
                //sqlpara[1].Direction = ParameterDirection.Output;
                //sqlpara[2].Direction = ParameterDirection.Output;

                //dzEntities.ExecuteStoreCommand("P_UN_REMOVE", sqlpara);

                System.Data.EntityClient.EntityConnection entityConnection = (System.Data.EntityClient.EntityConnection)dzEntities.Connection;
                entityConnection.Open();
                System.Data.Common.DbConnection storeConnection = entityConnection.StoreConnection;
                System.Data.Common.DbCommand cmd = storeConnection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "P_UN_REMOVE";

                //DbParameter inPara = cmd.CreateParameter();
                //inPara.Direction = ParameterDirection.Input;
                //inPara.ParameterName = "bz";
                //inPara.Value = "0";
                //inPara.DbType = DbType.Object;

                //DbParameter outPara1 = cmd.CreateParameter();
                //outPara1.Direction = ParameterDirection.Output;
                //outPara1.ParameterName = "p_ErrCode";
                //outPara1.DbType = DbType.Object;

                //DbParameter outPara2 = cmd.CreateParameter();
                //outPara2.Direction = ParameterDirection.Output;
                //outPara2.ParameterName = "p_ErrMsg";
                //outPara2.DbType = OracleDbType.Varchar2;

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
