using CakeMyBlog.Platform.Utilities;
using CakeMyBlog.Service;
using CakeMyBlog.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IMemberService _memberService;

        public AuthController(ILogger<AuthController> logger, IMemberService memberService)
        {
            _logger = logger;
            _memberService = memberService;
        }

        /// <summary>
        /// 登入頁面
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登入事件
        /// </summary>
        /// <param name="userName">帳號</param>
        /// <param name="passWord">密碼</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(string userName, string passWord)
        {
            var getMemberResult = _memberService.GetUserByUserNamePassWord(userName, passWord).Result;

            if (getMemberResult == null)
            {
                return BadRequest("查無會員。");
            }

            HttpContext.Session.SetString(MySession.SessionUserName, getMemberResult.Name);

            return Ok();
        }
    }
}
