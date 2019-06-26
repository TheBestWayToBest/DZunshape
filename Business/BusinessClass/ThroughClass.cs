using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Modle;

namespace Business.BusinessClass
{
    public class ThroughClass
    {
        //"SELECT tmp.* FROM (select  rownum as num, troughnum,id,machineseq," +
        //"cigarettecode,cigarettename,state,troughtype as type,cigarettetype as ctype,decode(cigarettetype,'10','混合','20','标准','30','异型','异型混合')as cigarettetype,
        //decode(state,'10','正常','0','禁用')as status, " + "decode(troughtype,10,'分拣',20,'重力式货架',30,'皮带机',40,'分拣出口')as troughtypes,groupno 
        //from t_produce_sorttrough t where  1=1 " + tmp +" )tmp where  tmp.num>" + (pager1.CurrentPageIndex - 1) * pager1.PageSize + " and 
        //    tmp.num<=" + pager1.CurrentPageIndex * pager1.PageSize + " order by to_number(tmp.troughnum)";

        public static List<ThroughInfo> GetThroughInfo(int index, string condition) 
        {
            using (DZEntities en = new DZEntities()) 
            {
                List<ThroughInfo> list = new List<ThroughInfo>();
                if (condition == "")
                {
                    list = en.T_PRODUCE_SORTTROUGH.Where(item => true).Select(item => new ThroughInfo
                    {
                        ThroughNum = item.TROUGHNUM,
                        ID = item.ID,
                        MachineSeq = item.MACHINESEQ ?? 0,
                        CigaretteCode = item.CIGARETTECODE,
                        CigaretteName = item.CIGARETTENAME,
                        State = item.STATE,
                        ThroughType = item.TROUGHTYPE ?? 0,
                        CigaretteType = item.CIGARETTETYPE ?? 0
                    }).ToList();
                }
                else 
                {
                    if (index == 0)
                    {
                        list = en.T_PRODUCE_SORTTROUGH.Where(item => item.CIGARETTECODE.Contains(condition)).Select(item => new ThroughInfo
                        {
                            ThroughNum = item.TROUGHNUM,
                            ID = item.ID,
                            MachineSeq = item.MACHINESEQ ?? 0,
                            CigaretteCode = item.CIGARETTECODE,
                            CigaretteName = item.CIGARETTENAME,
                            State = item.STATE,
                            ThroughType = item.TROUGHTYPE ?? 0,
                            CigaretteType = item.CIGARETTETYPE ?? 0
                        }).ToList();
                    }
                    else if (index == 1)
                    {
                        list = en.T_PRODUCE_SORTTROUGH.Where(item => item.CIGARETTENAME.Contains(condition)).Select(item => new ThroughInfo
                        {
                            ThroughNum = item.TROUGHNUM,
                            ID = item.ID,
                            MachineSeq = item.MACHINESEQ ?? 0,
                            CigaretteCode = item.CIGARETTECODE,
                            CigaretteName = item.CIGARETTENAME,
                            State = item.STATE,
                            ThroughType = item.TROUGHTYPE ?? 0,
                            CigaretteType = item.CIGARETTETYPE ?? 0
                        }).ToList();
                    }
                }
                
                return list;
            }
        }

        public static bool UpdateThroughState(ThroughInfo info) 
        {
            using (DZEntities en = new DZEntities()) 
            {
                T_PRODUCE_SORTTROUGH infos = new T_PRODUCE_SORTTROUGH();
                infos = en.T_PRODUCE_SORTTROUGH.Where(item => item.ID == info.ID && item.CIGARETTETYPE == Convert.ToDecimal(info.CigaretteType) && item.TROUGHTYPE == Convert.ToDecimal(info.ThroughType)).FirstOrDefault();
                infos.STATE = info.State;
                return en.SaveChanges() > 0 ? true : false;
            }
        }

        public static List<decimal> GetMachineseqByType(decimal type, decimal throughType) 
        {
            using (DZEntities en = new DZEntities()) 
            {
                List<decimal> list = new List<decimal>();
                list = en.T_PRODUCE_SORTTROUGH.Where(item => item.CIGARETTETYPE == type && item.TROUGHTYPE == throughType).Select(item => item.MACHINESEQ??0).ToList();
                return list;
            }
        }

        public static string InsertThrough(T_PRODUCE_SORTTROUGH through) 
        {
            using (DZEntities en = new DZEntities()) 
            {
                decimal id = en.T_PRODUCE_SORTTROUGH.Select(item=>item.ID).Max();


                int count = en.T_PRODUCE_SORTTROUGH.Where(item => item.CIGARETTETYPE == 40 && item.TROUGHTYPE == 10 && item.CIGARETTECODE == through.CIGARETTECODE).Count();
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
                    TROUGHNUM = through.TROUGHNUM,
                    TROUGHTYPE = through.TROUGHTYPE,
                    MACHINESEQ=through.MACHINESEQ
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
