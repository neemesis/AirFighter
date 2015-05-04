﻿using AirFighter.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirFighter {
    public class PlayerShip : SpaceShip {

        public PlayerShip() : base (new Point(157, 502), 10, Resources.planeReal) { }

        /// <summary>
        /// Dvizhenje na igrachot levo - desno.
        /// </summary>
        /// <param name="ToLeft">Promenliva koja oznachuva na koja strana kje se dvizhi.</param>
        public void Move(bool ToLeft) {
            if (ToLeft)
                Position = new Point(Position.X + 11, Position.Y);
            else
                Position = new Point(Position.X - 11, Position.Y);
        }

        public override void Shot() {
            
        }
    }
}
