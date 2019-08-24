
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Modle;
using Business.BusinessClass;

namespace Business.BusinessClass
{
    public class ExportClass
    {
        //SELECT batchcode,sum(t.taskquantity) as qty,COUNT(*)as cuscount,t.synseq,count(distinct regioncode) as regioncodecount 
        //from t_produce_task t where t.state=15 group BY t.batchcode,t.synseq order by synseq 
        public static List<ExportInfo> Getdata()
        {
            using (DZEntities en = new DZEntities())
            {
                
                List<ExportInfo> list = new List<ExportInfo>();
                list = en.T_UN_TASK.Where(item => item.STATE == "15").GroupBy(item => new { item.BATCHCODE, item.SYNSEQ }).Select(item =>
                    new ExportInfo
                    {
                        BatchCode = item.Key.BATCHCODE,
                        QTY = item.Sum(x => x.TASKQUANTITY) ?? 0,
                        CusCount = item.Count(),
                        Synseq = item.Key.SYNSEQ ?? 0,
                        RegionCount = item.Distinct().Count()
                    }).ToList();
                return list;
            }
        }
        //select * from ( " +
        //select p.sortnum ,t.customercode,t.customername,p.machineseq,h.cigarettecode,h.cigarettename ,p.pokenum as quantity,to_char(t.orderdate,'yyyy-mm-dd') as odate,
        //t.regioncode,r.sortname " + from t_produce_task t,t_produce_poke p,t_produce_sorttrough h,t_produce_sortlinename r " +
        //where t.tasknum = p.tasknum and p.troughnum = h.troughnum and h.troughtype=10 and h.cigarettetype=20 and h.state=10 and r.groupno=p.packagemachine 
        //and r.ctype=1 and t.synseq= " + synseq + union all " +
        //SELECT aa.sortnum,aa.customercode,aa.customername,pp.machineseq,hh.cigarettecode,hh.cigarettename,pp.pokenum as quantity,to_char(aa.orderdate,'yyyy-mm-dd') as odate,
        //aa.regioncode,rr.sortname " +FROM t_un_task aa,t_produce_sorttrough hh,t_un_poke pp, t_produce_sortlinename rr " +
        //WHERE aa.tasknum=pp.tasknum  and rr.groupno=aa.mainbelt and pp.troughnum=hh.troughnum and hh.troughtype=10 and hh.cigarettetype in (30,40) and hh.state='10' " +
        //and aa.synseq=" + synseq + " and rr.ctype=2 ) " +
        //order by sortnum,sortname,machineseq ";
        public static List<InfoExport> Export(decimal synseq)
        {
            using (DZEntities en = new DZEntities())
            {
                List<InfoExport> list = new List<InfoExport>();
                list = (from task in en.T_UN_TASK
                        join poke in en.T_UN_POKE on task.TASKNUM equals poke.TASKNUM
                        join through in en.T_PRODUCE_SORTTROUGH on poke.TROUGHNUM equals through.TROUGHNUM
                        where (through.TROUGHTYPE == 10) && ((through.CIGARETTETYPE == 30) || (through.CIGARETTETYPE == 40)) && (through.STATE == "10") && (task.SYNSEQ == synseq)
                        orderby poke.SORTNUM, poke.MACHINESEQ
                        select new InfoExport { SortNum = poke.SORTNUM ?? 0, CustomerCode = task.CUSTOMERCODE, CustomerName = task.CUSTOMERNAME, CigaretteCode=poke.CIGARETTECODE, MachineSeq = poke.MACHINESEQ ?? 0, CigaretteName = through.CIGARETTENAME, PokeNum = poke.POKENUM ?? 0, Orderdate = task.ORDERDATE.ToString(), RegionCode = task.REGIONCODE }).ToList();
                string sql = "select SEQ_ONEHAOGONGCHENG.Nextval from dual ";
                

                return list;
            }
        }
    }
}
