using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.BusinessClass
{
    public class RegionClass
    {
        public static List<T_PRODUCE_REGIONMANAGE> GetRegionSort() 
        {
            using (DZEntities en = new DZEntities()) 
            {
                return en.T_PRODUCE_REGIONMANAGE.ToList();
            }
        }
    }
}
