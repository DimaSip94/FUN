using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleCalendar
{
    class Program
    {
        static void Main(string[] args)
        {

            GoogleCalendarAPI googleCalendarAPI = new GoogleCalendarAPI("credentials.json", "dima");
            List<string> events = googleCalendarAPI.GetEvents(DateTime.Now, false, true, 1000, EventsResource.ListRequest.OrderByEnum.StartTime);
            foreach (var ev in events)
                Console.WriteLine(ev);
            Console.Read();

        }
    }
}
