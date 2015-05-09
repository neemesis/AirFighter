using AirFighter.Properties;
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
        /// <param name="Side">Promenliva koja oznachuva na koja strana kje se dvizhi.</param>
        public void Move(int Side, Point p) {
            if (Side == 3) {
                int c = p.X - 28;
                if (c < 0)
                    c = 0;
                else if (c > 326)
                    c = 326;
                Position = new Point(c, Position.Y);
            } else if (Side == 1) {
                int c = Position.X + 11;
                if (c > 326)
                    c = 326;
                Position = new Point(c, Position.Y);
            } else if (Side == 2) {
                int c = Position.X - 11;
                if (c < 0)
                    c = 0;
                Position = new Point(c, Position.Y);
            }
        }
    }
}
