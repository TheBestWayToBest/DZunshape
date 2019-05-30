using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Modle;
namespace Business.BusinessClass
{
   public class ChannelClass  :ValidationClass
    {
       /// <summary>
       /// 通道管理 ：对通道进行 增 删 改 查 操作
       /// </summary>
       public ChannelClass() 
       { 
          
       } 
       /// <summary>
       /// 查询通道表 (查询条件：1默认所有，2卷烟编码， 3卷烟名称， 4通道号，
       /// </summary>
       /// <returns></returns>
       public Response<List<T_PRODUCE_SORTTROUGH>> GetSortTroughInfo(object condition = null, int queryType = 1)
       {
           Response<List<T_PRODUCE_SORTTROUGH>> re = new Response<List<T_PRODUCE_SORTTROUGH>>("查询通道表：未找到任何数据,请检查网络连接！");
           try
           {
               using (DZEntities en = new DZEntities())
               {
                   var t_produce_sorttorugh = (from item in en.T_PRODUCE_SORTTROUGH select item).OrderBy(a => a.MACHINESEQ).ToList();
                   if (t_produce_sorttorugh.Any())
                   {
                       switch (queryType)
                       {
                           case 1:
                               re.Content = t_produce_sorttorugh;
                               re.IsSuccess = true;
                               re.MessageText = "查询成功！";
                               return re;
                           case 2:
                               re.Content = t_produce_sorttorugh.Where(a => a.CIGARETTECODE.StartsWith(condition.ToString())).ToList();
                               re.IsSuccess = true;
                               re.MessageText = "查询成功！";
                               return re;
                           case 3:
                               re.Content = t_produce_sorttorugh.Where(a => a.CIGARETTENAME.StartsWith(condition.ToString())).ToList();
                               re.IsSuccess = true;
                               re.MessageText = "查询成功！";
                               return re;

                           case 4:
                               re.Content = t_produce_sorttorugh.Where(a => a.MACHINESEQ == Convert.ToDecimal(condition)).ToList();
                               re.IsSuccess = true;
                               re.MessageText = "查询成功！";
                               return re;
                           default:
                               re.DefaultResponse.MessageText += "未识别的查询类型！" + queryType;
                               return re.DefaultResponse;
                       }
                   }
                   else
                   {
                       return re.DefaultResponse;
                   }
               }
           }
           catch (Exception e)
           {
               re.DefaultResponse.MessageText += "\r\n 异常信息：" + e.Message;
               return re.DefaultResponse;
           }

       }

       /// <summary>
       /// 增加一个通道
       /// </summary>
       /// <returns></returns>
       public Response<bool> AddOneTrough(T_PRODUCE_SORTTROUGH addInfo)
       {
           Response<bool> re = new Response<bool>("增加通道失败：");
           try
           {
               using (DZEntities en = new DZEntities())
               {
                   var res = ValiSingleChannel(addInfo);
                   if (res.IsSuccess)
                   {
                       en.T_PRODUCE_SORTTROUGH.AddObject(addInfo);
                       if (en.SaveChanges() > 0)
                       {
                           re.IsSuccess = true;
                           re.MessageText = "增加通道成功";
                           return re;
                       }
                       else
                       {
                           re.IsSuccess = false;
                           re.MessageText = "增加通道失败！";
                           return re;
                       }
                   }
                   else
                   {
                       re.DefaultResponse.MessageText = res.MessageText;
                       return re;
                   } 
               }
           }
           catch (Exception ex)
           {
               re.MessageText += "\r\n"+ex.Message;
               return re;
           }
       }
       ///// <summary>
       ///// 删除一个通道
       ///// </summary>
       ///// <returns></returns>
       //public Response<bool> RemoveOneTrough()
       //{

       //}

       ///// <summary>
       ///// 修改一个通道
       ///// </summary>
       ///// <returns></returns>
       //public Response<bool> ChangeOneTrough()
       //{

       //}
        

 
    }
}
 
