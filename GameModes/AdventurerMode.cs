using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EpochsUnbound.GameModes
{
    public class AdventurerMode
    {
        // Add methods and properties specific to the Adventurer mode here
        private Camera camera;
        private Grid grid;
        private SpriteBatch spriteBatch;
        private Texture2D gradientTexture;
        private Triangle triangle;

        public AdventurerMode(Camera camera, Grid grid, SpriteBatch spriteBatch, Texture2D gradientTexture, Triangle triangle)
        {
            this.camera = camera;
            this.grid = grid;
            this.spriteBatch = spriteBatch;
            this.gradientTexture = gradientTexture;
            this.triangle = triangle;
        }

        public void DrawAdventurerMode(GraphicsDevice graphicsDevice, BasicEffect effect)
        {
            // Draw a grid ground
            effect.World = Matrix.Identity;
            effect.View = camera.View;
            effect.Projection = camera.Projection;
            effect.DiffuseColor = Color.Cyan.ToVector3();
            effect.CurrentTechnique.Passes[0].Apply();
            grid.Draw(graphicsDevice);

            // Draw a gradient sky
            spriteBatch.Begin();
            spriteBatch.Draw(gradientTexture, new Rectangle(0, 0, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height), Color.White);
            spriteBatch.End();

            // Draw a spinning 3D triangle
            triangle.Draw(graphicsDevice, effect);
        }

        public void UpdateAdventurerMode(GameTime gameTime)
        {
            // Handle the movement of the triangle
            triangle.Update(gameTime);
        }
    }
}
