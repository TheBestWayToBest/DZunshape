using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Modle;

namespace Business.BusinessClass
{
    public class ThroughClass
    {
        public static List<ThroughInfo> GetThroughInfo(int index, List<decimal> groupNo, string condition)
        {
            using (DZEntities en = new DZEntities())
            {
                Func<T_PRODUCE_SORTTROUGH, bool> func;
                if (groupNo.Count == 1)
                    func = item => item.GROUPNO == groupNo[0];
                else if (groupNo.Count == 2)
                    func = item => (item.GROUPNO == groupNo[0] || item.GROUPNO == groupNo[1]);
                else
                    func = item => (item.GROUPNO == groupNo[0] || item.GROUPNO == groupNo[1] || item.GROUPNO == groupNo[2]);
                List<ThroughInfo> list = new List<ThroughInfo>();
                if (condition == "")
                {
                    list = en.T_PRODUCE_SORTTROUGH.Where(func).Select(item => new ThroughInfo
                    {
                        ThroughNum = item.TROUGHNUM,
                        ID = item.ID,
                        MachineSeq = item.MACHINESEQ ?? 0,
                        CigaretteCode = item.CIGARETTECODE,
                        CigaretteName = item.CIGARETTENAME,
                        State = item.STATE,
                        GroupNo = item.GROUPNO ?? 0,
                        CigaretteType = item.CIGARETTETYPE ?? 0
                    }).OrderBy(item => item.ThroughNum).OrderBy(item => item.MachineSeq).ToList();
                }
                else
                {
                    if (index == 0)
                    {
                        list = en.T_PRODUCE_SORTTROUGH.Where(item => item.CIGARETTECODE.Contains(condition)).Where(func).Select(item => new ThroughInfo
                        {
                            ThroughNum = item.TROUGHNUM,
                            ID = item.ID,
                            MachineSeq = item.MACHINESEQ ?? 0,
                            CigaretteCode = item.CIGARETTECODE,
                            CigaretteName = item.CIGARETTENAME,
                            State = item.STATE,
                            GroupNo = item.GROUPNO ?? 0,
                            CigaretteType = item.CIGARETTETYPE ?? 0
                        }).OrderBy(item => item.ThroughNum).OrderBy(item => item.MachineSeq).ToList();
                    }
                    else if (index == 1)
                    {
                        list = en.T_PRODUCE_SORTTROUGH.Where(item => item.CIGARETTENAME.Contains(condition)).Where(func).Select(item => new ThroughInfo
                        {
                            ThroughNum = item.TROUGHNUM,
                            ID = item.ID,
                            MachineSeq = item.MACHINESEQ ?? 0,
                            CigaretteCode = item.CIGARETTECODE,
                            CigaretteName = item.CIGARETTENAME,
                            State = item.STATE,
                            GroupNo = item.GROUPNO ?? 0,
                            CigaretteType = item.CIGARETTETYPE ?? 0
                        }).OrderBy(item => item.ThroughNum).OrderBy(item => item.MachineSeq).ToList();
                    }
                }

                return list;
            }
        }

        public static bool UpdateThroughState(ThroughInfo info)
        {
            using (DZEntities en = new DZEntities())
            {

                decimal CigType = Convert.ToDecimal(info.CigaretteType);
                decimal tType = Convert.ToDecimal(info.GroupNo);
                T_PRODUCE_SORTTROUGH infos = new T_PRODUCE_SORTTROUGH();
                infos = en.T_PRODUCE_SORTTROUGH.Where(item => item.ID == info.ID && item.CIGARETTETYPE == CigType && item.GROUPNO == tType).FirstOrDefault();
                if (info.State == "禁用")
                    infos.STATE = "0";
                else
                    infos.STATE = "10";
                return en.SaveChanges() > 0 ? true : false;
            }
        }

        public static List<string> GetMachineseqByType(decimal type)
        {
            using (DZEntities en = new DZEntities())
            {
                List<string> list = new List<string>();
                var query = en.T_PRODUCE_SORTTROUGH.Where(item => item.CIGARETTETYPE == type).GroupBy(item => new { item.MACHINESEQ, item.GROUPNO }).Select(item => new { machinseq = item.Key.MACHINESEQ ?? 0, groupNo = item.Key.GROUPNO }).ToList();
                foreach (var item in query)
                {
                    list.Add(item.groupNo.ToString() + "," + item.machinseq.ToString());
                }
                return list;
            }
        }

