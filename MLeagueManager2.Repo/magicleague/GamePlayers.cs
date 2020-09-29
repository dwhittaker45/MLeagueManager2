using System;
using System.Collections.Generic;

namespace MLeagueManager2.Repo.magicleague
{
    public partial class GamePlayers
    {
        public int GamePlayerId { get; set; }
        public int? GameId { get; set; }
        public int? TeamId { get; set; }

        public virtual LeagueGames Game { get; set; }
        public virtual Teams Team { get; set; }
    }
}
