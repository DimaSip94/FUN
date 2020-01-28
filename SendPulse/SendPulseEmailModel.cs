using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.API.SendPulse
{
    public class SendPulseEmailModel
    {
        public SendPulseEmailObject email {get;set;}
    }

    public class SendPulseEmailObject
    {
        public string html { get; set; }
        public string text { get; set; }
        public string subject { get; set; }
        public SendPulseAddressObject from { get; set; }
        public List<SendPulseAddressObject> to { get; set; }
        public Dictionary<string,string> attachments_binary { get; set; }
    }

    public class SendPulseAddressObject
    {
        public string name { get; set; }
        public string email { get; set; }
    }
}
