using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Ajax;


public partial class Game : System.Web.UI.Page
{
    private object _locker = new object();

    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Game));

    }

    [Ajax.AjaxMethod()]
    public bool Save(string json)
    {
        try
        {
            using (TextWriter tw = new StreamWriter(Server.MapPath("~/game.txt"), false, System.Text.Encoding.UTF8))
            {
                tw.WriteLine(json);
            }
            return true;
        }
        catch { return false; }
    }

    [Ajax.AjaxMethod()]
    public string GetJSON()
    {
        try
        {
            using (TextReader tr = new StreamReader(Server.MapPath("~/game.txt"), System.Text.Encoding.UTF8))
            {
                return tr.ReadLine();
            }
        }
        catch { return null; }
    }
}