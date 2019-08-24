using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Modle;

namespace Business.BusinessClass
{
    public class MixedClass
    {
        public static bool InsertPokeMixed(List<MixedInfo> infos)
        {
            using (DZEntities en = new DZEntities())
            {
                T_UN_POKE_HUNHE tph = new T_UN_POKE_HUNHE();
                decimal id = 0;
                try
                {
                    id = en.T_UN_POKE_HUNHE.Max(item => item.ID);
                }
                catch
                {
                    id = 0;
                }

                foreach (var info in infos)
                {
                    id = id + 1;

                    if (info.PokeNum > 1)
                    {
                        for (int j = 0; j < info.PokeNum; j++)
                        {
                            tph = new T_UN_POKE_HUNHE()
                            {
                                CIGARETTECODE = info.CigaretteCode,
                                MACHINESEQ = info.MachineSeq,
                                PACKMACHINESEQ = info.PackageMachineSeq,
                                POKEID = info.PokeID,
                                PULLSTATUS = info.PullStatus,
                                SENDTASKNUM = info.SendTasNum,
                                SORTNUM = info.SortNum,
                                TASKNUM = info.TaskNum,
                                TROUGHNUM = Convert.ToDecimal(info.ThroughNum),
                                ID = id
                            };
                            en.T_UN_POKE_HUNHE.AddObject(tph);
                            id = id + 1;
                            en.SaveChanges();
                        }
                    }
                    else
                    {
                        tph = new T_UN_POKE_HUNHE()
                        {
                            CIGARETTECODE = info.CigaretteCode,
                            MACHINESEQ = info.MachineSeq,
                            PACKMACHINESEQ = info.PackageMachineSeq,
                            POKEID = info.PokeID,
                            PULLSTATUS = info.PullStatus,
                            SENDTASKNUM = info.SendTasNum,
                            SORTNUM = info.SortNum,
                            TASKNUM = info.TaskNum,
                            TROUGHNUM = Convert.ToDecimal(info.ThroughNum),
                            ID = id
                        };
                        en.T_UN_POKE_HUNHE.AddObject(tph);
                        en.SaveChanges();
                    }
                }
                return en.SaveChanges() > 0;

            }
        }

        public static List<MixedInfo> GetUnPokeData()
        {
            using (DZEntities en = new DZEntities())
            {
                List<MixedInfo> list = new List<MixedInfo>();
                list = (from a in en.T_UN_POKE
                        join b in en.T_PRODUCE_SORTTROUGH on a.TROUGHNUM equals b.TROUGHNUM
                        where b.CIGARETTETYPE == 40
                        select new MixedInfo
                        {
                            ThroughNum = a.TROUGHNUM,
                            TaskNum = a.TASKNUM ?? 0,
                            SortNum = a.SORTNUM ?? 0,
                            SendTasNum = a.SENDTASKNUM ?? 0,
                            PullStatus = 0,
                            PokeID = a.POKEID,
                            PackageMachineSeq = a.PACKAGEMACHINE ?? 0,
                            MachineSeq = a.MACHINESEQ ?? 0,
                            CigaretteCode = a.CIGARETTECODE,
                            PokeNum = a.POKENUM ?? 0
                        }).OrderBy(item => item.SortNum).ToList();

                //list = en.T_UN_POKE.Where(item => item.MACHINESEQ == machineSeq).Select(item => new MixedInfo
                //{
                //    ThroughNum = item.TROUGHNUM,
                //    TaskNum = item.TASKNUM ?? 0,
                //    SortNum = item.SORTNUM ?? 0,
                //    SendTasNum = item.SENDTASKNUM ?? 0,
                //    PullStatus = 0,
                //    PokeID = item.POKEID,
                //    PackageMachineSeq = item.PACKAGEMACHINE ?? 0,
                //    MachineSeq = item.MACHINESEQ ?? 0,
                //    CigaretteCode = item.CIGARETTECODE,
                //    PokeNum = item.POKENUM ?? 0
                //}).ToList();
                return list;
            }
        }

        public static string[] GetCigInfoByCode(string cigCode)
        {
            using (DZEntities en = new DZEntities())
            {
                CigarettInfo info = en.T_WMS_ITEM.Where(item => item.ITEMNO.Contains(cigCode) && item.ITEMNO.Length == 13).Select(item => new CigarettInfo { BigBoxCode = "0", CigCode = item.ITEMNO, CigName = item.ITEMNAME }).FirstOrDefault();
                string[] str = new string[2];
                str[0] = info.CigCode;
                str[1] = info.CigName;
                return str;
            }
        }

