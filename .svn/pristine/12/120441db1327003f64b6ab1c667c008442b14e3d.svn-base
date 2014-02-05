using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITA.IDAL;
using System.Data;
using ITA.Model;

namespace ITA.BLL
{
    public class WorkBLL
    {
        private static readonly IWorkDAL dal = ITA.DALFactory.DataAccess.CreateWorkDAL();

        public DataTable GetWorks()
        {
            return dal.GetWorks();
        }

        public DataTable GetWorksByProjectID(int projectID)
        {
            return dal.GetWorksByProjectID(projectID);
        }

        public bool InsertWorks(List<Work> works)
        {
            return dal.InsertWorks(works);
        }

        public bool DeleteWorks(List<int> workIDs)
        {
            return dal.DeleteWorks(workIDs);
        }
    }
}
