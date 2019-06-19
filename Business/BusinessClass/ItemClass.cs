using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Modle;

namespace Business.BusinessClass
{
    public class ItemClass
    {
        public static List<ItemInfo> GetItemInfo(int index, string condition = "-1")
        {
            using (DZEntities en = new DZEntities())
            {
                Func<T_WMS_ITEM, bool> fCondition;
                if (index == 0 && condition != "-1" && condition != "")
                {
                    fCondition = item => item.ITEMNO.Contains(condition);
                }
                else if (index == 1 && condition != "-1" && condition != "")
                {
                    fCondition = item => item.ITEMNAME.Contains(condition);
                }
                else
                {
                    fCondition = item => true;
                }
                var query = en.T_WMS_ITEM.Where(item => item.ITEMNO.Length == 7).Where(fCondition).Select(item =>
                    new ItemInfo
                    {
                        ItemNo = item.ITEMNO,
                        ItemName = item.ITEMNAME,
                        BigBox_Bar = item.BIGBOX_BAR,
                        ILength = item.ILENGTH ?? 0,
                        IWidth = item.IWIDTH ?? 0,
                        JT_Size = item.JT_SIZE ?? 50,
                        RowStatus = item.ROWSTATUS??0,
                        Shiptype = item.SHIPTYPE
                    }).ToList();
                return query;
            }
        }

        public static bool UpdateItemInfo(ItemInfo item) 
        {
            using (DZEntities en = new DZEntities()) 
            {
                int rows=0;
                List<T_WMS_ITEM> list = new List<T_WMS_ITEM>();
                list = en.T_WMS_ITEM.Where(it => it.ITEMNO == item.ItemNo && it.ITEMNAME == item.ItemName).ToList();
                foreach (var ite in list)
                {
                    ite.ITEMNAME = item.ItemName;
                    ite.ILENGTH = item.ILength;
                    ite.IWIDTH = item.IWidth;
                    ite.JT_SIZE = item.JT_Size;
                    ite.ROWSTATUS = item.RowStatus;
                    ite.SHIPTYPE = item.Shiptype;
                    ///gogos
                    rows += en.SaveChanges();
                }
                if (rows > 0)
                    return true;
                return false;
            }
        }

        //"  SELECT ROWNUM AS num, cigarettecode,cigarettename,ccount ,orderqty  FROM" +
        //"(SELECT line.cigarettecode,line.cigarettename,count(*) as ccount,SUM(line.quantity)AS orderqty FROM t_produce_orderline line " +
        //" WHERE line.allowsort='非标' GROUP BY line.cigarettecode,line.cigarettename ORDER BY orderqty desc)";

        public static List<AllOrderData> GetUnCig() 
        {
            using (DZEntities en = new DZEntities()) 
            {
                List<AllOrderData> list = new List<AllOrderData>();
                list = en.T_PRODUCE_ORDERLINE.Where(item => item.ALLOWSORT == "非标").GroupBy(item => new { item.CIGARETTECODE, item.CIGARETTENAME }).
                    Select(item => new AllOrderData { CigaretteCode = item.Key.CIGARETTECODE, CigaretteName = item.Key.CIGARETTENAME, Count = item.Count(), QTY = item.Sum(x => x.QUANTITY)??0 }).OrderByDescending(item => item.QTY).ToList();
                return list;
            }
        }
    }
}
