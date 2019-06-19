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
                Func<T_PRODUCE_SORTTROUGH, bool> fun;
                if (index == 0)
                    fun = item => item.CIGARETTECODE.Contains(condition);
                else
                    fun = item => item.CIGARETTENAME.Contains(condition);
                list = en.T_PRODUCE_SORTTROUGH.Where(fun).Select(item => new ThroughInfo
                {
                    ThroughNum = item.TROUGHNUM,
                    ID = item.ID,
                    MachineSeq=item.MACHINESEQ??0,
                    CigaretteCode = item.CIGARETTECODE,
                    CigaretteName = item.CIGARETTENAME,
                    State = item.STATE,
                    ThroughType = item.TROUGHTYPE.ToString(),
                    CigeretteType = item.CIGARETTETYPE.ToString()
                }).ToList();
                return list;
            }
        }

        public static bool UpdateThroughState(ThroughInfo info) 
        {
            using (DZEntities en = new DZEntities()) 
            {
                T_PRODUCE_SORTTROUGH infos = new T_PRODUCE_SORTTROUGH();
                infos = en.T_PRODUCE_SORTTROUGH.Where(item => item.ID == info.ID && item.CIGARETTETYPE == Convert.ToDecimal(info.CigeretteType) && item.TROUGHTYPE == Convert.ToDecimal(info.ThroughType)).FirstOrDefault();
                infos.STATE = info.State;
                return en.SaveChanges() > 0 ? true : false;
            }
        }
    }
}
