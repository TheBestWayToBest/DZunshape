using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Modle;
using System.Data.SqlClient;

namespace Business.BusinessClass
{
    public class ReceiveClass  
    {
        /// <summary>
        /// 订单接收
        /// </summary>
        public ReceiveClass() //根据车组
        {
            //获取  V_SALE_ORDER_HEAD  订单中间表主视图  V_SALE_ORDER_LINE  订单中间表明细视图

        }
        /// <summary>
        /// SortNum 序列
        /// </summary>
        const string Str_Sortnum_SEQUENCE = "select ZOOMTEL.S_PRODUCE_SORTNUM.NEXTVAL from dual ";
 
        #region 订单接收 从数据源 到 ORDER表和ORDERLINE表中 
        /// <summary>
        /// 根据车组接收
        /// </summary>
        /// <param name="regioncode">车组</param>
        /// <returns></returns>
        public Response<bool> ReceiveSaleOrderToOrder(string regioncode)
        {
            // V_SALE_ORDER_HEAD  订单中间表主视图 
            Response<bool> re = new Response<bool>("车组接收异常：未能成功接收，检查车组号是否正确" + regioncode);
            StringBuilder sb = new StringBuilder();
            using (DZEntities en = new DZEntities())
            {
                //var V_SALE_ORDER_HEAD =  //获取订单主表 根据车组
                var V_SALE_ORDER_HEAD = new List<string>();//假设数据集 
                if (V_SALE_ORDER_HEAD.Any())//如果包含数据
                {
                    foreach (var order in V_SALE_ORDER_HEAD)//一个车组 
                    {
                        T_PRODUCE_ORDER t_produce_order = new T_PRODUCE_ORDER();//单个订单
                        //字段的赋值
                        // t_produce_order.BILLCODE = bill.code
                        var reDetail = ReceiveSaleLineToOrderLine(order);//接收单个订单的条烟明细
                        if (reDetail.IsSuccess)//如果这个这个订单的明细接收无异常
                        { 
                            en.T_PRODUCE_ORDER.AddObject(t_produce_order);//添加一个订单 
                        }
                        else//跳出循环
                        {
                          
                            sb.AppendLine(reDetail.MessageText);
                            re.MessageText += sb.ToString();
                            re.IsSuccess = false;
                            re.Content = false;
                            return re;
                        } 
                    }

                }
                else
                {
                    re.IsSuccess = false;
                    re.MessageText = "未找到该车组："+regioncode;
                    return re;
                    
                }

            } 
            return re;
        }

        /// <summary>
        /// 接收订单明细 根据订单
        /// </summary>
        /// <returns></returns>
        public Response ReceiveSaleLineToOrderLine(string  billcode)
        {
            Response re = new Response("接收订单明细异常：未能成功接收，订单号："+billcode);
            StringBuilder sb = new StringBuilder();
            using (DZEntities en = new DZEntities())
            {
                //var V_SALE_ORDER_LINE =  //根据订单号 获取订单明细
                var V_SALE_ORDER_LINE = new List<string>();//假设数据集 
                if (V_SALE_ORDER_LINE.Any())
                {
                    foreach (var detail in V_SALE_ORDER_LINE)
                    {
                        T_PRODUCE_ORDERLINE t_produce_orderline = new T_PRODUCE_ORDERLINE();
                        //字段赋值 

                        en.T_PRODUCE_ORDERLINE.AddObject(t_produce_orderline);//添加置实体集
                    }

                }
                else
                {
                    sb.AppendLine("订单号："+billcode +"未找到任何条烟明细");
                    re.MessageText = sb.ToString();
                    re.IsSuccess = false;
                    return re;
                }

            }

            return re.DefaultResponse;
        }
        #endregion

