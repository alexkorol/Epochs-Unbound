using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using EpochsUnbound.GameModes;

namespace EpochsUnbound
{
    public enum GameState
    {
        MainMenu,
        AdventurerMode,
        FirstPersonMode,
        Inventory,
        WorldSimMode,
        SkillTree
    }

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        private AdventurerMode adventurerMode;

        List<string> menuOptions;
        int selectedMenuIndex = 0;
        GameState CurrentState;

        Vector3 cameraPosition;
        Vector3 cameraDirection;
        float movementSpeed;
        MouseState previousMouseState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            cameraPosition = new Vector3(0, 0, 0);
            cameraDirection = new Vector3(0, 0, -1);
            movementSpeed = 0.1f;

            adventurerMode = new AdventurerMode();
        }

        protected override void Initialize()
        {
            menuOptions = new List<string>
            {
                "Adventurer Mode",
                "1st Person Mode",
                "Inventory",
                "WorldSim Mode",
                "SkillTree",
                "Exit"
            };

            CurrentState = GameState.MainMenu;

            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 800; // or your desired width
            graphics.PreferredBackBufferHeight = 600; // or your desired height
            graphics.ApplyChanges();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("eu");
        }

        protected override void Update(GameTime gameTime)
        {
            if (graphics.PreferredBackBufferWidth != Window.ClientBounds.Width ||
    graphics.PreferredBackBufferHeight != Window.ClientBounds.Height)
            {
                graphics.PreferredBackBufferWidth = Math.Min(Window.ClientBounds.Width, 1200);
                graphics.PreferredBackBufferHeight = Math.Min(Window.ClientBounds.Height, 900);
                graphics.ApplyChanges();
            }

            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.W))
            {
                cameraPosition += cameraDirection * movementSpeed;
            }
            if (state.IsKeyDown(Keys.S))
            {
                cameraPosition -= cameraDirection * movementSpeed;
            }
            if (state.IsKeyDown(Keys.A))
            {
                cameraPosition += Vector3.Cross(new Vector3(0, 1, 0), cameraDirection) * movementSpeed;
            }
            if (state.IsKeyDown(Keys.D))
            {
                cameraPosition -= Vector3.Cross(new Vector3(0, 1, 0), cameraDirection) * movementSpeed;
            }

            MouseState currentMouseState = Mouse.GetState();

            if (CurrentState == GameState.MainMenu)
            {
                if (menuOptions.Count > 0)
                {
                    Rectangle menuRect = new Rectangle(50, 50, 200, menuOptions.Count * 45);

                    if (menuRect.Contains(currentMouseState.Position))
                    {
                        selectedMenuIndex = (currentMouseState.Y - 50) / 45;

                        if (previousMouseState.LeftButton == ButtonState.Released &&
                            currentMouseState.LeftButton == ButtonState.Pressed)
                        {
                            switch (selectedMenuIndex)
                            {
                                case 0:
                                    CurrentState = GameState.AdventurerMode;
                                    break;
                                case 1:
                                    CurrentState = GameState.FirstPersonMode;
                                    break;
                                case 2:
                                    CurrentState = GameState.Inventory;
                                    break;
                                case 3:
                                    CurrentState = GameState.WorldSimMode;
                                    break;
                                case 4:
                                    CurrentState = GameState.SkillTree;
                                    break;
                                case 5:
                                    Exit();
                                    break;
                            }
                        }
                    }
                }
            }

            if (CurrentState == GameState.AdventurerMode)
            {
                // Assuming you have an instance of AdventurerMode class named adventurerMode
                adventurerMode.UpdateAdventurerMode(gameTime);
            }
            else if (CurrentState != GameState.MainMenu && state.IsKeyDown(Keys.Escape))
            {
                CurrentState = GameState.MainMenu;
            }

            previousMouseState = currentMouseState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            switch (CurrentState)
            {
                case GameState.MainMenu:
                    DrawMainMenu();
                    break;

                case GameState.AdventurerMode:
                    // Assuming you have an instance of AdventurerMode class named adventurerMode
                    adventurerMode.DrawAdventurerMode(GraphicsDevice, new BasicEffect(GraphicsDevice));
                    break;

                case GameState.FirstPersonMode:
                    DrawFirstPersonMode();
                    break;

                case GameState.Inventory:
                    spriteBatch.DrawString(font, "Inventory Mode - Press I to return", new Vector2(50, 200), Color.White);
                    break;

                case GameState.WorldSimMode:
                    spriteBatch.DrawString(font, "World Simulation Mode - Press W to return", new Vector2(50, 200), Color.White);
                    break;

                case GameState.SkillTree:
                    spriteBatch.DrawString(font, "Skill Tree Mode - Press S to return", new Vector2(50, 200), Color.White);
                    break;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawMainMenu()
        {
            int yOffset = 0;
            for (int i = 0; i < menuOptions.Count; i++)
            {
                Color color = Color.White;
                if (i == selectedMenuIndex)
                {
                    color = Color.Yellow;
                }
                spriteBatch.DrawString(font, menuOptions[i], new Vector2(50, 50 + yOffset), color, 0, new Vector2(0, 0), 1.5f, SpriteEffects.None, 0);
                yOffset += 45;
            }
        }

        private void DrawFirstPersonMode()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            BasicEffect effect = new BasicEffect(GraphicsDevice);
            effect.VertexColorEnabled = true;

            effect.View = Matrix.CreateLookAt(cameraPosition, cameraPosition + cameraDirection, Vector3.Up);
            effect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, GraphicsDevice.Viewport.AspectRatio, 0.1f, 100f);

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                // Draw a simple cube
                VertexPositionColor[] vertices = new VertexPositionColor[8];
                int[] indices = new int[24];

                // Define the cube vertices
                vertices[0] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.White);
                vertices[1] = new VertexPositionColor(new Vector3(1, -1, -1), Color.White);
                vertices[2] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.White);
                vertices[3] = new VertexPositionColor(new Vector3(1, 1, -1), Color.White);
                vertices[4] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.White);
                vertices[5] = new VertexPositionColor(new Vector3(1, -1, 1), Color.White);
                vertices[6] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.White);
                vertices[7] = new VertexPositionColor(new Vector3(1, 1, 1), Color.White);

                // Define the cube edges
                indices[0] = 0; indices[1] = 1;
                indices[2] = 0; indices[3] = 2;
                indices[4] = 1; indices[5] = 3;
                indices[6] = 2; indices[7] = 3;
                indices[8] = 4; indices[9] = 5;
                indices[10] = 4; indices[11] = 6;
                indices[12] = 5; indices[13] = 7;
                indices[14] = 6; indices[15] = 7;
                indices[16] = 0; indices[17] = 4;
                indices[18] = 1; indices[19] = 5;
                indices[20] = 2; indices[21] = 6;
                indices[22] = 3; indices[23] = 7;

                // Draw the cube
                GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.LineList, vertices, 0, 8, indices, 0, 12);
            }
        }
    }
}
