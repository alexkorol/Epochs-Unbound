using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EpochsUnbound.Utils;

namespace EpochsUnbound.GameModes
{
    public class AdventurerMode
    {
        public Camera Camera { get; private set; }

        public AdventurerMode()
        {
            Camera = new Camera();
        }

        public void UpdateAdventurerMode(GameTime gameTime)
        {
            // Update logic for AdventurerMode goes here
        }

        public void DrawAdventurerMode(GraphicsDevice graphicsDevice, BasicEffect basicEffect)
        {
            // Drawing logic for AdventurerMode goes here
        }
    }
}
