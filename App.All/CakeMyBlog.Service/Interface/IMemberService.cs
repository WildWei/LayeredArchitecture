using Model.DataAccessLayer;
using System.Collections.Generic;

namespace CakeMyBlog.Service.Interface
{
    public interface IMemberService
    {
        /// <summary>
        /// 取得所有會員資訊
        /// </summary>
        /// <returns></returns>
        List<Member> GetAllMembers();

        // <summary>
        /// 使用帳號密碼來查詢會員資訊
        /// </summary>
        /// <param name="userName">帳號</param>
        /// <param name="passWord">密碼</param>
        /// <returns></returns>
        Member GetUserByUserNamePassWord(string userName, string passWord);
    }
}
