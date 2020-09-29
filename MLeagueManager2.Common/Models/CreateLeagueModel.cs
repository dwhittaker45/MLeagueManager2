using System;
using System.Collections.Generic;
using System.Text;
using MLeagueManager2.Repo.magicleague;

namespace MLeagueManager2.Common
{
    public class CreateLeagueModel
    {
        public League LeagueObject { get; set; }
        public Teams TeamObject { get; set; }
        public MUser UserObject { get; set; }
    }
}
