using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using ITA.Utility;

/// <summary>
/// Utils 的摘要说明

/// </summary>
public class Utils
{
    public const string SESSIONUSER = "__@@SessionUser@@__";
    public const string SESSIONUSEREN = "__@@SessionUserEN@@__";
    public const string SESSIONWORDVERIFICATION = "__@@WordVerification@@__";
    public const string SESSIONPREFERREDCULTURE = "__@@PreferredCulture@@__";

    public static void GridViewBind(GridView gridView, System.Data.DataTable table)
    {
        gridView.DataSource = table;
        gridView.DataBind();
    }
    public static void RepeaterBind(Repeater rpt, System.Data.DataTable table)
    {
        rpt.DataSource = table;
        rpt.DataBind();
    }
    public static void DropDownListBind(DropDownList dropDownList, List<SiteMapClass> list, string dataTextField, string dataValueField)
    {
        dropDownList.DataTextField = dataTextField;
        dropDownList.DataValueField = dataValueField;
        dropDownList.DataSource = list;
        dropDownList.DataBind();
    }
    public static void DropDownListBind(DropDownList dropDownList, System.Data.DataTable table, string dataTextField, string dataValueField)
    {
        dropDownList.DataTextField = dataTextField;
        dropDownList.DataValueField = dataValueField;
        dropDownList.DataSource = table;
        dropDownList.DataBind();
    }

    public static void DropDownListBind(System.Web.UI.HtmlControls.HtmlSelect dropDownList, System.Data.DataTable table, string dataTextField, string dataValueField)
    {
        dropDownList.DataTextField = dataTextField;
        dropDownList.DataValueField = dataValueField;
        dropDownList.DataSource = table;
        dropDownList.DataBind();
    }

    public static void DropDownListBind(DropDownList dropDownList, object obj, string dataTextField, string dataValueField)
    {
        dropDownList.DataTextField = dataTextField;
        dropDownList.DataValueField = dataValueField;
        dropDownList.DataSource = obj;
        dropDownList.DataBind();
    }

    public static void DropDownListFixByText(DropDownList dropDownList, string dataTextField)
    {
        ListItem item = dropDownList.Items.FindByText(dataTextField);
        dropDownList.SelectedIndex = dropDownList.Items.IndexOf(item);
    }

    public static void DropDownListFixByValue(DropDownList dropDownList, string dataValueField)
    {
        ListItem item = dropDownList.Items.FindByValue(dataValueField);
        dropDownList.SelectedIndex = dropDownList.Items.IndexOf(item);
    }

    public static void ListBoxBind(ListBox listBox, System.Data.DataTable table, string dataTextField, string dataValueField)
    {
        listBox.DataSource = table;
        listBox.DataTextField = dataTextField;
        listBox.DataValueField = dataValueField;
        listBox.DataBind();
    }

    public static void ListBoxBind(ListBox listBox, DataView view, string dataTextField, string dataValueField)
    {
        listBox.DataSource = view;
        listBox.DataTextField = dataTextField;
        listBox.DataValueField = dataValueField;
        listBox.DataBind();
    }

    #region 替换文本的回车

    /// <summary>
    /// 替换文本的回车
    /// </summary>
    /// <param name="Text"></param>
    /// <returns></returns>
    public static string replace(string Text)
    {
        string reText = Text.Replace("\n", "<br>");
        return reText;
    }
    #endregion

    public static void ListBoxItemMove(ListBox sourceList, ListBox aimList)
    {
        int Isaddselect = 0;
        int intCount = sourceList.Items.Count;
        for (int i = 0; i < intCount; i++)
        {
            if (sourceList.Items[i].Selected)
            {
                ListItem item = sourceList.Items[i];
                ListItem newItem = new ListItem();
                newItem.Text = item.Text;
                newItem.Value = item.Value;
                aimList.Items.Add(newItem);
                sourceList.Items.Remove(item);
                i--;
                intCount--;
                Isaddselect = 1;
            }
        }
        if (Isaddselect == 0)
        {
            throw new Exception("请您选择要移动的内容!");
        }
    }

    public static string FormatString(string strSource, int length)
    {
        Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
        char[] stringChar = strSource.ToCharArray();
        StringBuilder sb = new StringBuilder();
        int nLength = 0;

        for (int i = 0; i < stringChar.Length; i++)
        {
            if (regex.IsMatch((stringChar[i]).ToString()))
            {
                sb.Append(stringChar[i]);
                nLength += 2;
            }
            else
            {
                sb.Append(stringChar[i]);
                nLength = nLength + 1;
            }

            if (nLength > length)
                return string.Format("{0}...", sb.ToString());
        }
        return strSource;
    }

    public static string FormatStringWithoutDot(string strSource, int length)
    {
        return FormatString(strSource, length).TrimEnd('.');
    }


    /// <summary>
    /// string转换byte[]
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static byte[] GetByteArray(string str)
    {
        return System.Text.Encoding.Default.GetBytes(str);
    }

