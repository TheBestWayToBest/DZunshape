using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Modle;


namespace Business.BusinessClass
{
    public class UnPokeClass
    {
        /// <summary>
        /// 异形烟烟柜烟仓特异形烟数据
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="outlist">接收完成任务集合</param>
        /// <param name="outStr">任务日志字符串</param>
        /// <returns></returns>
        public static object[] GetOneDateBaseTask(decimal status, string linenum, out StringBuilder outStr) 
        {
            object[] values = new object[102];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = 0;
            }
            StringBuilder sb = new StringBuilder();
            using (DZEntities en = new DZEntities())
            {
                List<T_UN_POKE> list = new List<T_UN_POKE>();
                var query = en.T_UN_POKE.Where(item => item.LINENUM == linenum && item.STATUS == status).OrderBy(item => item.SORTNUM).OrderBy(item => item.SENDTASKNUM).FirstOrDefault();
                if (query == null)
                {
                    outStr = null;
                    return values;
                }
                list = en.T_UN_POKE.Where(item => item.SENDTASKNUM == query.SENDTASKNUM && item.STATUS == status).OrderBy(item => item.SORTNUM).ToList();

                //混合道+++

                values[0] = query.SORTNUM;
                values[1] = query.SENDTASKNUM;
                decimal machineseq = 0;
                foreach (var item in list.GroupBy(item => item.MACHINESEQ).Select(item => new { MACHINESEQ=item.Key,QTY=item.Sum(x=>x.POKENUM) }).ToList())
                {
                    machineseq = (item.MACHINESEQ ?? 0) - 1000;
                    values[(int)machineseq+1]=item.QTY;
                    sb.AppendLine(linenum + "线 " + machineseq + " 号烟仓，出烟数量：" + item.QTY);
                }
                values[98] = list.Sum(item => item.POKENUM);
                values[99] = 0;
                values[100] = 0;
                values[101] = 1;
                sb.AppendLine("烟仓出烟数量：" + values[98] + "，任务发送标志位：" + values[101]);
                outStr = sb;
                return values;
            }
        }
        public static int UpdateTask(decimal packageNo, int status)
        {
            using (DZEntities data = new DZEntities())
            {
                long sendSeq = DateTime.Now.Ticks;
                List<T_UN_POKE> list = new List<T_UN_POKE>();
                list = data.T_UN_POKE.Where(item => item.SORTNUM == packageNo).ToList();
                if (list.Count > 0) 
                {
                    foreach (var item in list)
                    {
                        item.STATUS = status;
                        item.SENDSEQ = sendSeq;
                    }
                }
                int row = data.SaveChanges();
                return row;
            }
        }

        public static void UpdateunTask(decimal sortnum, int status) 
        {
            using (DZEntities en = new DZEntities())
            {
                var poke = en.T_UN_POKE.Where(item => item.SORTNUM == sortnum).ToList();
                foreach (var item in poke)
                {
                    if (item.STATUS == 15)
                    {
                        item.STATUS = status;
                    }
                }
                
                var taskFirst = poke.FirstOrDefault();
                if (taskFirst != null)
                {
                    var pokestate = en.T_UN_POKE.Where(item => item.TASKNUM == taskFirst.TASKNUM && (item.STATUS == 15 || item.STATUS == 10)).ToList();
                    if (pokestate.Count == 0)
                    {
                        var task = en.T_UN_TASK.Where(item => item.TASKNUM == taskFirst.TASKNUM).ToList();
                        foreach (var item in task)
                        {
                            if (item.STATE == "15")
                            {
                                item.STATE = "30";
                                item.FINISHTIME = DateTime.Now;
                            }
                        }
                    }
                }
                en.SaveChanges();
            }
        }

        public static Response GetDataAll(int pageNum,int sortNum=0,string regionCode="0",string cusCode="0")
        {
            Response re = new Response();
            using (DZEntities en = new DZEntities())
            {
                var data = en.T_UN_TASK.Join(en.T_UN_POKE, task => task.TASKNUM, poke => poke.TASKNUM,
                    (task, poke) => new
                    {
                        SortSeq = task.SORTSEQ,
                        SortNum = poke.SORTNUM,
                        RegionCode = task.REGIONCODE,
                        CusName = task.CUSTOMERNAME,
                        CigCode = poke.CIGARETTECODE,
                        Status = poke.STATUS,
                        ThroughNum = poke.TROUGHNUM,
                        BillCode = task.BILLCODE
                    }).Join(en.T_PRODUCE_SORTTROUGH, task => task.ThroughNum, through => through.TROUGHNUM,
                    (task, through) => new
                    {
                        SortSeq = task.SortSeq,
                        SortNum = task.SortNum,
                        RegionCode = task.RegionCode,
                        CusName = task.CusName,
                        CigCode = task.CigCode,
                        Status = task.Status,
                        ThroughNum = task.ThroughNum,
                        BillCode = task.BillCode,
                        CigName = through.CIGARETTENAME
                    }).Skip(pageNum * 50).Take(50).ToList();
                re.ResultObject = data;
                return re;
            }
        }
    }
}
