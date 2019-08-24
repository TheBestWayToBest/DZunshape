using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Modle;

namespace Business.BusinessClass
{
    public class OrderClass
    {
        public static List<OrderData> GetOrderByDate(DateTime date)
        {
            using (DZEntities en = new DZEntities())
            {
                List<OrderData> list = new List<OrderData>();
                list = en.T_PRODUCE_ORDER.Where(item => item.ORDERDATE == date).GroupBy(item => item.REGIONCODE).Select(item =>
                    new OrderData { RegionCode = item.Key, QTY = item.Sum(x => x.ORDERQUANTITY) ?? 0, Count = item.Count() }).ToList();
                return list;

            }
        }

        public static List<AllOrderData> GetAllOrder()
        {
            using (DZEntities en = new DZEntities())
            {
                List<AllOrderData> list = new List<AllOrderData>();
                list = en.T_PRODUCE_ORDERLINE.GroupBy(item => new { item.CIGARETTECODE, item.CIGARETTENAME }).OrderByDescending(item => item.Sum(x => x.QUANTITY)).Select(item =>
                    new AllOrderData { CigaretteCode = item.Key.CIGARETTECODE, CigaretteName = item.Key.CIGARETTENAME, Count = item.Count(), QTY = item.Sum(x => x.QUANTITY) ?? 0 }).ToList();
                return list;
            }
        }

        public static List<AllOrderData> GetUnnormalCig()
        {
            using (DZEntities en = new DZEntities())
            {
                List<AllOrderData> list = new List<AllOrderData>();
                //string str="非标";

                //list = en.T_PRODUCE_ORDERLINE.Where(item => item.ALLOWSORT == str).GroupBy(item => new { item.CIGARETTECODE, item.CIGARETTENAME }).OrderByDescending(item => item.Sum(x => x.QUANTITY)).Select(item =>
                //    new AllOrderData { CigaretteCode = item.Key.CIGARETTECODE, CigaretteName = item.Key.CIGARETTENAME, Count = item.Count(), QTY = item.Sum(x => x.QUANTITY) ?? 0 }).ToList();

                list = en.T_PRODUCE_ORDERLINE.Join(en.T_WMS_ITEM, orderline => orderline.CIGARETTECODE, item => item.ITEMNO, (orderline, item) => new
                {
                    cigarettecode = orderline.CIGARETTECODE,
                    cigarettename = orderline.CIGARETTENAME,
                    shiptype = item.SHIPTYPE,
                    qty = orderline.QUANTITY
                }).Where(item => item.shiptype == "1")
                .GroupBy(item => new { item.cigarettecode, item.cigarettename }).OrderByDescending(item => item.Sum(x => x.qty)).Select(item =>
                    new AllOrderData { CigaretteCode = item.Key.cigarettecode, CigaretteName = item.Key.cigarettename, Count = item.Count(), QTY = item.Sum(x => x.qty) ?? 0 }).ToList();
                return list;
            }
        }

        public static List<OnCigOrderInfo> GetOneCigOrder()
        {
            using (DZEntities en = new DZEntities())
            {
                List<OnCigOrderInfo> list = new List<OnCigOrderInfo>();
                //var query = en.T_UN_POKE.GroupBy(item => new { item.BILLCODE, item.SORTNUM }).Where(item => item.Sum(items => items.POKENUM) == 1).Select(item =>
                //    new { BillCode = item.Key.BILLCODE, Sortnum = item.Key.SORTNUM, Num = item.Sum(items => items.POKENUM) }).OrderBy(item => item.Sortnum).ToList();

                //list = (from task in en.T_UN_TASK
                //            join poke in query on task.SORTNUM equals poke.Sortnum
                //            select new OnCigOrderInfo
                //            {
                //                RegionCode = task.REGIONCODE,
                //                RegionDesc = task.REGIONDESC,
                //                BillCode = task.BILLCODE,
                //                CustomerCode = task.CUSTOMERCODE,
                //                CustomerName = task.CUSTOMERNAME,
                //                Num = poke.Num ?? 0,
                //                SortNum = poke.Sortnum ?? 0
                //            }).OrderBy(item => item.SortNum).ToList();
                string sqlStr = "select task.regioncode,task.regiondesc,task.billcode,task.customercode,task.customername,poke.num,POKE.SORTNUM from t_un_task task, " +
                                "(select billcode,sortnum,sum(pokenum) as num from t_un_poke group by billcode,sortnum having sum(pokenum)=1 order by sortnum) poke  " +
                                "where poke.sortnum=task.sortnum order by task.sortnum";
                list = en.ExecuteStoreQuery<OnCigOrderInfo>(sqlStr).ToList();
                return list;
            }
        }

        public static List<OrderLineInfo> GetRegionOrderline(string regioncode, DateTime date)
        {
            using (DZEntities en = new DZEntities())
            {
                List<OrderLineInfo> list = new List<OrderLineInfo>();
                //DateTime date = DateTime.Now.Date;
                var order = en.T_PRODUCE_ORDER.Where(item => item.ORDERDATE == date && item.REGIONCODE == regioncode).OrderBy(item => item.PRIORITY).ToList();

                //var query = order.Join(en.T_PRODUCE_ORDERLINE, ord => ord.BILLCODE, line => line.BILLCODE, (ord, line) => new
                //{
                //    RegionCode = ord.REGIONCODE,
                //    BillCode = ord.BILLCODE,
                //    CustomerName = ord.CUSTOMERNAME
                //}).ToList();

                for (int i = 0; i < order.Count; i++)
                {
                    string billcode = order[i].BILLCODE;
                    var query2 = en.T_PRODUCE_ORDERLINE.Where(item => item.BILLCODE == billcode).ToList();
                    var query = query2.Join(en.T_WMS_ITEM, que => que.CIGARETTECODE, item => item.ITEMNO, (que, item) => new { CIGARETTENAME = que.CIGARETTENAME, QUANTITY = que.QUANTITY, shiptype = item.SHIPTYPE }).Where(item => item.shiptype == "1").ToList();
                    OrderLineInfo info = new OrderLineInfo();
                    info.BillCode = order[i].BILLCODE;
                    info.RegionCode = order[i].REGIONCODE;
                    info.CustomerName = order[i].CUSTOMERNAME;
                    info.CigaretteDetail = "";
                    for (int j = 0; j < query.Count; j++)
                    {
                        if (j < query.Count - 1)
                            info.CigaretteDetail += query[j].CIGARETTENAME + "(" + query[j].QUANTITY + "),";
                        else
                            info.CigaretteDetail += query[j].CIGARETTENAME + "(" + query[j].QUANTITY + ")";
                    }
                    list.Add(info);
                }
                return list;
            }
        }
    }
}
