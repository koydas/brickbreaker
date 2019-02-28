using Microsoft.Xna.Framework.Graphics;

namespace Brick_Breaker.Elements.Interfaces
{
    public interface ICircle : IPosition, IDrawable
    {
        int Radius { get; set; }
    }
}
