using System.Collections.Generic;
using Brick_Breaker.Elements.Helpers;
using Brick_Breaker.Elements.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Brick_Breaker.Elements
{
    public class Ball : ICircle
    {
        public bool Glued;

        #region Implementation of ICircle

        public Vector2 Position { get; set; }
        public int Radius { get; set; }
        
        #endregion

        public Vector2 Velocity = Vector2.Zero;
        
        private readonly Texture2D _texture;

        public Ball()
        {
            Radius = 20;
            Glued = true;
            _texture = TextureHelper.CreateCircle(Radius);
            Position = new Vector2(1, BrickBreaker.ScreenHeight - 40);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }

        public void Update(Paddle paddle, List<Brick> bricks)
        {
            GluedManagement(paddle);

            this.WallsCollisions();
            this.PaddleCollisions(paddle);
            this.BricksCollisions(bricks);
            this.OffScreen();
        }

        private void GluedManagement(Paddle paddle)
        {
            if (Glued)
            {
                Position = new Vector2
                {
                    X = (paddle.Position.X + paddle.Width / (float) 2),
                    Y = paddle.Position.Y - paddle.Height
                };

                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    SendBall();
                }
            }
            else
            {
                Position = new Vector2
                {
                    X = Position.X + Velocity.X * BrickBreaker.DeltaTime,
                    Y = Position.Y + Velocity.Y * BrickBreaker.DeltaTime
                };
            }
        }

        private void SendBall()
        {
            Glued = false;

            Velocity.X = 200;
            Velocity.Y = -200;
        }
    }
}
