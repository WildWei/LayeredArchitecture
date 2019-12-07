
namespace CakeMyBlog.Platform.DataAccess
{
    public class DataAccessService
    {
        /// <summary>
        /// 連線字串
        /// </summary>
        private static string _connectionStr = "Data Source=(Localdb)\\MSSQLLocalDB;Database=CakeMyBlog;Trusted_Connection=True;MultipleActiveResultSets=true;";

        /// <summary>
        /// 全域的資料庫連線字串
        /// </summary>
        public static string connectionStr { get { return _connectionStr; } }
    }
}
