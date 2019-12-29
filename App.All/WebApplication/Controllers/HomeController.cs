using CakeMyBlog.Service;
using CakeMyBlog.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WebApplication.Controllers.Base;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemberService _memberService;

        public HomeController(ILogger<HomeController> logger, IMemberService memberService)
        {
            _logger = logger;
            _memberService = memberService;
        }

        public IActionResult Index()
        {
            var message = "Alcohol is important.";

            var memberList = _memberService.GetAllMembers();

            _logger.LogInformation(message);

            ViewBag.MessageValue = message;

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
