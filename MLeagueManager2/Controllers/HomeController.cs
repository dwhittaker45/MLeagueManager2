using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MLeagueManager2.Web.Models;
using MLeagueManager2.Service.Services;
using MLeagueManager2.Service.Interfaces;
using MLeagueManager2.Common;
using MLeagueManager2.Repo.magicleague;

namespace MLeagueManager2.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private magicleagueContext _context;
        public HomeController(ILogger<HomeController> logger, IUserService userService, magicleagueContext context)
        {
            _logger = logger;

            _userService = userService;

            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if(ViewData["Error"] == null)
            {
                ViewData.Add(new KeyValuePair<string, object>("Error", ""));
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel model)
        {
            try
            {
                MUser mu = new MUser();

                mu= _userService.AuthUser(model.uname,model.pword);
                return View("../UserMain/UserMain",mu);
            }
            catch (Exception e)
            {
                ViewData["Error"] = "Unable to locate User";
                return View();
            }
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

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(NewUserModel model)
        {
            MUser nUser = new MUser();
            HashSet<KeyValuePair<string, string>> kvp = new HashSet<KeyValuePair<string, string>>();

            kvp.Add(new KeyValuePair<string, string>("UserName", model.uname.ToString()));
            kvp.Add(new KeyValuePair<string, string>("Password", model.pword.ToString()));
            kvp.Add(new KeyValuePair<string, string>("Email", model.email.ToString()));

            nUser = _userService.AddUser(kvp);

            return View("../UserMain/UserMain",nUser);
        }
    }
}
