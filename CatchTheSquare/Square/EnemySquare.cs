using System;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheSquare
{
    public class EnemySquare : Square
    {
        
        private static Color Color = new Color(230, 50, 50);
        private static float MaxMovementSpeed = 3;
        private static float MovementStep = 0.05f;
        private static float MaxSize = 150;
        private static float SizeStep = 10;

        public EnemySquare(Vector2f position, float movementSpeed, IntRect movemetBounds) : base(position, movementSpeed, movemetBounds)
        {
            shape.FillColor = Color;

        }

        protected override void OnClick()
        {
            Game.IsLost = true;
        }

        protected override void OnReachedTarget()
        {
            if (movementSpeed < MaxMovementSpeed) movementSpeed += MovementStep;

            if (shape.Size.X < MaxSize) shape.Size += new Vector2f(SizeStep, SizeStep);
        }

    }
}
