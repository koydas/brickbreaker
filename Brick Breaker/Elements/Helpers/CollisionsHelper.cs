using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Brick_Breaker.Elements.Helpers
{
    public static class BallCollisionsExtension
    {
        public static void BricksCollisions(this Ball ball, List<Brick> bricks)
        {
            foreach (var brick in bricks.Where(x => !x.Destroyed))
            {
                if (brick.Position.Y + brick.Height > ball.Position.Y &&
                    (ball.Position.X > brick.Position.X && ball.Position.X < brick.Position.X + brick.Width))
                {
                    ScoreSystem.BreakBrick();

                    brick.Destroyed = true;
                    ball.Velocity.Y *= -1;

                    ball.Position = new Vector2
                    {
                        X = ball.Position.X,
                        Y = brick.Position.Y + brick.Height
                    };
                }
            }
        }

        public static void PaddleCollisions(this Ball ball, Paddle paddle)
        {
            if (ball.Position.Y + ball.Radius > BrickBreaker.ScreenHeight - paddle.Height && // Hauteur
                (ball.Position.X > paddle.Position.X && ball.Position.X < paddle.Position.X + paddle.Width)) // Largeur
            {
                ball.Velocity.Y *= -1;

                ball.Position = new Vector2
                {
                    X = ball.Position.X,
                    Y = BrickBreaker.ScreenHeight - paddle.Height - ball.Radius
                };
            }
        }

        public static void WallsCollisions(this Ball ball)
        {
            var rightWallCondition = ball.Position.X + ball.Radius > BrickBreaker.ScreenWidth;
            var leftWallCondition = ball.Position.X + ball.Radius < 0;

            var newPosition = ball.Position;

            if (rightWallCondition || leftWallCondition)
            {
                ball.Velocity.X *= -1;

                newPosition.X = rightWallCondition
                    ? BrickBreaker.ScreenWidth - ball.Radius
                    : 0;
            }

            if (ball.Position.Y - ball.Radius < 0)
            {
                ball.Velocity.Y *= -1;
                newPosition.Y = 0 + ball.Radius;
            }

            ball.Position = newPosition;
        }

        public static void OffScreen(this Ball ball)
        {
            if (ball.Position.Y + ball.Radius > BrickBreaker.ScreenHeight)
            {
                ScoreSystem.LoseBall();
                ball.Glued = true;
            }
        }
    }
}
