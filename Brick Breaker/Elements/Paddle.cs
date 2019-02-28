using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Brick_Breaker.Elements
{
    public class Paddle
    {
        public Vector2 Position;
        public int Width = 80;
        public int Height = 20;

        private readonly Texture2D _texture;
        
        private int _speed = 800;
        

        public Paddle()
        {
            _texture = new Texture2D(BrickBreaker.GraphicsDevice2, Width, Height);
            SetTextureData();

            // Initial position
            Position = new Vector2
            {
                X = BrickBreaker.ScreenWidth / 2 - Width / 2,
                Y = BrickBreaker.ScreenHeight - 20
            };
        }

        public void Controls()
        {
            MouseControls();
            KeyboardControls();
        }

        private void MouseControls()
        {
            var mouseState = Mouse.GetState();

            var mouseStateX = mouseState.X;

            if (mouseStateX < 0)
            {
                mouseStateX = 0;
            }

            if (mouseStateX > BrickBreaker.ScreenWidth - _texture.Width)
            {
                mouseStateX = BrickBreaker.ScreenWidth - _texture.Width;
            }

            Position.X = mouseStateX;
        }

        private void KeyboardControls()
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Left) && Position.X > 0)
            {
                Position.X -= _speed * BrickBreaker.DeltaTime;
            }

            if (keyboardState.IsKeyDown(Keys.Right) && Position.X < BrickBreaker.ScreenWidth - _texture.Width)
            {
                Position.X += _speed * BrickBreaker.DeltaTime;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // We draw paddle in the bottom-middle of the screen
            spriteBatch.Draw(_texture, Position, Color.White);
        }

        private void SetTextureData()
        {
            Color[] data = new Color[Width * Height]
                .Select(x => x = Color.White)
                .ToArray();
            
            _texture.SetData(data);
        }
    }
}
