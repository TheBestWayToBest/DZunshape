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

        string _state;
        public string State
        {
            get
            {
                return _state;
            }
            set
            {
                if (value == "10")
                    _state = "正常";
                else if (value == "0")
                    _state = "禁用";
                else
                    _state = "";
            }
        }
       
        public decimal ThroughType { get; set; }
        public decimal CigaretteType { get; set; }
    }
}
