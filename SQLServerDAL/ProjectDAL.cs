using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ITA.IDAL;
using ITA.Model;

namespace ITA.SQLServerDAL
{
    public class ProjectDAL : IProjectDAL
    {
        #region SQL
        public const string sqlGetProjects = "SELECT TbProject.*, TbCategory.CategoryName FROM TbProject LEFT OUTER JOIN TbCategory ON TbProject.CategoryID = TbCategory.CategoryID";
        public const string sqlGetProjectsByCategoryID = "SELECT TbProject.*,  TbCategory.CategoryName FROM TbProject LEFT OUTER JOIN TbCategory ON TbProject.CategoryID = TbCategory.CategoryID WHERE (TbProject.CategoryID = {0}) ORDER BY TbProject.ProjectDate DESC";
        public const string sqlGetProjectsByProjectID = "SELECT TbProject.*,  TbCategory.CategoryName FROM TbProject LEFT OUTER JOIN TbCategory ON TbProject.CategoryID = TbCategory.CategoryID WHERE (ProjectID = {0}) ORDER BY TbProject.ProjectDate DESC";
        public const string sqlGetLatestProjectForEachCategory = "SELECT TbProject.*, TbCategory.CategoryName FROM TbProject INNER JOIN TbCategory ON TbCategory.CategoryID = TbProject.CategoryID WHERE (TbProject.ProjectID IN (SELECT MAX(ProjectID) AS ids FROM TbProject AS TbProject_1 GROUP BY CategoryID)) ORDER BY TbProject.CategoryID";
        const string sqlUpdateProject = "UPDATE TbProject SET ProjectName = {0}, ProjectLogo = {1},ProjectDescription={2},ProjectDate={3},CategoryID={4},TextPos={5} WHERE (ProjectID = {6})";
        const string sqlInsertProject = "INSERT INTO TbProject (ProjectName, ProjectLogo, ProjectDescription, ProjectDate,CategoryID,TextPos) VALUES ({0},{1},{2},{3},{4},{5})";
        const string sqlDeleteProject = "Delete from TbProject where ProjectID={0}";



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

        #region IProjectDAL Members
        public DataTable GetProjects()
        {
            return DAO.Select(sqlGetProjects);
        }

        public DataTable GetProjectsByCategoryID(int categoryID)
        {
            SqlParameter[] sp = new SqlParameter[]{
                            new SqlParameter("@CategoryID", categoryID)
                        };
            return DAO.Select(string.Format(sqlGetProjectsByCategoryID, "@CategoryID"), sp);
        }

        public DataTable GetProjectsByProjectID(int projectID)
        {
            SqlParameter[] sp = new SqlParameter[]{
                            new SqlParameter("@ProjectID", projectID)
                        };
            return DAO.Select(string.Format(sqlGetProjectsByProjectID, "@ProjectID"), sp);
        }

        public DataTable GetLatestProjectForEachCategory()
        {
            return DAO.Select(sqlGetLatestProjectForEachCategory);
        }

        public bool UpdateProject(Project project)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter ("@ProjectName", project.ProjectName),
                new SqlParameter ("@ProjectLogo", project.ProjectLogo),
                new SqlParameter ("@ProjectDescription", project.ProjectDescription),
                new SqlParameter ("@ProjectDate", project.ProjectDate),
                new SqlParameter ("@CategoryID", project.CategoryID),
                new SqlParameter ("@TextPos", project.TextPos),
                new SqlParameter ("@ProjectID", project.ProjectID)
            };
            string sql = string.Format(sqlUpdateProject, "@ProjectName", "@ProjectLogo", "@ProjectDescription", "@ProjectDate", "@CategoryID", "@TextPos", "@ProjectID");

            return DAO.ExecuteSql(sql, sp);
        }

        public bool InsertProject(Project project)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter ("@ProjectName", project.ProjectName),
                new SqlParameter ("@ProjectLogo", project.ProjectLogo),
                new SqlParameter ("@ProjectDescription", project.ProjectDescription),
                new SqlParameter ("@ProjectDate", project.ProjectDate),
                new SqlParameter ("@TextPos", project.TextPos),
                new SqlParameter ("@CategoryID", project.CategoryID)
            };
            string sql = string.Format(sqlInsertProject, "@ProjectName", "@ProjectLogo", "@ProjectDescription", "@ProjectDate", "@CategoryID", "@TextPos");

            return DAO.ExecuteSql(sql, sp);
        }
        public bool DeleteProject(int projectID)
        {
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter ("@ProjectID",projectID),
    
            };
            string sql = string.Format(sqlDeleteProject, "@ProjectID");
            return DAO.ExecuteSql(sql, parms);
        }
        #endregion
    }
}
