using CakeMyBlog.DataAccessLayer.Interface;
using CakeMyBlog.Platform.DataAccess;
using Dapper;
using Model.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CakeMyBlog.DataAccessLayer
{
    public class MemberProvider: IMemberProvider
    {
        private readonly DataAccessService _dataAccessService = new DataAccessService();


        /// <summary>
        /// 查詢所有會員資料
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Member>> GetAllMembers()
        {
            string sqlCommand = @"
                    SELECT [Id]
                          ,[Name]
                          ,[Email]
                          ,[Gender]
                      FROM [Member]
                    ";

            return await _dataAccessService.QueryAsync<Member>(sqlCommand);
        }

        /// <summary>
        /// GetUser By 會員帳號、密碼
        /// </summary>
        /// <param name="userName">會員帳號</param>
        /// <param name="passWord">會員密碼</param>
        /// <returns></returns>
        public async Task<Member> GetUserByUserNamePassWord(string userName, string passWord)
        {
            var param = new DynamicParameters();
            param.Add("userName", userName);
            param.Add("passWord", passWord);

            string sqlCommand = @"
                    SELECT [Id]
                          ,[Name]
                          ,[Email]
                          ,[Gender]
                      FROM [Member]
                      Where Account = @userName
                      and PassWord = @PassWord
                    ";

            return await _dataAccessService.QueryFirstOrDefaultAsync<Member>(sqlCommand, param);
        }
    }

    
}
