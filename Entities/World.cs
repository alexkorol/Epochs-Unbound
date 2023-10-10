using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EpochsUnbound.Entities;

namespace EpochsUnbound.Entities
{
    public class World
    {
        public Tile[,] Tiles { get; private set; }

        public World(int width, int height)
        {
            Tiles = new Tile[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Tiles[i, j] = new Tile();
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var tile in Tiles)
            {
                tile.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            foreach (var tile in Tiles)
            {
                tile.Draw(spriteBatch, font);
            }

            // Draw grid overlay
            Texture2D pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.LightBlue });

            for (int x = 0; x < Tiles.GetLength(0); x++)
            {
                spriteBatch.Draw(pixel, new Rectangle(x * 64, 0, 1, Tiles.GetLength(1) * 64), Color.LightBlue);
            }

            for (int y = 0; y < Tiles.GetLength(1); y++)
            {
                spriteBatch.Draw(pixel, new Rectangle(0, y * 64, Tiles.GetLength(0) * 64, 1), Color.LightBlue);
            }
        }
    }
}
