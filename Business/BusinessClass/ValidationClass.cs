using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Modle;

namespace Business.BusinessClass
{
    /// <summary>
    /// 验证数据类
    /// </summary>
   public class ValidationClass
    {
       /// <summary>
        /// 验证数据类
       /// </summary>
       public ValidationClass()
       {

       }

       /// <summary>
       /// 验证单个通道 1验证，通道是否启用
       /// </summary>
       /// <param name="cahnnel"></param>
       /// <returns></returns>
       public Response ValiSingleChannel(T_PRODUCE_SORTTROUGH channel)
       {
           Response re = new Response();

           using(DZEntities en  = new DZEntities())
           {
               var date = (from item in en.T_PRODUCE_SORTTROUGH orderby item.MACHINESEQ select item ).ToList(); 
               //先判断该品牌是否通道中存在 
               var vali_1 = date.Where(a => a.CIGARETTECODE == channel.CIGARETTECODE && a.STATE == "10").ToList();
               var Vali_2 = date.Where(a => a.MACHINESEQ == channel.MACHINESEQ && a.STATE == "10").ToList();
               if (!vali_1.Any())
               {
                   if (!Vali_2.Any())
                   { 
                       re.IsSuccess = true;
                       re.MessageText = "该通道未被启用" + channel.MACHINESEQ;
                       return re;
                   }
                   else
                   {
                       re.IsSuccess = false;
                       re.MessageText = "该通道已经启用:" + channel.MACHINESEQ;
                       return re;
                   }
                
               }
               else
               {
                   re.IsSuccess = false;
                   re.MessageText = "该通道已经启用:" + channel.MACHINESEQ; 
                   return re;

               }

             

           }

       }


       /// <summary>
       /// 验证批次
       /// </summary>
       /// <returns></returns>
       public Response ValiBatchCode()
       {
           Response re = new Response();
           using(DZEntities en  = new DZEntities())
           {
               var MaxBtach = (from item in en.T_PRODUCE_BATCH
                               where item.STATE == 10 && item.BATCHTYPE == 20
                               select
                                   item).Max(a => a.BATCHCODE);
               if (!string.IsNullOrWhiteSpace (MaxBtach) && MaxBtach != "0")
               {
                   re.IsSuccess = true;
                   re.MessageText = "有新的批次";
                   re.ResultObject = MaxBtach;
                   return re;
               }
               else
               {
                   re.IsSuccess = false;
                   re.MessageText = "查询不到批次号，接收订单前请先创建批次！";
                   return re;
               }

           }

       }

       /// <summary>
       /// 验证接收订单日期
       /// </summary>
       /// <param name="nowTime"></param>
       /// <returns></returns>
       public Response ValiDataTime(DateTime nowTime)
       {

           Response re = new Response();
           using (DZEntities en = new DZEntities())
           {
               var orderTime = (from item in en.T_PRODUCE_ORDER select item
                                ).ToList();
               if (orderTime.Any())
               {
                   if (nowTime == orderTime.FirstOrDefault().ORDERDATE)
                   {
                       re.IsSuccess = true;
                       re.MessageText = "日期无误！";
                       return re;
                   }
                   else
                   {
                       re.IsSuccess = false;
                       re.MessageText = "当前接收订单日期与已接收订单日期不符，请重新选择订单进行接收！";
                       return re;
                   }
               }
               else
               {
                   re.IsSuccess = true;
                   re.MessageText = "未接收任务任何数据！";
                       return re;
               }
           }
       }
       /// <summary>
       /// 验证订单数量是否与源数据一致
       /// </summary>
       /// <returns></returns>
       public Response ValiOrderNum(decimal maxSyncseq,DateTime nowDate)
       {
           Response response = new Response();
           response.IsSuccess = true;
           using (DZEntities dzEntities = new DZEntities())
           {
               //订单个数
               var regionInfo = (from region in dzEntities.T_PRODUCE_ORDER where region.SYNSEQ==maxSyncseq select region.REGIONCODE).Distinct().ToList();
               var orderCount = (from order in dzEntities.T_PRODUCE_ORDER where order.SYNSEQ == maxSyncseq select order).ToList() ;
               var saleOrder  = (from sale in dzEntities.T_SALE_ORDER_HEAD where sale.ORDERDATE==nowDate && regionInfo.Contains(sale.ROUTECODE) select sale).ToList();

               if (orderCount.Count()!=saleOrder.Count())
               {
                   response.IsSuccess = false;
                   response.MessageText = "中间表订单数：" + saleOrder.Count() + "个，接收订单数：" + orderCount.Count() + "个，两边信息不一致！";
               }
               //订单明细条数
               var orderLineCount = (from order in dzEntities.T_PRODUCE_ORDER join line in dzEntities.T_PRODUCE_ORDERLINE on order.BILLCODE equals line.BILLCODE
                                     where order.SYNSEQ == maxSyncseq select line).ToList();
               var saleLineOrder = (from sale in dzEntities.T_SALE_ORDER_HEAD join sline in dzEntities.T_SALE_ORDER_LINE on sale.ORDERNO equals sline.ORDERNO 
                                     where sale.ORDERDATE==nowDate && regionInfo.Contains(sale.ROUTECODE) select sline).ToList();
               if (orderLineCount.Count() != saleLineOrder.Count())
               {
                   response.IsSuccess = false;
                   response.MessageText = response.MessageText + "中间表订单明细数：" + orderLineCount.Count() + "个，接收订单明细数：" + orderLineCount.Count() + "个，两边信息不一致！";
               }
           }
           return response;
       }

