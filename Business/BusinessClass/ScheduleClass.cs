using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Modle;
using System.Data.SqlClient;

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
        const string Str_Sortnum_SEQUENCE = "select ZOOMTEL.S_PRODUCE_SORTNUM.NEXTVAL from dual ";


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
                var exp = HeadGroup.Except(ReadyRegion);//未排程的车组

                foreach (var item in exp)
                {
                    MainOrder mo = new MainOrder();
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
        public Response ReceiveSaleOrderToOrder(DateTime nowDate, string regioncode)
        {
            // V_SALE_ORDER_HEAD  订单中间表主视图 
            Response re = new Response("车组接收异常：未能成功接收，检查车组号是否正确" + regioncode);
            StringBuilder sb = new StringBuilder();
            using (DZEntities en = new DZEntities())
            {
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
                        foreach (var order in V_SALE_ORDER_HEAD)//一个车组 
                        {
                            T_PRODUCE_ORDER t_produce_order = new T_PRODUCE_ORDER();//单个订单
                            //字段的赋值 
                            t_produce_order.BILLCODE = order.ORDERNO;
                            t_produce_order.COMPANYCODE = "";//公司编码
                            t_produce_order.COMPANYNAME = ""; //公司名称
                            t_produce_order.BATCHCODE = valBatch.ResultObject.ToString();
                            t_produce_order.SYNSEQ = 1;//批次号
                            t_produce_order.ORDERQUANTITY = order.TOTALQTY;
                            t_produce_order.ORDERMONEY = order.TOTALAMOUNT;
                            t_produce_order.CUSTOMERCODE = order.CUSTOMER_ID;
                            t_produce_order.ADDRESS = order.CONTACTADDRESS;
                            t_produce_order.TELEPHONE = order.CONTACTPHONE;
                            t_produce_order.PRIORITY = 1;//送货顺序（数据源未提供）
                            t_produce_order.REGIONCODE = order.ROUTECODE;
                            t_produce_order.TASKBOXIES = "";
                            t_produce_order.TASKNUMBERS = "";
                            t_produce_order.STATE = "新增";
                            t_produce_order.DEVSEQ = 1;//原始送货顺序
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
        public Response<List<T_PRODUCE_ORDER>> GetRouteInFO()
        {
            Response<List<T_PRODUCE_ORDER>> reList = new Response<List<T_PRODUCE_ORDER>>();
            using (DZEntities en = new DZEntities())
            {
                var query = (from item in en.T_PRODUCE_ORDER where item.STATE == "新增" select item).ToList();
                if (query.Any())
                {
                    reList.IsSuccess = true;
                    reList.MessageText = "找到数据了，在Content里面";
                    reList.Content = query;
                    return reList;
                }
                else
                {
                    reList.IsSuccess = false;
                    reList.MessageText = "为找到新增车组！";
                    return reList;
                }

            }

        }
        /// <summary>
        /// 对单个车组进行预排程
        /// </summary>
        /// <param name="regioncode"></param>
        /// <returns></returns>
        public Response PreSchedule(string regioncode)
        {
            Response re = new Response("预排程失败未找到对应的车组" + regioncode);
            StringBuilder sb = new StringBuilder();
            using (DZEntities en = new DZEntities())
            {
                var valBatch = ValiBatchCode();
                if (!valBatch.IsSuccess)
                {
                    return valBatch;
                }
                var t_produce_Order = (from item in en.T_PRODUCE_ORDER where item.REGIONCODE == regioncode select item).ToList();//根据车组查询ORder表中所对应的订单

                if (t_produce_Order.Any())
                {
                    foreach (var item in t_produce_Order)
                    {
                        T_UN_TASK t_un_task = new T_UN_TASK();
                        //字段赋值
                        t_un_task.TASKNUM = item.SELATASKNUM ?? 0;
                        t_un_task.LINENUM = "1";
                        t_un_task.EXPORTNUM = "1";
                        t_un_task.REGIONCODE = item.REGIONCODE;
                        t_un_task.REGIONDESC = item.REGIONCODE;
                        t_un_task.BILLCODE = item.BILLCODE;
                        t_un_task.COMPANYCODE = item.COMPANYCODE;
                        t_un_task.COMPANYNAME = item.COMPANYNAME;
                        t_un_task.BATCHCODE = item.BATCHCODE;
                        t_un_task.SYNSEQ = item.SYNSEQ;
                        t_un_task.CUSTOMERCODE = item.CUSTOMERCODE;
                        t_un_task.ORDERQUANTITY = item.ORDERQUANTITY;
                        t_un_task.TASKQUANTITY = item.ORDERQUANTITY;
                        t_un_task.PRIORITY = Convert.ToInt32(item.PRIORITY);//送货顺序
                        t_un_task.TASKBOX = "F";
                        t_un_task.SORTSEQ = item.PRIORITY;//户序
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
                        var psDetail = PreScheduleDetail(en, item.BILLCODE, item.SELATASKNUM ?? 0);//添加单个订单的条烟明细到TASKLINE
                        if (psDetail.IsSuccess)
                        {
                            en.T_PRODUCE_ORDER.Where(a => a.REGIONCODE == regioncode).FirstOrDefault
                                ().STATE = "排程";
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
        /// <summary>
        /// 添加订单明细（ORDERLINE） 到任务明细（TASKLINE）
        /// </summary>
        /// <param name="en"></param>
        /// <param name="billcode"></param>
        /// <param name="Selatasknum"></param>
        /// <returns></returns>
        private Response PreScheduleDetail(DZEntities en, string billcode, decimal Selatasknum = 0)
        {
            Response re = new Response("未找到订单号：" + billcode + " 条烟明细！");
            var t_produce_ordelrine = (from item in en.T_PRODUCE_ORDERLINE
                                       where item.BILLCODE == billcode
                                       select item).ToList();//根据订单号获取该订单的条烟明细
            if (t_produce_ordelrine.Any())
            {
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
                }
                if (en.SaveChanges() > 0)
                {
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
        public Response<List<T_UN_TASK>> GetTaskInfo()
        {
            Response<List<T_UN_TASK>> reList = new Response<List<T_UN_TASK>>();
            using (DZEntities en = new DZEntities())
            {
                var query = (from item in en.T_UN_TASK where item.STATE == "10" select item).ToList();
                if (query.Any())
                {
                    reList.IsSuccess = true;
                    reList.MessageText = "找到数据了，在content里面";
                    reList.Content = query;
                    return reList;
                }
                else
                {
                    reList.IsSuccess = false;
                    reList.MessageText = "未找到数据";
                    return reList;
                }


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
                var t_un_taskUnionTaskline = (from item in en.T_UN_TASK
                                              join item2 in en.T_UN_TASKLINE on item.TASKNUM equals item2.TASKNUM
                                              join item3 in en.T_PRODUCE_SORTTROUGH on item2.CIGARETTECODE equals item3.CIGARETTECODE
                                              where item3.STATE == "10" && item.STATE == "10"//条件：1 通道必须启用， 车组间排程完毕
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
                                                  Status = 10,
                                                  TaskQty = 1,
                                                  TaskNum = item.TASKNUM,
                                                  CustomerCode = item.CUSTOMERCODE,
                                                  SecSortNum = item.SORTNUM,
                                                  Ctype = 1,
                                                  PackageMachine = item.PACKAGEMACHINE,
                                                  LineNum = item.LINENUM,
                                              }).ToList();//任务信息表
                decimal pokeId = GetMaxPokeId(en).Content;//获取最大POKEID
                if (t_un_taskUnionTaskline.Any())
                {
                    foreach (var item in t_un_taskUnionTaskline)
                    {

                        for (int i = 1; i <= item.Quantity; i++)//根据条烟数量拆分成单条数据
                        {
                            T_UN_POKE t_un_poke = new T_UN_POKE();
                            t_un_poke.POKEID = pokeId++;
                            t_un_poke.TROUGHNUM = item.TroughNum;
                            t_un_poke.POKENUM = 1;
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
                            t_un_poke.CTYPE = 1;
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



        //select a.regioncode,a.cigarettecode,a.cigarettename,a.quantity,b.pokenum from(
        //select o.regioncode, line.cigarettecode,line.cigarettename,sum(quantity) quantity from t_produce_order o,t_produce_orderline line where o.state='排程'
        //group by o.regioncode, line.cigarettecode,line.cigarettename
        //) a left join
        //(
        //select cigarettecode,sum(pokenum) pokenum,regioncode
        //from(
        //select s.cigarettecode,p.pokenum,t.regioncode from t_produce_poke p,t_produce_sorttrough s,t_produce_task t where t.billcode=p.billcode and p.troughnum=s.troughnum 
        //and s.troughtype=10 and s.cigarettetype=20
        //union all
        //select p.cigarettecode,p.pokenum,t.regioncode  from t_un_poke p,t_produce_task t where p.billcode=t.billcode
        //)
        //group by  cigarettecode,regioncode
        //) b on a.regioncode=b.regioncode and a.cigarettecode=b.cigarettecode

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
    }
}
