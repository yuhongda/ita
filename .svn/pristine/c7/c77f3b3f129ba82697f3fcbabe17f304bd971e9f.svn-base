using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ITA.IDAL;
using ITA.Model;
using System.Data.SqlClient;

namespace ITA.SQLServerDAL
{
    public class WorkDAL : IWorkDAL
    {

        #region SQL
        public const string sqlGetWorks = "SELECT * FROM TbWork";
        public const string sqlGetWorksByProjectID = "SELECT * FROM TbWork WHERE (ProjectID = {0}) ORDER BY PublishDate DESC";
        public const string sqlGetWorksByProjectID4Manage = "SELECT * FROM TbWork WHERE (ProjectID = {0})";
        public const string sqlInsertWork = "INSERT INTO TbWork (WorkName, FilePath, Description, PublishDate, ProjectID) VALUES ({0},{1},{2},{3},{4})";
        const string sqlDeleteWork = "Delete from TbWork where WorkID={0}";
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

        #region IWorkDAL Members

        public DataTable GetWorks()
        {
            return DAO.Select(sqlGetWorks);
        }

        public DataTable GetWorksByProjectID(int projectID)
        {
            SqlParameter[] sp = new SqlParameter[]{
                            new SqlParameter("@ProjectID", projectID)
                        };
            return DAO.Select(string.Format(sqlGetWorksByProjectID, "@ProjectID"), sp);
        }

        public bool InsertWorks(List<Work> works)
        {
            Dictionary<SqlParameter[], string> insertSqls = new Dictionary<SqlParameter[], string>();

            foreach (Work w in works)
            {
                string sql = string.Format(sqlInsertWork, "@WorkName", "@FilePath", "@Description", "@PublishDate", "@ProjectID");
                SqlParameter[] parms = new SqlParameter[] { 
                    new SqlParameter ("@WorkName", w.WorkName),
                    new SqlParameter ("@FilePath", w.FilePath),
                    new SqlParameter ("@Description", w.Description),
                    new SqlParameter ("@PublishDate", w.PublishDate),
                    new SqlParameter ("@ProjectID", w.ProjectID)
                };
                insertSqls.Add(parms, sql);
            }

            return DAO.ExecuteSqlTran(insertSqls);
        }

        public bool DeleteWorks(List<int> workIDs)
        {
            Dictionary<SqlParameter[], string> deleteSqls = new Dictionary<SqlParameter[], string>();
            for (int i = 0; i < workIDs.Count; i++)
            {
                SqlParameter[] parms = new SqlParameter[] { 
                    new SqlParameter ("@WorkID",workIDs[i])
                  };
                string sql = string.Format(sqlDeleteWork, "@WorkID");
                deleteSqls.Add(parms, sql);
            }
            return DAO.ExecuteSqlTran(deleteSqls);
        }
        #endregion
    }
}
