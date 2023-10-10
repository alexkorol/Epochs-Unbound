using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EpochsUnbound.Entities
{
    public class Player
    {
        public Vector2 Position { get; private set; }
        public float Speed { get; private set; }

        public Player()
        {
            Position = Vector2.Zero;
            Speed = 1.0f;
        }

        public void Move(Direction direction)
        {
            Vector2 newPosition = Position;
            switch (direction)
            {
                case Direction.Up:
                    newPosition.Y -= Speed;
                    break;
                case Direction.Down:
                    newPosition.Y += Speed;
                    break;
                case Direction.Left:
                    newPosition.X -= Speed;
                    break;
                case Direction.Right:
                    newPosition.X += Speed;
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
