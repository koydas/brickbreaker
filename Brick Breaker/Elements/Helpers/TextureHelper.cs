using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Brick_Breaker.Elements.Helpers
{
    public static class TextureHelper
    {
        public static Texture2D CreateSquare(int width, int height)
        {
            var texture = new Texture2D(BrickBreaker.GraphicsDevice2, width, height);
            texture = SetSquareTextureData(texture, width, height);

            return texture;
        }

        public static Texture2D CreateCircle(int radius)
        {
            Texture2D texture = new Texture2D(BrickBreaker.GraphicsDevice2, radius, radius);
            texture = SetCircleTextureData(texture, radius);

            return texture;
        }

        private static Texture2D SetSquareTextureData(Texture2D texture, int width, int height)
        {
            Color[] data = new Color[width * height]
                .Select(x => x = Color.White)
                .ToArray();

            texture.SetData(data);

            return texture;
        }

        private static Texture2D SetCircleTextureData(Texture2D texture, int radius)
        {
            Color[] colorData = new Color[radius * radius];

            float diam = radius / 2f;
            float diamsq = diam * diam;

            for (int x = 0; x < radius; x++)
            {
                for (int y = 0; y < radius; y++)
                {
                    int index = x * radius + y;
                    Vector2 pos = new Vector2(x - diam, y - diam);
                    if (pos.LengthSquared() <= diamsq)
                    {
                        colorData[index] = Color.White;
                    }
                    else
                    {
                        colorData[index] = Color.Transparent;
                    }
                }
            }

            texture.SetData(colorData);
            return texture;
        }
    }
}
