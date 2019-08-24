using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Modle
{
    public class SortInfo
    {
        //private string ctype;
        //public string Ctype 
        //{ 
        //    get
        //    { return ctype; } 
        //    set
        //    {
        //        if(value == "1")
        //        {
        //            ctype = "特异形烟道";
        //        }
        //        else if (value == "2")
        //        {
        //            if (value == "90")
        //                ctype = "立式烟仓混合道";
        //            else
        //                ctype = "立式烟仓";
        //        }
        //        else 
        //        {
        //            ctype = "卧式烟仓";
        //        }
        //    }
        //}
        public decimal Ctype { get; set; }
        public decimal MachineSeq { get; set; }
        public string CigaretteCode { get; set; }
        public string CigaretteName { get; set; }
        public decimal SortedNum { get; set; }
        public decimal UnSortNum { get; set; }
        public decimal TotalNum { get; set; }
    }
}
