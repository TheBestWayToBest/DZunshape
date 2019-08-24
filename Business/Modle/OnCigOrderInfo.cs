using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Modle
{
    public class OnCigOrderInfo
    {
        public string RegionCode { get; set; }
        public string RegionDesc { get; set; }
        public string BillCode { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public decimal Num { get; set; }
        public decimal SortNum { get; set; }
    }
}
