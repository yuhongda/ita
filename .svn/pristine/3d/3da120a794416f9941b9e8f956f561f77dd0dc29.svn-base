using System;
using System.Data;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;
using System.Text;
using ITA.Utility;
using AdamTibi.Web.Security;
using ITA.BLL;
using System.Collections;
using ITA.Model;

/// <summary>
/// PageBase 的摘要说明
/// </summary>
public partial class PageBase : System.Web.UI.Page
{
    const string _pagebaseAttributes = "_@@_PAGEBASEATTRIBUTES";
    const string _prePageAttrib = "__PREPAGE";
    public ScriptManager scriptManager = null;

    Lazy_Yu<UserBLL> lazyUserBLL = new Lazy_Yu<UserBLL>(() => new UserBLL());
    public UserBLL LazyUserBLL
    {
        get { return this.lazyUserBLL.Value; }
    }

    public PageBase()
    {
        this.Load += new EventHandler(PageBase_Load);
        this.ViewState[_pagebaseAttributes] = new Dictionary<string, string>();
    }

    protected virtual void PageBase_Load(object sender, EventArgs e)
    {
        if (this.SessionUser == null)
        {
            HttpCookie cookie = Request.Cookies["ITACookies"];
            if (cookie != null)
            {
                try
                {
                    HttpCookie decodedCookie = HttpSecureCookie.Decode(cookie);
                    int userID = decodedCookie["ITAUserID"].ToInt();
                    DataTable dtUser = LazyUserBLL.GetUserByUserID(userID);
                    if (dtUser.Rows.Count > 0)
                    {
                        string user_IP = Request.ServerVariables.GetValues("REMOTE_ADDR")[0];

                        List<string> roles = new List<string>();
                        roles.Add(dtUser.Rows[0]["RoleID"].ToString());
                        SessionUser sessionUser = new SessionUser(dtUser.Rows[0]["UserID"].ToString(), dtUser.Rows[0]["UserName"].ToString(), roles, dtUser.Rows[0]["Email"].ToString());
                        this.Session[Utils.SESSIONUSER] = sessionUser;
                        System.Collections.Generic.List<string> onlineUsers = (System.Collections.Generic.List<string>)Application["GLOBAL_ONLINEUSER"];
                        if (!onlineUsers.Contains(sessionUser.UserID))
                        {
                            onlineUsers.Add(sessionUser.UserID);
                            Application["GLOBAL_ONLINEUSER"] = onlineUsers;
                        }
                    }
                    else
                    {
                        //this.lblErrorMsg.Text = "您输入的用户名Cookie已过期，请手动输入用户名和密码登录。";
                        //this.phPopup.Style["display"] = "block";
                    }
                }
                catch (Exception)
                {
                    //this.lblErrorMsg.Text = "您输入的用户名Cookie已过期，请手动输入用户名和密码登录。";
                    //this.phPopup.Style["display"] = "block";
                }
            }
        }
        //if (!this.IsPermission)
        //{
        //    Server.Transfer(string.Format("~/Error.aspx?code=DENYACCESS&url={0}", Request.RawUrl));
        //}
        if (this.Request[_prePageAttrib] != null && this.Request[_prePageAttrib] != string.Empty)
        {
            string path = this.Request[_prePageAttrib];
            PrePageConvert(ref path);
            this.AddAttributes(_prePageAttrib, path);
        }
        try
        {
            scriptManager = ScriptManager.GetCurrent(this.Page);
            if (scriptManager != null)
            {
                scriptManager.AsyncPostBackError += new EventHandler<AsyncPostBackErrorEventArgs>(scriptManager_AsyncPostBackError);
                scriptManager.AllowCustomErrorsRedirect = false;
            }
        }
        catch { }
    }

