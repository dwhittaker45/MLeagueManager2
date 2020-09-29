using System;
using System.Collections.Generic;

namespace MLeagueManager2.Repo.magicleague
{
    public partial class BracketedGames
    {
        public int BracketedGamesId { get; set; }
        public int GameId { get; set; }
        public int BracketRound { get; set; }
        public int BracketMatch { get; set; }

        public virtual LeagueGames Game { get; set; }
    }
}
