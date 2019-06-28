using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Modle;

namespace Business.BusinessClass
{
    public class HunheClass
    {
        public static List<string> GetHunheThrough()
        {
            using (DZEntities en = new DZEntities())
            {
                List<string> list = new List<string>();
                var query = en.T_PRODUCE_SORTTROUGH.Where(item => item.GROUPNO == 2 && item.CIGARETTETYPE == 40).GroupBy(item => item.MACHINESEQ).OrderBy(item => item.Key).Select(item => item.Key ?? 0).ToList();
                foreach (var item in query)
                {
                    list.Add(item.ToString());
                }
                return list;
            }
        }

        public static List<HunheInfo> GetHunheData(decimal status, decimal machinseq)
        {
            using (DZEntities en = new DZEntities())
            {
                List<decimal> t = new List<decimal>();
                t = en.T_PRODUCE_SORTTROUGH.Where(item => item.GROUPNO == 2 && item.CIGARETTETYPE == 40).GroupBy(item => item.MACHINESEQ).OrderBy(item => item.Key).Select(item => item.Key ?? 0).ToList();
                List<HunheInfo> list = new List<HunheInfo>();
                string sqlStr = "";
                if (machinseq == 0)
                {

                    if (t.Count == 3)
                    {
                        sqlStr = "select through.CIGARETTENAME,poke.POKENUM,task.CUSTOMERNAME,poke.MACHINESEQ,task.REGIONCODE,poke.SORTNUM " +
                            "from T_UN_TASK task,T_UN_POKE poke,T_PRODUCE_SORTTROUGH through where (through.MACHINESEQ=" + t[0] +
                            " or through where through.MACHINESEQ=" + t[1] + " or through where through.machineseq=poke.machineseq and poke.tasknum=task.tasknum and"+
                            " through.MACHINESEQ=" + t[2] + ") and poke.STATUS =" + status +
                            " order by poke.POKEID";
                        //list = (from task in en.T_UN_TASK
                        //        join poke in en.T_UN_POKE on task.TASKNUM equals poke.TASKNUM
                        //        join through in en.T_PRODUCE_SORTTROUGH on poke.MACHINESEQ equals through.MACHINESEQ
                        //        where (through.MACHINESEQ != t[0] || through.MACHINESEQ != t[1] || through.MACHINESEQ != t[2]) && poke.STATUS == status
                        //        select new HunheInfo { CigaretteName = through.CIGARETTENAME, CigaretteNum = poke.POKENUM ?? 0, CusName = task.CUSTOMERNAME, MachineSeq = poke.MACHINESEQ ?? 0, Regioncode = task.REGIONCODE, SortNum = poke.SORTNUM ?? 0 }).ToList();
                    }
                    else if (t.Count == 2)
                    {
                        sqlStr = "select through.CIGARETTENAME,poke.POKENUM,task.CUSTOMERNAME,poke.MACHINESEQ,task.REGIONCODE,poke.SORTNUM " +
                            "from T_UN_TASK task,T_UN_POKE poke,T_PRODUCE_SORTTROUGH through where through.machineseq=poke.machineseq and poke.tasknum=task.tasknum and"+
                            " (through.MACHINESEQ=" + t[0] +
                            " or through where through.MACHINESEQ=" + t[1] + ") and poke.STATUS =" + status +
                            " order by poke.POKEID";
                        //list = (from task in en.T_UN_TASK
                        //        join poke in en.T_UN_POKE on task.TASKNUM equals poke.TASKNUM
                        //        join through in en.T_PRODUCE_SORTTROUGH on poke.MACHINESEQ equals through.MACHINESEQ
                        //        where (through.MACHINESEQ != t[0] || through.MACHINESEQ != t[1]) && poke.STATUS == status
                        //        select new HunheInfo { CigaretteName = through.CIGARETTENAME, CigaretteNum = poke.POKENUM ?? 0, CusName = task.CUSTOMERNAME, MachineSeq = poke.MACHINESEQ ?? 0, Regioncode = task.REGIONCODE, SortNum = poke.SORTNUM ?? 0 }).ToList();
                    }
                    else if (t.Count == 1)
                    {
                        sqlStr = "select through.CIGARETTENAME,poke.POKENUM,task.CUSTOMERNAME,poke.MACHINESEQ,task.REGIONCODE,poke.SORTNUM " +
                            "from T_UN_TASK task,T_UN_POKE poke,T_PRODUCE_SORTTROUGH through where  through.machineseq=poke.machineseq and poke.tasknum=task.tasknum and"+
                            " (through.MACHINESEQ=" + t[0] +
                            ") and poke.STATUS =" + status +
                            " order by poke.POKEID";
                        //list = (from task in en.T_UN_TASK
                        //        join poke in en.T_UN_POKE on task.TASKNUM equals poke.TASKNUM
                        //        join through in en.T_PRODUCE_SORTTROUGH on poke.MACHINESEQ equals through.MACHINESEQ
                        //        where (through.MACHINESEQ != t[0]) && poke.STATUS == status
                        //        select new HunheInfo { CigaretteName = through.CIGARETTENAME, CigaretteNum = poke.POKENUM ?? 0, CusName = task.CUSTOMERNAME, MachineSeq = poke.MACHINESEQ ?? 0, Regioncode = task.REGIONCODE, SortNum = poke.SORTNUM ?? 0 }).ToList();
                    }
                }
                else
                {
                    sqlStr = "select through.CIGARETTENAME,poke.POKENUM,task.CUSTOMERNAME,poke.MACHINESEQ,task.REGIONCODE,poke.SORTNUM " +
                            "from T_UN_TASK task,T_UN_POKE poke,T_PRODUCE_SORTTROUGH through where  through.machineseq=poke.machineseq and poke.tasknum=task.tasknum and"+
                            " (through.MACHINESEQ=" + machinseq +
                            ") and poke.STATUS =" + status +
                            " order by poke.POKEID";
                    //list = (from task in en.T_UN_TASK
                    //        join poke in en.T_UN_POKE on task.TASKNUM equals poke.TASKNUM
                    //        join through in en.T_PRODUCE_SORTTROUGH on poke.MACHINESEQ equals through.MACHINESEQ
                    //        where through.MACHINESEQ == machinseq && poke.STATUS == status
                    //        select new HunheInfo { CigaretteName = through.CIGARETTENAME, CigaretteNum = poke.POKENUM ?? 0, CusName = task.CUSTOMERNAME, MachineSeq = poke.MACHINESEQ ?? 0, Regioncode = task.REGIONCODE, SortNum = poke.SORTNUM ?? 0 }).ToList();
                }

                list = en.ExecuteStoreQuery<HunheInfo>(sqlStr).ToList();
                return list;

            }
        }
    }
}