    public void scriptManager_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
    {
        //scriptManager.AsyncPostBackErrorMessage = e.Exception.Message;
        try
        {
            //Exception ex = Server.GetLastError();
            //if (ex != null)
            //{
            //    System.Xml.Linq.XDocument mailServerXML = System.Xml.Linq.XDocument.Load(Server.MapPath("~\\App_Data\\XMLData\\MailServerSettings.xml"));
            //    System.Collections.Generic.List<System.Net.Mail.MailMessage> mails = new System.Collections.Generic.List<System.Net.Mail.MailMessage>();
            //    System.Collections.Generic.List<ITA.Utility.MailUtils.MailException> mailException = new System.Collections.Generic.List<ITA.Utility.MailUtils.MailException>();
            //    var servers = from server in mailServerXML.Descendants("Server")
            //                  where server.Attribute("status") != null && server.Attribute("status").Value == "enable"
            //                  select new ITA.Model.MailServer
            //                  {
            //                      ExchangeServer = server.Element("ExchangeServer").Value,
            //                      Account = server.Element("Account").Value,
            //                      Password = server.Element("Password").Value
            //                  };
            //    ITA.Model.MailServer mailServer = servers.SingleOrDefault();

            //    System.Net.Mail.MailMessage _mailMessage = new System.Net.Mail.MailMessage();
            //    _mailMessage.From = new System.Net.Mail.MailAddress("webmaster@ita.com", "ITA");
            //    _mailMessage.To.Clear();
            //    _mailMessage.To.Add(new System.Net.Mail.MailAddress("yuhongda@ita.com"));
            //    _mailMessage.Subject = "[ITA] System Exception Mail";

            //    StringBuilder sb = new StringBuilder();
            //    sb.Append("Hello, ");
            //    sb.Append("<pre>A exception occurred on ITA Design Website. Below is the detailed information about this exception. </pre>");
            //    sb.Append("<hr>");
            //    sb.Append(string.Format("<h1>{0}</h1>", ex.Message));
            //    sb.Append(string.Format("<pre>{0}</pre>", ex.ToString()));
            //    sb.Append("<hr>");
            //    sb.Append("Sincerely,<br>");
            //    sb.Append("ITA Design");

            //    _mailMessage.Body = sb.ToString();
            //    mails.Add(_mailMessage);

            //    ITA.Utility.MailUtils mailUtils = new ITA.Utility.MailUtils(mailServer.ExchangeServer, mailServer.Account, mailServer.Password);
            //    mailException = mailUtils.SendMailArray(mails, true);
            //}
        }
        catch { }
    }

    protected virtual void PrePageConvert(ref string prePageKey)
    {

    }

    protected void GotoPrePage()
    {
        string prepage = this.GetAttributes(_prePageAttrib);
        if (prepage != string.Empty)
        {
            this.Response.Redirect(prepage);
        }
    }

    protected string GetPrePage()
    {
        return this.GetAttributes(_prePageAttrib);
    }

    public SessionUser SessionUser
    {
        get
        {
            if (this.Session[Utils.SESSIONUSER] == null)
            {
                return null;
            }
            else
            {
                return (SessionUser)this.Session[Utils.SESSIONUSER];
            }
        }
    }

    public string SessionUserID
    {
        get
        {
            if (this.SessionUser == null)
            {
                return string.Empty;
            }
            else
            {
                return this.SessionUser.UserID;
            }
        }
    }

    public List<string> SessionUserRoles
    {
        get
        {
            if (this.SessionUser == null)
            {
                return null;
            }
            else
            {
                return this.SessionUser.Roles;
            }
        }
    }

