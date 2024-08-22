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


        public SquareList() 
        {
            squares =  new List<Square>();
        }

        public void Update(RenderWindow win) 
        {
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
            }
        }

        public void SpawnPlayerSquare() 
        {
            squares.Add(new PlayerSquare(new Vector2f(Mathf.Random.Next(0, 800), (Mathf.Random.Next(0, 600))), 10, new IntRect(0, 0, 800, 600)));
            

        }
        public void SpawnEnemySquare() 
        {
            squares.Add(new EnemySquare(new Vector2f(Mathf.Random.Next(0, 800), (Mathf.Random.Next(0, 600))), 10, new IntRect(0, 0, 800, 600)));

        }


    }
}
