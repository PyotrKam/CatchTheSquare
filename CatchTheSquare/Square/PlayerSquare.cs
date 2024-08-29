using System;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheSquare
{
    public class PlayerSquare : Square
    {
        private static Color Color = new Color(50, 50, 50);
        private static float SizeStep = 10;
        private static float MinSize = 30;

        public PlayerSquare(Vector2f position, float movementSpeed, IntRect movemetBounds) : base (position, movementSpeed, movemetBounds)
        {
            shape = new RectangleShape(Mathf.defaultSize);
            shape.Position = position;

            shape.FillColor = Color;
        }

        public override void Move()
        {
            shape.Position = Mathf.MoveTowards(shape.Position, movementTarget, movementSpeed);

            if (shape.Position == movementTarget)
            {
                
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

            if (mousePos.X > shape.Position.X && mousePos.X < shape.Position.X + shape.Size.X
                && mousePos.Y > shape.Position.Y && mousePos.Y < shape.Position.Y + shape.Size.Y) OnClick();
        }

        protected override void OnClick()
        {
            Game.Scores++;

            shape.Size -= new Vector2f(SizeStep, SizeStep);

            if (shape.Size.X < MinSize)
            {
                IsActive = false;
                return;
            }

            UpdateMovementTarget();
            shape.Position = movementTarget;
        }

    }
}
