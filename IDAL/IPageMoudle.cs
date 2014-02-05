using System;
using System.Collections.Generic;
using System.Text;

namespace ITA.IDAL
{
    public interface IPageMoudle
    {
        System.Data.DataTable CurrentData { get; }
        int CurrentPage { get; set; }
        int PageCount { get; }
        int TotalCount { get; set; }
        int PageSize { get; set; }
    }
}
