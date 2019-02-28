using Microsoft.Xna.Framework.Graphics;

namespace Brick_Breaker.Elements.Interfaces
{
    public interface ISquare : IPosition
    {
        Texture2D Texture { get; set; }

        int Width { get; set; }
        int Height { get; set; }
    }
}
