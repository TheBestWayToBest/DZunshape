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
                        ShortName = item.SHORTNAME,
                        BigBox_Bar = item.BIGBOX_BAR,
                        Weight = item.WEIGHT ?? 0,
                        ILength = item.ILENGTH ?? 0,
                        IWidth = item.IWIDTH ?? 0,
                        JZ_Size = item.JT_SIZE ?? 50
                    }).ToList();
                return query;
            }
        }
    }
}
