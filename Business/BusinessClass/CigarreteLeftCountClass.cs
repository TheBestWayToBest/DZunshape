using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Modle;

namespace Business.BusinessClass
{
    public class CigarreteLeftCountClass
    {
        public static List<CigarreteLeftCountInfo> GetLeftCount(decimal groupNo) 
        {
            using (DZEntities en = new DZEntities()) 
            {
                List<CigarreteLeftCountInfo> list = new List<CigarreteLeftCountInfo>();
                list = en.T_PRODUCE_SORTTROUGH.Where(item => item.CIGARETTETYPE == 30 && item.GROUPNO == groupNo && item.STATE == "10").Select(item => new CigarreteLeftCountInfo
                        {
                            CigaretteCode = item.CIGARETTECODE,
                            CigaretteName = item.CIGARETTENAME,
                            MachineSeq = item.MACHINESEQ ?? 0,
                            Mantissa = item.MANTISSA ?? 0,
                            Threshold = item.THRESHOLD ?? 0

                        }).OrderBy(item => item.MachineSeq).ToList();
                return list;
            }
        }

        public static bool UpdateLeftCount(CigarreteLeftCountInfo info,decimal groupNo)
        {
            using (DZEntities en = new DZEntities()) 
            {
                T_PRODUCE_SORTTROUGH infos = new T_PRODUCE_SORTTROUGH();
                infos = en.T_PRODUCE_SORTTROUGH.Where(item => item.CIGARETTETYPE == 30 && item.GROUPNO == groupNo && item.STATE == "10" && item.MACHINESEQ == info.MachineSeq).OrderBy(item => item.MACHINESEQ).FirstOrDefault();
                infos.MANTISSA = info.Mantissa;
                infos.THRESHOLD = info.Threshold;
                return en.SaveChanges() > 0;
            }
        }
    }
}
