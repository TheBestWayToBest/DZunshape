using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business;
using Business.Modle;
namespace Business.BusinessClass
{
    public class Replan
    {

        public Boolean AutoGenReplan()
        {
            Boolean flag=false;
            int i = 0;
            using (DZEntities entites = new DZEntities())
            {
                try
                {
                    var sortList = (from item in entites.T_PRODUCE_SORTTROUGH where item.TROUGHTYPE == 10 && item.STATE == "10" && (item.CIGARETTETYPE == 30 || item.CIGARETTETYPE == 40) select item).ToList();
                    sortList.ForEach(x => x.LASTMANTISSA = x.MANTISSA);//更新上次尾数
                    var pokeList1 = (from item in entites.T_UN_POKE where item.STATUS == 0 select item).ToList();
                    var pokeList = (from item in entites.T_UN_POKE where item.STATUS == 0 group item by new { item.SORTNUM, item.TROUGHNUM, item.CIGARETTECODE } into g select new { SORTNUM = g.Key.SORTNUM, TROUGHNUM = g.Key.TROUGHNUM, CIGARETTECODE = g.Key.CIGARETTECODE, POKENUM = g.Count() }).OrderBy(x => x.SORTNUM).OrderBy(x => x.TROUGHNUM).ToList();
                    var itemList = (from item in entites.T_WMS_ITEM select item).ToList();
                    var list = (from item in entites.T_PRODUCE_REPLENISHPLAN select item.ID).ToList();
                    decimal maxid = 0;
                    if (list.Count > 0)
                    {
                        maxid = list.Max();
                    }

                    foreach (var item in pokeList)
                    {
                        T_PRODUCE_SORTTROUGH sorttrough = sortList.Find(x => x.CIGARETTECODE == item.CIGARETTECODE);

                        T_WMS_ITEM citem = itemList.Find(x => x.ITEMNO == item.CIGARETTECODE);
                        if (sorttrough.THRESHOLD - sorttrough.MANTISSA >= citem.JT_SIZE)//如果空出一件烟就可以补
                        {
                            i++;
                            T_PRODUCE_REPLENISHPLAN plan = new T_PRODUCE_REPLENISHPLAN();

                            plan.CIGARETTECODE = item.CIGARETTECODE;
                            plan.CIGARETTENAME = sorttrough.CIGARETTENAME;
                            plan.ID = (++maxid);
                            plan.JYCODE = citem.BIGBOX_BAR;
                            plan.REPLENISHQTY = 1;
                            plan.TASKNUM = plan.ID + "";
                            plan.MANTISSA = sorttrough.MANTISSA + citem.JT_SIZE;
                            sorttrough.MANTISSA = plan.MANTISSA;
                            plan.TROUGHNUM = sorttrough.MACHINESEQ.ToString();//通道编号默认
                            plan.STATUS = 0;//新增状态
                            plan.TYPE = 30;//排程自动补货
                            plan.SEQ = 0;
                            plan.ISCOMPLETED = 10;//已生成托盘补货计划
                            entites.T_PRODUCE_REPLENISHPLAN.AddObject(plan);
                            //item.STATUS = 10;//已生成托盘补货计划
                            if (i == 100)
                            {
                                entites.SaveChanges();
                                i = 0;
                            }
                        }
                        sorttrough.MANTISSA = sorttrough.MANTISSA - item.POKENUM;
                        //entites.SaveChanges();
                    }
                    pokeList1.ForEach(x => x.STATUS = 10);
                    entites.SaveChanges();
                    flag = true;
                    
                }
                catch (Exception e){
                    flag = false;
                }

                return flag;
            }
        }

        public static List<PlanInfo> GetPlan() 
        {
            using (DZEntities en = new DZEntities()) 
            {
                List<PlanInfo> list = new List<PlanInfo>();
                list = en.T_PRODUCE_REPLENISHPLAN.GroupBy(item => new { item.CIGARETTECODE,item
                .CIGARETTENAME ,item.JYCODE}).Select(item => new PlanInfo { CigaretteCode = item.Key.CIGARETTECODE, CigaretteName = item.Key.CIGARETTENAME, JYCode = item.Key.JYCODE, QTY = item.Sum(x=>x.REPLENISHQTY)??0 }).OrderByDescending(item => item.QTY).ToList();
                return list;
            }
        }
    }
}
