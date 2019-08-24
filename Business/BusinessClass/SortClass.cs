using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Modle;

namespace Business.BusinessClass
{
    public class SortClass
    {
        public static List<SortInfo> GetSortInfo()
        {
            using (DZEntities en = new DZEntities())
            {
                List<SortInfo> list = new List<SortInfo>();
                string sqlStr = "select a.ctype,a.machineseq,a.cigarettecode,CigaretteName,decode(SortedNum,null,0,SortedNum) as SortedNum,decode(SortedNum,null,TotalNum,(TotalNum-SortedNum)) as UnSortNum,TotalNum from " +
                                " (select ctype,machineseq,cigarettecode,i.itemname as CigaretteName,sum(pokenum) as TotalNum from t_un_poke p,t_wms_item i where p.cigarettecode=i.itemno " +
                                " group by ctype,machineseq,cigarettecode,i.itemname order by ctype,machineseq) a left join " +
                                " (select ctype,machineseq,cigarettecode,sum(pokenum) as SortedNum from t_un_poke where status=20 group by ctype,machineseq,cigarettecode " +
                                " order by ctype,machineseq) b on a.ctype=b.ctype and a.machineseq=b.machineseq and a.cigarettecode=b.cigarettecode";
                list = en.ExecuteStoreQuery<SortInfo>(sqlStr).ToList();
                return list;
            }
        }

        public static List<SortReplaceInfo> GetSortThroughInfo(decimal ctype, decimal machineseq)
        {
            using (DZEntities en = new DZEntities())
            {
                List<SortReplaceInfo> list = new List<SortReplaceInfo>();
                if (machineseq == 0)
                {
                    list = en.T_UN_POKE.Join(en.T_PRODUCE_SORTTROUGH, poke => poke.TROUGHNUM, through => through.TROUGHNUM, (poke, through) => new
                          {
                              MACHINESEQ = poke.MACHINESEQ ?? 0,
                              CTYPE = poke.CTYPE ?? 0,
                              CIGARETTENAME = through.CIGARETTENAME,
                              CIGARETTECODE = poke.CIGARETTECODE,
                              TROUGHNUM = through.TROUGHNUM
                          }).Where(item => true && item.CTYPE == ctype)
                          .Select(item => new SortReplaceInfo { MachineSeq = item.MACHINESEQ, ThroughNum = item.TROUGHNUM, CigaretteCode = item.CIGARETTECODE, CigaretteName = item.CIGARETTENAME }).Distinct().OrderBy(item=>item.MachineSeq).ToList();
                }
                else
                {
                    list = en.T_UN_POKE.Join(en.T_PRODUCE_SORTTROUGH, poke => poke.TROUGHNUM, through => through.TROUGHNUM, (poke, through) => new
                            {
                                MACHINESEQ = poke.MACHINESEQ ?? 0,
                                CTYPE = poke.CTYPE ?? 0,
                                CIGARETTENAME = through.CIGARETTENAME,
                                CIGARETTECODE = poke.CIGARETTECODE,
                                TROUGHNUM = through.TROUGHNUM
                            }).Where(item => item.MACHINESEQ == machineseq && item.CTYPE == ctype)
                            .Select(item => new SortReplaceInfo { MachineSeq = item.MACHINESEQ, ThroughNum = item.TROUGHNUM, CigaretteCode = item.CIGARETTECODE, CigaretteName = item.CIGARETTENAME }).Distinct().OrderBy(item => item.MachineSeq).ToList();
                }
                return list;
            }
        }

        public static int SpecialSmokePosition(decimal sortNum) 
        {
            using (DZEntities en = new DZEntities()) 
            {

                var query = en.T_UN_POKE.Where(item => item.CTYPE == 1 && item.SORTNUM >= sortNum).ToList();
                for (int i = 0; i < query.Count; i++)
                {
                    query[i].STATUS = 10;
                }
                var query2 = en.T_UN_POKE.Where(item => item.CTYPE == 1 && item.SORTNUM < sortNum).ToList();
                for (int i = 0; i < query2.Count; i++)
                {
                    query2[i].STATUS = 20;
                }
                return en.SaveChanges();
            }
        }
    }
}
