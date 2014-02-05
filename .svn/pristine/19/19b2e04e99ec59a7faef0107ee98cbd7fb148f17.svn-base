using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Collections;
using ITA.SQLServerDAL;
using ITA.IDAL;
using System.Data.SqlClient;
using ITA.IDAL;
using ITA.SQLServerDAL;

/// <summary>
/// PageCountBase 的摘要说明

/// </summary>

public class PagerBase: PageBase
{
    private struct PagerItem
    {
        public int PageSize;
        public int ShowPageNumber;
        public IPageMoudle PageModle;
        public Repeater PagerFliper;
        public GridView ItemList;
    }

    /// <summary>
    /// 显示的页码数
    /// </summary>

    Dictionary<string, PagerItem> pagers = new Dictionary<string, PagerItem>();

    protected void RegistrPager(GridView itemList, Repeater pagerFliper, int showPageNumber, IPageMoudle pageModle)
    {
        PagerItem pi=new PagerItem();
        pi.PageModle = pageModle;
        pi.PagerFliper = pagerFliper;
        pi.ItemList = itemList;
        pi.ShowPageNumber = showPageNumber;
        this.pagers.Remove(pi.PagerFliper.UniqueID);
        this.pagers.Add(pi.PagerFliper.UniqueID,pi);
    }

    public PageMoudle FillPageMoudleWithParams(int pageSize, string sql, SqlParameter[] sp, List<SortField> sortFields)
    {
        PageMoudle pm = new PageMoudle(sql, sp);
        pm.SortField = sortFields;
        pm.PageSize = pageSize;
        return pm;
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
           }
        }          
    }

    void PagerFliper_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName != string.Empty)
        {
            BindPage(((Control)source).UniqueID, Convert.ToInt32(e.CommandName));
        }
    }

    //总显示10个页码，形如：<< < 1 2 3 4 5 6 7 8 9 10 > >>
    protected internal void BindPage(string controlId,int pageIndex)
    {
        PagerItem pi =pagers[controlId];

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
                pageNumberList.Add(new PageNumberItem("首页", "1", false));
                pageNumberList.Add(new PageNumberItem("上一页", (pageIndex - 1).ToString(), false));
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
                pageNumberList.Add(new PageNumberItem("下一页", (pageIndex + 1).ToString(), false));
                pageNumberList.Add(new PageNumberItem("末页", pi.PageModle.PageCount.ToString(), false));
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

    public int TotalCount(string controlId)
    {
        PagerItem pi = pagers[controlId];
        return pi.PageModle.TotalCount;
    }

    public PageMoudle FillPageMoudle(int pageSize, string sql, List<SortField> sortFields)
    {
        PageMoudle pm = new PageMoudle(sql);
        pm.SortField = sortFields;
        pm.PageSize = pageSize;
        return pm;
    }

    #region IDataView 成员
    public virtual void  Select(params object[] args)
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
