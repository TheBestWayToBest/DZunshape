using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Modle;


namespace Business.BusinessClass
{
    /// <summary>
    /// 批次管理
    /// </summary>
   public class BatchClass
    {
        /// <summary>
    /// 批次管理
    /// </summary>
       public BatchClass(){

       }

       /// <summary>
       /// 获取批次表
       /// </summary>
       public Response<List<T_PRODUCE_BATCH>> GetBatchDetail()
       {
           Response<List<T_PRODUCE_BATCH>> response = new Response<List<T_PRODUCE_BATCH>>("批次表不包涵任何数据");
           using (DZEntities en = new DZEntities())
           {

               var t_batch = (from item in en.T_PRODUCE_BATCH
                              orderby item.BATCHCODE descending
                              select item).ToList();
               if (t_batch.Any())
               {
                   response.IsSuccess = true;
                   response.Content = t_batch;
                   return response;
               }
               else
               {
                   return response ;
               }

           }
       }
       
       /// <summary>
       /// 根据批次号 操作一个批次 
       /// </summary>
       /// <param name="batchcode">批次号</param>
       /// <param name="optionType">操作0 关闭最近一个创建的批次（默认） ， 1 创建一个批次 , 2 关闭一个指定的批次</param>
       public Response OperationBatch(string batchcode = "", int optionType = 0)
       {
           Response response = new Response("操作失败：未找到该批次号，或者该批次号有误："+batchcode);
           using (DZEntities en = new DZEntities())
           {
              
               if (optionType == 0)//关闭最近一个创建的批次
               {
                   var old_batch = (from item in en.T_PRODUCE_BATCH where item.STATE == 10 select item).ToList();
                   if (old_batch.Any())
                   {
                       if (old_batch.Count() >= 2)
                       {

                           response.IsSuccess = false;
                           response.MessageText = "批次：数据中同时出现两个或两个以上的批次未完成！";
                           return response;
                       }
                       else
                       {
                           old_batch.ForEach(a => a.STATE = 0);//更新批次为关闭
                           old_batch.ForEach(a => a.ENDTIME = DateTime.Now);//更新批次为关闭
                           response.IsSuccess = true;
                           response.MessageText = "批次：关闭批次成功！";
                           en.SaveChanges();
                           return response;
                       }
                   }
                   else
                   {
                       response.IsSuccess = true;
                       return response; 
                   } 
                 
               }
               else if (optionType == 1)//创建一个批次
               {
                   T_PRODUCE_BATCH t_batch = new T_PRODUCE_BATCH();
                   t_batch.BATCHCODE = batchcode;
                   t_batch.STARTTIME = DateTime.Now;
                   t_batch.STATE = 10;
                   t_batch.BATCHTYPE = 20;
                   en.T_PRODUCE_BATCH.AddObject(t_batch);
                   if (en.SaveChanges() > 0)
                   {
                       response.IsSuccess = true;
                       response.MessageText = "批次：批次创建成功";
                       return response;
                   }
                   else
                   {
                       response.IsSuccess = false; 
                       response.MessageText = "批次：创建失败，数据更新行数为0！";
                       return response;
                   }
                 
               }
               else if (optionType == 2)//关闭一个指定的批次
               {
                   var old_batch = (from item in en.T_PRODUCE_BATCH where item.BATCHCODE == batchcode select item).FirstOrDefault();
                   if (old_batch != null)
                   {
                       old_batch.ENDTIME = DateTime.Now;
                       old_batch.STATE = 0;
                       if (en.SaveChanges() > 0)
                       {
                           response.IsSuccess = true;
                           response.MessageText = "批次：指定批次关闭成功";
                           return response;
                       }
                       else
                       {
                           response.IsSuccess = false;
                           response.MessageText = "批次：关闭失败，数据更新行数为0！";
                           return response;
                       }
                   }
                   else
                   {
                       return response.DefaultResponse;
                   }
               }
               else
               {
                   return response.DefaultResponse;
               } 
           } 
       }

       /// <summary>
       /// 获取批次号
       /// </summary>
       /// <returns>字符串批次号</returns>
       public Response CreateBatchCode()
       {
           Response re = new Response("未找到数据！");
           String yearmonth = DateTime.Now.ToString("yyyyMMdd");
           using (DZEntities en = new DZEntities())
           { 
               
               var t_batch_count = (from item in en.T_PRODUCE_BATCH where item.BATCHCODE.StartsWith(yearmonth) select item).Count();
               if (t_batch_count < 0)
               {
                   re.DefaultResponse.DefaultResponse.ResultObject = yearmonth +"0"+ 1;
                   return re.DefaultResponse;
               }
               else
               { 
                   if (t_batch_count < 10)
                   {
                       re.ResultObject = yearmonth + "0" + (t_batch_count + 1);
                   }
                   else
                   {
                       re.ResultObject = yearmonth + (t_batch_count + 1);
                   }
                   re.IsSuccess = true;
                   re.MessageText = "成功获取新的批次";
               }
           }
           return re;

       }

      
    }
}