using Microsoft.Xna.Framework;

namespace Brick_Breaker.Elements.Helpers
{
    public static class ScoreSystem
    {
        public static int Score;
        public static Vector2 Position;

        public static void BreakBrick()
        {
            AddPoints(100);
        }

        public static void LoseBall()
        {
            AddPoints(-1000);
        }

        private static void AddPoints(int points)
        {
            Score += points;

            if (Score < 0)
            {
                Score = 0;
            }
        }
    }
}
