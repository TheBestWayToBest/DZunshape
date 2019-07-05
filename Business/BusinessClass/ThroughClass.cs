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
                Func<T_PRODUCE_SORTTROUGH,bool> func;
                if (groupNo.Count == 1)
                    func = item => item.GROUPNO == groupNo[0];
                else if (groupNo.Count == 2)
                    func = item => (item.GROUPNO == groupNo[0] || item.GROUPNO == groupNo[1]);
                else
                    func = item => (item.GROUPNO == groupNo[0] || item.GROUPNO == groupNo[1] || item.GROUPNO == groupNo[1]);
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
                    }).OrderBy(item=>item.ThroughNum).OrderBy(item=>item.MachineSeq).ToList();
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
                var query = en.T_PRODUCE_SORTTROUGH.Where(item => item.CIGARETTETYPE == type).Select(item => new { machinseq = item.MACHINESEQ ?? 0, groupNo = item.GROUPNO }).ToList();
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
                decimal id = en.T_PRODUCE_SORTTROUGH.Select(item=>item.ID).Max();
                decimal throughNum = Convert.ToDecimal(en.T_PRODUCE_SORTTROUGH.Select(item => item.TROUGHNUM).Max());

                int count = en.T_PRODUCE_SORTTROUGH.Where(item => item.CIGARETTETYPE == 30 && item.GROUPNO == 2 && item.CIGARETTECODE == through.CIGARETTECODE).Count();
                if (count == 0)
                    return "该品牌在混合道中已经存在-" + through.CIGARETTENAME;
                T_PRODUCE_SORTTROUGH tps = new T_PRODUCE_SORTTROUGH()
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
                    MACHINESEQ = through.MACHINESEQ
                };
                
                en.T_PRODUCE_SORTTROUGH.AddObject(tps);
                int rows = en.SaveChanges();
                if (rows > 0)
                    return "异形烟混合通道-" + through.CIGARETTENAME + "创建成功!";
                return "异形烟混合通道-" + through.CIGARETTENAME + "创建失败!";
            }
        }

        public static string UpdateThrough(T_PRODUCE_SORTTROUGH info) 
        {
            using (DZEntities en = new DZEntities()) 
            {
                T_PRODUCE_SORTTROUGH tps = new T_PRODUCE_SORTTROUGH();
                tps = en.T_PRODUCE_SORTTROUGH.Where(item => item.ID == info.ID).FirstOrDefault();
                tps.CIGARETTECODE = info.CIGARETTECODE;
                tps.CIGARETTENAME = info.CIGARETTENAME;
                int rows = en.SaveChanges();
                if (rows > 0)
                    return "分拣通道信息修改成功!";
                return "分拣通道信息修改失败!";
            }
        }
    }
}
