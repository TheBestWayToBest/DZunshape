using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Modle
{
    public class Replenish
    {
        public decimal TaskNum { get; set; }
        public string RegionCode { get; set; }
        public string CustomerName { get; set; }
        public string ThroughNum { get; set; }
        public string CigaretteCode { get; set; }
        public string CigaretteName { get; set; }
        public decimal Num { get; set; }
        public decimal Status { get; set; }
        public string JY_Code { get; set; }
    }
}
