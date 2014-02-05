using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITA.BLL;
using ITA.Model;
using ITA.Utility;

public partial class Case : PageBase
{
    Lazy_Yu<ProjectBLL> lazyProjectBLL = new Lazy_Yu<ProjectBLL>(() => new ProjectBLL());
    public ProjectBLL LazyProjectBLL
    {
        get { return this.lazyProjectBLL.Value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //Project project = this.LazyProjectBLL.GetProjectsByProjectID(this.GetQueryString("projectID", false).ToInt()).ToList<Project>().SingleOrDefault();
        //if (project != null)
        //{
        //    this.projectLogo.ImageUrl = this.ResolveUrl(project.ProjectLogo);
        //    this.info.CssClass = "info " + (project.TextPos == 0 ? "left" : "right");
        //    this.projectName.Text = project.ProjectName;
        //    this.projectDesc.Text = project.ProjectDescription;
        //}
    }

    protected string GetCaseUrl()
    {
        return string.Format(Utils.GetRootURI()+"/UploadFiles/Cases/{0}/", this.GetQueryString("projectID", false));
    }
}