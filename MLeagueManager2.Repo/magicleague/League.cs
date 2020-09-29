using System;
using System.Collections.Generic;

namespace MLeagueManager2.Repo.magicleague
{
    public partial class League
    {
        public League()
        {
            LeagueGames = new HashSet<LeagueGames>();
            Teams = new HashSet<Teams>();
        }

        public int LeagueId { get; set; }
        public string LeagueYear { get; set; }
        public string LeagueName { get; set; }
        public int? DeckRules { get; set; }
        public int? LeagueAdmin { get; set; }
        public DateTime? LeagueStart { get; set; }
        public DateTime? LeagueEnd { get; set; }
        public int? LeagueGameMax { get; set; }
        public int? GamePlayerMax { get; set; }

        public virtual Users LeagueAdminNavigation { get; set; }
        public virtual ICollection<LeagueGames> LeagueGames { get; set; }
        public virtual ICollection<Teams> Teams { get; set; }
    }
}
