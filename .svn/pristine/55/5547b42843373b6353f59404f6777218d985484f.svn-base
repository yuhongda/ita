using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITA.BLL;
using ITA.SQLServerDAL;
using System.IO;
using System.Data.SqlClient;

public partial class Management_Works_WorkList : RepeaterPagerBase
{
    Lazy_Yu<WorkBLL> lazyWorkBLL = new Lazy_Yu<WorkBLL>(() => new WorkBLL());
    public WorkBLL LazyWorkBLL
    {
        get { return this.lazyWorkBLL.Value; }
    }

    List<int> workIDs = new List<int>();


    protected void Page_Load(object sender, EventArgs e)
    {
        SqlParameter[] sp = new SqlParameter[] { 
            new SqlParameter ("@ProjectID", this.GetQueryString("ProjectID", false).ToInt())
        };
        this.RegistrPager(this.Repeater1, this.rptPageFliper, 7, this.FillPageMoudleWithParams(20, string.Format(ITA.SQLServerDAL.WorkDAL.sqlGetWorksByProjectID4Manage, "@ProjectID"), sp, new List<SortField>() { 
            new SortField() { FieldName = "WorkID", DESC = false }
        }));

    }

    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        List<string> file_list_to_delete = new List<string>();

        foreach (RepeaterItem item in this.Repeater1.Items)
        {
            CheckBox chk = (CheckBox)item.FindControl("chkCheck");
            if (chk.Checked)
            {
                HiddenField hidWorkID = (HiddenField)item.FindControl("hidWorkID");
                HyperLink hlnkUrl = (HyperLink)item.FindControl("hlnkUrl");
                file_list_to_delete.Add(hlnkUrl.ToolTip);
                workIDs.Add(hidWorkID.Value.ToInt());
            }
        }
        if (this.LazyWorkBLL.DeleteWorks(workIDs))
        {
            foreach (string file in file_list_to_delete)
            {
                if (File.Exists(Server.MapPath(file)))
                {
                    File.Delete(Server.MapPath(file));
                }
            }
        }
        this.BindPage(this.rptPageFliper.UniqueID, 1);
    }
}