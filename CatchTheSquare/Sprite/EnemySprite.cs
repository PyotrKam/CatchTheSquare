using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace CatchTheSquare
{
    class EnemySprite : Square
    {
        static Texture EnemyTexture;
                
        private static float MaxMovementSpeed = 3;
        private static float MovementStep = 0.05f;
        private static float maxSpriteSize = 150;
        private static float spriteSizeStep = 1f;

        public EnemySprite(Vector2f position, float movementSpeed, IntRect movemetBounds) : base(position, movementSpeed, movemetBounds)
        {
            EnemyTexture = new Texture("pirate.png");
            shapeSprite = new Sprite(EnemyTexture);
            shapeSprite.Position = position;
        }

        public override void Move()
        {
            shapeSprite.Position = Mathf.MoveTowards(shapeSprite.Position, movementTarget, movementSpeed);

            if (shapeSprite.Position == movementTarget)
            {
                OnReachedTarget();
                UpdateMovementTarget();
            }
        }
        public override void Draw(RenderWindow win)
        {
            base.Draw(win);

            win.Draw(shapeSprite);
        }
        public override void CheckMousePosition(Vector2i mousePos)
        {
            base.CheckMousePosition(mousePos);

            if (mousePos.X > shape.Position.X && mousePos.X < shape.Position.X + shape.Size.X
                && mousePos.Y > shape.Position.Y && mousePos.Y < shape.Position.Y + shape.Size.Y) OnClick();
        }

        protected override void OnClick()
        {
            Game.IsLost = true;
        }

        protected override void OnReachedTarget()
        {
            if (movementSpeed < MaxMovementSpeed) movementSpeed += MovementStep;

            if (shapeSprite.Scale.X < maxSpriteSize) shapeSprite.Scale += new Vector2f(spriteSizeStep, spriteSizeStep);
        }

    }
}
