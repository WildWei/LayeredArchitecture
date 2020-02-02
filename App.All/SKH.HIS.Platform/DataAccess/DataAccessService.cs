
using StackExchange.Profiling;
using StackExchange.Profiling.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

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

        private int _connectionTimeout = 20;
        private bool _enableMiniprofiler = true;

        /// <summary>
        /// 查詢資料
        /// </summary>
        /// <typeparam name="TReturn">回覆的資料類型</typeparam>
        /// <param name="querySql">SQL敘述</param>
        /// <param name="param">查詢參數物件</param>
        /// <param name="commandType">敘述類型</param>
        /// <returns>資料物件</returns>x
        public async Task<IEnumerable<TReturn>> QueryAsync<TReturn>(string querySql, object param = null, CommandType commandType = CommandType.Text)
        {
            using (IDbConnection con = GetDbConnection())
            {
                return await con.QueryAsync<TReturn>(querySql, param, null, _connectionTimeout, commandType).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// 查詢第一筆資料
        /// (無結果回傳Null)
        /// </summary>
        /// <typeparam name="TResult">回傳的資料型態</typeparam>
        /// <param name="querySql">SQL敘述</param>
        /// <param name="param">查詢參數</param>
        /// <param name="commandType">敘述類型</param>
        /// <returns>資料物件</returns>
        public async Task<TResult> QueryFirstOrDefaultAsync<TResult>(string querySql, object param = null, CommandType commandType = CommandType.Text)
        {
            using (IDbConnection con = GetDbConnection())
            {
                return await con.QueryFirstOrDefaultAsync<TResult>(querySql, param, null, _connectionTimeout, commandType).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// 建立資料庫連線
        /// </summary>
        /// <returns>資料庫連線</returns>
        private IDbConnection GetDbConnection()
        {
            IDbConnection dBConnection;

            if (!_enableMiniprofiler)
            {
                dBConnection = new SqlConnection(_connectionStr);
            }
            else
            {
                dBConnection = new ProfiledDbConnection(
                    new SqlConnection(_connectionStr), MiniProfiler.Current);
            }

            if (dBConnection.State != ConnectionState.Open)
            {
                dBConnection.Open();
            }

            return dBConnection;
        }
    }
}
