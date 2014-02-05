using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ITA.Model;

namespace ITA.IDAL
{
    public interface IProjectDAL
    {
        DataTable GetProjects();
        bool UpdateProject(Project project);
        bool InsertProject(Project project);
        bool DeleteProject(int projectID);
        DataTable GetProjectsByCategoryID(int categoryID);
        DataTable GetLatestProjectForEachCategory();
        DataTable GetProjectsByProjectID(int projectID);
    }
}
