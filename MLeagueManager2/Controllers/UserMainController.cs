using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MLeagueManager2.Web.Models;
using MLeagueManager2.Service.Services;
using MLeagueManager2.Service.Interfaces;
using MLeagueManager2.Common;
using MLeagueManager2.Repo.magicleague;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace MLeagueManager2.Web.Controllers
{
    public class UserMainController : Controller
    {
        private readonly ILogger<UserMainController> _logger;
        private readonly IUserService _userService;
        private magicleagueContext _context;

        public UserMainController(ILogger<UserMainController> logger, IUserService userService, magicleagueContext context)
        {
            _logger = logger;

            _userService = userService;

            _context = context;
        }

        public IActionResult UserMain(MUser mUser)
        {
            if (!(mUser.UserName is null)) { 
                if (mUser.ActiveLeagues.Count() > 0)
                {
                    return View(mUser);
                }
                else
                {
                    return View(mUser);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult  CreateLeague(MUser mUser)
        {
            if (!(mUser.UserName is null))
            {
                CreateLeagueModel nLeague = new CreateLeagueModel();

                nLeague.UserObject = mUser;

                return View(nLeague);
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }
        public IActionResult NewLeaguePartial(League league)
        {
            return new PartialViewResult
            {
                ViewName = "LeagueEdit_New",
                ViewData = ViewData,
            };
        }
    }
}
