using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Modle;

namespace Business.BusinessClass
{
    public class ItemClass
    {
        public static List<ItemInfo> GetItemInfo(int index,string shipType,decimal status, string condition = "-1")
        {
            using (DZEntities en = new DZEntities())
            {
                Func<T_WMS_ITEM, bool> fCondition;
                Func<T_WMS_ITEM, bool> func;
                
                if (index == 0 && condition != "-1" && condition != "")
                {
                    fCondition = item => item.ITEMNO.Contains(condition) && item.ROWSTATUS == status;
                }
                else if (index == 1 && condition != "-1" && condition != "")
                {
                    fCondition = item => item.ITEMNAME.Contains(condition) && item.ROWSTATUS == status;
                }
                else
                {
                    fCondition = item => true && item.ROWSTATUS == status;
                }
                if (shipType == "0")
                    func = item => item.SHIPTYPE == shipType;
                else
                    func = item => item.SHIPTYPE != "0";
                var query = en.T_WMS_ITEM.Where(fCondition).Where(func).Select(item =>
                    new ItemInfo
                    {
                        ItemNo = item.ITEMNO,
                        ItemName = item.ITEMNAME,
                        BigBox_Bar = item.BIGBOX_BAR,
                        ILength = item.ILENGTH ?? 0,
                        IWidth = item.IWIDTH ?? 0,
                        IHeight = item.IHEIGHT ?? 0,
                        JT_Size = item.JT_SIZE ?? 50,
                        RowStatus = item.ROWSTATUS ?? 0,
                        Shiptype = item.SHIPTYPE
                    }).OrderBy(item=>item.ItemNo).OrderBy(x => x.Shiptype).ToList();
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
                    ite.IHEIGHT = item.IHeight;
                    ite.JT_SIZE = item.JT_Size;
                    ite.ROWSTATUS = item.RowStatus;
                    ite.SHIPTYPE = item.Shiptype;
                    ite.BIGBOX_BAR = item.BigBox_Bar;
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


        public static List<ItemInfo> GetCig(int index,string condition) 
        {
            using (DZEntities en = new DZEntities()) 
            {
                List<ItemInfo> list = new List<ItemInfo>();
                if (condition == "")
                {
                    list = en.T_WMS_ITEM.Where(item => true).Select(item => new ItemInfo
                    {
                        ItemNo = item.ITEMNO,
                        ItemName = item.ITEMNAME,
                        BigBox_Bar = item.SHORTNAME,
                        ILength = 0,
                        IWidth = 0,
                        JT_Size = 0,
                        RowStatus = 0,
                        Shiptype = ""
                    }).ToList();
                }
                else 
                {
                    if (index == 0)
                    {
                        list = en.T_WMS_ITEM.Where(item => item.ITEMNO.Contains(condition)).Select(item => new ItemInfo
                        {
                            ItemNo = item.ITEMNO,
                            ItemName = item.ITEMNAME,
                            BigBox_Bar = item.SHORTNAME,
                            ILength = 0,
                            IWidth = 0,
                            JT_Size = 0,
                            RowStatus = 0,
                            Shiptype = ""
                        }).ToList();
                    }
                    else 
                    {
                        list = en.T_WMS_ITEM.Where(item => item.ITEMNAME.Contains(condition)).Select(item => new ItemInfo
                        {
                            ItemNo = item.ITEMNO,
                            ItemName = item.ITEMNAME,
                            BigBox_Bar = item.SHORTNAME,
                            ILength = 0,
                            IWidth = 0,
                            JT_Size = 0,
                            RowStatus = 0,
                            Shiptype = ""
                        }).ToList();
                    }
                }
                return list;
            }
        }
    }
}
