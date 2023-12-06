using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    public class MapController
    {
        public Image arcanoidSet;

        public const int mapWidth = 20;
        public const int mapHeight = 30;

        public int[,] map = new int[mapHeight, mapWidth];

        public MapController()
        {
            arcanoidSet = new Bitmap("C:\\Users\\Sulpa\\OneDrive\\Документы\\ПИОГИ\\arcanoid.png");
        }

        public void AddLine()
        {
            for (int i = mapHeight - 2; i > 0; i--)
            {
                for (int j = 0; j < MapController.mapWidth; j += 2)
                {
                   map[i, j] = map[i - 1, j];
                }
            }
            Random r = new Random();
            for (int j = 0; j < mapWidth; j += 2)
            {
                int currPlatform = r.Next(1, 5);
                map[0, j] = currPlatform;
                map[0, j + 1] = currPlatform + currPlatform * 10;
            }
        }

        public void DrawMap(Graphics g,Player player)
        {
            g.DrawImage(arcanoidSet, new Rectangle(new Point(player.platformX, player.platformY), new Size(60, 20)), 398+(170*player.platformAnnimationFrame), 17, 150, 50, GraphicsUnit.Pixel);
            g.DrawImage(arcanoidSet, new Rectangle(new Point(player.ballX,player.ballY), new Size(20, 20)), 806, 548, 73, 73, GraphicsUnit.Pixel);
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if (map[i, j] == 1)
                    {
                        g.DrawImage(arcanoidSet, new Rectangle(new Point(j * 20, i * 20), new Size(40, 20)), 20, 16, 170, 59, GraphicsUnit.Pixel);
                    }
                    if (map[i, j] == 2)
                    {
                        g.DrawImage(arcanoidSet, new Rectangle(new Point(j * 20, i * 20), new Size(40, 20)), 20, 16 + 77 * (map[i, j] - 1), 170, 59, GraphicsUnit.Pixel);
                    }
                    if (map[i, j] == 3)
                    {
                        g.DrawImage(arcanoidSet, new Rectangle(new Point(j * 20, i * 20), new Size(40, 20)), 20, 16 + 77 * (map[i, j] - 1), 170, 59, GraphicsUnit.Pixel);
                    }
                    if (map[i, j] == 4)
                    {
                        g.DrawImage(arcanoidSet, new Rectangle(new Point(j * 20, i * 20), new Size(40, 20)), 20, 16 + 77 * (map[i, j] - 1), 170, 59, GraphicsUnit.Pixel);
                    }
                    if (map[i, j] == 5)
                    {
                        g.DrawImage(arcanoidSet, new Rectangle(new Point(j * 20, i * 20), new Size(40, 20)), 20, 16 + 77 * (map[i, j] - 1), 170, 59, GraphicsUnit.Pixel);
                    }
                }
            }
        }

        public void DrawArea(Graphics g)
        {
            g.DrawRectangle(Pens.Black, new Rectangle(0, 0, MapController.mapWidth * 20, MapController.mapHeight * 20));
        }
    }
}
