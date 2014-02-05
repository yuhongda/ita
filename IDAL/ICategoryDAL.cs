using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ITA.IDAL
{
    public interface ICategoryDAL
    {
        DataTable GetCategories();
    }
}
