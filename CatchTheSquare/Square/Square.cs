using System;
using SFML.Graphics;
using SFML.System;

namespace CatchTheSquare
{
    public class Square
    {
        public static Vector2f DefaultSize = new Vector2f(100, 100);

        public bool IsActive = true;
        public bool bonusActive = false;

        public RectangleShape shape;
        public CircleShape shapeCircle;
        protected Sprite shapeSprite;

        protected float movementSpeed;
        protected Vector2f movementTarget;
        protected IntRect movementBounds;

        public Square(float movementSpeed, IntRect movemetBounds) 
        {    
            this.movementSpeed = movementSpeed;
            this.movementBounds = movemetBounds;

            UpdateMovementTarget();        
        }
        public virtual void Move()
        {
            
        }

        public virtual void Draw(RenderWindow win) 
        {
            if (IsActive == false) return;        
        }


        public virtual void CheckMousePosition(Vector2i mousePos) 
        {
            if (IsActive == false) return;
        }

        protected void UpdateMovementTarget() 
        {            
            movementTarget.X = Mathf.Random.Next(movementBounds.Left, movementBounds.Left + movementBounds.Width);
            movementTarget.Y = Mathf.Random.Next(movementBounds.Top, movementBounds.Top + movementBounds.Height);        
        }
        protected virtual void OnClick() { }
        protected virtual void OnReachedTarget() { }        
    }
}
