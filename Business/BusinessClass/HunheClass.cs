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
                var query = en.T_PRODUCE_SORTTROUGH.Where(item => /*item.GROUPNO == 2 &&*/ item.CIGARETTETYPE == 40).GroupBy(item => item.MACHINESEQ).OrderBy(item => item.Key).Select(item => item.Key ?? 0).ToList();
                foreach (var item in query)
                {
                    list.Add(item.ToString());
                }
                return list;
            }
        }

        public static List<HunheInfo> GetHunheData(decimal machinseq)
        {
            using (DZEntities en = new DZEntities())
            {
                List<decimal> t = new List<decimal>();
                t = en.T_PRODUCE_SORTTROUGH.Where(item => /*item.GROUPNO == 2 &&*/ item.CIGARETTETYPE == 40).GroupBy(item => item.MACHINESEQ).OrderBy(item => item.Key).Select(item => item.Key ?? 0).ToList();
                List<HunheInfo> list = new List<HunheInfo>();
                string sqlStr = "";
                if (machinseq == 0)
                {
                    if (t.Count == 2)
                    {
                        //sqlStr = "SELECT * FROM T_PRODUCE_SORTTROUGH S,T_UN_POKE P WHERE S.TROUGHNUM=P.TROUGHNUM AND (S.MACHINESEQ=" + t[0] +
                        //         " or S.MACHINESEQ=" + t[1] + ") AND CIGARETTETYPE = 40 "+
                        //        " ORDER BY SORTNUM";
                        sqlStr = "SELECT P.MACHINESEQ,T.CUSTOMERNAME,S.CIGARETTENAME,P.POKENUM,P.SORTNUM,T.REGIONDESC FROM T_PRODUCE_SORTTROUGH S,T_UN_POKE P,T_UN_TASK T" +
                                  " WHERE S.TROUGHNUM=P.TROUGHNUM AND T.SORTNUM=P.SORTNUM" +
                                  "  and (S.MACHINESEQ=" + t[0] + " OR S.MACHINESEQ= " + t[1] + ") AND CIGARETTETYPE = 40 ORDER BY P.SORTNUM,P.TROUGHNUM";
                    }
                    else if (t.Count == 1)
                    {
                        //sqlStr = "SELECT * FROM T_PRODUCE_SORTTROUGH S,T_UN_POKE P WHERE S.TROUGHNUM=P.TROUGHNUM AND S.MACHINESEQ=" + t[0] +
                        //        " AND CIGARETTETYPE = 40 AND "+
                        //        " ORDER BY SORTNUM";
                        sqlStr = "SELECT P.MACHINESEQ,T.CUSTOMERNAME,S.CIGARETTENAME,P.POKENUM,P.SORTNUM,T.REGIONDESC FROM T_PRODUCE_SORTTROUGH S,T_UN_POKE P,T_UN_TASK T" +
                                  " WHERE S.TROUGHNUM=P.TROUGHNUM AND T.SORTNUM=P.SORTNUM" +
                                  "  and S.MACHINESEQ=" + t[0] + " AND CIGARETTETYPE = 40 ORDER BY P.SORTNUM,P.TROUGHNUM";
                    }

                }
                else
                {
                    if (machinseq == 1)
                    {
                        sqlStr = "SELECT P.MACHINESEQ,T.CUSTOMERNAME,S.CIGARETTENAME,P.POKENUM,P.SORTNUM,T.REGIONDESC FROM T_PRODUCE_SORTTROUGH S,T_UN_POKE P,T_UN_TASK T" +
                                  " WHERE S.TROUGHNUM=P.TROUGHNUM AND CTYPE=1 AND S.GROUPNO=1 AND T.SORTNUM=P.SORTNUM" +
                                  "  and S.MACHINESEQ=" + machinseq + "  AND CIGARETTETYPE = 40 ORDER BY P.SORTNUM,P.TROUGHNUM";
                    }
                    else
                    {
                        sqlStr = "SELECT P.MACHINESEQ,T.CUSTOMERNAME,S.CIGARETTENAME,P.POKENUM,P.SORTNUM,T.REGIONDESC FROM T_PRODUCE_SORTTROUGH S,T_UN_POKE P,T_UN_TASK T" +
                                  " WHERE S.TROUGHNUM=P.TROUGHNUM AND CTYPE=2 AND S.GROUPNO=2 AND T.SORTNUM=P.SORTNUM" +
                                  "  and S.MACHINESEQ=" + machinseq + "  AND CIGARETTETYPE = 40 ORDER BY P.SORTNUM,P.TROUGHNUM";
                    }
                }

                list = en.ExecuteStoreQuery<HunheInfo>(sqlStr).ToList();
                return list;

            }
        }

        public static List<HunheNowViewInfo> GetSearchCigarette(string cname, int type)
        {
            using (DZEntities entity = new DZEntities())
            {
                try
                {
                    if (type == 1)
                    {
                        var query = (from item in entity.T_UN_POKE
                                     join item2 in entity.T_PRODUCE_SORTTROUGH
                                     on item.TROUGHNUM equals item2.TROUGHNUM
                                     join item3 in entity.T_UN_TASK on item.TASKNUM equals item3.TASKNUM
                                     where item2.CIGARETTETYPE == 40 && (item2.CIGARETTENAME.Contains(cname))
                                     orderby item.SORTNUM, item2.MACHINESEQ, item2.TROUGHNUM, item.POKEID
                                     select new HunheNowViewInfo() { TaskSort = item3.SORTSEQ ?? 0, TaskNum = item.TASKNUM ?? 0, CigaretteCode = item.CIGARETTECODE, SortNum = item.SORTNUM ?? 0, CustomerName = item3.CUSTOMERNAME, RegionCode = item3.REGIONCODE, ThroughNum = item.MACHINESEQ ?? 0, CigaretteName = item2.CIGARETTENAME, PokeNum = item.POKENUM ?? 0, Status = item.STATUS ?? 0, PokeId = item.POKEID }).ToList();
                        return query;
                    }
                    else
                    {
                        var query = (from item in entity.T_UN_POKE
                                     join item2 in entity.T_PRODUCE_SORTTROUGH
                                     on item.TROUGHNUM equals item2.TROUGHNUM
                                     join item3 in entity.T_UN_TASK on item.TASKNUM equals item3.TASKNUM
                                     where item2.CIGARETTETYPE == 40 && (item3.CUSTOMERNAME.Contains(cname))
                                     orderby item.SORTNUM, item2.MACHINESEQ, item2.TROUGHNUM
                                     select new HunheNowViewInfo() { TaskSort = item3.SORTSEQ ?? 0, TaskNum = item.TASKNUM ?? 0, CigaretteCode = item.CIGARETTECODE, SortNum = item.SORTNUM ?? 0, CustomerName = item3.CUSTOMERNAME, RegionCode = item3.REGIONCODE, ThroughNum = item.MACHINESEQ ?? 0, CigaretteName = item2.CIGARETTENAME, PokeNum = item.POKENUM ?? 0, Status = item.STATUS ?? 0, PokeId = item.POKEID }).ToList();
                        return query;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <param name="seq">通道号</param>
        /// <returns></returns>
        public static List<HunheNowViewInfos> GetALLCigarette(decimal seq, decimal groupNo)
        {
            using (DZEntities entity = new DZEntities())
            {
                try
                {

                    var query = (from item in entity.T_UN_POKE
                                 join item2 in entity.T_PRODUCE_SORTTROUGH
                                 on item.TROUGHNUM equals item2.TROUGHNUM
                                 join item3 in entity.T_UN_TASK on item.TASKNUM equals item3.TASKNUM
                                 join item4 in entity.T_UN_POKE_HUNHE on item.POKEID equals item4.POKEID
                                 where item2.CIGARETTETYPE == 40 && item.MACHINESEQ == seq && item2.GROUPNO == groupNo
                                 orderby item.SORTNUM, item2.MACHINESEQ, item2.TROUGHNUM, item.POKEID
                                 select new HunheNowViewInfos() { PULLSTATUS = item4.PULLSTATUS, tasknum = item.TASKNUM, sortnum = item.SORTNUM, customername = item3.CUSTOMERNAME, regioncode = item3.REGIONCODE, TROUGHNUM = item.MACHINESEQ, CIGARETTECODE = item2.CIGARETTECODE, CIGARETTENAME = item2.CIGARETTENAME, pokenum = item.POKENUM, status = item.STATUS, pokeid = item.POKEID, sendtasknum = item.SENDTASKNUM }).ToList();
                    return query;



                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

    }
}
