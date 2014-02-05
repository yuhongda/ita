using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITA.BLL;

public partial class Management_Categories_Default : System.Web.UI.Page
{
    Lazy_Yu<CategoryBLL> lazyCategoryBLL = new Lazy_Yu<CategoryBLL>(() => new CategoryBLL());
    public CategoryBLL LazyCategoryBLL
    {
        get { return this.lazyCategoryBLL.Value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.GridView1.DataSource = this.LazyCategoryBLL.GetCategories();
        this.GridView1.DataBind();
    }
}