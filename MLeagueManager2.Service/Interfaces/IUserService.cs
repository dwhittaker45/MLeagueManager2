using System;
using System.Collections.Generic;
using System.Text;
using MLeagueManager2.Common;

namespace MLeagueManager2.Service.Interfaces
{
    public interface IUserService
    {

        //Make sure that you come back to add other auth
        public MUser AuthUser(string uname, string pword);
        public MUser AddUser(ICollection<KeyValuePair<string,string>> uinfo);
    }
}
