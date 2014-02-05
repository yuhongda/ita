using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITA.Model;
using System.IO;
using ITA.BLL;
using ITA.Utility;

public partial class Management_Works_Default : PageBase
{
    Lazy_Yu<WorkBLL> lazyWorkBLL = new Lazy_Yu<WorkBLL>(() => new WorkBLL());
    public WorkBLL LazyWorkBLL
    {
        get { return this.lazyWorkBLL.Value; }
    }

    Lazy_Yu<ProjectBLL> lazyProjectBLL = new Lazy_Yu<ProjectBLL>(() => new ProjectBLL());
    public ProjectBLL LazyProjectBLL
    {
        get { return this.lazyProjectBLL.Value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.DropDownListBind(this.ddlProjects, this.LazyProjectBLL.GetProjects(), "ProjectName", "ProjectID");
            this.ddlProjects.Items.Insert(0, new ListItem("请选择...", string.Empty));
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Session["file_info"] != null)
        {
            List<string> file_list_to_delete = new List<string>();
            try
            {
                List<Thumbnail> thumbnails = Session["file_info"] as List<Thumbnail>;
                List<Work> works = new List<Work>();

                string UploadPath = Server.MapPath(Misc.work_filepath);
                if (!System.IO.Directory.Exists(UploadPath))
                {
                    System.IO.Directory.CreateDirectory(UploadPath);
                }

                foreach (Thumbnail img in thumbnails)
                {
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(img.ID).ToLower();
                    file_list_to_delete.Add(Misc.work_filepath + "/" + filename);
                    FileStream fs = new FileStream(UploadPath + "\\" + filename, FileMode.Create);
                    BinaryWriter bw = new BinaryWriter(fs);
                    bw.Write(img.Data);
                    bw.Close();
                    fs.Close();

                    works.Add(new Work() { 
                        WorkName = img.FileName, 
                        Description = img.FileName, 
                        FilePath = Misc.work_filepath + "/" + filename, 
                        PublishDate = DateTime.Now, 
                        ProjectID = this.ddlProjects.SelectedValue.ToInt()
                    });
                }
                if (this.LazyWorkBLL.InsertWorks(works))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Key5", "javascript:" + string.Format("$({0}).text('{1}');$({0}).fadeIn();", this.panelMessage.ClientID, "上传成功!嘻嘻..."), true);
                }
                else
                {
                    throw new Exception("保存时发生错误");
                }
            }
            catch (Exception ex)
            {
                foreach (string file in file_list_to_delete)
                {
                    if (File.Exists(Server.MapPath(file)))
                    {
                        File.Delete(Server.MapPath(file));
                    }
                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Key3", "javascript:" + string.Format("$({0}).text('{1}');$({0}).fadeIn();", this.panelMessage.ClientID, "抱歉，保存时发生错误，请您重试。"), true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Key4", "javascript:setTimeout(function(){" + string.Format("$({0}).hide();window.location.reload();", this.panelMessage.ClientID) + "},5000);", true);
            }
            finally
            {
                Session.Remove("file_info");
            }
        }
    }
}