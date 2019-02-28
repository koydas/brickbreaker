using Brick_Breaker.Elements.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Brick_Breaker.Elements
{
    public class Ball
    {
        public bool Glued;
        public Vector2 Position;
        public Vector2 Velocity = Vector2.Zero;

        private int _radius = 20;
        
        private readonly Texture2D _texture;

        public Ball()
        {
            Glued = true;
            _texture = TextureHelper.CreateCircle(_radius);
            Position = new Vector2(1, BrickBreaker.ScreenHeight - 40);
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            // We draw paddle in the bottom-middle of the screen
            spriteBatch.Draw(_texture, Position, Color.White);
        }

        public void Update(Paddle paddle)
        {
            GluedManagement(paddle);
            Collisions(paddle);
        }

        private void Collisions(Paddle paddle)
        {
            var rightWallCondition = Position.X + _radius > BrickBreaker.ScreenWidth;
            var leftWallCondition = Position.X + _radius < 0;

            if (rightWallCondition || leftWallCondition)
            {
                Velocity.X *= -1;

                Position.X = rightWallCondition 
                    ? BrickBreaker.ScreenWidth - _radius 
                    : 0;
            }

            if (Position.Y - _radius < 0)
            {
                Velocity.Y *= -1;
                Position.Y = 0 + _radius;
            }

            if (Position.Y + _radius > BrickBreaker.ScreenHeight - paddle.Height && // Hauteur
                 (Position.X >= paddle.Position.X && Position.X <= paddle.Position.X + paddle.Width)) // Largeur
            {
                Velocity.Y *= -1;
            }

            // Dead
            if (Position.Y + _radius >= BrickBreaker.ScreenHeight)
            {
                Glued = true;
            }
        }

        private void GluedManagement(Paddle paddle)
        {
            if (Glued)
            {
                Position.X = (paddle.Position.X + paddle.Width / (float)2);
                Position.Y = paddle.Position.Y - paddle.Height;

                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    SendBall();
                }
            }
            else
            {
                Position.X += Velocity.X * BrickBreaker.DeltaTime;
                Position.Y += Velocity.Y * BrickBreaker.DeltaTime;
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
