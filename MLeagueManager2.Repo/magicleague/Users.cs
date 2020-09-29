using System;
using System.Collections.Generic;

namespace MLeagueManager2.Repo.magicleague
{
    public partial class Users
    {
        public Users()
        {
            League = new HashSet<League>();
            Teams = new HashSet<Teams>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public short? CanLeagueadmin { get; set; }
        public short? IsSysadmin { get; set; }

        public virtual ICollection<League> League { get; set; }
        public virtual ICollection<Teams> Teams { get; set; }
    }
}
