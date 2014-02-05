using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using ITA.SQLServerDAL;
using ITA.IDAL;
using System.Text;
using System.Data.SqlClient;

/// <summary>
///RepeaterPagerBase 的摘要说明
/// </summary>
public class RepeaterPagerBase:PageBase
{
    private struct PagerItem
    {
        public int PageSize;
        public int ShowPageNumber;
        public IPageMoudle PageModle;
        public Repeater PagerFliper;
        public Repeater ItemList;
        public Panel EmptyPanel;
    }

    Dictionary<string, PagerItem> pagers = new Dictionary<string, PagerItem>();

    protected void RegistrPager(Repeater itemList, Repeater pagerFliper, int showPageNumber, IPageMoudle pageModle)
    {
        PagerItem pi = new PagerItem();
        pi.PageModle = pageModle;
        pi.PagerFliper = pagerFliper;
        pi.ItemList = itemList;
        pi.ShowPageNumber = showPageNumber;
        this.pagers.Remove(pi.PagerFliper.UniqueID);
        this.pagers.Add(pi.PagerFliper.UniqueID, pi);
    }

    protected void RegistrPager(Repeater itemList, Repeater pagerFliper, int showPageNumber, IPageMoudle pageModle, Panel panelEmpty)
    {
        PagerItem pi = new PagerItem();
        pi.PageModle = pageModle;
        pi.PagerFliper = pagerFliper;
        pi.ItemList = itemList;
        pi.ShowPageNumber = showPageNumber;
        pi.EmptyPanel = panelEmpty;
        this.pagers.Remove(pi.PagerFliper.UniqueID);
        this.pagers.Add(pi.PagerFliper.UniqueID, pi);
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        foreach (PagerItem pi in pagers.Values)
        {
            pi.PagerFliper.ItemCommand += new RepeaterCommandEventHandler(PagerFliper_ItemCommand);
        }
        if (!IsPostBack)
        {
            foreach (string pi in pagers.Keys)
            {
                BindPage(pi, 1);

                #region Repeater's EmptyTemplate
                PagerItem pagerItem = pagers[pi];
                if (pagerItem.EmptyPanel != null)
                {
                    if (pagerItem.PageModle.CurrentData.Rows.Count > 0)
                    {
                        pagerItem.EmptyPanel.Visible = false;
                    }
                    else
                    {
                        pagerItem.EmptyPanel.Visible = true;
                    }
                }
                #endregion
            }
        }
    }

