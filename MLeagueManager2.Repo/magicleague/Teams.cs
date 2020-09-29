using System;
using System.Collections.Generic;

namespace MLeagueManager2.Repo.magicleague
{
    public partial class Teams
    {
        public Teams()
        {
            GamePlayers = new HashSet<GamePlayers>();
            LeagueGamesGameLoserNavigation = new HashSet<LeagueGames>();
            LeagueGamesGameWinnerNavigation = new HashSet<LeagueGames>();
        }

        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int? TeamOwner { get; set; }
        public int? LeagueId { get; set; }
        public int LeaguePos { get; set; }

        public virtual League League { get; set; }
        public virtual Users TeamOwnerNavigation { get; set; }
        public virtual ICollection<GamePlayers> GamePlayers { get; set; }
        public virtual ICollection<LeagueGames> LeagueGamesGameLoserNavigation { get; set; }
        public virtual ICollection<LeagueGames> LeagueGamesGameWinnerNavigation { get; set; }
    }
}
