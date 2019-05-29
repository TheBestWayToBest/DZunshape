using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Modle;

namespace Business.BusinessClass
{
    /// <summary>
    /// 分拣任务类
    /// </summary>
   public class TaskClass
    {
       /// <summary>
        /// 分拣任务类
       /// </summary>
       public TaskClass()
       {

       }
       /// <summary>
       /// 判断分拣任务是否全部完成
       /// </summary>
       /// <returns></returns>
       public Response JugTaskIsOrNotFinish()
       { 
           StringBuilder sb = new StringBuilder();
           int index = 0;
           using (DZEntities en = new DZEntities())
           {
               var t_task = (from item
                              in en.T_UN_TASK
                             where item.STATE != "30"
                             select item).ToList();//获取task表中 任务未完成的数据
               if (t_task.Any())
               {
                   foreach (var item in t_task)
                   {
                       if (index == 9)
                       {
                           sb.AppendLine("还有订单数据" + (t_task.Count() - index + 1) + "未完成");
                           break; 
                       }
                       sb.AppendLine("任务号" + item.SECSORTNUM + "," + item.CUSTOMERNAME + "客户未完成 ");
                       index++;
                       
                   }
               } 
               var t_poke = (from item in en.T_UN_POKE where item.STATUS != 20 select item).ToList();//获取poke 表中任务 未完成的数据
               if (t_poke.Any())
               {
                   sb.AppendLine("分拣明细表有" + t_poke.Count() + "条任务未完成");
               }
               Response re = new Response(sb.ToString());
               if (sb.Length == 0)
               {
                   re.IsSuccess = true;
                   re.MessageText = "分拣任务已经全部完成！";
                   return re;
               }
               else
               {
                   List<object> list = new  List<object>();
                   list.Add(t_task);
                   list.Add(t_poke);
                   re.DefaultResponse.ResultObject = list;
                   return re.DefaultResponse;
               }

           }

       }

