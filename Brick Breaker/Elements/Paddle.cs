using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Brick_Breaker.Elements
{
    public class Paddle
    {
        private readonly GraphicsDeviceManager _graphics;
        private readonly Texture2D _texture;

        private Vector2 _position;
        private int _speed = 800;
        private int _width = 80;
        private int _height = 20;

        public Paddle(BrickBreaker brickBreaker)
        {

            _texture = new Texture2D(BrickBreaker.GraphicsDevice2, _width, _height);
            SetTextureData();

            // Initial position
            _position = new Vector2
            {
                X = BrickBreaker.ScreenWidth / 2 - _width / 2,
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

            _position.X = mouseStateX;
        }

        private void KeyboardControls()
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Left) && _position.X > 0)
            {
                _position.X -= _speed * BrickBreaker.DeltaTime; // todo : ajouter le deltatime
            }

            if (keyboardState.IsKeyDown(Keys.Right) && _position.X < BrickBreaker.ScreenWidth - _texture.Width)
            {
                _position.X += _speed * BrickBreaker.DeltaTime; // todo : ajouter le deltatime
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // We draw paddle in the bottom-middle of the screen
            spriteBatch.Draw(_texture, _position, Color.White);
        }

        private void SetTextureData()
        {
            Color[] data = new Color[_width * _height]
                .Select(x => x = Color.White)
                .ToArray();
            
            _texture.SetData(data);
        }
    }
}
