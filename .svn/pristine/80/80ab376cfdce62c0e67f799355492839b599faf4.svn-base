using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ITA.IDAL;

namespace ITA.BLL
{
    public class UserBLL
    {
        private static readonly IUserDAL dal = ITA.DALFactory.DataAccess.CreateUserDAL();

        public DataTable GetUserByUserID(int userID)
        {
            return dal.GetUserByUserID(userID);
        }
    }
}
