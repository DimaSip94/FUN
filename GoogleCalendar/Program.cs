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

            using (GoogleCalendarAPI googleCalendarAPI = new GoogleCalendarAPI("credentials.json", "dima"))
            {
                //List<string> events = googleCalendarAPI.GetEvents(DateTime.Now, DateTime.Now.AddYears(10), false, true, 1000, EventsResource.ListRequest.OrderByEnum.StartTime);
                //foreach (var ev in events)
                //    Console.WriteLine(ev);

                //googleCalendarAPI.TryEventCreated += EventCreated;
                //googleCalendarAPI.CreateEventAsync(DateTime.Now, DateTime.Now.AddDays(1), "Тестовая");

                Dictionary<string, string> calendars = googleCalendarAPI.GetCalendars();
                foreach (var ev in calendars)
                    Console.WriteLine($"{ev.Key} {ev.Value}");
            }

            Console.Read();
        }

        public static void EventCreated(CreateEventArgs createEventArgs)
        {
            Console.WriteLine($"{createEventArgs.message} {createEventArgs.id}");
        }
    }
}
