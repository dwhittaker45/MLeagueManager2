using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Text;
using MLeagueManager2.Common;
using MLeagueManager2.Repo.Interfaces;
using MLeagueManager2.Service.Interfaces;
using MLeagueManager2.Repo.magicleague;
using System.Diagnostics;

namespace MLeagueManager2.Service.Services
{
    class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        private magicleagueContext _context;
        public UserService(IUserRepository userRepo,magicleagueContext context)
        {
            _userRepo = userRepo;
            _context = context;
        }
        public MUser AddUser(ICollection<KeyValuePair<string, string>> uinfo)
        {
            _userRepo.SignUp(uinfo);

            string uname ="";
            string pword ="";

            foreach(KeyValuePair<string,string> kvp in uinfo)
            {
                switch (kvp.Key)
                {
                    case "UserName":
                        uname = kvp.Value;
                        break;
                    case "Password":
                        pword = kvp.Value;
                        break;
                }
            }
            return AuthUser(uname, pword);

        }

        public MUser AuthUser(string uname, string pword)
        {
            MUser AuthedUser = new MUser();

            Users NUser = new Users();

            NUser = _userRepo.AuthUser(uname, pword);

            AuthedUser.UserId = NUser.UserId;
            AuthedUser.UserEmail = NUser.UserEmail;
            AuthedUser.UserName = NUser.UserName;
            AuthedUser.Teams = NUser.Teams;
            AuthedUser.League = NUser.League;
            AuthedUser.IsSysadmin = NUser.IsSysadmin;
            AuthedUser.CanLeagueadmin = NUser.CanLeagueadmin;
            AuthedUser.ManagedLeagues = _userRepo.GetManagedLeagues(NUser.UserId);


            return AuthedUser;
        }
    }
}
