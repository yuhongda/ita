using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITA.BLL;
using ITA.SQLServerDAL;

public partial class Management_Users_UserList : PagerBase
{

    Lazy_Yu<UserBLL> lazyUserBLL = new Lazy_Yu<UserBLL>(() => new UserBLL());
    public UserBLL LazyUserBLL
    {
        get { return this.lazyUserBLL.Value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.RegistrPager(this.GridView1, this.rptPageFliper, 7, this.FillPageMoudle(20, ITA.SQLServerDAL.WorkDAL.sqlGetWorks, new List<SortField>() { 
                    new SortField() { FieldName = "PublishDate", DESC = true }
                }));
        var users = this.LazyUserBLL.GetUserByUserID(1);
    }
}