﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Modle;

namespace Business.BusinessClass
{
    public class RelenishimentClass
    {
        public static List<T_PRODUCE_REPLENISHPLAN> GetReplenishplan()
        {
            using (DZEntities en = new DZEntities())
            {
                List<T_PRODUCE_REPLENISHPLAN> list = new List<T_PRODUCE_REPLENISHPLAN>();
                list = en.T_PRODUCE_REPLENISHPLAN.Where(item => item.ISCOMPLETED == 10).ToList();
                return list;
            }
        }

        public static object[] GetSendTask(decimal status, out StringBuilder outStr)
        {
            using (DZEntities en = new DZEntities())
            {
                object[] data = new object[6];
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = 0;
                }
                var query = en.T_PRODUCE_REPLENISHPLAN.Where(item => item.STATUS == status).Select(item => new { tasknum = item.TASKNUM, throughnum = item.TROUGHNUM, jmcode = item.JYCODE }).FirstOrDefault();
                data[0] = query.tasknum;
                data[1] = query.throughnum;
                data[2] = query.jmcode;
                data[3] = 0;
                data[4] = 0;
                data[5] = 1;
                sb.AppendLine(data[1] + "号通道补烟，任务发送标志位：" + data[5]);
                outStr = sb;
                return data;
            }
        }

        /// <summary>
        /// 获取已发送未完成的件烟信息
        /// </summary>
        /// <param name="taskNum"></param>
        /// <returns></returns>
        public static List<T_PRODUCE_REPLENISHPLAN> GetFinishedReplenishplan(string tasknum)
        {
            using (DZEntities en = new DZEntities())
            {
                List<T_PRODUCE_REPLENISHPLAN> list = new List<T_PRODUCE_REPLENISHPLAN>();
                list = en.T_PRODUCE_REPLENISHPLAN.Where(item => Convert.ToDecimal(item.TASKNUM) <= Convert.ToDecimal(tasknum) && item.ISCOMPLETED == 15).ToList();
                return list;
            }
        }

        public static bool IsCompleted(string taskNum)
        {
            using (DZEntities en = new DZEntities())
            {
                var data = en.T_PRODUCE_REPLENISHPLAN.Where(item => item.TASKNUM == taskNum).ToList();
                foreach (var item in data)
                {
                    item.ISCOMPLETED = 15;
                }

                int rows = en.SaveChanges();
                if (rows > 0)
                    return true;
                return false;
            }
        }
        public static bool Completed(string taskNum)
        {
            using (DZEntities en = new DZEntities())
            {
                var data = en.T_PRODUCE_REPLENISHPLAN.Where(item => item.TASKNUM == taskNum).ToList();
                foreach (var item in data)
                {
                    item.ISCOMPLETED = 20;
                    item.FINISHTIME = DateTime.Now;
                }

                //var task = en.T_UN_TASK.Where(item => item.TASKNUM == Convert.ToDecimal(taskNum)).FirstOrDefault();
                var taskFirst = data.FirstOrDefault();
                if (taskFirst != null)
                {
                    var pokestate = en.T_PRODUCE_REPLENISHPLAN.Where(item => item.TASKNUM == taskFirst.TASKNUM && (item.STATUS == 15 || item.STATUS == 10)).ToList();
                    if (pokestate.Count == 0)
                    {
                        var tasks = en.T_UN_TASK.Where(item => item.TASKNUM == Convert.ToDecimal(taskFirst.TASKNUM)).ToList();
                        foreach (var item in tasks)
                        {
                            if (item.STATE == "15")
                            {
                                item.STATE = "30";
                                item.FINISHTIME = DateTime.Now;
                            }
                        }
                    }
                }
                int rows = en.SaveChanges();
                if (rows > 0)
                    return true;
                return false;
            }
        }

