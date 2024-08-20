using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections.Generic;


namespace CatchTheSquare
{
    class Program 
    {
        public static Random Random = new Random();
        public static void Main(string[] args)
        {
            RenderWindow win = new RenderWindow(new VideoMode(800, 600), "Game");
            win.Closed += Win_closed;
            win.SetFramerateLimit(60);

            Square square = new Square(new Vector2f(100, 100), 10, new IntRect(0, 0, 800, 600));

            List<Square> squares = new List<Square>();
            squares.Add( new PlayerSquare(new Vector2f(100, 100), 10, new IntRect(0, 0, 800, 600)) );
            squares.Add( new EnemySquare(new Vector2f(200, 100), 10, new IntRect(0, 0, 800, 600)) );

            while (win.IsOpen == true)
            {
                win.Clear(new Color(230, 230, 230));

                

                win.DispatchEvents();
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

                win.Display();
            }

        }

         static void Win_closed(object sender, EventArgs e)
        {
            ((RenderWindow)sender).Close();
        }
    }
}
