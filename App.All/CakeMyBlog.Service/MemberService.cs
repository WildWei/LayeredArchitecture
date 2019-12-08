﻿using CakeMyBlog.DataAccessLayer;
using Model.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CakeMyBlog.Service
{
    public class MemberService
    {
        MemberProvider memberProvider;

        public MemberService() {
            memberProvider = new MemberProvider();
        }

        public List<Member> GetAllMembers()
        {
            var result = memberProvider.GetAllMembers();
            return result;
        }

        public Member GetUserByUserNamePassWord(string userName, string passWord)
        {
            var result = memberProvider.GetUserByUserNamePassWord(userName, passWord);
            return result;
        }
    }
}