        public static string InsertThrough(T_PRODUCE_SORTTROUGH through)
        {
            using (DZEntities en = new DZEntities())
            {
                decimal id = en.T_PRODUCE_SORTTROUGH.Select(item => item.ID).Max();
                decimal throughNum = Convert.ToDecimal(en.T_PRODUCE_SORTTROUGH.Where(item => item.GROUPNO == through.GROUPNO).Select(item => item.TROUGHNUM).Max());
                decimal seq = en.T_PRODUCE_SORTTROUGH.Where(item => item.GROUPNO == through.GROUPNO).Select(item => item.SEQ).Max() ?? 0;
                T_PRODUCE_SORTTROUGH tps = new T_PRODUCE_SORTTROUGH();
                if (through.MACHINESEQ == 90)
                {
                    int count = en.T_PRODUCE_SORTTROUGH.Where(item => item.CIGARETTETYPE == 40 && item.GROUPNO == 2 && item.CIGARETTECODE == through.CIGARETTECODE).Count();
                    if (count != 0)
                        return "该品牌在混合道中已经存在-" + through.CIGARETTENAME;
                    tps = new T_PRODUCE_SORTTROUGH()
                    {
                        ID = id + 1,
                        CIGARETTECODE = through.CIGARETTECODE,
                        CIGARETTENAME = through.CIGARETTENAME,
                        CIGARETTETYPE = through.CIGARETTETYPE,
                        GROUPNO = through.GROUPNO,
                        LINENUM = through.LINENUM,
                        MANTISSA = through.MANTISSA,
                        SEQ = through.SEQ,
                        STATE = through.STATE,
                        TROUGHNUM = (throughNum + 1).ToString(),
                        TROUGHTYPE = through.TROUGHTYPE,
                        MACHINESEQ = through.MACHINESEQ,
                        LASTMANTISSA = through.LASTMANTISSA,
                        THRESHOLD = through.THRESHOLD,
                        ACTCOUNT = through.ACTCOUNT,
                        TROUGHDESC = through.TROUGHDESC
                    };
                }
                else
                {
                    int count = en.T_PRODUCE_SORTTROUGH.Where(item => item.CIGARETTETYPE == 40 && item.GROUPNO == 1 && item.CIGARETTECODE == through.CIGARETTECODE).Count();
                    if (count != 0)
                        return "该品牌在特异形烟混合道中已经存在-" + through.CIGARETTENAME;
                    tps = new T_PRODUCE_SORTTROUGH()
                    {
                        ID = id + 1,
                        CIGARETTECODE = through.CIGARETTECODE,
                        CIGARETTENAME = through.CIGARETTENAME,
                        CIGARETTETYPE = through.CIGARETTETYPE,
                        GROUPNO = through.GROUPNO,
                        LINENUM = through.LINENUM,
                        MANTISSA = through.MANTISSA,
                        SEQ = seq + 1,
                        STATE = through.STATE,
                        TROUGHNUM = (throughNum + 1).ToString(),
                        TROUGHTYPE = through.TROUGHTYPE,
                        MACHINESEQ = through.MACHINESEQ,
                        LASTMANTISSA = through.LASTMANTISSA,
                        THRESHOLD = through.THRESHOLD,
                        ACTCOUNT = through.ACTCOUNT,
                        TROUGHDESC = through.TROUGHDESC
                    };
                }


                en.T_PRODUCE_SORTTROUGH.AddObject(tps);
                int rows = en.SaveChanges();
                if (rows > 0)
                    return "异形烟混合通道-" + through.CIGARETTENAME + "创建成功!";
                return "异形烟混合通道-" + through.CIGARETTENAME + "创建失败!";
            }
        }

