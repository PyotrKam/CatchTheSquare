using System;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheSquare
{
    class BonusCircle : Square
    {
        private static Color color = new Color(Color.Yellow);
        private static float maxMovementSpeed = 5;
        private static float movementStep = 0.1f;
        private static float minCircleSize = 30;
        private static float sizeStep = 10;


        public BonusCircle(Vector2f position, float movementSpeed, IntRect movementBounds) : base(movementSpeed, movementBounds)
        {
            shapeCircle = new CircleShape(Mathf.defaultRadius);
            shapeCircle.Position = position;

            shapeCircle.FillColor = color;
        }

        public override void Move()
        {
            shapeCircle.Position = Mathf.MoveTowards(shapeCircle.Position, movementTarget, movementSpeed);

            if (shapeCircle.Position == movementTarget)
            {
                OnReachedTarget();

                UpdateMovementTarget();
            }
        }

        public override void Draw(RenderWindow win)
        {
            base.Draw(win);

            win.Draw(shapeCircle);
        }

        public override void CheckMousePosition(Vector2i mousePos)
        {
            base.CheckMousePosition(mousePos);

            if (Math.Pow((mousePos.X - (shapeCircle.Position.X + shapeCircle.Radius)), 2) + Math.Pow((mousePos.Y - (shapeCircle.Position.Y + shapeCircle.Radius)), 2) <=
                Math.Pow(shapeCircle.Radius, 2))
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

            if (shapeCircle.Radius > minCircleSize)
                shapeCircle.Radius -= sizeStep;

            if (shapeCircle.Radius == minCircleSize)
            {
                IsActive = false;
                return;
            }
        }
    }
}
