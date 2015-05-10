using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirFighter {
    public class ScoreboardEntry {
        public int Score { get; private set; }
        public string Name { get; set; }

        public ScoreboardEntry(int Score) {
            this.Score = Score;
        }
    }
}
