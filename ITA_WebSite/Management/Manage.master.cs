using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Management_Manage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 根据用户角色判断浏览权限
    /// </summary>
    /// <param name="currentNode"></param>
    /// <returns></returns>
    protected bool IsVisible(SiteMapNode currentNode)
    {
        if (currentNode.ResourceKey == "1")
        {
            SessionUser sessionUser = (SessionUser)this.Session[Utils.SESSIONUSER];

            if (sessionUser == null)
                return false;

            if (currentNode.Roles.Count > 0)
            {
                foreach (string userRole in sessionUser.Roles)
                {
                    if (currentNode.Roles.Contains(userRole))
                        return true;
                }
                return false;
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}
