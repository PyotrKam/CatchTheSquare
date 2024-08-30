using SFML.Window;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace CatchTheSquare
{
    class SquareList
    {
        private List<Square> squares;
        public bool SquareHasRemoved;
        public Square RemovedSquare;


        public SquareList() 
        {
            squares =  new List<Square>();
        }

        public void Reset() 
        {
            SquareHasRemoved = false;
            RemovedSquare = null;

            squares.Clear();
        }

        public void Update(RenderWindow win) 
        {
            SquareHasRemoved = false;
            RemovedSquare = null;

            if (Mouse.IsButtonPressed(Mouse.Button.Left) == true)
            {
                for (int i = 0; i < squares.Count; i++)
                {
                    squares[i].CheckMousePosition(Mouse.GetPosition(win));
                }
            }

            for (int i = 0; i < squares.Count; i++)
            {
                squares[i].Move();
                squares[i].Draw(win);

                if (squares[i].IsActive == false)
                {
                    RemovedSquare = squares[i];
                    squares.Remove(squares[i]);
                    SquareHasRemoved = true;
                }
            }
        }

        public void SquareBlueBonus() 
        {
            for (int i = 0; i < squares.Count; i++)
            {
                if (squares[i] is EnemySquare && RemovedSquare.bonusActive == true)
                {
                    squares[i].shape.Size = Mathf.defaultSize;
                }
            }
        }

        public void CircleYellowBonus()
        {
            for (int i = 0; i < squares.Count; i++)
            {
                if (squares[i] is PlayerCircle && RemovedSquare.bonusActive == true)
                {
                    squares[i].shapeCircle.Radius = Mathf.defaultRadius;
                }
            }
        }


    


        public void SpawnPlayerSquare() 
        {
            squares.Add(new PlayerSquare(new Vector2f(Mathf.Random.Next(0, 800), (Mathf.Random.Next(0, 600))), 5, new IntRect(0, 0, 800, 600)));
        }
        public void SpawnEnemySquare() 
        {
            squares.Add(new EnemySquare(new Vector2f(Mathf.Random.Next(0, 800), (Mathf.Random.Next(0, 600))), 5, new IntRect(0, 0, 800, 600)));
        }

        public void SpawnPlayerCircle()
        {
            squares.Add(new PlayerCircle(new Vector2f(Mathf.Random.Next(0, 800), (Mathf.Random.Next(0, 600))), 5, new IntRect(0, 0, 800, 600)));
        }

        public void SpawnEnemyCircle()
        {
            squares.Add(new EnemyCircle(new Vector2f(Mathf.Random.Next(0, 800), (Mathf.Random.Next(0, 600))), 5, new IntRect(0, 0, 800, 600)));
        }

        public void SpawnPlayerSprite()
        {
            squares.Add(new PlayerSprite(new Vector2f(Mathf.Random.Next(0, 800), (Mathf.Random.Next(0, 600))), 5, new IntRect(0, 0, 800, 600)));
        }

        public void SpawnEnemySprite()
        {
            squares.Add(new EnemySprite(new Vector2f(Mathf.Random.Next(0, 800), (Mathf.Random.Next(0, 600))), 5, new IntRect(0, 0, 800, 600)));
        }

        public void SpawnBonusSquare()
        {
            squares.Add(new BonusSquare(new Vector2f(Mathf.Random.Next(0, 800), (Mathf.Random.Next(0, 600))), 5, new IntRect(0, 0, 800, 600)));
        }

        public void SpawnBonusCircle()
        {
            squares.Add(new BonusCircle(new Vector2f(Mathf.Random.Next(0, 800), (Mathf.Random.Next(0, 600))), 5, new IntRect(0, 0, 800, 600)));
        }

    }
}
