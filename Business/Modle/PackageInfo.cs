using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Modle
{
    public class PackageInfo
    {
        public string OrderDate { get; set; }
        public string BatchCode { get; set; }
        public string RoteCode { get; set; }
        public string RoteName { get; set; }
        public string CusCode { get; set; }
        public string CusName { get; set; }
        public string OrderId { get; set; }
        public decimal Devseq { get; set; }
        public string PackInfo { get; set; }
        public string PackNum { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public string PayState { get; set; }
    }
}