    #region 判断用户是否具有访问权限
    /// <summary>
    /// 判断用户是否具有访问权限
    /// </summary>
    public bool IsPermission
    {
        get
        {
            bool flag = false;

            if (SiteMap.Providers["WebSiteMap"].CurrentNode != null)
            {
                if (SiteMap.Providers["WebSiteMap"].CurrentNode.Roles.Count > 0)
                {
                    foreach (string userRole in this.SessionUserRoles)
                    {
                        if (SiteMap.Providers["WebSiteMap"].CurrentNode.Roles.Contains(userRole))
                        {
                            flag = true;
                            break;
                        }
                    }
                }
                else
                {
                    flag = true;
                }
            }
            else if (SiteMap.Providers["ManageSiteMap"].CurrentNode != null)
            {
                if (this.SessionUser != null)
                {
                    if (SiteMap.Providers["ManageSiteMap"].CurrentNode.Roles.Count > 0)
                    {
                        foreach (string userRole in this.SessionUserRoles)
                        {
                            if (SiteMap.Providers["ManageSiteMap"].CurrentNode.Roles.Contains(userRole))
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        flag = true;
                    }
                }
                else
                {
                    flag = false;
                }
            }
            else
            {
                flag = true;
            }
            return flag;
        }
    }
    #endregion

    public string GetAttributesFromRequest(string key, string requestKey)
    {
        try
        {
            Dictionary<string, string> dictionary = (Dictionary<string, string>)this.ViewState[_pagebaseAttributes];
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, this.Request[requestKey]);
            }

            return dictionary[key];
        }
        catch
        {
            return string.Empty;
        }
    }

    public string GetAttributes(string key)
    {
        try
        {
            Dictionary<string, string> dictionary = (Dictionary<string, string>)this.ViewState[_pagebaseAttributes];
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }
            else
            {
                return string.Empty;
            }
        }
        catch
        {
            return string.Empty;
        }
    }

    public bool AddAttributes(string key, string value)
    {
        bool result = false;
        try
        {
            Dictionary<string, string> dictionary = (Dictionary<string, string>)this.ViewState[_pagebaseAttributes];
            if (value == null)
            {
                value = string.Empty;
            }
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = value;
            }
            else
            {
                dictionary.Add(key, value);
            }
            this.ViewState[_pagebaseAttributes] = dictionary;
            result = true;
        }
        catch { }

        return result;
    }

    public bool RemoveAttributes(string key)
    {
        bool result = false;
        try
        {
            Dictionary<string, string> dictionary = (Dictionary<string, string>)this.ViewState[_pagebaseAttributes];
            result = dictionary.Remove(key);
            this.ViewState[_pagebaseAttributes] = dictionary;
        }
        catch { }

        return result;
    }

    public void DropDownListBind(DropDownList dropDownList, System.Data.DataTable table, string dataTextField, string dataValueField)
    {
        dropDownList.DataTextField = dataTextField;
        dropDownList.DataValueField = dataValueField;
        dropDownList.DataSource = table;
        dropDownList.DataBind();
    }

    public void DropDownListBind(System.Web.UI.HtmlControls.HtmlSelect dropDownList, System.Data.DataTable table, string dataTextField, string dataValueField)
    {
        dropDownList.DataTextField = dataTextField;
        dropDownList.DataValueField = dataValueField;
        dropDownList.DataSource = table;
        dropDownList.DataBind();
    }

    public void DropDownListBind(DropDownList dropDownList, object obj, string dataTextField, string dataValueField)
    {
        dropDownList.DataTextField = dataTextField;
        dropDownList.DataValueField = dataValueField;
        dropDownList.DataSource = obj;
        dropDownList.DataBind();
    }

    public void DropDownListFixByText(DropDownList dropDownList, string dataTextField)
    {
        ListItem item = dropDownList.Items.FindByText(dataTextField);
        dropDownList.SelectedIndex = dropDownList.Items.IndexOf(item);
    }

    public void DropDownListFixByValue(DropDownList dropDownList, string dataValueField)
    {
        ListItem item = dropDownList.Items.FindByValue(dataValueField);
        dropDownList.SelectedIndex = dropDownList.Items.IndexOf(item);
    }

    public void ListBoxBind(ListBox listBox, System.Data.DataTable table, string dataTextField, string dataValueField)
    {
        listBox.DataSource = table;
        listBox.DataTextField = dataTextField;
        listBox.DataValueField = dataValueField;
        listBox.DataBind();
    }

    public void ListBoxBind(ListBox listBox, DataView view, string dataTextField, string dataValueField)
    {
        listBox.DataSource = view;
        listBox.DataTextField = dataTextField;
        listBox.DataValueField = dataValueField;
        listBox.DataBind();
    }

    public void ListBoxRemove(ListBox sourceList, ListBox aimList)
    {
        int Isaddselect = 0;
        int intCount = sourceList.Items.Count;
        for (int i = 0; i < intCount; i++)
        {
            if (sourceList.Items[i].Selected)
            {
                ListItem item = sourceList.Items[i];
                ListItem newItem = new ListItem();
                newItem.Text = item.Text;
                newItem.Value = item.Value;
                aimList.Items.Add(newItem);
                sourceList.Items.Remove(item);
                i--;
                intCount--;
                Isaddselect = 1;
            }
        }
        if (Isaddselect == 0)
        {
            throw new Exception("请您选择要移动的内容!");
        }
    }

    public string GetQueryString(string queryString, bool IsEncrypt)
    {
        if (Request.QueryString[queryString] != null)
        {
            try
            {
                if (IsEncrypt)
                    return DESEncrypt.DecryptQueryString(Request.QueryString[queryString].ToString());
                else
                    return Request.QueryString[queryString].ToString();
            }
            catch (Exception ex)
            {
                Response.Redirect("~//Error.aspx");
                return null;
            }

        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Override InitializeCulture (For 本地化)
    /// </summary>
    //protected override void InitializeCulture()
    //{
    //    if (this.Session[Utils.SESSIONPREFERREDCULTURE] == null)
    //        this.Session[Utils.SESSIONPREFERREDCULTURE] = Request.UserLanguages[0];
    //    string UserCulture = this.Session[Utils.SESSIONPREFERREDCULTURE].ToString();
    //    if (!string.IsNullOrEmpty(UserCulture))
    //    {
    //        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(UserCulture);
    //        Thread.CurrentThread.CurrentUICulture = new CultureInfo(UserCulture);
    //    }
    //}
}