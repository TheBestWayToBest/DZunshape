using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Modle;

namespace Business.BusinessClass
{
    public class ReceiveClass
    {
        /// <summary>
        /// 订单接收
        /// </summary>
        public ReceiveClass()//根据车组
        {
            //获取  V_SALE_ORDER_HEAD  订单中间表主视图  V_SALE_ORDER_LINE  订单中间表明细视图

        }
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
    }
}
