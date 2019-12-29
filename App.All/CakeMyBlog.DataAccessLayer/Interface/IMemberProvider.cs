using Model.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CakeMyBlog.DataAccessLayer.Interface
{
    public interface IMemberProvider
    {
        /// <summary>
        /// 查詢所有會員資料
        /// </summary>
        /// <returns></returns>
        List<Member> GetAllMembers();

        Member GetUserByUserNamePassWord(string userName, string passWord);
    }
}
