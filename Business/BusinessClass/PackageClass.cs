using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Modle;

namespace Business.BusinessClass
{
    public class PackageClass
    {
        public static List<string> GetAllRegion()
        {
            using (DZEntities en = new DZEntities())
            {
                List<string> list = new List<string>();
                list = en.T_PRODUCE_PACKAGECALLBACK.Select(item => item.ROTENAME).Distinct().ToList();
                return list;
            }
        }


        public static List<T_PRODUCE_PACKAGECALLBACK> GetPackInfoByRegion(string regionName) 
        {
            using (DZEntities en = new DZEntities()) 
            {
                List<T_PRODUCE_PACKAGECALLBACK> list = new List<T_PRODUCE_PACKAGECALLBACK>();
                string date = DateTime.Now.Date.ToString("yyyy-MM-dd");
                list = en.T_PRODUCE_PACKAGECALLBACK.Where(item => item.ROTENAME == regionName && item.ORDERDATE == date).OrderBy(item => item.DEVSEQ).ToList();
                return list;
            }
        }
    }
}
