using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.ComponentModel;
using System.Net;
using System.Configuration;

namespace ITA.Utility
{
    public class MailUtils
    {
        List<MailException> mailException = new List<MailException>();
        private string _ExchangeServer;// = System.Configuration.ConfigurationSettings.AppSettings["ExchangeServer"].ToString();
        public string ExchangeServer
        {
            get
            {
                return _ExchangeServer;
            }
            set
            {
                _ExchangeServer = value;
            }
        }
        private string _ExchangeServerUserName;// = System.Configuration.ConfigurationSettings.AppSettings["ExchangeServerUserName"].ToString();
        public string ExchangeServerUserName
        {
            get
            {
                return _ExchangeServerUserName;
            }
            set
            {
                _ExchangeServerUserName = value;
            }
        }
        private string _ExchangeServerPassword;// = System.Configuration.ConfigurationSettings.AppSettings["ExchangeServerPassword"].ToString();
        public string ExchangeServerPassword
        {
            get
            {
                return _ExchangeServerPassword;
            }
            set
            {
                _ExchangeServerPassword = value;
            }
        }

        public MailUtils(string exchangeServer, string exchangeServerUserName, string exchangeServerPassword)
        {
            this.ExchangeServer = exchangeServer;
            this.ExchangeServerUserName = exchangeServerUserName;
            this.ExchangeServerPassword = exchangeServerPassword;
        }

        public List<MailException> SendMailArray(List<MailMessage> mails, bool isAyn)
        {
            if (this.mailException != null)
            {
                this.mailException.Clear();
            }
            
            foreach (MailMessage mail in mails)
            {
                SmtpClient smtpClient = new SmtpClient(this.ExchangeServer);
                smtpClient.Credentials = new NetworkCredential(this.ExchangeServerUserName, this.ExchangeServerPassword);
                smtpClient.Port = 587;//smtpClient.Port = 25;
                //smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;

                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                try
                {
                    if (isAyn)
                    {
                        smtpClient.SendCompleted += new SendCompletedEventHandler(this.SendCompletedCallback);
                        smtpClient.SendAsync(mail, mail.To[0].ToString());
                    }
                    else
                    {
                        smtpClient.Send(mail);
                    }
                }
                catch (Exception ex)
                {
                    if (this.mailException != null && mail.To.Count > 0)
                    {
                        this.mailException.Add(new MailException(ex.Message.ToString(), mail.To[0].ToString()));
                    }
                }
            }
            return this.mailException;
        }

        public void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            lock (this)
            {
                string token = (string)e.UserState;

                if (e.Error != null)
                {
                    this.mailException.Add(new MailException(e.Error.ToString(), token));
                }
            }
        }


        public class MailException : System.Exception
        {
            public MailException(string message, string address)
                : base(message)
            {
                Address = address;
            }

            public string Address = string.Empty;
        }
    }
}
