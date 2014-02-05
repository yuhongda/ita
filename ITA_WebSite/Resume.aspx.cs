using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

public partial class Resume : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    /// <summary>
    /// Override InitializeCulture (For 本地化)
    /// </summary>
    protected override void InitializeCulture()
    {
        if (this.Session[Utils.SESSIONPREFERREDCULTURE] == null)
            this.Session[Utils.SESSIONPREFERREDCULTURE] = Request.UserLanguages[0];
        string UserCulture = this.Session[Utils.SESSIONPREFERREDCULTURE].ToString();
        if (!string.IsNullOrEmpty(UserCulture))
        {
            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(UserCulture);
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(UserCulture);

            //解决Win8下IE10本地化问题
            try
            {
                if (UserCulture == "zh-Hans")
                {
                    UserCulture = "zh-CN";
                }
                else if (UserCulture == "zh-Hant")
                {
                    UserCulture = "zh-TW";
                }
                Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(UserCulture);
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Thread.CurrentThread.CurrentCulture.Name, false);
            }
            catch (Exception ex)
            {
                throw new Exception(UserCulture);
            }
        }
    }
    protected void lbtnCN_Click(object sender, EventArgs e)
    {
        this.Session[Utils.SESSIONPREFERREDCULTURE] = "zh-CN";
        Response.Redirect(Request.Url.PathAndQuery);
    }
    protected void lbtnEN_Click(object sender, EventArgs e)
    {
        this.Session[Utils.SESSIONPREFERREDCULTURE] = "en-US";
        Response.Redirect(Request.Url.PathAndQuery);
    }
}