        public static string UpdateThrough(T_PRODUCE_SORTTROUGH info, string lastCigarettecode)
        {
            using (DZEntities en = new DZEntities())
            {
                T_PRODUCE_SORTTROUGH tps = new T_PRODUCE_SORTTROUGH();
                tps = en.T_PRODUCE_SORTTROUGH.Where(item => item.ID == info.ID).FirstOrDefault();
                tps.CIGARETTECODE = info.CIGARETTECODE;
                tps.CIGARETTENAME = info.CIGARETTENAME;
                int rows = en.SaveChanges();
                if (rows > 0)
                {
                    try
                    {
                        SetThroughActcount(info.CIGARETTECODE, info.GROUPNO ?? 0, lastCigarettecode);
                    }
                    catch (Exception ex)
                    {
                        return "分拣通道信息修改失败!" + ex.ToString();
                    }
                    return "分拣通道信息修改成功!";
                }

                return "分拣通道信息修改失败!";
            }
        }

        public static bool SetThroughActcount(string cigarettecode, decimal groupNo, string lastCigarettecode = "0")
        {
            using (DZEntities en = new DZEntities())
            {
                if (lastCigarettecode != "0" && lastCigarettecode != "")
                {
                    var query = en.T_PRODUCE_SORTTROUGH.Where(item => item.STATE == "10" && item.GROUPNO == groupNo && item.CIGARETTECODE == cigarettecode).ToList();
                    if (query.Count > 1)
                    {
                        foreach (var item in query)
                        {
                            item.ACTCOUNT = 2;
                        }
                    }
                    else
                    {
                        foreach (var item in query)
                        {
                            item.ACTCOUNT = 1;
                        }
                    }
                    var query2 = en.T_PRODUCE_SORTTROUGH.Where(item => item.STATE == "10" && item.GROUPNO == groupNo && item.CIGARETTECODE == lastCigarettecode).ToList();
                    if (query2.Count > 1)
                    {
                        foreach (var item in query2)
                        {
                            item.ACTCOUNT = 2;
                        }
                    }
                    else
                    {
                        foreach (var item in query2)
                        {
                            item.ACTCOUNT = 1;
                        }
                    }
                }
                else
                {
                    var query = en.T_PRODUCE_SORTTROUGH.Where(item => item.STATE == "10" && item.GROUPNO == groupNo && item.CIGARETTECODE == cigarettecode).ToList();
                    if (query.Count > 1)
                    {
                        foreach (var item in query)
                        {
                            item.ACTCOUNT = 2;
                        }
                    }
                    else
                    {
                        if (query.Count == 0)
                        {
                            query = en.T_PRODUCE_SORTTROUGH.Where(item => item.GROUPNO == groupNo && item.CIGARETTECODE == cigarettecode).ToList();
                        }
                        foreach (var item in query)
                        {
                            item.ACTCOUNT = 1;
                        }
                    }
                }
                return en.SaveChanges() > 0;
            }

        }

        public static List<ThroughSortDataInfo> GetMachineSeq()
        {
            using (DZEntities en = new DZEntities())
            {
                List<ThroughSortDataInfo> list = new List<ThroughSortDataInfo>();
                list = en.T_PRODUCE_SORTTROUGH.Where(item => item.GROUPNO == 2).OrderBy(item => item.MACHINESEQ).Select(item => new ThroughSortDataInfo { CigaretteName = item.CIGARETTENAME, MachineSeq = item.MACHINESEQ ?? 0, TotalNum = 0, OverNum = 0 }).ToList();
                return list;
            }
        }

        public static List<ThroughSortDataInfo> GetMachineSeqSortData()
        {
            using (DZEntities en = new DZEntities())
            {
                //en.T_UN_POKE.Where(item => item.CTYPE == 2).GroupBy(item => item.MACHINESEQ).Select(item => new ThroughSortDataInfo { MachineSeq = item.Key ?? 0, TotalNum = item.Sum(x => x.POKENUM) ?? 0, OverNum = 0 });
                List<ThroughSortDataInfo> list = new List<ThroughSortDataInfo>();
                list = GetMachineSeq();
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].TotalNum = en.T_UN_POKE.Where(item => item.MACHINESEQ == list[i].MachineSeq).Sum(item => item.POKENUM) ?? 0;
                    list[i].OverNum = en.T_UN_POKE.Where(item => item.MACHINESEQ == list[i].MachineSeq && item.STATUS == 20).Sum(item => item.POKENUM) ?? 0;
                }
                return list;

            }
        }
    }
}