        public static List<MixInfo> GetMixCig(decimal machineSeq, decimal groupNo, decimal pullState)
        {
            using (DZEntities en = new DZEntities())
            {
                //en.T_UN_POKE_HUNHE.Where(item=>item.PULLSTATUS==0&&item.MACHINESEQ==machineSeq).Select(item=>new CigarettInfo{ BigBoxCode="0", CigCode=item.CIGARETTECODE})
                List<MixInfo> list = new List<MixInfo>();
                list = (from a in en.T_UN_POKE_HUNHE
                        join b in en.T_PRODUCE_SORTTROUGH on a.CIGARETTECODE equals b.CIGARETTECODE
                        where b.GROUPNO == groupNo && a.PULLSTATUS == pullState
                        select new MixInfo { PokeID = a.POKEID ?? 0, SortNum = a.SORTNUM ?? 0, CigCode = b.CIGARETTECODE, CigName = b.CIGARETTENAME, PokeNum = 1 }).GroupBy(item => new { item.SortNum, item.PokeID, item.CigCode, item.CigName })
                        .Select(item => new MixInfo { PokeID = item.Key.PokeID, SortNum = item.Key.SortNum, CigCode = item.Key.CigCode, CigName = item.Key.CigName, PokeNum = item.Sum(x => x.PokeNum) })
                            .OrderBy(item => new { item.SortNum, item.PokeID })
                            .Take(15).ToList();
                return list;
            }
        }

        public static List<MixInfo> GetMixCig3(decimal machineSeq, decimal groupNo, decimal pullState)
        {
            using (DZEntities en = new DZEntities())
            {
                //en.T_UN_POKE_HUNHE.Where(item=>item.PULLSTATUS==0&&item.MACHINESEQ==machineSeq).Select(item=>new CigarettInfo{ BigBoxCode="0", CigCode=item.CIGARETTECODE})
                List<MixInfo> list = new List<MixInfo>();
                list = (from a in en.T_UN_POKE_HUNHE
                        join b in en.T_PRODUCE_SORTTROUGH on a.CIGARETTECODE equals b.CIGARETTECODE
                        where b.GROUPNO == groupNo && a.PULLSTATUS == pullState
                        select new MixInfo { PokeID = a.POKEID ?? 0, SortNum = a.SORTNUM ?? 0, CigCode = b.CIGARETTECODE, CigName = b.CIGARETTENAME, PokeNum = 1 }).GroupBy(item => new { item.SortNum, item.CigCode, item.CigName })
                        .Select(item => new MixInfo { PokeID = 0, SortNum = item.Key.SortNum, CigCode = item.Key.CigCode, CigName = item.Key.CigName, PokeNum = item.Sum(x => x.PokeNum) })
                            .OrderByDescending(item => new { item.SortNum })
                            .ToList();
                return list;
            }
        }

        public static List<MixInfos> GetMixCig2(decimal machineSeq, decimal groupNo, decimal pullState)
        {
            using (DZEntities en = new DZEntities())
            {
                //en.T_UN_POKE_HUNHE.Where(item=>item.PULLSTATUS==0&&item.MACHINESEQ==machineSeq).Select(item=>new CigarettInfo{ BigBoxCode="0", CigCode=item.CIGARETTECODE})
                List<MixInfos> list = new List<MixInfos>();
                //list = (from a in en.T_UN_POKE_HUNHE
                //        join b in en.T_PRODUCE_SORTTROUGH on a.CIGARETTECODE equals b.CIGARETTECODE
                //        where b.GROUPNO == groupNo && a.PULLSTATUS == pullState
                //        select new MixInfos { PokeID = a.POKEID ?? 0, SortNum = a.SORTNUM ?? 0, CigCode = b.CIGARETTECODE, CigName = b.CIGARETTENAME, PokeNum = 1, ThroughNum=b.TROUGHNUM })
                //            .OrderBy(item=>item.ThroughNum).OrderBy(item => item.SortNum )
                //            .Take(15).ToList();

                string sqlStr = "select pokeid,sortnum,p.cigarettecode as cigcode,cigarettename as cigname,t.troughnum as throughnum,sortnum,1 as pokenum from t_un_poke_hunhe p, t_produce_sorttrough t  where t.cigarettecode=p.cigarettecode " +
                                " and p.machineseq =" + machineSeq + " and t.groupno=" + groupNo + " and pullstatus=" + pullState + " order by p.sortnum,t.troughnum";
                list = en.ExecuteStoreQuery<MixInfos>(sqlStr).Take(15).ToList();

                return list;
            }
        }

