using System;
using System.Collections.Generic;

namespace MLeagueManager2.Repo.magicleague
{
    public partial class LeagueGames
    {
        public LeagueGames()
        {
            BracketedGames = new HashSet<BracketedGames>();
            GamePlayers = new HashSet<GamePlayers>();
        }

        public int GameId { get; set; }
        public DateTime GameDate { get; set; }
        public int? GameWinner { get; set; }
        public int? GameLoser { get; set; }
        public int LeagueId { get; set; }
        public short IsBracketed { get; set; }
        public int? BracketParent1 { get; set; }
        public int? BracketParent2 { get; set; }
        public string GameRound { get; set; }

        public virtual Teams GameLoserNavigation { get; set; }
        public virtual Teams GameWinnerNavigation { get; set; }
        public virtual League League { get; set; }
        public virtual ICollection<BracketedGames> BracketedGames { get; set; }
        public virtual ICollection<GamePlayers> GamePlayers { get; set; }
    }
}