    /// <summary>
    /// 创建文件
    /// </summary>
    /// <param name="strPath"></param>
    /// <param name="strData"></param>
    /// <returns></returns>
    public static bool CreateFile(string strPath, string strData)
    {
        try
        {
            using (System.IO.FileStream fs = System.IO.File.Create(strPath))
            {
                fs.Write(GetByteArray(strData), 0, strData.Length);
                fs.Flush();
                fs.Close();
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// 根据用户角色显示或隐藏WebControl
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="userRoles"></param>
    /// <param name="visibleRoles"></param>
    public static void SetControlVisibleByRole(WebControl obj, string userRoles, string visibleRoles)
    {
        obj.Visible = false;
        string[] userRoleArray = userRoles.Split(',');
        string[] visibleRoleArray = visibleRoles.Split(',');

        foreach (string userRole in userRoleArray)
        {
            foreach (string visibleRole in visibleRoleArray)
            {
                if (userRole == visibleRole)
                {
                    obj.Visible = true;
                }
            }
        }
    }

    /// <summary>
    /// 根据用户角色显示或隐藏HtmlControl
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="userRoles"></param>
    /// <param name="visibleRoles"></param>
    public static void SetControlVisibleByRole(HtmlControl obj, string userRoles, string visibleRoles)
    {
        obj.Visible = false;
        string[] userRoleArray = userRoles.Split(',');
        string[] visibleRoleArray = visibleRoles.Split(',');

        foreach (string userRole in userRoleArray)
        {
            foreach (string visibleRole in visibleRoleArray)
            {
                if (userRole == visibleRole)
                {
                    obj.Visible = true;
                }
            }
        }
    }

    /// <summary>
    /// 将DataTable按日期转换为Dictionary
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="keyField"></param>
    /// <returns></returns>
    public static Dictionary<string, DataTable> ConvertDataTableToDictionary(DataTable dt, string keyField)
    {
        Dictionary<string, DataTable> dict = new Dictionary<string, DataTable>();

        if (keyField != string.Empty && dt.Columns.Contains(keyField))
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strKey = Convert.ToDateTime(dt.Rows[i][keyField]).ToString("yyyy-MM-dd");
                DataTable dtValue = null;
                if (!dict.ContainsKey(strKey))
                {
                    dtValue = dt.Copy();
                    dtValue.Clear();
                    DataRow dr = dtValue.NewRow();
                    dr.ItemArray = dt.Rows[i].ItemArray;
                    dtValue.Rows.Add(dr);
                    dict.Add(strKey, dtValue);
                }
                else
                {
                    dtValue = (DataTable)dict[strKey];
                    dtValue.Rows.Add(dt.Rows[i]);
                    dict[strKey] = dtValue;
                }
            }
            return dict;
        }
        else
        {
            return null;
        }
    }

    public static string StripHtmlXmlTags(string content)
    {
        return Regex.Replace(content, "<[^>]+>", "", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    }

    public static string StripAllTags(string stringToStrip)
    {
        // paring using RegEx
        //
        stringToStrip = Regex.Replace(stringToStrip, "</p(?:\\s*)>(?:\\s*)<p(?:\\s*)>", "\n\n", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        stringToStrip = Regex.Replace(stringToStrip, "<br(?:\\s*)/>", "\n", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        stringToStrip = Regex.Replace(stringToStrip, "\"", "''", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        stringToStrip = StripHtmlXmlTags(stringToStrip);
        return stringToStrip;
    }

    public static string CreateRandomColor()
    {
        string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F";
        string[] allCharArray = allChar.Split(',');
        StringBuilder randomCode = new StringBuilder();
        int temp = -1;
        Random rand = new Random();
        for (int i = 0; i < 6; i++)
        {
            if (temp != -1)
            {
                rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
            }
            int t = rand.Next(15);
            if (temp == t)
            {
                return CreateRandomColor();
            }
            temp = t;
            randomCode.Append(allCharArray[t]);
        }
        System.Threading.Thread.Sleep(rand.Next(50)); 
        return "#" + randomCode.ToString();
    }

    public static string CreateSpecifiedColor(List<string> list)
    {
        Random r = new Random();
        System.Threading.Thread.Sleep(r.Next(50)); 
        return list[r.Next(list.Count)];
    }

    /// <summary>
    /// 获取网站URL
    /// </summary>
    /// <returns></returns>
    public static string GetRootURI()
    {
        string AppPath = "";
        HttpContext HttpCurrent = HttpContext.Current;
        HttpRequest Req;
        if (HttpCurrent != null)
        {
            Req = HttpCurrent.Request;

            string UrlAuthority = Req.Url.GetLeftPart(UriPartial.Authority);
            if (Req.ApplicationPath == null || Req.ApplicationPath == "/")
                //直接安装在 Web 站点   
                AppPath = UrlAuthority;
            else
                //安装在虚拟子目录下   
                AppPath = UrlAuthority + Req.ApplicationPath;
        }
        return AppPath;
    }
}
