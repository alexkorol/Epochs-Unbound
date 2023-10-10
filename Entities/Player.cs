using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EpochsUnbound.Utils;

namespace EpochsUnbound.Entities
{
    public class Player
    {
        public Vector2 Position { get; private set; }
        public float Speed { get; private set; }

        public Player(float speed)
        {
            Position = Vector2.Zero;
            Speed = speed;
        }

        public void Move(HexDirection direction)
        {
            Vector2 newPosition = Position;
            switch (direction)
            {
                case HexDirection.NorthWest:
                    newPosition.Y -= Speed;
                    break;
                case HexDirection.NorthEast:
                    newPosition.Y -= Speed;
                    break;
                case HexDirection.East:
                    newPosition.X += Speed;
                    break;
                case HexDirection.SouthEast:
                    newPosition.Y += Speed;
                    break;
                case HexDirection.SouthWest:
                    newPosition.Y += Speed;
                    break;
                case HexDirection.West:
                    newPosition.X -= Speed;
                    break;
            }
            Position = newPosition;
        }

        public void Update(GameTime gameTime)
        {
            // Implement update logic here
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            // Implement draw logic here
        }
    }
}
