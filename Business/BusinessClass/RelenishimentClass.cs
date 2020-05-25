using System;
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
                string sqlStr = "select * from T_PRODUCE_REPLENISHPLAN where iscompleted != 20 and cigarettecode in(" +
                                "select cigarettecode from t_produce_sorttrough where groupno=3) and troughnum<=6 order by id";
                list = en.ExecuteStoreQuery<T_PRODUCE_REPLENISHPLAN>(sqlStr).ToList();
                return list;
            }
        }

        public static object[] GetSendTask(decimal isCompleted, out StringBuilder outStr)
        {
            using (DZEntities en = new DZEntities())
            {
                object[] data = new object[6];
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = 0;
                }
                List<T_PRODUCE_REPLENISHPLAN> list = new List<T_PRODUCE_REPLENISHPLAN>();
                string sqlStr = "select * from T_PRODUCE_REPLENISHPLAN where iscompleted = 10 and cigarettecode in(" +
                                "select cigarettecode from t_produce_sorttrough where groupno=3) and troughnum<=6 order by id";
                list = en.ExecuteStoreQuery<T_PRODUCE_REPLENISHPLAN>(sqlStr).ToList();
                data[0] = list[0].TASKNUM;
                data[1] = Convert.ToDecimal(list[0].TROUGHNUM);
                data[2] = list[0].JYCODE;
                data[3] = 0;
                data[4] = 0;
                data[5] = 1;
                sb.AppendLine("任务号：" + data[0] + "，" + data[1] + "号通道补烟，任务发送标志位：" + data[5]);
                outStr = sb;
                return data;
            }
        }

        public static object[] GetSendTasks(decimal isCompleted, out StringBuilder outStr)
        {
            using (DZEntities en = new DZEntities())
            {
                object[] data = new object[7];
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = 0;
                }
                UnnormalInfo info = new UnnormalInfo();
                string sqlStr = "select sortnum,sum(pokenum) as num from t_un_poke where ctype=1 and status = 10 group by sortnum order by sortnum";
                info = en.ExecuteStoreQuery<UnnormalInfo>(sqlStr).FirstOrDefault();
                if (info != null)
                {
                    data[0] = info.SortNum;
                    data[1] = info.SortNum;
                    data[2] = info.Num;
                    data[3] = info.Num;
                    data[4] = 0;
                    data[5] = 0;
                    data[6] = 1;
                    sb.AppendLine(data[0] + "，数量：" + data[2]+"，任务发送标志位：" + data[6] );
                }
                //int count = en.T_UN_POKE_HUNHE.Where(item => item.SORTNUM == info.SortNum).Count();
                else
                {
                    sb.AppendLine("特异型烟道暂无任务");
                }
                outStr = sb;
                return data;
            }
        }

        public static decimal GetMinSortNum()
        {
            using (DZEntities en = new DZEntities())
            {
                string sqlStr = "select min(sortnum) as num from t_un_poke where ctype=1 and status = 15 group by sortnum order by sortnum";
                return en.ExecuteStoreQuery<decimal>(sqlStr).FirstOrDefault();
            }
        }

        public static bool UpdateReplanTask(string tasknum, decimal isCompleted)
        {
            using (DZEntities en = new DZEntities())
            {
                var query = en.T_PRODUCE_REPLENISHPLAN.Where(item => item.TASKNUM == tasknum).ToList();
                for (int i = 0; i < query.Count; i++)
                {
                    query[i].ISCOMPLETED = isCompleted;
                }

                return en.SaveChanges() > 0;
            }
        }

        public static bool UpdateMixTask(decimal sortNum, decimal status)
        {
            using (DZEntities en = new DZEntities())
            {
                var query = en.T_UN_POKE.Where(item => item.SORTNUM == sortNum && item.TROUGHNUM.Substring(0, 1) == "1").FirstOrDefault();
                query.STATUS = status;
                return en.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 获取已发送未完成的件烟信息
        /// </summary>
        /// <param name="taskNum"></param>
        /// <returns></returns>
        public static List<T_PRODUCE_REPLENISHPLAN> GetFinishedReplenishplan()
        {
            using (DZEntities en = new DZEntities())
            {
                List<T_PRODUCE_REPLENISHPLAN> list = new List<T_PRODUCE_REPLENISHPLAN>();
                string sqlStr = "select * from T_PRODUCE_REPLENISHPLAN where cigarettecode in (select distinct cigarettecode from T_PRODUCE_SORTTROUGH where groupno = 3 ) and troughnum<=6 and ISCOMPLETED = 20 order by id desc";

                list = en.ExecuteStoreQuery<T_PRODUCE_REPLENISHPLAN>(sqlStr).Take(10).ToList();
                //list = en.T_PRODUCE_REPLENISHPLAN.Where(item => (item.TROUGHNUM == "1" || item.TROUGHNUM == "2" || item.TROUGHNUM == "3" || item.TROUGHNUM == "4" || item.TROUGHNUM == "5" || item.TROUGHNUM == "6") && item.ISCOMPLETED == 15 && item.STATUS == 1).ToList();
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
                //var taskFirst = data.FirstOrDefault();
                //if (taskFirst != null)
                //{
                //    var pokestate = en.T_PRODUCE_REPLENISHPLAN.Where(item => item.TASKNUM == taskFirst.TASKNUM && (item.STATUS == 15 || item.STATUS == 10)).ToList();
                //    if (pokestate.Count == 0)
                //    {
                //        var tasks = en.T_UN_TASK.Where(item => item.TASKNUM == Convert.ToDecimal(taskFirst.TASKNUM)).ToList();
                //        foreach (var item in tasks)
                //        {
                //            if (item.STATE == "15")
                //            {
                //                item.STATE = "30";
                //                item.FINISHTIME = DateTime.Now;
                //            }
                //        }
                //    }
                //}
                int rows = en.SaveChanges();
                if (rows > 0)
                    return true;
                return false;
            }
        }

        public static bool UpdateReplanStatus(string taskNum)
        {
            using (DZEntities en = new DZEntities())
            {
                T_PRODUCE_REPLENISHPLAN replan = en.T_PRODUCE_REPLENISHPLAN.Where(item => item.TASKNUM == taskNum).FirstOrDefault();
                replan.STATUS = 1;
                return en.SaveChanges() > 0;
            }
        }

        public static List<ReplenishInfo> GetReplenish(decimal condition)
        {
            using (DZEntities en = new DZEntities())
            {
                string sqlStr="";
                //Func<T_PRODUCE_REPLENISHPLAN, bool> fun;
                if (condition == 0)
                    sqlStr = "select r.TROUGHNUM as ThroughNum,r.CIGARETTENAME,JYCODE,REPLENISHQTY,TASKNUM,r.CIGARETTECODE from t_produce_replenishplan r,t_produce_sorttrough s " +
                                " where s.machineseq=r.troughnum and s.cigarettecode=r.cigarettecode " +
                                " and s.groupno=3 order by r.id";
                else
                    sqlStr = "select r.TROUGHNUM as ThroughNum,r.CIGARETTENAME,JYCODE,REPLENISHQTY,TASKNUM,r.CIGARETTECODE from t_produce_replenishplan r,t_produce_sorttrough s " +
                                " where s.machineseq=r.troughnum and s.cigarettecode=r.cigarettecode " +
                                " and s.groupno=3 and iscompleted=" + condition + "  order by r.id";

                List<ReplenishInfo> list = new List<ReplenishInfo>();
                list = en.ExecuteStoreQuery<ReplenishInfo>(sqlStr).ToList();
          
                //var query = en.T_PRODUCE_REPLENISHPLAN.Where(fun).Select(item => new
                //{

                //    ThroughNum = item.TROUGHNUM,
                //    CigaretteName = item.CIGARETTENAME,
                //    JYCode = item.JYCODE,
                //    ReplenishQTY = item.REPLENISHQTY ?? 0,
                //    TaskNum = item.TASKNUM,
                //    cigarettecode = item.CIGARETTECODE
                //}).OrderBy(item => Convert.ToDecimal(item.TaskNum)).ToList();
                //list = query.Join(en.T_PRODUCE_SORTTROUGH, plan => new { plan.ThroughNum, plan.cigarettecode }, through => new { through.TROUGHNUM, through.CIGARETTECODE }, (plan, through) =>
                //    new
                //    {
                //        throughNum = plan.ThroughNum,
                //        CigaretteName = plan.CigaretteName,
                //        JYCode = plan.JYCode,
                //        ReplenishQTY = plan.ReplenishQTY,
                //        TaskNum = plan.TaskNum,
                //        groupNo = through.GROUPNO
                //    }).Where(item => item.groupNo == 3).Select(item => new ReplenishInfo
                //    {
                //        ThroughNum = item.throughNum,
                //        CigaretteName = item.CigaretteName,
                //        JYCode = item.JYCode,
                //        ReplenishQTY = item.ReplenishQTY,
                //        TaskNum = item.TaskNum
                //    }).OrderBy(item => Convert.ToDecimal(item.TaskNum)).ToList();




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