        #region 预排程 从ORDER,ORDERLINE 接收数据至 TASK 和TASKLINE
        /// <summary>
        /// 对单个车组进行预排程
        /// </summary>
        /// <param name="regioncode"></param>
        /// <returns></returns>
        public Response   PreSchedule ( string regioncode )
        {
            Response re = new Response();
            StringBuilder sb = new StringBuilder();
            using (DZEntities en = new DZEntities())
            {
                var t_produce_Order = (from item in en.T_PRODUCE_ORDER where item.REGIONCODE == regioncode select item).ToList();//根据车组查询ORder表中所对应的订单

                if (t_produce_Order.Any())
                {
                    foreach (var item in t_produce_Order)
                    {
                        T_UN_TASK t_un_task = new T_UN_TASK();
                        //字段赋值
                        t_un_task.TASKNUM = item.SELATASKNUM ?? 0;
                        t_un_task.STATE = "10";
                        t_un_task.SORTNUM = en.ExecuteStoreQuery<decimal>(Str_Sortnum_SEQUENCE, null).FirstOrDefault();//SortNum序列


                        var psDetail = PreScheduleDetail(en, item.BILLCODE,item.SELATASKNUM ?? 0);//添加单个订单的条烟明细到TASKLINE
                        if (psDetail.IsSuccess)
                        { 
                            en.T_UN_TASK.AddObject(t_un_task);//添加到实体集
                            if (en.SaveChanges() > 0)//一个订单保存一次
                            {

                            }
                            else
                            {
                                return re.DefaultResponse;
                            }
                        }
                        else
                        {
                            return psDetail;
                        } 
                    } 
                }
                else
                {
                    
                }
            }
            return re.DefaultResponse;

        }

        /// <summary>
        /// 添加订单明细（ORDERLINE） 到任务明细（TASKLINE）
        /// </summary>
        /// <param name="en"></param>
        /// <param name="billcode"></param>
        /// <param name="Selatasknum"></param>
        /// <returns></returns>
        public Response PreScheduleDetail(DZEntities en, string billcode,decimal Selatasknum =0)
        {
            Response re = new Response("未找到订单号："+billcode +" 条烟明细！");
            var t_produce_ordelrine = (from item in en.T_PRODUCE_ORDERLINE
                                       where item.BILLCODE == billcode
                                       select item).ToList();//根据订单号获取该订单的条烟明细
            if (t_produce_ordelrine.Any())
            {
                foreach (var item in t_produce_ordelrine)
                {
                    T_UN_TASKLINE t_un_taskline = new T_UN_TASKLINE();
                    t_un_taskline.TASKNUM = Selatasknum; 
                    //字段赋值 
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
        /// 任务数据排程 直接一次性排程Task表中的所有数据
        /// </summary>
        /// <returns></returns>
        public Response SchedulePoke() 
        {
            Response re = new Response("数据排程：未找对应的数据！");
            using (DZEntities en = new DZEntities())
            {
                var t_un_taskUnionTaskline = (from item in en.T_UN_TASK
                                              join item2 in en.T_UN_TASKLINE   on item.TASKNUM equals item2.TASKNUM
                                              join item3 in en.T_PRODUCE_SORTTROUGH on item2.CIGARETTECODE equals item3.CIGARETTECODE 
                                              where item3.STATE == "10"  && item.STATE == "10"//条件：1 通道必须启用， 车组间排程完毕
                                              select new
                                              { 
                                                  SortNum = item.SORTNUM,
                                                  BillCode = item.BILLCODE, 
                                                  MachineSeq = item3.MACHINESEQ,
                                                  CigName =  item3.CIGARETTENAME,
                                                  CigCode = item3.CIGARETTECODE, 
                                                  Quantity = item2.QUANTITY,
                                                  TroughNum = item3.TROUGHNUM,
                                                  Status = 10,
                                                  TaskQty = 1,
                                                  TaskNum = item.TASKNUM,
                                                  CustomerCode = item.CUSTOMERCODE,
                                                  SecSortNum = item.SORTNUM,
                                                  Ctype = 1 ,
                                                  PackageMachine = item.PACKAGEMACHINE, 
                                                  LineNum = item.LINENUM,
                                              }).ToList();//任务信息表
                decimal pokeId = GetMaxPokeId(en).Content;//获取最大POKEID
                if (t_un_taskUnionTaskline.Any())
                {
                    foreach (var item in t_un_taskUnionTaskline)
                    {
                        T_UN_POKE t_un_poke = new T_UN_POKE();
                        for (int i = 1; i <= item.Quantity; i++)//根据条烟数量拆分成单挑数据
                        {
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
                    }
                    if (en.SaveChanges() > 0)
                    {
                        re.IsSuccess = true;
                        re.MessageText = "任务数据生成成功";
                        return re;
                    }
                    else
                    {
                        return re.DefaultResponse;
                    }
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
                red.Content = maxPokeID.Max(a => a.POKEID);
                return red; 
            }
            else//如果不包含任何数据 初始值为0
            {
                red.IsSuccess = true;
                red.Content = 0;
                return red;
            }
          
        }



        #endregion
    }
}
