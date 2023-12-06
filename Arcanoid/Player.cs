using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    public class Player
    {
        public int platformX;
        public int platformY;
        public int ballX;
        public int ballY;
        public int score;
        public int lives;
        public int dirX = 0;
        public int dirY = 0;
        public int platformAnnimationFrame = 0; // max = 3;
    }
}
