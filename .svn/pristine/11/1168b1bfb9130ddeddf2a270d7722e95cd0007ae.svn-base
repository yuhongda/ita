using System;
using System.Reflection;

namespace ITA.DALFactory
{
    /// <summary>
    /// DataAccess 的摘要说明。
    /// </summary>
    public sealed class DataAccess
    {
        private static readonly string path = System.Configuration.ConfigurationManager.AppSettings["ITADAL"];

        private DataAccess() { }

        public static ITA.IDAL.IWorkDAL CreateWorkDAL()
        {
            string className = path + ".WorkDAL";
            return (ITA.IDAL.IWorkDAL)Assembly.Load(path).CreateInstance(className);
        }

        public static ITA.IDAL.IUserDAL CreateUserDAL()
        {
            string className = path + ".UserDAL";
            return (ITA.IDAL.IUserDAL)Assembly.Load(path).CreateInstance(className);
        }

        public static ITA.IDAL.IProjectDAL CreateProjectDAL()
        {
            string className = path + ".ProjectDAL";
            return (ITA.IDAL.IProjectDAL)Assembly.Load(path).CreateInstance(className);
        }

        public static ITA.IDAL.ICategoryDAL CreateCategoryDAL()
        {
            string className = path + ".CategoryDAL";
            return (ITA.IDAL.ICategoryDAL)Assembly.Load(path).CreateInstance(className);
        }
    }
}
