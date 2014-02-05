using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITA.BLL;
using ITA.Model;
using System.IO;
using ITA.Utility;
using ITA.SQLServerDAL;

public partial class Management_Projects_Default : PagerBase
{
    Lazy_Yu<CategoryBLL> lazyCategoryBLL = new Lazy_Yu<CategoryBLL>(() => new CategoryBLL());
    public CategoryBLL LazyCategoryBLL
    {
        get { return this.lazyCategoryBLL.Value; }
    }
    Lazy_Yu<ProjectBLL> lazyProjectBLL = new Lazy_Yu<ProjectBLL>(() => new ProjectBLL());
    public ProjectBLL LazyProjectBLL
    {
        get { return this.lazyProjectBLL.Value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.RegistrPager(this.GridView1, this.rptPageFliper, 7, this.FillPageMoudle(20, ITA.SQLServerDAL.ProjectDAL.sqlGetProjects, new List<SortField>() { 
                    new SortField() { FieldName = "ProjectID", DESC = true }
                }));
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.lblID.Text.Trim()))
        {
            //ADD
            if (this.FileUpload1.HasFile)
            {
                if (!System.IO.Directory.Exists(Server.MapPath(Misc.filepath)))
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(Misc.filepath));
                }
                string filename = DateTime.Now.ToString("yyyyMMdd") + Guid.NewGuid().ToString().Replace("-", string.Empty) + System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                this.FileUpload1.PostedFile.SaveAs(Server.MapPath(Misc.filepath) + "/" + filename);
                this.AddAttributes("LogoPathTemp", Server.MapPath(Misc.filepath) + "/" + filename);

                bool result = this.LazyProjectBLL.InsertProject(new Project()
                {
                    ProjectName = this.txtName.Text.Trim(),
                    ProjectLogo = Misc.filepath + "/" + filename,
                    ProjectDate = DateTime.Now,
                    ProjectDescription = this.txtDesc.Text.Trim(),
                    CategoryID = this.ddlCategories.SelectedValue.ToInt(),
                    TextPos = this.ddlPos.SelectedValue.ToInt()
                });

