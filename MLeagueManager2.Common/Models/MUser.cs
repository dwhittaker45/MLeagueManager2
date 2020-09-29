using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MLeagueManager2.Repo.magicleague;
namespace MLeagueManager2.Common
{
    public class MUser : Users
    {
        public MUser()
        {
            ManagedLeagues = new HashSet<League>();
        }

        public ICollection<League> ManagedLeagues { get; set; }

        public ICollection<League> ActiveLeagues 
        {
            get
            {
                ICollection<League> rval = new HashSet<League>();

                foreach(League L in this.League)
                {
                    if (L.LeagueEnd is null || L.LeagueEnd < DateTime.Today)
                    {
                        rval.Add(L);
                    }
                }

                return rval;
            }
        }


    }
}
