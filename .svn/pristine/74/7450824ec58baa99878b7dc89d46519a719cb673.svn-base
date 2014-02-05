using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITA.IDAL;
using System.Data;

namespace ITA.BLL
{
    public class CategoryBLL
    {
        private static readonly ICategoryDAL dal = ITA.DALFactory.DataAccess.CreateCategoryDAL();

        public DataTable GetCategories()
        {
            return dal.GetCategories();
        }
    }
}
