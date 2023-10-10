using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EpochsUnbound.Utils;

namespace EpochsUnbound.Utils
{
    public static class SpriteBatchExtensions
    {
        public static void DrawLine(this SpriteBatch spriteBatch, EpochsUnbound.Utils.Point start, EpochsUnbound.Utils.Point end, Texture2D texture, Color color)
        {
            Vector2 startVector = new Vector2((float)start.x, (float)start.y);
            Vector2 endVector = new Vector2((float)end.x, (float)end.y);
            Vector2 edge = endVector - startVector;
            float angle = (float)Math.Atan2(edge.Y, edge.X);

            spriteBatch.Draw(texture,
                new Rectangle((int)startVector.X, (int)startVector.Y, (int)edge.Length(), 1),
                null,
                color,
                angle,
                new Vector2(0, 0),
                SpriteEffects.None,
                0);
        }
    }
}
