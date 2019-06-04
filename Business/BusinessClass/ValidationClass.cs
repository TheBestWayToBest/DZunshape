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
       public Response ValiOrderNum()
       {
           Response re = new Response();
           using (DZEntities en = new DZEntities())
           {

               return re;
           }

       }
 
    }
}
