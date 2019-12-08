using CakeMyBlog.Platform.DataAccess;
using Dapper;
using Model.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CakeMyBlog.DataAccessLayer
{
    public class MemberProvider
    {
        /// <summary>
        /// 查詢所有會員資料
        /// </summary>
        /// <returns></returns>
        public List<Member> GetAllMembers()
        {
            List<Member> members = null;

            string sqlCommand = @"
                    SELECT [Id]
                          ,[Name]
                          ,[Email]
                          ,[Gender]
                      FROM [Member]
                    ";

            using (var conn = new SqlConnection(DataAccessService.connectionStr)) {
                members = conn.Query<Member>(sqlCommand).ToList();
            }

            return members;
        }

        public Member GetUserByUserNamePassWord(string userName, string passWord)
        {
            Member member = null;
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

            using (var conn = new SqlConnection(DataAccessService.connectionStr))
            {
                member = conn.Query<Member>(sqlCommand, param).FirstOrDefault();
            }

            return member;
        }
    }

    
}
