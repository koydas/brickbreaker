using System.Collections.Generic;
using System.Linq;
using Brick_Breaker.Elements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Brick_Breaker.Levels
{
    public static class LevelHelper
    {
        public static List<Brick> GenerateLevel(int rowCount, int columnCount, int? brickWidth = null, int brickHeight = 20)
        {
            var brickList = new List<Brick>();

            int spaceBetweenBricks = 3;
            var position = new Vector2(0, spaceBetweenBricks);

            if (brickWidth == null)
            {
                brickWidth = (BrickBreaker.ScreenWidth / columnCount) - spaceBetweenBricks;
            }

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    brickList.Add(new Brick(position, brickWidth.Value, brickHeight));
                    position.X += brickList[j].Texture.Width + spaceBetweenBricks;
                }

                position.X = 0;
                position.Y += brickList[i].Texture.Height + spaceBetweenBricks;
            }

            return brickList;
        }

        public static void DrawLevel(this SpriteBatch spriteBatch, List<Brick> brickList)
        {
            foreach (var brick in brickList.Where(x => !x.Destroyed))
            {
                brick.Draw(spriteBatch);
            }
        }
    }
}
