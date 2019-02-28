using Brick_Breaker.Elements.Helpers;
using Brick_Breaker.Elements.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Brick_Breaker.Elements
{
    public class Brick : ISquare
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Brick(Vector2 position)
        {
            Texture = TextureHelper.CreateSquare(Width, Height);

            Position = position;
        }
    }
}
