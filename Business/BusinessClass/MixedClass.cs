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
                    i++;
                }
                return en.SaveChanges() > 0;

            }
        }

        public static List<MixedInfo> GetUnPokeData(decimal machineSeq)
        {
            using (DZEntities en = new DZEntities())
            {
                List<MixedInfo> list = new List<MixedInfo>();
                list = en.T_UN_POKE.Where(item => item.MACHINESEQ == machineSeq).Select(item => new MixedInfo
                {
                    ThroughNum = item.TROUGHNUM,
                    TaskNum = item.TASKNUM ?? 0,
                    SortNum = item.SORTNUM ?? 0,
                    SendTasNum = item.SENDTASKNUM ?? 0,
                    PullStatus = 0,
                    PokeID = item.POKEID,
                    PackageMachineSeq = item.PACKAGEMACHINE ?? 0,
                    MachineSeq = item.MACHINESEQ ?? 0,
                    CigaretteCode = item.CIGARETTECODE
                }).ToList();
                return list;
            }
        }
    }
}
