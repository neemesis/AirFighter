using AirFighter.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirFighter {
    public class Player : SpaceShip {

        public Player() : base (new Point(580, 200), 100, Resources.plane2) {
        }

        public override void RemoveHealth() {
            Health -= 10;
        }

        public override void Shot() {
            
        }
    }
}
