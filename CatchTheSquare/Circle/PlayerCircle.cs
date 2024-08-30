using System;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheSquare
{
    public class PlayerCircle : Square
    {
        private static Color Color = new Color(50, 50, 50);
        private static float SizeStep = 10f;
        private static float MinSize = 30f;

        public PlayerCircle(Vector2f position, float movementSpeed, IntRect movemetBounds) : base (movementSpeed, movemetBounds)
        {
            shapeCircle = new CircleShape(Mathf.defaultRadius);
            shapeCircle.Position = position;

            shapeCircle.FillColor = Color;
        }
        public override void Move()
        {
            shapeCircle.Position = Mathf.MoveTowards(shapeCircle.Position, movementTarget, movementSpeed);

            if (shapeCircle.Position == movementTarget)
            {    
                UpdateMovementTarget();
            }
        }

        public override void Draw(RenderWindow win)
        {
            if (IsActive == false) return;

            win.Draw(shapeCircle);
        }

        public override void CheckMousePosition(Vector2i mousePos)
        {
            if (IsActive == false) return;

            if (Math.Pow((mousePos.X - (shapeCircle.Position.X + shapeCircle.Radius)), 2) + 
                Math.Pow((mousePos.Y - (shapeCircle.Position.Y + shapeCircle.Radius)), 2) <= shapeCircle.Radius * shapeCircle.Radius) OnClick();
        }

        protected override void OnClick()
        {
            Game.Scores++;

            shapeCircle.Radius -= SizeStep;

            if (shapeCircle.Radius < MinSize)
            {
                IsActive = false;
                return;
            }

            UpdateMovementTarget();
            shapeCircle.Position = movementTarget;
        }

    }
}
