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
        }
    }
}
