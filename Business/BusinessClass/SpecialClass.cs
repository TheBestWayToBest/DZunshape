using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.BusinessClass
{
    public class SpecialClass
    {
        public static bool UpdateSpecialState(decimal sortnum,decimal pullstatus) 
        {
            using (DZEntities en = new DZEntities()) 
            {
                List<T_UN_POKE_HUNHE> hunhe=new List<T_UN_POKE_HUNHE> ();
                hunhe = en.T_UN_POKE_HUNHE.Where(item => item.SORTNUM == sortnum).ToList();
                foreach (var item in hunhe)
                {
                    item.PULLSTATUS = pullstatus;
                }
                return en.SaveChanges() > 0;
            }
        }
    }
}