    protected virtual void PagerFliper_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName != string.Empty)
        {
            BindPage(((Control)source).UniqueID, Convert.ToInt32(e.CommandName));
        }
    }

    //总显示10个页码，形如：<< < 1 2 3 4 5 6 7 8 9 10 > >>
    protected internal void BindPage(string controlId, int pageIndex)
    {
        PagerItem pi = pagers[controlId];

        if (pageIndex < 1) { pageIndex = 1; }
        if (pageIndex > pi.PageModle.PageCount) { pageIndex = pi.PageModle.PageCount; }

        pi.PageModle.CurrentPage = pageIndex;
        pi.ItemList.DataSource = pi.PageModle.CurrentData;
        //pi.ItemList.DataSource = this.DAOProduct.SelectWithPaging(pageIndex - 1, pi.PageModle.PageSize);

        List<PageNumberItem> pageNumberList = new List<PageNumberItem>();
        if (pi.PageModle.PageCount > 1)
        {
            if (pageIndex != 1)
            {
                pageNumberList.Add(new PageNumberItem(!this.IsEng ? "首页" : "First", "1", false));
                pageNumberList.Add(new PageNumberItem(!this.IsEng ? "上一页" : "Prev", (pageIndex - 1).ToString(), false));
            }

            if (pi.PageModle.PageCount <= pi.ShowPageNumber)
            {
                for (int i = 1; i <= pi.PageModle.PageCount; i++)
                {
                    pageNumberList.Add(new PageNumberItem(i.ToString(), i.ToString(), (i == pageIndex)));
                }
            }
            else
            {
                if ((pageIndex > (pi.ShowPageNumber / 2)) && (pageIndex < pi.PageModle.PageCount - (pi.ShowPageNumber / 2)))
                {
                    for (int i = pageIndex - (pi.ShowPageNumber / 2); i <= pageIndex + (pi.ShowPageNumber / 2); i++)
                    {
                        pageNumberList.Add(new PageNumberItem(i.ToString(), i.ToString(), (i == pageIndex)));
                    }
                }
                else if (pageIndex <= (pi.ShowPageNumber / 2))
                {
                    for (int i = 1; i <= pi.ShowPageNumber; i++)
                    {
                        pageNumberList.Add(new PageNumberItem(i.ToString(), i.ToString(), (i == pageIndex)));
                    }
                }
                else if (pageIndex >= pi.PageModle.PageCount - (pi.ShowPageNumber / 2))
                {
                    for (int i = pi.PageModle.PageCount - pi.ShowPageNumber + 1; i <= pi.PageModle.PageCount; i++)
                    {
                        pageNumberList.Add(new PageNumberItem(i.ToString(), i.ToString(), (i == pageIndex)));
                    }
                }
            }

            if (pageIndex != pi.PageModle.PageCount)
            {
                pageNumberList.Add(new PageNumberItem(!this.IsEng ? "下一页" : "Next", (pageIndex + 1).ToString(), false));
                pageNumberList.Add(new PageNumberItem(!this.IsEng ? "末页" : "Last", pi.PageModle.PageCount.ToString(), false));
            }
        }
        pi.PagerFliper.DataSource = pageNumberList;
        pi.PagerFliper.DataBind();
        pi.ItemList.DataBind();
    }

    public void ResetBind(string controlId)
    {
        BindPage(controlId, 1);
    }

    /// <summary>
    /// 页面编号对象
    /// </summary>
    public class PageNumberItem
    {
        string pageNumberText;
        string pageNumberCommand;
        bool isCurrentPage;

        public PageNumberItem(string pageNumberText, string pageNumberCommand, bool isCurrentPage)
        {
            this.pageNumberText = pageNumberText;
            this.pageNumberCommand = pageNumberCommand;
            this.isCurrentPage = isCurrentPage;
        }

        public string PageNumberText
        {
            get { return pageNumberText; }
            set { pageNumberText = value; }
        }

        public string PageNumberCommand
        {
            get { return pageNumberCommand; }
            set { pageNumberCommand = value; }
        }

        public bool IsCurrentPage
        {
            get { return isCurrentPage; }
            set { isCurrentPage = value; }
        }
    }

    public int TotalPage(string controlId)
    {
        PagerItem pi = pagers[controlId];
        return pi.PageModle.PageCount;
    }

    public PageMoudle FillPageMoudle(int pageSize, string sql, List<SortField> sortFields)
    {
        PageMoudle pm = new PageMoudle(sql);
        pm.SortField = sortFields;
        pm.PageSize = pageSize;
        return pm;
    }

    public PageMoudle FillPageMoudleWithParams(int pageSize, string sql, SqlParameter[] sp, List<SortField> sortFields)
    {
        PageMoudle pm = new PageMoudle(sql, sp);
        pm.SortField = sortFields;
        pm.PageSize = pageSize;
        return pm;
    }

    protected virtual string StyleGenerator(PageNumberItem item)
    {
        List<string> list = new List<string>() { "上一页", "下一页", "首页", "末页" };
        StringBuilder style = new StringBuilder();
        if (list.Contains(item.PageNumberText))
            style.Append("text-align:center;width:40px;height:20px; display:-moz-inline-box; display:inline-block; float:left;line-height:20px; margin-left:5px;");
        else
            style.Append("text-align:center;width:20px;height:20px; display:-moz-inline-box; display:inline-block; float:left;line-height:20px; margin-left:5px;");

        if (item.IsCurrentPage)
            style.Append("background-color:#01439c; color:#ffffff;");
        else
            style.Append("background-color:#f1fbfd; color:#000000;");
        return style.ToString();
    }

    //是否为英文页码
    private bool _IsEng = false;
    public bool IsEng 
    {
        get { return this._IsEng; }
        set { this._IsEng = value; }
    }

    #region IDataView 成员
    public virtual void Select(params object[] args)
    {
        foreach (PagerItem pi in pagers.Values)
        {
            pi.PagerFliper.DataSource = new bool[pi.PageModle.PageCount];
        }
    }

    public virtual void SelectView(params object[] args)
    {
        foreach (PagerItem pi in pagers.Values)
        {
            pi.PagerFliper.DataBind();
            pi.ItemList.DataBind();
        }
    }

    public virtual void Update(params object[] args)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public virtual void Insert(params object[] args)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public virtual void Delete(params object[] args)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public virtual void UpdateView(params object[] args)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public virtual void InsertView(params object[] args)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public virtual void DeleteView(params object[] args)
    {
        throw new Exception("The method or operation is not implemented.");
    }
    #endregion
}