        public static List<ReplenishInfo> GetReplenish(decimal condition)
        {
            using (DZEntities en = new DZEntities())
            {
                Func<T_PRODUCE_REPLENISHPLAN, bool> fun;
                if (condition == 0)
                    fun = item => true;
                else
                    fun = item => item.STATUS == condition;

                List<ReplenishInfo> list = new List<ReplenishInfo>();
                list = en.T_PRODUCE_REPLENISHPLAN.Where(fun).Select(item => new ReplenishInfo
                {
                    ThroughNum = item.TROUGHNUM,
                    CigaretteName = item.CIGARETTENAME,
                    JYCode = item.JYCODE,
                    ReplenishQTY = item.REPLENISHQTY ?? 0,
                    TaskNum = item.TASKNUM
                }).OrderBy(item => item.TaskNum).ToList();
                return list;
            }
        }

        public static List<Replenish> GetReplenishByCusNameOrCigName(int index, string condition)
        {
            using (DZEntities en = new DZEntities())
            {
                List<Replenish> list = new List<Replenish>();
                string sqlStr = "";
                if (condition == "")
                {
                    sqlStr = "select tt.TASKNUM,tr.CIGARETTECODE,tr.CIGARETTENAME,tt.CUSTOMERNAME,tr.JYCODE,tr.REPLENISHQTY,tt.REGIONCODE,tr.STATUS,tr.TROUGHNUM " +
                             "from T_PRODUCE_REPLENISHPLAN tr,T_UN_TASK tt where tt.TASKNUM=tr.TASKNUM order by TASKNUM,TROUGHNUM";
                }
                else
                {
                    if (index == 0)
                    {
                        sqlStr = "select tt.TASKNUM,tr.CIGARETTECODE,tr.CIGARETTENAME,tt.CUSTOMERNAME,tr.JYCODE,tr.REPLENISHQTY,tt.REGIONCODE,tr.STATUS,tr.TROUGHNUM " +
                             "from T_PRODUCE_REPLENISHPLAN tr,T_UN_TASK tt where tt.TASKNUM=tr.TASKNUM and tr.CIGARETTENAME like '%" + condition + "%' order by TASKNUM,TROUGHNUM";
                    }
                    else
                    {
                        sqlStr = "select tt.TASKNUM,tr.CIGARETTECODE,tr.CIGARETTENAME,tt.CUSTOMERNAME,tr.JYCODE,tr.REPLENISHQTY,tt.REGIONCODE,tr.STATUS,tr.TROUGHNUM " +
                             "from T_PRODUCE_REPLENISHPLAN tr,T_UN_TASK tt where tt.TASKNUM=tr.TASKNUM  and tt.CUSTOMERNAME like '%" + condition + "%'order by TASKNUM,TROUGHNUM";
                    }
                }
                list = en.ExecuteStoreQuery<Replenish>(sqlStr).ToList();
                return list;
            }
        }

        public static List<Replenish> GetReplenishByCigName(int index, string condition)
        {
            using (DZEntities en = new DZEntities())
            {
                List<Replenish> list = new List<Replenish>();
                string sqlStr = "";
                if (condition == "")
                {
                    sqlStr = "select tr.TASKNUM,tr.CIGARETTECODE,tr.CIGARETTENAME,tr.JYCODE,tr.REPLENISHQTY,tr.STATUS,tr.TROUGHNUM " +
                             "from T_PRODUCE_REPLENISHPLAN tr order by TASKNUM,TROUGHNUM";
                }
                else
                {
                    if (index == 0)
                    {
                        sqlStr = "select tr.TASKNUM,tr.CIGARETTECODE,tr.CIGARETTENAME,tr.JYCODE,tr.REPLENISHQTY,tr.STATUS,tr.TROUGHNUM " +
                             "from T_PRODUCE_REPLENISHPLAN tr where  tr.CIGARETTENAME like '" + condition + "%' order by TASKNUM,TROUGHNUM";
                    }
                    else
                    {
                        sqlStr = "select tr.TASKNUM,tr.CIGARETTECODE,tr.CIGARETTENAME,tr.JYCODE,tr.REPLENISHQTY,tr.STATUS,tr.TROUGHNUM " +
                             "from T_PRODUCE_REPLENISHPLAN tr where  tr.JYCODE like '" + condition + "%' order by TASKNUM,TROUGHNUM";
                    }
                }
                list = en.ExecuteStoreQuery<Replenish>(sqlStr).ToList();
                return list;
            }
        }
    }
}
