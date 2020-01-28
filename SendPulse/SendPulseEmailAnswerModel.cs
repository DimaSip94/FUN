using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.API.SendPulse
{
    public class SendPulseEmailAnswerModel
    {
        public bool result { get; set; }
        public string id { get; set; }
        public string error_code { get; set; }
        public string message { get; set; }
    }
}
