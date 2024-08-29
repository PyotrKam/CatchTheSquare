using System;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheSquare
{
    public class PlayerSprite : Square
    {
        static Texture PlayerTexture;
        private static float SizeStep = 10f;
        private static float MinSize = 30f;

        public PlayerSprite(Vector2f position, float movementSpeed, IntRect movemetBounds) : base (position, movementSpeed, movemetBounds)
        {
            PlayerTexture = new Texture("smile.png");
            shapeSprite = new Sprite(PlayerTexture);
            shapeSprite.Position = position;            
        }
        public override void Move()
        {
            shapeSprite.Position = Mathf.MoveTowards(shapeCircle.Position, movementTarget, movementSpeed);

            if (shapeSprite.Position == movementTarget)
            {    
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

            if (mousePos.X > shapeSprite.Position.X && mousePos.X < shapeSprite.Position.X + shapeSprite.Texture.Size.X &&
                mousePos.Y > shapeSprite.Position.Y && mousePos.Y < shapeSprite.Position.Y + shapeSprite.Texture.Size.Y)
                OnClick();

        }

        protected override void OnClick()
        {
            Game.Scores++;

            shapeSprite.Scale -= new Vector2f(SizeStep, SizeStep); ;

            if (shapeSprite.Scale.X < MinSize)
            {
                IsActive = false;
                return;
            }

            UpdateMovementTarget();
            shapeSprite.Position = movementTarget;
        }

    }
}
