using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using ITA.BLL;

public partial class Index : System.Web.UI.Page
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
            //this.imgBanner1.ImageUrl = this.ResolveUrl(pics.Where(p => p.Position == "1").SingleOrDefault().FilePath);
            //this.hlinkBanner1.NavigateUrl = this.ResolveUrl(pics.Where(p => p.Position == "1").SingleOrDefault().Url);
            //this.imgBanner2.ImageUrl = this.ResolveUrl(pics.Where(p => p.Position == "2").SingleOrDefault().FilePath);
            //this.hlinkBanner2.NavigateUrl = this.ResolveUrl(pics.Where(p => p.Position == "2").SingleOrDefault().Url);
            //this.imgBanner3.ImageUrl = this.ResolveUrl(pics.Where(p => p.Position == "3").SingleOrDefault().FilePath);
            //this.hlinkBanner3.NavigateUrl = this.ResolveUrl(pics.Where(p => p.Position == "3").SingleOrDefault().Url);

            //Bind Categories
            //this.rptCategories.DataSource = this.LazyProjectBLL.GetLatestProjectForEachCategory();
            //this.rptCategories.DataBind();
        }
    }
}