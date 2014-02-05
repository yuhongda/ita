using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITA.IDAL;
using System.Data.SqlClient;
using ITA.Model;
using System.Data;
using System.Collections;

namespace ITA.SQLServerDAL
{
    public class UserDAL : IUserDAL
    {
        #region SQL
        public const string sqlGetUsers = "SELECT * FROM TbUser";
        const string sqlGetUserByUserID = "SELECT * FROM TbUser WHERE (UserID = {0})";
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

        #region IUserDAL Members
        public System.Data.DataTable GetUserByUserID(int userID)
        {
            SqlParameter[] sp = new SqlParameter[]{
                            new SqlParameter("@UserID", userID)
                        };
            return DAO.Select(string.Format(sqlGetUserByUserID, "@UserID"), sp);
        }
        #endregion
    }
}
