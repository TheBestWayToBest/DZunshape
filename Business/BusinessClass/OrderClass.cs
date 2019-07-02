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
                string str="非标";

                list = en.T_PRODUCE_ORDERLINE.Where(item => item.ALLOWSORT == str).GroupBy(item => new { item.CIGARETTECODE, item.CIGARETTENAME }).OrderByDescending(item => item.Sum(x => x.QUANTITY)).Select(item =>
                    new AllOrderData { CigaretteCode = item.Key.CIGARETTECODE, CigaretteName = item.Key.CIGARETTENAME, Count = item.Count(), QTY = item.Sum(x => x.QUANTITY) ?? 0 }).ToList();
                return list;
            }
        }
    }
}
