using System;
using System.Collections.Generic;
using System.Text;

namespace MLeagueManager2.Common
{
    public class NewLeague
    {
        public string LName { get; set; }
        public DateTime LStart { get; set; }
        public DateTime LEnd { get; set; }
        public int? SMax { get; set; }
        public int? GPMax { get; set; }
    }
}
