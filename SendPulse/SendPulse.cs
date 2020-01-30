using BLL.Core.I;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.API.SendPulse
{
    public class SendPulse 
    {       
        private static SendPulse instance;
        private static object syncRoot = new Object();

        //link documentation https://sendpulse.ua/integrations/api
        private const string baseUrl = "https://api.sendpulse.com";
        private const string oauthLink = "/oauth/access_token";
        private const string sendEmailLink = "/smtp/emails";
        private const string allowDomainsLink = "/smtp/domains";
        private const string sendSMSLink = "/sms/send";

        private string clientId = "";
        private string clientSecret = "";
        private DateTime TokenDeadline = DateTime.Now;
        /// <summary>
        /// Oauth token, use this in each request to API like parameter cookie 
        /// Simple: Authorization: Bearer tf4Si1LydYpTAPyHXUgjig72jlrd5HpIJL5oigmc
        /// </summary>
        private string token = "";
        private string Token
        {
            get
            {
                if (string.IsNullOrEmpty(token) || TokenDeadline < DateTime.Now)
                {
                    SimpleBrowser simpleBrowser = new SimpleBrowser(baseUrl);
                    string answer = simpleBrowser.PostJSON(oauthLink, new SendPulseOauthReqestModel
                    { 
                        client_id = clientId,
                        client_secret = clientSecret,
                        grant_type = "client_credentials"
                    }).Result;
                    try
                    {
                        SendPulseOauthAnswerModel modelAnswer = JsonConvert.DeserializeObject<SendPulseOauthAnswerModel>(answer);
                        token = modelAnswer.access_token;
                        TokenDeadline = DateTime.Now.AddMinutes(modelAnswer.expires_in / 60);
                    }
                    catch
                    {
                        token = "";
                    }
                }
                return token;
            }
        }

        protected SendPulse(string clientId, string clientSecret)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
        }

        /// <summary>
        /// Send Pulse API
        /// </summary>
        /// <param name="clientId">Your API ID</param>
        /// <param name="clientSecret">Your API Secret</param>
        public static SendPulse getInstance(string clientId, string clientSecret)
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    instance = new SendPulse(clientId, clientSecret);
                }
            }
            return instance;
        }

        /// <summary>
        /// List allow domains for sender
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> GetAllowDomains()
        {
            List<string> domains = new List<string>();
            try
            {
                SimpleBrowser simpleBrowser = new SimpleBrowser(baseUrl);
                string answer = await simpleBrowser.Get(allowDomainsLink, bearerAccessToken: Token);
                domains = JsonConvert.DeserializeObject<List<string>>(answer);
            }
            catch 
            {
                domains = null;
            }
            return domains;
        }

        /// <summary>
        /// Add New Sender domain
        /// </summary>
        /// <param name="email">email</param>
        /// <returns></returns>
        public async Task<bool> AddNewDomain(string email)
        {
            bool result = false;
            try
            {
                SimpleBrowser simpleBrowser = new SimpleBrowser(baseUrl);
                string answer = await simpleBrowser.PostJSON(allowDomainsLink, new { email = email }, Token);
                result = answer == "result=true";
            }
            catch
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Send Email
        /// </summary>
        /// <param name="fromMail">From Email</param>
        /// <param name="fromName">From Name</param>
        /// <param name="toEmailsName">List name and emails TO</param>
        /// <param name="subject">Subject</param>
        /// <param name="body">Body</param>
        /// <param name="attachments">Files</param>
        /// <returns></returns>
        public SendPulseEmailAnswerModel SendEmail(string fromMail, string fromName, Dictionary<string, string> toEmailsName, string subject, string body, List<string> attachments = null)
        {
            SendPulseEmailAnswerModel result = new SendPulseEmailAnswerModel();
            try
            {
                SimpleBrowser simpleBrowser = new SimpleBrowser(baseUrl);
                attachments = attachments ?? new List<string>();
                Dictionary<string, string> attachments_binary = new Dictionary<string, string>();
                foreach (var at in attachments)
                {
                    Byte[] bytes = File.ReadAllBytes(at);
                    String file = Convert.ToBase64String(bytes);
                    attachments_binary.Add(at, file);
                }

                List<SendPulseAddressObject> toMails = new List<SendPulseAddressObject>();
                foreach (var em in toEmailsName) toMails.Add(new SendPulseAddressObject { email = em.Key, name = em.Value });

                string answer = simpleBrowser.PostJSON(sendEmailLink, new SendPulseEmailModel
                {
                    email = new SendPulseEmailObject
                    { 
                        from = new SendPulseAddressObject { email = "c-rbadinb1@c-rb.com"/*fromMail*/, name = fromName },
                        html = "",
                        subject = subject,
                        text = body,
                        to = toMails,
                        attachments_binary = attachments_binary
                    }
                }, Token).Result;
                result = JsonConvert.DeserializeObject<SendPulseEmailAnswerModel>(answer);
            }
            catch (Exception exc)
            {
                result.error_code = "503";
                result.message = exc.Message;
            }
            return result;
        }

        /// <summary>
        /// Send SMS
        /// </summary>
        /// <param name="sender">sender name</param>
        /// <param name="phones">array phones</param>
        /// <param name="body">body message</param>
        /// <param name="isEmulate">1 or 0 , translit body</param>
        /// <param name="isTranslit">is translit text</param>
        /// <returns></returns>
        public SendPulseSMSAnswerModel SendSMS(string sender, string [] phones, string body, bool isTranslit = false, bool isEmulate = false)
        {
            SendPulseSMSAnswerModel result = new SendPulseSMSAnswerModel();
            try
            {
                SimpleBrowser simpleBrowser = new SimpleBrowser(baseUrl);
                SendPulseSMSModel sendPulseSMSModel = new SendPulseSMSModel();
                sendPulseSMSModel.sender = "TestSender";//sender;
                sendPulseSMSModel.phones = phones;
                sendPulseSMSModel.body = body;
                sendPulseSMSModel.transliterate = isTranslit ? 1 : 0;
                sendPulseSMSModel.emulate = isEmulate ? 1 : 0;
                string answer = simpleBrowser.PostJSON(sendSMSLink, sendPulseSMSModel, Token).Result;
                SendPulseSMSAnswerModel answerObject = JsonConvert.DeserializeObject<SendPulseSMSAnswerModel>(answer);
            }
            catch (Exception exc)
            {
                result.result = false;
                result.error_code = "503";
                result.message = exc.Message;
            }
            return result;
        }

        /// <summary>
        /// Send Email Async
        /// </summary>
        /// <param name="fromMail">From Email</param>
        /// <param name="fromName">From Name</param>
        /// <param name="toEmailsName">List name and emails TO</param>
        /// <param name="subject">Subject</param>
        /// <param name="body">Body</param>
        /// /// <param name="attachments">Files</param>
        /// <returns></returns>
        public async Task<SendPulseEmailAnswerModel> SendEmailAsync(string fromMail, string fromName, Dictionary<string, string> toEmailsName, string subject, string body, List<string> attachments = null)
        {
            SendPulseEmailAnswerModel res = new SendPulseEmailAnswerModel();
            res = await Task.Run(()=> {
                return SendEmail(fromMail, fromName, toEmailsName, subject, body, attachments);
            });
            return res;
        }

        /// <summary>
        /// Send SMS
        /// </summary>
        /// <param name="sender">number of s</param>
        /// <param name="phones">array phones</param>
        /// <param name="body">body message</param>
        /// <param name="isEmulate">1 or 0 , translit body</param>
        /// <param name="isTranslit">is translit text</param>
        /// <returns></returns>
        public async Task<SendPulseSMSAnswerModel> SendSMSAsync(string sender, string[] phones, string body, bool isTranslit = false, bool isEmulate = false)
        {
            SendPulseSMSAnswerModel res = new SendPulseSMSAnswerModel();
            res = await Task.Run(() => {
                return SendSMS(sender, phones, body, isTranslit, isEmulate);
            });
            return res;
        }
    }
}
