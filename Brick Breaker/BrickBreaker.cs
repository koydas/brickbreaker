using System;
using System.Collections.Generic;
using System.Linq;
using Brick_Breaker.Elements;
using Brick_Breaker.Elements.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Brick_Breaker
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class BrickBreaker : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Paddle _paddle;
        private Ball _ball;

        public static int ScreenWidth;
        public static int ScreenHeight;
        public static float DeltaTime;
        public static GraphicsDevice GraphicsDevice2;
        private List<Brick> _brickList = new List<Brick>();

        public BrickBreaker()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            GraphicsDevice2 = GraphicsDevice;

            ScreenWidth = GraphicsDevice.PresentationParameters.Bounds.Width;
            ScreenHeight = GraphicsDevice.PresentationParameters.Bounds.Height;

            _paddle = new Paddle();
            _ball = new Ball();

            int spaceBetweenBricks = 3;
            var position = new Vector2(0, spaceBetweenBricks);
            var brickWidth = (ScreenWidth / 10) - spaceBetweenBricks;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    _brickList.Add(new Brick(position, brickWidth, 20));
                    position.X += _brickList[j].Texture.Width + spaceBetweenBricks;
                }

                position.X = 0;
                position.Y += _brickList[i].Texture.Height + spaceBetweenBricks;
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Controls.MouseControls(_paddle);
            _ball.Update(_paddle, _brickList);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _paddle.Draw(_spriteBatch);
            _ball.Draw(_spriteBatch);

            foreach (var brick in _brickList.Where(x => !x.Destroyed))
            {
                brick.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
