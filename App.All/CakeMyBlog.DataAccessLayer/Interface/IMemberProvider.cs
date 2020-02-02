using Model.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CakeMyBlog.DataAccessLayer.Interface
{
    public interface IMemberProvider
    {
        /// <summary>
        /// 查詢所有會員資料
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Member>> GetAllMembers();

        /// <summary>
        /// GetUser By 會員帳號、密碼
        /// </summary>
        /// <param name="userName">會員帳號</param>
        /// <param name="passWord">會員密碼</param>
        /// <returns></returns>
        Task<Member> GetUserByUserNamePassWord(string userName, string passWord);
    }
}