                if (!result)
                {
                    if (!string.IsNullOrEmpty(this.GetAttributes("LogoPathTemp")))
                    {
                        if (File.Exists(this.GetAttributes("LogoPathTemp")))
                        {
                            File.Delete(this.GetAttributes("LogoPathTemp"));
                        }
                    }
                    this.lblError.Text = "出错啦！！";
                }
                else
                {
                    this.lblError.Text = "嘻嘻！！";
                }
            }
        }
        else
        {
            //EDIT
            string filename = DateTime.Now.ToString("yyyyMMdd") + Guid.NewGuid().ToString().Replace("-", string.Empty) + System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
            string oldFilename = this.GetAttributes("OldLogoFilename");
            if (this.FileUpload1.HasFile)
            {
                if (!System.IO.Directory.Exists(Server.MapPath(Misc.filepath)))
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(Misc.filepath));
                }
                if (!string.IsNullOrEmpty(this.GetAttributes("OldLogoPath")))
                {
                    if (File.Exists(this.GetAttributes("OldLogoPath")))
                    {
                        File.Delete(this.GetAttributes("OldLogoPath"));
                    }
                }
                this.FileUpload1.PostedFile.SaveAs(Server.MapPath(Misc.filepath) + "/" + filename);
                this.AddAttributes("LogoPathTemp", Server.MapPath(Misc.filepath) + "/" + filename);
            }
            bool result = this.LazyProjectBLL.UpdateProject(new Project()
            {
                ProjectID = this.lblID.Text.Trim().ToInt(),
                ProjectName = this.txtName.Text.Trim(),
                ProjectLogo = this.FileUpload1.HasFile ? Misc.filepath + "/" + filename : oldFilename,
                ProjectDate = DateTime.Now,
                ProjectDescription = this.txtDesc.Text.Trim(),
                CategoryID = this.ddlCategories.SelectedValue.ToInt(),
                TextPos = this.ddlPos.SelectedValue.ToInt()
            });

            if (!result)
            {
                if (!string.IsNullOrEmpty(this.GetAttributes("LogoPathTemp")))
                {
                    if (File.Exists(this.GetAttributes("LogoPathTemp")))
                    {
                        File.Delete(this.GetAttributes("LogoPathTemp"));
                    }
                }
                this.lblError.Text = "出错啦！！";
            }
            else
            {
                this.lblError.Text = "嘻嘻！！";
            }
        }
        this.BindPage(this.rptPageFliper.UniqueID, 1);
        this.ResetForm();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        this.Panel1.Visible = true;
        this.lblDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
        this.DropDownListBind(this.ddlCategories, this.LazyCategoryBLL.GetCategories(), "CategoryName", "CategoryID");

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "MOD")
        {
            try
            {
                this.Panel1.Visible = true;
                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
                string strID = ((Label)this.GridView1.Rows[row.RowIndex].Cells[1].FindControl("lblID")).Text.Trim();
                string strName = ((Label)this.GridView1.Rows[row.RowIndex].Cells[2].FindControl("lblName")).Text.Trim();
                string strLogoPath = ((Image)this.GridView1.Rows[row.RowIndex].Cells[3].FindControl("imgLogo")).ImageUrl.Trim();
                string strDesc = ((Label)this.GridView1.Rows[row.RowIndex].Cells[4].FindControl("lblDescription")).Text.Trim();
                string strDate = ((Label)this.GridView1.Rows[row.RowIndex].Cells[5].FindControl("lblDate")).Text.Trim();
                string categoryID = ((HiddenField)this.GridView1.Rows[row.RowIndex].Cells[6].FindControl("hidCategoryID")).Value.Trim();
                string oldProjectLogo = ((HiddenField)this.GridView1.Rows[row.RowIndex].Cells[3].FindControl("hidProjectLogo")).Value.Trim();
                string pos = ((HiddenField)this.GridView1.Rows[row.RowIndex].Cells[7].FindControl("hidPos")).Value.Trim();


                this.lblID.Text = strID;
                this.txtName.Text = strName;
                this.imgLogo.ImageUrl = this.ResolveUrl(strLogoPath);
                this.AddAttributes("OldLogoPath", Server.MapPath(oldProjectLogo));
                this.AddAttributes("OldLogoFilename", oldProjectLogo);
                this.txtDesc.Text = strDesc;
                this.lblDate.Text = strDate;
                this.DropDownListBind(this.ddlCategories, this.LazyCategoryBLL.GetCategories(), "CategoryName", "CategoryID");
                this.ddlCategories.SelectedIndex = this.ddlCategories.Items.IndexOf(this.ddlCategories.Items.FindByValue(categoryID));
                this.ddlPos.SelectedIndex = this.ddlPos.Items.IndexOf(this.ddlPos.Items.FindByValue(pos));
            }
            catch { }
        }
        else if (e.CommandName == "DEL")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            string strID = ((Label)this.GridView1.Rows[row.RowIndex].Cells[1].FindControl("lblID")).Text.Trim();
            this.LazyProjectBLL.DeleteProject(strID.ToInt());
            this.BindPage(this.rptPageFliper.UniqueID, 1);
        }
        else if (e.CommandName == "MOD_WORK")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            string strID = ((Label)this.GridView1.Rows[row.RowIndex].Cells[1].FindControl("lblID")).Text.Trim();
            Response.Redirect("~/Management/Works/WorkList.aspx?ProjectID=" + strID);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ResetForm();
    }

    private void ResetForm()
    {
        this.Panel1.Visible = false;
        this.lblID.Text = string.Empty;
        this.txtName.Text = string.Empty;
        this.imgLogo.ImageUrl = string.Empty;
        this.txtDesc.Text = string.Empty;
        this.lblDate.Text = string.Empty;
        this.DropDownListBind(this.ddlCategories, this.LazyCategoryBLL.GetCategories(), "CategoryName", "CategoryID");
        this.lblError.Text = string.Empty;
    }
}