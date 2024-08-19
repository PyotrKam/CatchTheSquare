using System;
using SFML.Graphics;
using SFML.System;

namespace CatchTheSquare
{
    public class Square
    {
        public bool IsActive = true;

        private RectangleShape shape;
        private float movementSpeed;
        private Vector2f movementTarget;
        private IntRect movementBounds;

        public Square(Vector2f position, float movementSpeed, IntRect movemetBounds) 
        {
            shape = new RectangleShape(new Vector2f(100, 100));
            shape.Position = position;

            this.movementSpeed = movementSpeed;
            this.movementBounds = movemetBounds;

            UpdateMovementTarget();        
        
        }

        public void Move()
        {
            Vector2f dir = movementTarget - shape.Position;
            float magnitude = (float) Math.Sqrt(dir.X * dir.X + dir.Y * dir.Y);

            if (magnitude <= movementSpeed)
            {
                shape.Position = movementTarget;
            }
            else
            {
                shape.Position += dir / magnitude * movementSpeed;
            }

            

            if (shape.Position == movementTarget)
            {
                UpdateMovementTarget();
            }

        }

        public void Draw(RenderWindow win) 
        {
            if (IsActive == false) return;

            win.Draw(shape);
        
        }

        private void UpdateMovementTarget() 
        {
            Random rnd = new Random();

            movementTarget.X = rnd.Next(movementBounds.Left, movementBounds.Left + movementBounds.Width);
            movementTarget.Y = rnd.Next(movementBounds.Top, movementBounds.Top + movementBounds.Height);
        
        }

        
    }
}
