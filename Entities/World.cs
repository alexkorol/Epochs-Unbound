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

            // Draw hex grid overlay
            Texture2D pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.LightBlue });

            Layout layout = new Layout(Layout.FlatTop, new Point(64, 64), new Point(0, 0));

            for (int x = 0; x < Tiles.GetLength(0); x++)
            {
                for (int y = 0; y < Tiles.GetLength(1); y++)
                {
                    Hex hex = new Hex(x, y, -x - y);
                    Point[] corners = Layout.PolygonCorners(layout, hex);

                    for (int i = 0; i < 6; i++)
                    {
                        Point start = corners[i];
                        Point end = corners[(i + 1) % 6];
                        spriteBatch.DrawLine(start, end, pixel, Color.LightBlue);
                    }
                }
            }
        }
    }
}
