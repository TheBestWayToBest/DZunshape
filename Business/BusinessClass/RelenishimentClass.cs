using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.BusinessClass
{
    public class RelenishimentClass
    {
        public static List<T_PRODUCE_REPLENISHPLAN> GetReplenishplan() 
        {
            using (DZEntities en = new DZEntities()) 
            {
                List<T_PRODUCE_REPLENISHPLAN> list=new List<T_PRODUCE_REPLENISHPLAN> ();
                list = en.T_PRODUCE_REPLENISHPLAN.Where(item => item.ISCOMPLETED == 10).ToList();
                return list;
            }
        }

        /// <summary>
        /// 获取已发送未完成的件烟信息
        /// </summary>
        /// <param name="taskNum">扫码头所给的任务号</param>
        /// <returns></returns>
        public static List<T_PRODUCE_REPLENISHPLAN> GetFinishedReplenishplan(string taskNum) 
        {
            using (DZEntities en = new DZEntities()) 
            {
                List<T_PRODUCE_REPLENISHPLAN> list = new List<T_PRODUCE_REPLENISHPLAN>();
                list = en.T_PRODUCE_REPLENISHPLAN.Where(item => item.ISCOMPLETED == 15 && Convert.ToDecimal(item.TASKNUM) <= Convert.ToDecimal(taskNum)).ToList();
                return list;
            }
        }

        public static bool IsCompleted(string taskNum) 
        {
            using (DZEntities en = new DZEntities()) 
            {
                var data = en.T_PRODUCE_REPLENISHPLAN.Where(item => item.TASKNUM == taskNum).FirstOrDefault();
                data.ISCOMPLETED = 15;
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
                var data = en.T_PRODUCE_REPLENISHPLAN.Where(item => item.TASKNUM == taskNum).FirstOrDefault();
                data.ISCOMPLETED = 20;
                data.FINISHTIME = DateTime.Now;
                int rows = en.SaveChanges();
                if (rows > 0)
                    return true;
                return false;
            }
        }
    }
}
