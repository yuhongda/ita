<%@ WebHandler Language="C#" Class="MailHandler" %>

using System;
using System.Web;
using System.Net.Mail;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using ITA.Utility;
using ITA.Model;
using System.Text;

public class MailHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{

    private XDocument _mailServerXML;
    public XDocument MailServerXML
    {
        get
        {
            if (this._mailServerXML == null)
                this._mailServerXML = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/xmldata/MailServerSettings.xml"));
            return this._mailServerXML;
        }
    }
    private string strMailBody = "Hi，<p><b>姓名：</b></p><p>{0}</p><p><b>公司名称：</b></p><p>{1}</p><p><b>邮箱地址：</b></p><p>{2}</p><p><b>联系电话：</b></p><p>{3}</p><p><b>我的公司网址是：</b></p><p>{4}</p><p><b>详细需求描述：</b></p><p>{5}</p>";
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        List<MailMessage> mails = new List<MailMessage>();
        List<MailUtils.MailException> mailException = new List<MailUtils.MailException>();
        var servers = from server in this.MailServerXML.Descendants("Server")
                      where server.Attribute("status") != null && server.Attribute("status").Value == "enable"
                      select new MailServer
                      {
                          ExchangeServer = server.Element("ExchangeServer").Value,
                          Account = server.Element("Account").Value,
                          Password = server.Element("Password").Value
                      };
        MailServer mailServer = servers.SingleOrDefault();

        Mail mail = context.Request.Form["maildata"].ToString().FromJsonTo<Mail>();
        MailMessage _mailMessage = new MailMessage();
        _mailMessage.From = new MailAddress("itadesign.stuido@gmail.com", "customer");
        _mailMessage.To.Clear();
        _mailMessage.To.Add(new MailAddress("63366736@qq.com"));
        //_mailMessage.To.Add("silverage.y@gmail.com");
        _mailMessage.Subject = "From itaDesign Website";
        
        _mailMessage.Body = string.Format(strMailBody, mail.Name, mail.Company, mail.Email, mail.Phone, mail.Website, HttpUtility.HtmlDecode(mail.Desc));
        mails.Add(_mailMessage);

        MailUtils mailUtils = new MailUtils(mailServer.ExchangeServer, mailServer.Account, mailServer.Password);
        mailException = mailUtils.SendMailArray(mails, true);

        context.Response.Write(new JSONStatus() { Status = (mailException.Count==0).ToString() }.ToJSON());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}