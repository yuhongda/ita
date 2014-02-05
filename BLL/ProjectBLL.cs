using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITA.IDAL;
using System.Data;
using ITA.Model;

namespace ITA.BLL
{
    public class ProjectBLL
    {
        private static readonly IProjectDAL dal = ITA.DALFactory.DataAccess.CreateProjectDAL();

        public DataTable GetProjects()
        {
            return dal.GetProjects();
        }

        public DataTable GetProjectsByCategoryID(int categoryID)
        {
            return dal.GetProjectsByCategoryID(categoryID);
        }

        public DataTable GetProjectsByProjectID(int projectID)
        {
            return dal.GetProjectsByProjectID(projectID);
        }

        public DataTable GetLatestProjectForEachCategory()
        {
            return dal.GetLatestProjectForEachCategory();
        }

        public bool UpdateProject(Project project)
        {
            return dal.UpdateProject(project);
        }

        public bool InsertProject(Project project)
        {
            return dal.InsertProject(project);
        }

        public bool DeleteProject(int projectID)
        {
            return dal.DeleteProject(projectID);
        }
    }
}