        public static List<MixInfos> GetMixCig4(decimal machineSeq, decimal groupNo, decimal pullState)
        {
            using (DZEntities en = new DZEntities())
            {
                //en.T_UN_POKE_HUNHE.Where(item=>item.PULLSTATUS==0&&item.MACHINESEQ==machineSeq).Select(item=>new CigarettInfo{ BigBoxCode="0", CigCode=item.CIGARETTECODE})
                List<MixInfos> list = new List<MixInfos>();
                //list = (from a in en.T_UN_POKE_HUNHE
                //        join b in en.T_PRODUCE_SORTTROUGH on a.CIGARETTECODE equals b.CIGARETTECODE
                //        where b.GROUPNO == groupNo && a.PULLSTATUS == pullState
                //        select new MixInfo { PokeID = a.POKEID ?? 0, SortNum = a.SORTNUM ?? 0, CigCode = b.CIGARETTECODE, CigName = b.CIGARETTENAME, PokeNum = 1 })
                //            .OrderByDescending(item=>item.PokeID).OrderByDescending(item =>item.SortNum  )
                //            .Take(15).ToList();

                string sqlStr = "select pokeid,sortnum,p.cigarettecode as cigcode,cigarettename as cigname,t.troughnum as throughnum,sortnum,1 as pokenum from t_un_poke_hunhe p, t_produce_sorttrough t  where t.cigarettecode=p.cigarettecode " +
                                "and t.machineseq=1 and pullstatus=1  order by p.sortnum desc,t.troughnum desc";
                list = en.ExecuteStoreQuery<MixInfos>(sqlStr).Take(15).ToList();
                return list;
            }
        }

        public static bool UpdatePullStatus2Put(decimal machineSeq, decimal sortnum, string cigarettecode)
        {
            using (DZEntities en = new DZEntities())
            {
                T_UN_POKE_HUNHE th = en.T_UN_POKE_HUNHE.Where(item => item.CIGARETTECODE == cigarettecode && item.SORTNUM == sortnum && item.MACHINESEQ == machineSeq && item.PULLSTATUS == 0).OrderBy(item => item.SORTNUM).FirstOrDefault();
                th.PULLSTATUS = 1;
                return en.SaveChanges() > 0;
            }
        }

        public static bool UpdatePullStatus2Put3(string cigarettecode, decimal machineSeq, decimal sortnum)
        {
            using (DZEntities en = new DZEntities())
            {
                List<T_UN_POKE_HUNHE> th = en.T_UN_POKE_HUNHE.Where(item => item.CIGARETTECODE == cigarettecode && item.SORTNUM == sortnum && item.MACHINESEQ == machineSeq && item.PULLSTATUS == 0).OrderBy(item => item.SORTNUM).ToList();
                for (int i = 0; i < th.Count; i++)
                {
                    th[i].PULLSTATUS = 1;
                }

                return en.SaveChanges() > 0;
            }
        }


        public static bool UpdatePullStatus2Put2(decimal machineSeq, decimal sortnum)
        {
            using (DZEntities en = new DZEntities())
            {
                T_UN_POKE_HUNHE th = en.T_UN_POKE_HUNHE.Where(item => item.POKEID == sortnum && item.MACHINESEQ == machineSeq && item.PULLSTATUS == 0).OrderBy(item => item.SORTNUM).FirstOrDefault();
                th.PULLSTATUS = 1;
                return en.SaveChanges() > 0;
            }
        }

        public static void GetSortFinish()
        {
            using (DZEntities en = new DZEntities())
            {
                T_UN_POKE_HUNHE hunhe = en.T_UN_POKE_HUNHE.Where(item => item.PULLSTATUS == 1).OrderBy(item => item.SORTNUM).FirstOrDefault();
                if (hunhe != null)
                {
                    decimal status = en.T_UN_POKE.Where(item => item.SORTNUM == hunhe.SORTNUM).Select(item => item.STATUS).FirstOrDefault() ?? 0;
                    if (status == 20)
                    {
                        hunhe.PULLSTATUS = 2;
                        en.SaveChanges();
                    }
                }
            }
        }

        public static void RemoveHunhe()
        {
            using (DZEntities en = new DZEntities())
            {
                List<T_UN_POKE_HUNHE> list = new List<T_UN_POKE_HUNHE>();
                list = en.T_UN_POKE_HUNHE.ToList();
                foreach (var item in list)
                {
                    en.T_UN_POKE_HUNHE.DeleteObject(item);
                }
                en.SaveChanges();
            }
        }
    }
}
