using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace CatchTheSquare
{
    class EnemyCircle : Square
    {
        private static Color Color = new Color(230, 50, 50);
        private static float MaxMovementSpeed = 3;
        private static float MovementStep = 0.05f;
        private static float MaxSize = 150;
        private static float SizeStep = 10;

        public EnemyCircle(Vector2f position, float movementSpeed, IntRect movemetBounds) : base(position, movementSpeed, movemetBounds)
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
                OnReachedTarget();
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
            Game.IsLost = true;
        }

        protected override void OnReachedTarget()
        {
            if (movementSpeed < MaxMovementSpeed) movementSpeed += MovementStep;

            if (shapeCircle.Radius < MaxSize) shapeCircle.Radius += SizeStep;
        }

    }
}
