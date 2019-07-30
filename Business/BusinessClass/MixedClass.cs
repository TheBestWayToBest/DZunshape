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
                int i = 0;
                foreach (var info in infos)
                {
                    if (i == 100)
                    {
                        en.SaveChanges();
                    }
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
                                TROUGHNUM = Convert.ToDecimal(info.ThroughNum)
                            };
                            en.T_UN_POKE_HUNHE.AddObject(tph);
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
                            TROUGHNUM = Convert.ToDecimal(info.ThroughNum)
                        };
                        en.T_UN_POKE_HUNHE.AddObject(tph);
                    }
                    i++;
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
                            }).ToList();

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
                        select new MixInfo { PokeID = a.POKEID, SortNum = a.SORTNUM ?? 0, CigCode = b.CIGARETTECODE, CigName = b.CIGARETTENAME }).OrderBy(item => new { item.PokeID, item.SortNum }).ToList();
                return list;
            }
        }

        public static bool UpdatePullStatus2Put(decimal machineSeq, decimal pokeID)
        {
            using (DZEntities en = new DZEntities())
            {
                T_UN_POKE_HUNHE th = en.T_UN_POKE_HUNHE.Where(item => item.POKEID == pokeID && item.MACHINESEQ == machineSeq && item.PULLSTATUS == 0).OrderBy(item => item.SORTNUM).FirstOrDefault();
                th.PULLSTATUS = 1;
                return en.SaveChanges() > 0;
            }
        }

    }
}
