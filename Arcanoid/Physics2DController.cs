using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcanoid
{
    class Physics2DController
    {
        public bool IsCollide(Player player,MapController map,Label scoreLabel)
        {
            bool isColliding = false;
            if (player.ballX/20 + player.dirX > MapController.mapWidth - 1 || player.ballX / 20 + player.dirX < 0)
            {
                player.dirX *= -1;
                isColliding = true;
            }
            if (player.ballY / 20 + player.dirY < 0)
            {
                player.dirY *= -1;
                isColliding = true;
            }

            if (map.map[player.ballY / 20 + player.dirY, player.ballX / 20] != 0)
            {
                bool addScore = false;
                isColliding = true;

                if (map.map[player.ballY / 20 + player.dirY, player.ballX / 20] > 10 && map.map[player.ballY / 20 + player.dirY, player.ballX / 20] < 99)
                {
                    map.map[player.ballY / 20 + player.dirY, player.ballX / 20] = 0;
                    map.map[player.ballY / 20 + player.dirY, player.ballX / 20 - 1] = 0;
                    addScore = true;
                }
                else if (map.map[player.ballY / 20 + player.dirY, player.ballX / 20] < 9)
                {
                    map.map[player.ballY / 20 + player.dirY, player.ballX / 20] = 0;
                    map.map[player.ballY / 20 + player.dirY, player.ballX / 20 + 1] = 0;
                    addScore = true;
                }
                if (addScore)
                {
                    player.score += 50;
                    if (player.score % 200 == 0 && player.score > 0)
                    {
                        map.AddLine();
                    }
                }
                player.dirY *= -1;
            }
            if (map.map[player.ballY / 20, player.ballX / 20 + player.dirX] != 0)
            {
                bool addScore = false;
                isColliding = true;

                if (map.map[player.ballY / 20, player.ballX / 20 + player.dirX] > 10 && map.map[player.ballY / 20 + player.dirY, player.ballX / 20] < 99)
                {
                    map.map[player.ballY / 20, player.ballX / 20 + player.dirX] = 0;
                    map.map[player.ballY / 20, player.ballX / 20 + player.dirX - 1] = 0;
                    addScore = true;
                }
                else if (map.map[player.ballY / 20, player.ballX / 20 + player.dirX] < 9)
                {
                    map.map[player.ballY / 20, player.ballX / 20 + player.dirX] = 0;
                    map.map[player.ballY / 20, player.ballX / 20 + player.dirX + 1] = 0;
                    addScore = true;
                }
                if (addScore)
                {
                    player.score += 50;
                    if (player.score % 200 == 0 && player.score > 0)
                    {
                        map.AddLine();
                    }
                }
                player.dirX *= -1;
            }
            scoreLabel.Text = "Score: " + player.score;

            return isColliding;
        }
    }
}
