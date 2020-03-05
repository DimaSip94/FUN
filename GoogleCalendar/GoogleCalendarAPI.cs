using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace GoogleCalendar
{
    public class GoogleCalendarAPI
    {
        private string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        private string ApplicationName = "Google Calendar API .NET Quickstart";
        private UserCredential credential;
        private CalendarService service;
        /// <summary>
        /// Конструктор API
        /// </summary>
        /// <param name="fileCredentialJson">файл с credentionl.json</param>
        /// <param name="username">имя пользователя</param>
        public GoogleCalendarAPI(string fileCredentialJson, string username)
        {
            try
            {
                using (var stream =
               new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    // The file token.json stores the user's access and refresh tokens, and is created
                    // automatically when the authorization flow completes for the first time.
                    string credPath = $"token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        username,
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                }
                service = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
            }
            catch(Exception exc)
            {
                throw new Exception($"Не удалось создать экземпляр класса, подробнее в исключении: {exc.Message}");
            }
        }

        /// <summary>
        /// Возвращает список событий
        /// </summary>
        /// <param name="timeMin">С какого времени забирать события</param>
        /// <param name="showDeleted">Показывать удаленные, по умолчанию false</param>
        /// <param name="singleEvents">Показывать единичные, по умолчанию true</param>
        /// <param name="maxResults">Максимальное количество событий, по умолчанию 100</param>
        /// <param name="orderBy">Сортировка событий</param>
        /// <returns></returns>
        public List<string> GetEvents(DateTime timeMin, bool showDeleted = false, bool singleEvents = true, int maxResults = 100, EventsResource.ListRequest.OrderByEnum orderBy = EventsResource.ListRequest.OrderByEnum.StartTime)
        {
            List<string> result = new List<string>();
            try
            {
                EventsResource.ListRequest request = service.Events.List("primary");
                request.TimeMin = timeMin;
                request.ShowDeleted = showDeleted;
                request.SingleEvents = singleEvents;
                request.MaxResults = maxResults;
                request.OrderBy = orderBy;

                // List events.
                Events events = request.Execute();
                if (events.Items != null && events.Items.Count > 0)
                {
                    foreach (var eventItem in events.Items)
                    {
                        string when = eventItem.Start.DateTime.ToString();
                        if (String.IsNullOrEmpty(when))
                        {
                            when = eventItem.Start.Date;
                        }
                        result.Add($"{eventItem.Summary} {when}");
                    }
                }
                else
                {
                    result.Add("События не найдены");
                }
            }
            catch(Exception exc)
            {
                result = new List<string>();
                result.Add("Eception Error: "+exc.Message);
            }
            return result;
            
        }


    }
}
