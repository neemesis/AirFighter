using AirFighter.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirFighter {
    public class PlayerShip : SpaceShip {

        public PlayerShip() : base (new Point(140, 450), 10, Resources.plane2) { }

        public override void Shot() {
            
        }
    }
}
