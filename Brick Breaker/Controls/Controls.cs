using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Brick_Breaker.Elements.Helpers
{
    public static class Controls
    {
        public static void MouseControls(Paddle paddle)
        {
            var mouseState = Mouse.GetState();

            var mouseStateX = mouseState.X;

            if (mouseStateX < 0)
            {
                mouseStateX = 0;
            }

            if (mouseStateX > BrickBreaker.ScreenWidth - paddle.Texture.Width)
            {
                mouseStateX = BrickBreaker.ScreenWidth - paddle.Texture.Width;
            }

            paddle.Position = new Vector2(mouseStateX, paddle.Position.Y);
        }
    }
}
