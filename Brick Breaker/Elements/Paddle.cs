using Brick_Breaker.Elements.Helpers;
using Brick_Breaker.Elements.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Brick_Breaker.Elements
{
    public class Paddle : ISquare
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        
        public Paddle()
        {
            Width = 80;
            Height = 20;
            Texture = TextureHelper.CreateSquare(Width, Height);

            Position = new Vector2
            {
                X = BrickBreaker.ScreenWidth / 2 - Width / 2,
                Y = BrickBreaker.ScreenHeight - 20
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
