<%@ WebHandler Language="C#" Class="ProjectHandler" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using ITA.BLL;
using ITA.Model;

public class ProjectHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    
    Lazy_Yu<ProjectBLL> lazyProjectBLL = new Lazy_Yu<ProjectBLL>(() => new ProjectBLL());
    public ProjectBLL LazyProjectBLL
    {
        get { return this.lazyProjectBLL.Value; }
    }

    private List<Project> projects = null;
    public List<Project> Projects
    {
        get{
            if (this.projects == null)
            {
                projects = LazyProjectBLL.GetProjects().ToList<Project>();
            }
            return this.projects;
        }

    }
    int pagesize = 5;

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        int skip = context.Request.Form["skip"].ToInt();
        context.Response.Write(this.Projects.Skip<Project>(skip).Take<Project>(pagesize).ToJSON());
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}