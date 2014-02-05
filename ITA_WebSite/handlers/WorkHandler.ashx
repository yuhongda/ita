<%@ WebHandler Language="C#" Class="WorkHandler" %>

using System;
using System.Web;
using System.Collections.Generic;
using ITA.BLL;
using ITA.Model;

public class WorkHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    Lazy_Yu<WorkBLL> lazyWorkBLL = new Lazy_Yu<WorkBLL>(() => new WorkBLL());
    public WorkBLL LazyWorkBLL
    {
        get { return this.lazyWorkBLL.Value; }
    }

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        //try
        //{
        int projectID = context.Request.Form["pid"].ToInt();
        List<WorkModel> works = this.LazyWorkBLL.GetWorksByProjectID(projectID).ToList<WorkModel>();
        context.Response.Write(works.ToJSON());
        //System.Text.RegularExpressions.Regex regDate = new System.Text.RegularExpressions.Regex(@"\\/Date\((\d+)\)\\/");
        //System.Text.RegularExpressions.Regex regMM = new System.Text.RegularExpressions.Regex(@"(\d+)");
        //string date = regDate.Match(jsonWorks).Value;
        //string mm = regMM.Match(date).Value;
        //string result = regDate.Replace(jsonWorks, mm);
        //context.Response.Write(result);

        //List<WorkModel> workmodels = new List<WorkModel>();
        //works.ForEach(w => workmodels.Add(new WorkModel() { Description = w.Description, FilePath = w.FilePath, ProjectID = w.ProjectID, PublishDate = DateTime.Now.ToString("yyyy-MM-dd"), WorkID = w.WorkID, WorkName = w.WorkName }));
        

        //context.Response.Write("[{\"WorkID\":2,\"WorkName\":\"sample9 - 副本 (2) - 副本.jpg\",\"FilePath\":\"~/UploadFiles/Works/20120223172446376e9792dbb991c4d11b292a934b6bbbb3d.jpg\",\"Description\":\"sample9 - 副本 (2) - 副本.jpg\",\"PublishDate\":\"1329989086387\",\"ProjectID\":7},{\"WorkID\":1,\"WorkName\":\"sample9 - 副本 - 副本.jpg\",\"FilePath\":\"~/UploadFiles/Works/20120223172446376a09ba161482947ce999c7ede0e3855ae.jpg\",\"Description\":\"sample9 - 副本 - 副本.jpg\",\"PublishDate\":\"1329989086387\",\"ProjectID\":7}]");
        //}
        //catch(Exception ex){
        //    context.Response.Write(ex.Message);
        //}
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}

public class WorkModel
{
    public int WorkID { get; set; }
    public string WorkName { get; set; }
    public string FilePath { get; set; }
    public string Description { get; set; }
    public DateTime PublishDate { get; set; }
    public int ProjectID { get; set; }
}