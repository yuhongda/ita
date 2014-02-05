using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ITA.IDAL;

namespace ITA.SQLServerDAL
{
    public class CategoryDAL : ICategoryDAL
    {
        #region SQL
        public const string sqlGetCategories = "SELECT * FROM TbCategory";
        #endregion

        #region Variables
        private static DataAccessObjectBase _dao = null;
        public static DataAccessObjectBase DAO
        {
            get
            {
                if (_dao == null)
                    _dao = new DataAccessObjectBase();
                return _dao;
            }
            set
            {
                _dao = value;
            }
        }
        #endregion

        #region ICategoryDAL Members
        public DataTable GetCategories()
        {
            return DAO.Select(sqlGetCategories);
        }
        #endregion
    }
}
