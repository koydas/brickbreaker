using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Brick_Breaker.Elements
{
    public class Brick
    {
        public Vector2 Position;
        public int Width = 80;
        public int Height = 20;

        private readonly Texture2D _texture;

        public Brick(Vector2 position)
        {
            //_texture = new Texture2D(BrickBreaker.GraphicsDevice2, Width, Height);
            //SetTextureData();

            Position = position;
        }
    }
}
