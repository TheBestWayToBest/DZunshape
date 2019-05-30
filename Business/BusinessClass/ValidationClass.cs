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
               if (!vali_1.Any())
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

       }
    }
}
