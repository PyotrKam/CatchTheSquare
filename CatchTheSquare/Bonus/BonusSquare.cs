using System;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheSquare
{
    class BonusSquare : Square
    {
        private static Color color = new Color(Color.Blue);
        private static float maxMovementSpeed = 5;
        private static float movementStep = 0.1f;
        private static float minSize = 30;
        public static float sizeStep = 10;


        public BonusSquare(Vector2f position, float movementSpeed, IntRect movementBounds) : base(movementSpeed, movementBounds)
        {
            shape = new RectangleShape(Mathf.defaultSize);
            shape.Position = position;

            shape.FillColor = color;
        }

        public override void Move()
        {
            shape.Position = Mathf.MoveTowards(shape.Position, movementTarget, movementSpeed);

            if (shape.Position == movementTarget)
            {
                OnReachedTarget();

                UpdateMovementTarget();
            }
        }

        public override void Draw(RenderWindow win)
        {
            base.Draw(win);

            win.Draw(shape);
        }

        public override void CheckMousePosition(Vector2i mousePos)
        {
            base.CheckMousePosition(mousePos);

            if (mousePos.X > shape.Position.X && mousePos.X < shape.Position.X + shape.Size.X &&
                mousePos.Y > shape.Position.Y && mousePos.Y < shape.Position.Y + shape.Size.Y)
                OnClick();
        }

        protected override void OnClick()
        {
            bonusActive = true;
            IsActive = false;
        }

        protected override void OnReachedTarget()
        {
            if (movementSpeed < maxMovementSpeed)
                movementSpeed += movementStep;

            if (shape.Size.X > minSize)
            {
                shape.Size -= new Vector2f(sizeStep, sizeStep);
            }

            if (shape.Size.X == minSize)
            {
                IsActive = false;
                return;
            }
        }
    }
}
