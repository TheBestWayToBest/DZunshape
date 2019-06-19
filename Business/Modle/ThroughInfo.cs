using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Modle
{
    public class ThroughInfo
    {
        public string ThroughNum { get; set; }
        public decimal ID { get; set; }
        public decimal MachineSeq { get; set; }
        public string CigaretteCode { get; set; }
        public string CigaretteName { get; set; }
        public string State
        {
            get { return State; }
            set
            {
                if (value == "10")
                    State = "正常";
                else
                    State = "禁用";
            }
        }
       
        public string ThroughType { get; set; }
        public string CigeretteType { get; set; }
    }
}
