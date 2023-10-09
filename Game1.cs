using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace EpochsUnbound
{
    public enum GameState
    {
        MainMenu,
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

        List<string> menuOptions;
        int selectedMenuIndex = 0;
        GameState CurrentState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            menuOptions = new List<string>
            {
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

            MouseState mouseState = Mouse.GetState();

            MouseState previousMouseState = Mouse.GetState();

            if (CurrentState == GameState.MainMenu)
            {
                if (menuOptions.Count > 0)
                {
                    Rectangle menuRect = new Rectangle(50, 50, 200, menuOptions.Count * 45);

                    if (menuRect.Contains(mouseState.Position))
                    {
                        selectedMenuIndex = (mouseState.Y - 50) / 45;

                        if (previousMouseState.LeftButton == ButtonState.Pressed &&
                            mouseState.LeftButton == ButtonState.Released)
                        {
                            switch (selectedMenuIndex)
                            {
                                case 0:
                                    CurrentState = GameState.FirstPersonMode;
                                    break;
                                case 1:
                                    CurrentState = GameState.Inventory;
                                    break;
                                case 2:
                                    CurrentState = GameState.WorldSimMode;
                                    break;
                                case 3:
                                    CurrentState = GameState.SkillTree;
                                    break;
                                case 4:
                                    this.Exit(); // Directly exit when the "Exit" menu item is selected
                                    break;
                            }
                        }
                    }
                }
            }

            else
            {
                KeyboardState state = Keyboard.GetState();

                if (CurrentState == GameState.FirstPersonMode && state.IsKeyDown(Keys.Space))
                {
                    CurrentState = GameState.MainMenu;
                }
                else if (CurrentState == GameState.Inventory && state.IsKeyDown(Keys.I))
                {
                    CurrentState = GameState.MainMenu;
                }
                else if (CurrentState == GameState.WorldSimMode && state.IsKeyDown(Keys.W))
                {
                    CurrentState = GameState.MainMenu;
                }
                else if (CurrentState == GameState.SkillTree && state.IsKeyDown(Keys.S))
                {
                    CurrentState = GameState.MainMenu;
                }
            }

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
            // TODO: Add code here to render the 3D environment for the first person mode
        }
    }
}