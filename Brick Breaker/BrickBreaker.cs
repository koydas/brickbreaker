using System.Collections.Generic;
using System.Linq;
using Brick_Breaker.Elements;
using Brick_Breaker.Elements.Helpers;
using Brick_Breaker.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Brick_Breaker
{
    public class BrickBreaker : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Paddle _paddle;
        private Ball _ball;

        public static int ScreenWidth;
        public static int ScreenHeight;
        public static float DeltaTime;
        public static GraphicsDevice Graphics;
        private List<Brick> _brickList = new List<Brick>();

        public BrickBreaker()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Graphics = GraphicsDevice;

            ScreenWidth = GraphicsDevice.PresentationParameters.Bounds.Width;
            ScreenHeight = GraphicsDevice.PresentationParameters.Bounds.Height;

            _paddle = new Paddle();
            _ball = new Ball();

            _brickList = LevelHelper.GenerateLevel(5, 10);

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

            _spriteBatch.DrawLevel(_brickList);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
