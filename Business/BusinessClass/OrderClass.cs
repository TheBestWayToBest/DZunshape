using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Modle;

namespace Business.BusinessClass
{
    public class OrderClass
    {
        //"with lst as (SELECT routecode,SUM(totalqty)as order_qty,count(1) as count_hs FROM t_wms_shiporder " +
        //"WHERE   orderdate=to_date('" + time + "','yyyy-mm-dd') GROUP BY routecode) select rownum,lst.* from lst";

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
        //"select rownum as num  , cigarettecode,cigarettename,  ccount,  orderqty  from (SELECT  cigarettecode,cigarettename,count(*) as ccount,SUM(quantity) AS orderqty   
        //FROM t_produce_orderline GROUP BY cigarettecode,cigarettename ORDER BY orderqty   desc)"
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
    }
}
