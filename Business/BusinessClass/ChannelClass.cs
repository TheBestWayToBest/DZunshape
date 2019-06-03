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
       const string Str_SortTId = "   select  s_produce_sorttrough.nextval from dual";
       #region 通道维护
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
                               var con = t_produce_sorttorugh.Where(a => a.CIGARETTENAME.StartsWith(condition.ToString())).ToList();
                               re.Content = con;
                               re.IsSuccess = true;
                               re.MessageText = "查询成功！";
                               return re;
                           case 3:
                               re.Content = t_produce_sorttorugh.Where(a => a.CIGARETTECODE.StartsWith(condition.ToString())).ToList();
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
       public Response AddOneTrough(T_PRODUCE_SORTTROUGH addInfo)
       {
           Response re = new Response("增加通道失败：");
           try
           {
               using (DZEntities en = new DZEntities())
               {
                   var res = ValiSingleChannel(addInfo);
                   if (res.IsSuccess)
                   {

                       addInfo.ID = GetId;//自增 涨一个ID
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
                       return res;
                   } 
               }
           }
           catch (Exception ex)
           {
               re.MessageText += "\r\n"+ex.Message;
               return re;
           }
       }
       /// <summary>
       /// 删除一个通道
       /// </summary>
       /// <returns></returns>
       public Response  RemoveOneTrough(T_PRODUCE_SORTTROUGH tps,bool thDelete = false)
       {
            Response re = new Response("删除通道失败：");
            try
            {
                using (DZEntities en = new DZEntities())
                {
                    var res = ValiSingleChannel(tps);
                    if (res.IsSuccess)//如果通道已经启用
                    {
                        if (thDelete)//如果强制删除 则删除
                        {
                            en.T_PRODUCE_SORTTROUGH.DeleteObject(tps);
                            if (en.SaveChanges() > 0)
                            {
                                re.IsSuccess = true;
                                re.MessageText = tps.MACHINESEQ + "通道删除成功";
                                return re;
                            }
                            else
                            {
                                re.DefaultResponse.MessageText += "数据更新行数为0";
                                return re.DefaultResponse;
                            }
                        }
                        else
                        {
                            res.IsSuccess = false;
                            res.MessageText += "通道删除失败！";
                            return res;
                        }
                    }
                    else//如果没有启用 则直接删除
                    {
                        en.T_PRODUCE_SORTTROUGH.DeleteObject(tps);
                        if (en.SaveChanges() > 0)
                        {
                            re.IsSuccess = true;
                            re.MessageText = tps.MACHINESEQ + "通道删除成功";
                            return re;
                        }
                        else
                        {
                            return re.DefaultResponse;
                        }
                    }
                }
            }
            catch(Exception ex )
            {
                re.DefaultResponse.MessageText += ex.Message;
                return re;
            }
       }
       /// <summary>
       /// 获取新的ID
       /// </summary>
       /// <returns></returns>
      private  decimal GetTroughId()
       {
           using (DZEntities en = new DZEntities())
           {
               return en.ExecuteStoreQuery<decimal>(Str_SortTId, null).FirstOrDefault();
           }
       }

       public decimal GetId { get { return GetTroughId(); } }
       /// <summary>
       /// 修改一个通道
       /// </summary>
       /// <returns></returns>
       public Response ChangeOneTrough(T_PRODUCE_SORTTROUGH tps)
       {
           Response re = new Response("修改通道失败：");
           using (DZEntities en = new DZEntities())
           {
               var date = (from item in en.T_PRODUCE_SORTTROUGH where item.MACHINESEQ == tps.MACHINESEQ select item).ToList();
               if (date.Any())
               {
                   var singleDate = date.FirstOrDefault(); 
                   singleDate.STATE = tps.STATE;
                   singleDate.ACTCOUNT = tps.ACTCOUNT;
                   singleDate.CIGARETTECODE = tps.CIGARETTECODE;
                   singleDate.CIGARETTENAME = tps.CIGARETTENAME;
                   singleDate.CIGARETTETYPE = tps.CIGARETTETYPE;
                   singleDate.GROUPNO = tps.GROUPNO;
                   singleDate.LASTMANTISSA = tps.LASTMANTISSA;
                   singleDate.LINENUM = tps.LINENUM;
                   singleDate.MACHINESEQ = tps.MACHINESEQ;
                   singleDate.MANTISSA = tps.MANTISSA;
                   singleDate.SEQ = tps.SEQ;
                   if (en.SaveChanges() > 0)
                   {
                       re.IsSuccess = true;
                       re.MessageText = "通道修改成功";

                       return re;
                   }
                   else
                   {
                       re.IsSuccess = false;
                       re.MessageText = "通道修改失败"; 
                       return re;
                   }
               }
               else
               {
                   re.DefaultResponse.MessageText += "未找到该通道";
                   return re;
               }
           }
       }

       /// <summary>
       /// 获取一个通道
       /// </summary>
       /// <returns></returns>
       public Response<T_PRODUCE_SORTTROUGH> GetSingleTrough(decimal machineseq)
       {
           Response<T_PRODUCE_SORTTROUGH> res = new Response<T_PRODUCE_SORTTROUGH>();
           using (DZEntities en = new DZEntities())
           {
               var data  = (from item in en.T_PRODUCE_SORTTROUGH where item.MACHINESEQ 
                            == machineseq select item) .FirstOrDefault() ;

               if (data!=null)
               {
                   res.Content = data;
                   res.IsSuccess = true;
                   return res;
               }
               else
               {
                   res.Content = null;
                   res.IsSuccess = false;
                   return res;
               }

           }
       }
       #endregion


       /// <summary>
       /// 获取品牌信息
       /// </summary>
       /// <param name="condition"></param>
       /// <param name="queryType"></param>
       /// <returns></returns>
       public Response<List<CigarettInfo>> GetCigInfo(object condition = null, int queryType = 0)
       {

           Response<List<CigarettInfo>> res = new Response<List<CigarettInfo>>("错误：可能是为标记的查询类型：" + queryType);
           try
           { 
               using (DZEntities en = new DZEntities())
               {
                   var query = (from item in en.T_WMS_ITEM where item.ITEMNO.Length > 7 select item).ToList();
                   res.IsSuccess = true;
                   switch (queryType)
                   {
                       case 0:
                           res.Content = query.Select(a => new CigarettInfo { BigBoxCode = a.BIGBOX_BAR, CigCode = a.ITEMNO, CigName = a.ITEMNAME }).ToList();
                           return res;
                       case 1:
                           res.Content = (from item in query where item.ITEMNAME.StartsWith(condition.ToString()) select new CigarettInfo { BigBoxCode = item.BIGBOX_BAR, CigCode = item.ITEMNO, CigName = item.ITEMNAME }).ToList();
                           return res;
                       case 2:
                           res.Content = query.Where(a => a.ITEMNO.StartsWith(condition.ToString())).Select(a => new CigarettInfo { BigBoxCode = a.BIGBOX_BAR, CigCode = a.ITEMNO, CigName = a.ITEMNAME }).ToList();
                           return res;

                       default:
                           return res.DefaultResponse;
                   }

               }
           }
           catch (Exception ex)
           {
               res.DefaultResponse.MessageText = "错误：" + ex.Message;
               return res;
           }

       }
    }
}
 
