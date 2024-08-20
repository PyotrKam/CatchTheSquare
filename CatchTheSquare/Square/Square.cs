using System;
using SFML.Graphics;
using SFML.System;

namespace CatchTheSquare
{
    public class Square
    {
        public static Vector2f DefaultSize = new Vector2f(100, 100);

        public bool IsActive = true;

        protected RectangleShape shape;
        protected float movementSpeed;
        protected Vector2f movementTarget;
        protected IntRect movementBounds;

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
                OnReachedTarget();


                UpdateMovementTarget();
            }

        }

        public void Draw(RenderWindow win) 
        {
            if (IsActive == false) return;

            win.Draw(shape);
        
        }


        public void CheckMousePosition(Vector2i mousePos) 
        {
            if (IsActive == false) return;

            if (mousePos.X > shape.Position.X && mousePos.X < shape.Position.X + shape.Size.X 
                && mousePos.Y > shape.Position.Y && mousePos.Y < shape.Position.Y + shape.Size.Y) OnClick();
            
        
        }

        protected void UpdateMovementTarget() 
        {
            Random rnd = new Random();

            movementTarget.X = rnd.Next(movementBounds.Left, movementBounds.Left + movementBounds.Width);
            movementTarget.Y = rnd.Next(movementBounds.Top, movementBounds.Top + movementBounds.Height);
        
        }

        protected virtual void OnClick() { }
        protected virtual void OnReachedTarget() { }

        
    }
}
