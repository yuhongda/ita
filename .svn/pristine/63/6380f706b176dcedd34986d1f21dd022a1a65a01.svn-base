<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        Application["GLOBAL_ONLINEUSER"] = new System.Collections.Generic.List<string>();

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        string strUserName = User.Identity.Name;
        string strIPAddress = Request.ServerVariables.GetValues("REMOTE_ADDR")[0];

        SessionUser sessionUser = new SessionUser(System.Guid.NewGuid().ToString(), "TempUser", new System.Collections.Generic.List<string>() { "0" }, string.Empty);
        this.Session[Utils.SESSIONUSER] = sessionUser;

        System.Collections.Generic.List<string> onlineUsers = (System.Collections.Generic.List<string>)Application["GLOBAL_ONLINEUSER"];
        onlineUsers.Add(sessionUser.UserName);
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        
        SessionUser sessionUser = (SessionUser)this.Session[Utils.SESSIONUSER];
        if (sessionUser != null)
        {
            System.Collections.Generic.List<string> onlineUsers = (System.Collections.Generic.List<string>)Application["GLOBAL_ONLINEUSER"];
            onlineUsers.Remove(sessionUser.UserID);
            Application["GLOBAL_ONLINEUSER"] = onlineUsers;
        }
    }

    void Application_BeginRequest(object sender, EventArgs e)
    {
        var Request = HttpContext.Current.Request;
        var Response = HttpContext.Current.Response;
        /* Fix for the Flash Player Cookie bug in Non-IE browsers.
         * Since Flash Player always sends the IE cookies even in FireFox
         * we have to bypass the cookies by sending the values as part of the POST or GET
         * and overwrite the cookies with the passed in values.
         * 
         * The theory is that at this point (BeginRequest) the cookies have not been read by
         * the Session and Authentication logic and if we update the cookies here we'll get our
         * Session and Authentication restored correctly
         */

        try
        {
            string session_param_name = "ASPSESSID";
            string session_cookie_name = "ASP.NET_SESSIONID";

            if (HttpContext.Current.Request.Form[session_param_name] != null)
            {
                UpdateCookie(session_cookie_name, HttpContext.Current.Request.Form[session_param_name]);
            }
            else if (HttpContext.Current.Request.QueryString[session_param_name] != null)
            {
                UpdateCookie(session_cookie_name, HttpContext.Current.Request.QueryString[session_param_name]);
            }
        }
        catch (Exception)
        {
            Response.StatusCode = 500;
            Response.Write("Error Initializing Session");
        }
    }
    static void UpdateCookie(string cookie_name, string cookie_value)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(cookie_name);
        if (cookie == null)
        {
            cookie = new HttpCookie(cookie_name);
            //SWFUpload 的Demo中给的代码有问题，需要加上cookie.Expires 设置才可以
            cookie.Expires = DateTime.Now.AddYears(1);
            HttpContext.Current.Request.Cookies.Add(cookie);
        }
        cookie.Value = cookie_value;
        HttpContext.Current.Request.Cookies.Set(cookie);
    }
       
</script>
