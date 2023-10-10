using Microsoft.Xna.Framework;

namespace EpochsUnbound.Utils
{
    public class Camera
    {
        public Vector3 Position { get; private set; }
        public Vector3 Rotation { get; private set; }
        public float Zoom { get; private set; }

        public Camera()
        {
            Position = Vector3.Zero;
            Rotation = Vector3.Zero;
            Zoom = 1.0f;
        }

        public void MoveForward(float speed)
        {
            Position += Vector3.Forward * speed;
        }

        public void MoveBackward(float speed)
        {
            Position += Vector3.Backward * speed;
        }

        public void MoveLeft(float speed)
        {
            Position += Vector3.Left * speed;
        }

        public void MoveRight(float speed)
        {
            Position += Vector3.Right * speed;
        }
    }
}
