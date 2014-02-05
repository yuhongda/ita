using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using ITA.BLL;
using ITA.Model;

public partial class _Default : PageBase
{
    private XDocument _datesourceXML;
    public XDocument DateSourceXML
    {
        get
        {
            if (this._datesourceXML == null)
                this._datesourceXML = XDocument.Load(Server.MapPath("~/App_Data/xmldata/datasource.xml"));
            return this._datesourceXML;
        }
    }
    Lazy_Yu<ProjectBLL> lazyProjectBLL = new Lazy_Yu<ProjectBLL>(() => new ProjectBLL());
    public ProjectBLL LazyProjectBLL
    {
        get { return this.lazyProjectBLL.Value; }
    }
    Lazy_Yu<CategoryBLL> lazyCategoryBLL = new Lazy_Yu<CategoryBLL>(() => new CategoryBLL());
    public CategoryBLL LazyCategoryBLL
    {
        get { return this.lazyCategoryBLL.Value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //Banner
            var pics = from server in this.DateSourceXML.Descendants("Pic")
                       select new
                       {
                           Position = server.Element("Position").Value,
                           Url = server.Element("Url").Value,
                           FilePath = server.Element("FilePath").Value
                       };
            this.imgBanner1.ImageUrl = this.ResolveUrl(pics.Where(p => p.Position == "1").SingleOrDefault().FilePath);
            this.hlinkBanner1.NavigateUrl = this.ResolveUrl(pics.Where(p => p.Position == "1").SingleOrDefault().Url);
            this.imgBanner2.ImageUrl = this.ResolveUrl(pics.Where(p => p.Position == "2").SingleOrDefault().FilePath);
            this.hlinkBanner2.NavigateUrl = this.ResolveUrl(pics.Where(p => p.Position == "2").SingleOrDefault().Url);
            this.imgBanner3.ImageUrl = this.ResolveUrl(pics.Where(p => p.Position == "3").SingleOrDefault().FilePath);
            this.hlinkBanner3.NavigateUrl = this.ResolveUrl(pics.Where(p => p.Position == "3").SingleOrDefault().Url);


            //Gallery
            var galleries = from server in this.DateSourceXML.Descendants("Gallery")
                       select new
                       {
                           Position = server.Element("Position").Value,
                           CategoryID = server.Element("CategoryID").Value
                       };
            List<Category> categories = this.LazyCategoryBLL.GetCategories().ToList<Category>();
            this.literCategoryName1.Text = HttpUtility.HtmlEncode(categories.Where(c => c.CategoryID == 1).SingleOrDefault().CategoryName);
            this.literCategoryName2.Text = HttpUtility.HtmlEncode(categories.Where(c => c.CategoryID == 2).SingleOrDefault().CategoryName);
            this.literCategoryName3.Text = HttpUtility.HtmlEncode(categories.Where(c => c.CategoryID == 3).SingleOrDefault().CategoryName);
            this.literCategoryName4.Text = HttpUtility.HtmlEncode(categories.Where(c => c.CategoryID == 4).SingleOrDefault().CategoryName);

            this.rptGallery1.ItemDataBound += new RepeaterItemEventHandler(rptGallery_ItemDataBound);
            this.rptGallery2.ItemDataBound += new RepeaterItemEventHandler(rptGallery_ItemDataBound);
            this.rptGallery3.ItemDataBound += new RepeaterItemEventHandler(rptGallery_ItemDataBound);
            this.rptGallery4.ItemDataBound += new RepeaterItemEventHandler(rptGallery_ItemDataBound);

            this.rptGallery1.DataSource = this.LazyProjectBLL.GetProjectsByCategoryID(1).ToList<Project>().Take(4);
            this.rptGallery1.DataBind();
            this.rptGallery2.DataSource = this.LazyProjectBLL.GetProjectsByCategoryID(2).ToList<Project>().Take(4);
            this.rptGallery2.DataBind();
            this.rptGallery3.DataSource = this.LazyProjectBLL.GetProjectsByCategoryID(3).ToList<Project>().Take(4);
            this.rptGallery3.DataBind();
            this.rptGallery4.DataSource = this.LazyProjectBLL.GetProjectsByCategoryID(4).ToList<Project>().Take(4);
            this.rptGallery4.DataBind();

            //Photoslider
        }
    }
    protected void rptGallery_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HyperLink hlnkProject = (HyperLink)e.Item.FindControl("hlnkProject");
            Image imgProject = (Image)e.Item.FindControl("imgProject");
            switch (e.Item.ItemIndex + 1)
            {
                case 1:
                    hlnkProject.Style["top"] = "40px";
                    hlnkProject.Style["left"] = "0px";
                    hlnkProject.CssClass = "switch_item current";
                    imgProject.Width = 444;
                    imgProject.Height = 180;
                    break;
                case 2:
                    hlnkProject.Style["top"] = "171px";
                    hlnkProject.Style["left"] = "466px";
                    hlnkProject.CssClass = "switch_item";
                    imgProject.Width = 120;
                    imgProject.Height = 49;
                    break;
                case 3:
                    hlnkProject.Style["top"] = "171px";
                    hlnkProject.Style["left"] = "608px";
                    hlnkProject.CssClass = "switch_item";
                    imgProject.Width = 120;
                    imgProject.Height = 49;
                    break;
                case 4:
                    hlnkProject.Style["top"] = "171px";
                    hlnkProject.Style["left"] = "750px";
                    hlnkProject.CssClass = "switch_item";
                    imgProject.Width = 120;
                    imgProject.Height = 49;
                    break;
                default:
                    break;
            }
        }
    }
}