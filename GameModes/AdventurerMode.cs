using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EpochsUnbound.Entities;

namespace EpochsUnbound.GameModes
{
    public class AdventurerMode
    {
        public Player Player { get; private set; }
        public World World { get; private set; }

        public AdventurerMode()
        {
            Player = new Player();
            World = new World(100, 100); // Initialize with a 100x100 world
        }

        public void MovePlayer(Direction direction)
        {
            Player.Move(direction);
        }

        public void UpdateAdventurerMode(GameTime gameTime)
        {
            Player.Update(gameTime);
            World.Update(gameTime);
        }

        public void DrawAdventurerMode(SpriteBatch spriteBatch, SpriteFont font)
        {
            World.Draw(spriteBatch, font);
            Player.Draw(spriteBatch, font);
        }
    }
}
