using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCalendar
{
    public class CreateEventArgs
    {
        public bool isSuccess { get; set; }
        public string message { get; set; }
        public string id { get; set; }
        public string etag { get; set; }
        public CreateEventArgs(bool isSuccess, string message, string id, string etag)
        {
            this.isSuccess = isSuccess;
            this.message = message;
            this.id = id;
            this.etag = etag;
        }
    }
}
