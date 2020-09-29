using MLeagueManager2.Repo.Interfaces;
using MLeagueManager2.Repo.magicleague;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLeagueManager2.Repo.Repositories
{
    class UsersRepository : IUserRepository
    {
        private magicleagueContext db;
        public UsersRepository(magicleagueContext context)
        {
            db = context;
        }
        public Users AuthUser(string uname, string pword)
        {

                Users u = db.Users.Where(x => x.UserName == uname && x.Password == pword).FirstOrDefault();

                return u;

        }

        public ICollection<League> GetManagedLeagues(int uid)
        {
                var L = db.League.Where(x => x.LeagueAdmin == uid).ToList();

                return L;
        }

        public ICollection<Users> GetUsers()
        {
 
                return db.Users.ToList(); ;
        }

        public Users GetUser(int uid)
        {

                var u = db.Users.Where(x => x.UserId == uid).FirstOrDefault();

                return u;
        }

        public void SignUp(ICollection<KeyValuePair<string, string>> uinfo)
        {
            Users NewUser = new Users();

            foreach(KeyValuePair<string,string> nuprop in uinfo)
            {
                switch (nuprop.Key)
                {
                    case "UserName":
                        NewUser.UserName = nuprop.Value;
                        break;
                    case "Email":
                        NewUser.UserEmail = nuprop.Value;
                        break;
                    case "Password":
                        NewUser.Password = nuprop.Value;
                        break;
                }
            }

            NewUser.CanLeagueadmin = 1;

                db.Users.Add(NewUser);
                db.SaveChanges();
        }
    }
}