       /// <summary>
       /// 移除分拣数据到历史数据
       /// </summary>
       /// <returns></returns>
       public Response RemoveTask()
       {
           
           Response re = new Response();
           StringBuilder sb = new StringBuilder();
           try
           { 
               using (DZEntities en = new DZEntities())
               {
                   var t_un_task = (from item in en.T_UN_TASK select item
                                  ).ToList();
                   if (t_un_task.Any())
                   {
                       foreach (var item in t_un_task)
                       {
                           T_UN_TASK_H th = new T_UN_TASK_H();
                           th.BATCHCODE = item.BATCHCODE;
                           th.BILLCODE = item.BILLCODE;
                           th.TASKNUM = item.TASKNUM;
                           th.LINENUM = item.LINENUM;
                           th.EXPORTNUM = item.EXPORTNUM;
                           th.REGIONCODE = item.REGIONCODE;
                           th.REGIONDESC = item.REGIONDESC;
                           th.BILLCODE = item.BILLCODE;
                           th.COMPANYCODE = item.COMPANYCODE;
                           th.COMPANYNAME = item.COMPANYNAME;
                           th.BATCHCODE = item.BATCHCODE;
                           th.SYNSEQ = item.SYNSEQ;
                           th.CUSTOMERCODE = item.CUSTOMERCODE;
                           th.ORDERQUANTITY = item.ORDERQUANTITY;
                           th.CUSTOMERNAME = item.CUSTOMERNAME;
                           th.ORDERMONEY = item.ORDERMONEY;
                           th.TASKQUANTITY = item.TASKQUANTITY;
                           th.PRIORITY = item.PRIORITY;
                           th.TASKBOX = item.TASKBOX;
                           th.SORTSEQ = item.SORTSEQ;
                           th.LABLENUM = item.LABLENUM;
                           th.PLANTIME = item.PLANTIME;
                           th.SORTTIME = item.SORTTIME;
                           th.FINISHTIME = item.FINISHTIME;
                           th.STATE = item.STATE;
                           th.LABELBATCH = item.LABELBATCH;
                           th.PALLETNUM = item.PALLETNUM;
                           th.EXISTRCD = item.EXISTRCD;
                           th.ORDERDATE = item.ORDERDATE;
                           th.MAINBELT = item.MAINBELT;
                           th.PACKAGEMACHINE = item.PACKAGEMACHINE;
                           th.SORTNUM = item.SORTNUM;
                           th.SECSORTNUM = item.SECSORTNUM;
                           th.INSERTTIME = DateTime.Now;
                           en.T_UN_TASK_H.AddObject(th);

                       }
                       if (en.SaveChanges() > 0)
                       {
                           re.MessageText += "Task表移除至历史表成功！\r\n";
                           re.IsSuccess = true;
                       }
                       else
                       {
                           sb.AppendLine("Task表移除至历史表失败,数据库改变的行数为0！");

                       }

                   }
                   else
                   {
                       sb.AppendLine("未找到Task表数据！");
                   }
                   var t_un_poke = (from item in en.T_UN_POKE select item
                                  ).ToList();

                   if (t_un_poke.Any())
                   {

                       foreach (var item in t_un_poke)
                       {
                           T_UN_POKE_H tuh = new T_UN_POKE_H();
                           tuh.POKEID = item.POKEID;
                           tuh.TROUGHNUM = item.TROUGHNUM;
                           tuh.POKENUM = item.POKENUM;
                           tuh.STATUS = item.STATUS;
                           tuh.TASKNUM = item.TASKNUM;
                           tuh.TASKQTY = item.TASKQTY;
                           tuh.PACKAGEMACHINE = item.PACKAGEMACHINE;
                           tuh.MACHINESEQ = item.MACHINESEQ;
                           tuh.LINENUM = item.LINENUM;
                           tuh.CIGARETTECODE = item.CIGARETTECODE;
                           tuh.CUSTOMERCODE = item.CUSTOMERCODE;
                           tuh.SORTNUM = item.SORTNUM;
                           tuh.SECSORTNUM = item.SECSORTNUM;
                           tuh.BILLCODE = item.BILLCODE;
                           tuh.CTYPE = item.CTYPE;
                           tuh.SENDTASKNUM = item.SENDTASKNUM;
                           tuh.STORENUM = item.STORENUM;
                           tuh.GRIDNUM = item.GRIDNUM;
                           tuh.INVFLAG = item.INVFLAG;
                           tuh.ORDERDATE = OrderDataBySortnum(en, item.SORTNUM ?? 0);
                           tuh.SENDSEQ = item.SENDSEQ;
                       }
                       if (en.SaveChanges() > 0)
                       {
                           re.MessageText += "Poke表移除至历史表成功！";
                           re.IsSuccess = true;
                       }
                       else
                       {
                           sb.AppendLine("Poke表移除至历史表失败,数据库改变的行数为0！");

                       }
                   }
                   else
                   {
                       sb.AppendLine("未找到POKE表数据！");
                   }

                   if (sb.Length == 0)
                   {
                       return re;
                   }
                   else
                   {
                       re.MessageText = sb.ToString();
                       re.IsSuccess = false;
                       return re;
                   }

               }
           }
           catch (Exception ex)
           {
               re.IsSuccess = false;
               re.MessageText = ex.Message;
               return re;
           }
       }

       /// <summary>
       /// 获取订单日期
       /// </summary>
       /// <param name="en"></param>
       /// <param name="sortnum"></param>
       /// <returns></returns>
       public  DateTime? OrderDataBySortnum( DZEntities en ,decimal sortnum)
       {
           var task_order = (from item in en.T_UN_TASK where item.SORTNUM == sortnum select item
                              ).FirstOrDefault();
           if (task_order != null)
           {
               return task_order.ORDERDATE  ;
           }
           else
           {
               return DateTime.Now;
           }
       }

    }
}
