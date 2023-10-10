using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using EpochsUnbound.GameModes;
using EpochsUnbound.Entities;
using EpochsUnbound.Utils;

namespace EpochsUnbound
{
    public enum GameState
    {
        MainMenu,
        AdventurerMode,
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

            adventurerMode = new AdventurerMode(movementSpeed);
        }

        protected override void Initialize()
        {
            menuOptions = new List<string>
            {
                "Adventurer Mode",
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

        Texture2D playerTexture;

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("eu");
            playerTexture = Content.Load<Texture2D>("player");
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

            if (CurrentState == GameState.AdventurerMode)
            {
                if (state.IsKeyDown(Keys.W))
                {
                    adventurerMode.MovePlayer(HexDirection.NorthWest);
                }
                if (state.IsKeyDown(Keys.E))
                {
                    adventurerMode.MovePlayer(HexDirection.NorthEast);
                }
                if (state.IsKeyDown(Keys.D))
                {
                    adventurerMode.MovePlayer(HexDirection.East);
                }
                if (state.IsKeyDown(Keys.X))
                {
                    adventurerMode.MovePlayer(HexDirection.SouthEast);
                }
                if (state.IsKeyDown(Keys.Z))
                {
                    adventurerMode.MovePlayer(HexDirection.SouthWest);
                }
                if (state.IsKeyDown(Keys.A))
                {
                    adventurerMode.MovePlayer(HexDirection.West);
                }
                if (state.IsKeyDown(Keys.Escape))
                {
                    CurrentState = GameState.MainMenu;
                }
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
                                    CurrentState = GameState.Inventory;
                                    break;
                                case 2:
                                    CurrentState = GameState.WorldSimMode;
                                    break;
                                case 3:
                                    CurrentState = GameState.SkillTree;
                                    break;
                                case 4:
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
                    adventurerMode.DrawAdventurerMode(spriteBatch, font, playerTexture);
                    break;

                // case GameState.FirstPersonMode has been removed as FirstPersonMode no longer exists

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

        // DrawFirstPersonMode method has been removed as FirstPersonMode no longer exists
    }
}