       /// <summary>
       /// 验证是否有新品牌
       /// </summary>
       /// <returns></returns>
       public Response ValidNewItem(decimal maxSyncseq)
       {
           Response response = new Response();
           using (DZEntities dzEntities = new DZEntities())
           {

               //正常使用的品牌信息
               var T_WMS_ITEM = (from item in dzEntities.T_WMS_ITEM where item.ROWSTATUS == 10 select new { id = item.ID, itemno = item.ITEMNO, itemname = item.ITEMNAME }).ToList();
               //maxSyncseq批次接收的订单信息
               var T_WMS_ORDERITEM = (from order in dzEntities.T_PRODUCE_ORDER
                                      join line in dzEntities.T_PRODUCE_ORDERLINE on order.BILLCODE equals line.BILLCODE
                                      where order.SYNSEQ == maxSyncseq
                                      select new
                                      {
                                          id = line.CIGARETTECODE,
                                          itemno = line.CIGARETTECODE,
                                          itemname = line.CIGARETTENAME
                                      }).ToList(); ;
               var newItem = T_WMS_ORDERITEM.Except(T_WMS_ITEM).ToList();
               if (newItem.Count() > 0)
               {
                   decimal count = newItem.Count();
                   string itemnamestr = "";
                   foreach (var item in newItem)
                   {
                       
                       var query=(from cig in dzEntities.T_WMS_ITEM where cig.ID==item.id select cig).ToList();
                       if (query.Count() > 0)
                       {
                           query.FirstOrDefault().ROWSTATUS = 10;
                           query.FirstOrDefault().SHIPTYPE = "2";
                       }
                       else 
                       {
                           T_WMS_ITEM iteminfo = new T_WMS_ITEM();
                           iteminfo.ID = item.id;
                           iteminfo.ITEMNO = item.itemno;
                           iteminfo.ITEMNAME = item.itemname;
                           iteminfo.SHIPTYPE = "2";
                           iteminfo.ROWSTATUS = 10;
                           dzEntities.T_WMS_ITEM.AddObject(iteminfo);
                       }
                       
                       int count1=dzEntities.SaveChanges();

                       itemnamestr = itemnamestr + "," + item.itemname;
                   }
                   //dzEntities.SaveChanges();
                   response.IsSuccess = false;
                   response.MessageText = "订单接收发现【" + count + "】个新品牌（" + itemnamestr.Substring(1) + "），请为新品牌完善品牌信息！";
               }
               else
               {
                   response.IsSuccess = true;
                   response.MessageText = "本次接收暂未发现新品牌！";
               }

           }
           return response;
       }
       /// <summary>
       /// 验证是否有新客户
       /// </summary>
       /// <returns></returns>
       public Response ValidNewCustomer(decimal maxSyncseq)
       {
           Response response = new Response();
           using (DZEntities dzEntities = new DZEntities())
           {
               var query= (from pitem in dzEntities.T_WMS_CUSTOMER where pitem.DELSTATUS==10 select pitem.ID ).ToList();

               //var newCust = (from order in dzEntities.T_PRODUCE_ORDER where !query.Contains(order.CUSTOMERCODE) select order).ToList();

               var newCust1 = (from order in dzEntities.T_PRODUCE_ORDER where order.SYNSEQ==maxSyncseq select order.CUSTOMERCODE).ToList();
               var newCust= newCust1.Except(query).ToList();
               if (newCust.Count() > 0)
               {
                   response.IsSuccess = false;
                   response.MessageText = "订单接收发现【" + newCust.Count() + "】个新客户，请为同步零售户信息！";
               }
               else
               {
                   response.IsSuccess = true;
                   response.MessageText = "本次接收暂未发现新零售户！";
               }

           }
           return response;
       }
    }
}
