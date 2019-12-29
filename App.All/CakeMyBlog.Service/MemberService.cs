using CakeMyBlog.DataAccessLayer;
using CakeMyBlog.DataAccessLayer.Interface;
using CakeMyBlog.Service.Interface;
using Model.DataAccessLayer;
using System.Collections.Generic;

namespace CakeMyBlog.Service
{
    public class MemberService : IMemberService
    {
        IMemberProvider _memberProvider;

        public MemberService(IMemberProvider memberProvider) {
            _memberProvider = memberProvider;
        }

        /// <summary>
        /// 取得所有會員資訊
        /// </summary>
        /// <returns></returns>
        public List<Member> GetAllMembers()
        {
            var result = _memberProvider.GetAllMembers();
            return result;
        }

        /// <summary>
        /// 使用帳號密碼來查詢會員資訊
        /// </summary>
        /// <param name="userName">帳號</param>
        /// <param name="passWord">密碼</param>
        /// <returns></returns>
        public Member GetUserByUserNamePassWord(string userName, string passWord)
        {
            var result = _memberProvider.GetUserByUserNamePassWord(userName, passWord);
            return result;
        }
    }
}
