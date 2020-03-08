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
    public class GoogleCalendarAPI:IDisposable
    {
        private bool disposed = false;

        public delegate void CreateEventHandler(CreateEventArgs createEventArgs);
        /// <summary>
        /// Возникает при попытке добавлении события в календарь
        /// </summary>
        public CreateEventHandler TryEventCreated;

        private string[] Scopes = { CalendarService.Scope.Calendar };
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
                using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
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
        /// /// <param name="timeMax">До какого времени забирать события</param>
        /// <param name="showDeleted">Показывать удаленные, по умолчанию False</param>
        /// <param name="singleEvents">Показывать единичные, по умолчанию False</param>
        /// <param name="maxResults">Максимальное количество событий, по умолчанию 250</param>
        /// <param name="orderBy">Сортировка событий</param>
        /// <param name="calendarId">Id календаря (по умолчанию primary)</param>
        /// <returns></returns>
        public List<string> GetEvents(DateTime timeMin, DateTime timeMax, bool showDeleted = false, bool singleEvents = false, int maxResults = 250, EventsResource.ListRequest.OrderByEnum orderBy = EventsResource.ListRequest.OrderByEnum.StartTime, string calendarId = "primary")
        {
            List<string> result = new List<string>();
            try
            {
                EventsResource.ListRequest request = service.Events.List(calendarId);
                request.TimeMin = timeMin;
                request.TimeMax = timeMax;
                request.ShowDeleted = showDeleted;
                request.SingleEvents = singleEvents;
                request.MaxResults = maxResults;
                request.OrderBy = orderBy;

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

        private CreateEventArgs CreateEvent(DateTime startEvent, DateTime endEvent, string summary, string calendarId)
        {
            CreateEventArgs result;
            try
            {
                Event body = new Event();
                body.Summary = summary;
                body.Start = GetEventDateTime(startEvent);
                body.End = GetEventDateTime(endEvent); 
                EventsResource.InsertRequest request = service.Events.Insert(body, calendarId);
                body = request.Execute();
                result = new CreateEventArgs(true, "Событие успешно создано", body.Id, body.ETag);
            }
            catch (Exception exc)
            {
                result = new CreateEventArgs(false, exc.Message, "", "");
            }
            return result;
        }

        /// <summary>
        /// Создает событие в календаре
        /// </summary>
        /// <param name="startEvent">Начало события</param>
        /// <param name="endEvent">Конец события</param>
        /// <param name="summary">Описание</param>
        /// <param name="calendarId">Id календаря (по умолчанию primary)</param>
        /// <returns></returns>
        public async Task<bool> CreateEventAsync(DateTime startEvent, DateTime endEvent, string summary, string calendarId="primary")
        {
            var task = await Task.Run(()=> {
                var tryCreateEvent = CreateEvent(startEvent, endEvent, summary, calendarId);
                TryEventCreated?.Invoke(tryCreateEvent);
                return tryCreateEvent.isSuccess;
            });
            return task;
        }

        /// <summary>
        /// Преобразует Datetime в Eventdatetime
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private EventDateTime GetEventDateTime(DateTime dateTime)
        {
            EventDateTime eventDateTime = new EventDateTime();
            eventDateTime.DateTime = dateTime;
            eventDateTime.TimeZone = "Europe/Moscow";
            return eventDateTime;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing && service!=null)
                {
                    service.Dispose();
                }
                disposed = true;
            }
        }

        /// <summary>
        /// Возвращает словарь (TKey-Id, TValue-Название) календарей
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetCalendars()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                CalendarListResource.ListRequest request = service.CalendarList.List();
                var calendarList = request.Execute();
                foreach (var cl in calendarList.Items)
                {
                    result.Add(cl.Id, cl.Summary);    
                }
            }
            catch (Exception exc)
            {
                result = new Dictionary<string, string>();
                result.Add("Error", "Eception Error: " + exc.Message);
            }
            return result;

        }


    }
}
