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
            switch (direction)
            {
                case Direction.Up:
                    Position.Y -= Speed;
                    break;
                case Direction.Down:
                    Position.Y += Speed;
                    break;
                case Direction.Left:
                    Position.X -= Speed;
                    break;
                case Direction.Right:
                    Position.X += Speed;
                    break;
            }
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
