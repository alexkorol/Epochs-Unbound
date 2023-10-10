using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EpochsUnbound.Utils
{
    public static class SpriteBatchExtensions
    {
        public static void DrawLine(this SpriteBatch spriteBatch, Point start, Point end, Texture2D texture, Color color)
        {
            Vector2 edge = end.ToVector2() - start.ToVector2();
            float angle = (float)Math.Atan2(edge.Y, edge.X);

            spriteBatch.Draw(texture,
                new Rectangle((int)start.x, (int)start.y, (int)edge.Length(), 1),
                null,
                color,
                angle,
                new Vector2(0, 0),
                SpriteEffects.None,
                0);
        }
    }
}
