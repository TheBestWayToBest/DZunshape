using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business;
using Business.Modle;
using System.Transactions;

namespace Business.BusinessClass
{
    public class Replan
    {

        public Response AutoGenReplan()
        {
            Response response = new Response();
            Boolean flag = false;
            int i = 0;
            using (DZEntities entites = new DZEntities())
            {
                TransactionOptions transactionOption = new TransactionOptions();
                transactionOption.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                using (TransactionScope tran = new TransactionScope(TransactionScopeOption.Required, transactionOption)) 
                {
                    try
                    {
                        decimal maxid = 0;
                        //卧式通道预补货
                        var wsList = (from ws in entites.T_PRODUCE_SORTTROUGH where ws.STATE == "10" && ws.GROUPNO == 3 select ws).ToList();
                        var itemList = (from item in entites.T_WMS_ITEM where item.ROWSTATUS == 10 select item).ToList();
                        if (wsList.Any())
                        {
                            foreach (var item in wsList)
                            {
                                T_WMS_ITEM citem = itemList.Find(x => x.ITEMNO == item.CIGARETTECODE);
                                //计算需要预补多少件
                                decimal jtsize = citem.JT_SIZE ?? 0;
                                if (jtsize > 0)
                                {
                                    decimal ct = ((item.THRESHOLD - item.MANTISSA) / jtsize) ?? 0;
                                    double cigCount = Math.Floor(Convert.ToDouble(ct));
                                    if (cigCount > 0)
                                    {
                                        for (int j = 0; j < cigCount; j++)
                                        {
                                            i++;
                                            T_PRODUCE_REPLENISHPLAN plan = new T_PRODUCE_REPLENISHPLAN();

                                            plan.CIGARETTECODE = item.CIGARETTECODE;
                                            plan.CIGARETTENAME = item.CIGARETTENAME;
                                            plan.ID = (++maxid);
                                            plan.JYCODE = citem.BIGBOX_BAR;
                                            plan.REPLENISHQTY = 1;
                                            plan.TASKNUM = maxid.ToString();
                                            plan.MANTISSA = item.MANTISSA + citem.JT_SIZE;
                                            item.MANTISSA = plan.MANTISSA;
                                            plan.TROUGHNUM = item.MACHINESEQ.ToString();//通道编号默认
                                            plan.STATUS = 0;//新增状态
                                            plan.TYPE = 10;//排程自动补货
                                            plan.SEQ = 1;
                                            plan.ISCOMPLETED = 10;//已生成托盘补货计划
                                            entites.T_PRODUCE_REPLENISHPLAN.AddObject(plan);
                                            //item.STATUS = 10;//已生成托盘补货计划
                                        }
                                    }
                                }
                            }
                            entites.SaveChanges();//提交 最多24条补货
                        }
                        //根据订单正常补货
                        var sortList = (from item in entites.T_PRODUCE_SORTTROUGH where item.TROUGHTYPE == 10 && item.STATE == "10" && (item.CIGARETTETYPE == 30 || item.CIGARETTETYPE == 40) select item).ToList();
                        sortList.ForEach(x => x.LASTMANTISSA = x.MANTISSA);//更新上次尾数
                        var pokeList1 = (from item in entites.T_UN_POKE where item.STATUS == 0 select item).ToList();
                        var pokeList = (from item in entites.T_UN_POKE where item.STATUS == 0 group item by new { item.SORTNUM, item.TROUGHNUM, item.CIGARETTECODE } into g orderby g.Key.SORTNUM, g.Key.TROUGHNUM select new { SORTNUM = g.Key.SORTNUM, TROUGHNUM = g.Key.TROUGHNUM, CIGARETTECODE = g.Key.CIGARETTECODE, POKENUM = g.Sum(x => x.POKENUM) }).ToList();

                        var list = (from item in entites.T_PRODUCE_REPLENISHPLAN select item.ID).ToList();

                        if (list.Count > 0)
                        {
                            maxid = list.Max();
                        }
                        if (pokeList1.Any())
                        {
                            foreach (var item in pokeList)
                            {
                                T_PRODUCE_SORTTROUGH sorttrough = sortList.Find(x => x.CIGARETTECODE == item.CIGARETTECODE && x.TROUGHNUM == item.TROUGHNUM);


                                T_WMS_ITEM citem = itemList.Find(x => x.ITEMNO == item.CIGARETTECODE);
                                sorttrough.MANTISSA = sorttrough.MANTISSA - item.POKENUM;
                                if (sorttrough.THRESHOLD - sorttrough.MANTISSA >= citem.JT_SIZE)//如果空出一件烟就可以补
                                {
                                    i++;
                                    T_PRODUCE_REPLENISHPLAN plan = new T_PRODUCE_REPLENISHPLAN();

                                    plan.CIGARETTECODE = item.CIGARETTECODE;
                                    plan.CIGARETTENAME = sorttrough.CIGARETTENAME;
                                    plan.ID = (++maxid);
                                    plan.JYCODE = citem.BIGBOX_BAR;
                                    plan.REPLENISHQTY = 1;
                                    plan.TASKNUM = maxid.ToString();
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
                                //
                                //entites.SaveChanges();
                            }
                            pokeList1.ForEach(x => x.STATUS = 10);
                            entites.SaveChanges();
                            tran.Complete();
                            flag = true;
                            response.MessageText = "补货计划生成成功！";
                        }
                        else
                        {
                            flag = false;
                            response.MessageText = "暂无新的分拣数据，无需生成补货计划！";
                        }
                        response.IsSuccess = flag;
                        
                    }
                    catch (Exception e)
                    {
                        flag = false;
                        response.MessageText = "生成补货计划出错，请联系系统管理员！" + e.ToString();
                        response.IsSuccess = flag;
                    }

                    return response;
                }
                
            }
        }

        public static List<PlanInfo> GetPlan()
        {
            using (DZEntities en = new DZEntities())
            {
                List<PlanInfo> list = new List<PlanInfo>();
                list = en.T_PRODUCE_REPLENISHPLAN.GroupBy(item => new
                {
                    item.CIGARETTECODE,
                    item
                    .CIGARETTENAME,
                    item.JYCODE
                }).Select(item => new PlanInfo { CigaretteCode = item.Key.CIGARETTECODE, CigaretteName = item.Key.CIGARETTENAME, JYCode = item.Key.JYCODE, QTY = item.Sum(x => x.REPLENISHQTY) ?? 0 }).OrderByDescending(item => item.QTY).ToList();
                return list;
            }
        }
    }
}
