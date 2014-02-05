using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ITA.Model;

namespace ITA.IDAL
{
    public interface IWorkDAL
    {
        DataTable GetWorks();
        bool InsertWorks(List<Work> works);
        DataTable GetWorksByProjectID(int projectID);
        bool DeleteWorks(List<int> workIDs);
    }
}
