using System;
using System.Collections.Generic;
using System.Text;
using MLeagueManager2.Repo.magicleague;

namespace MLeagueManager2.Repo.Interfaces
{
    public interface IUserRepository
    {
        ICollection<Users> GetUsers();
        Users GetUser(int uid);
        Users AuthUser(string uname, string pword);
        ICollection<League> GetManagedLeagues(int uid);
        void SignUp(ICollection<KeyValuePair<string, string>> uinfo);
    }
}
