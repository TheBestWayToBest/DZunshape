using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Modle
{
    public class ExportInfo
    {
        public string BatchCode { get; set; }
        public decimal QTY { get; set; }
        public int CusCount { get; set; }
        public decimal Synseq { get; set; }
        public int RegionCount { get; set; }
    }
}
