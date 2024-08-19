using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;


namespace CatchTheSquare
{
    class Program 
    {
        public static void Main(string[] args)
        {
            RenderWindow win = new RenderWindow(new VideoMode(800, 600), "Game");
            win.Closed += Win_closed;
            win.SetFramerateLimit(60);

            Square square = new Square(new Vector2f(100, 100), 10, new IntRect(0, 0, 800, 600));

            while (win.IsOpen == true)
            {
                win.Clear(new Color(230, 230, 230));

                square.Move();
                square.Draw(win);

                win.DispatchEvents();

                win.Display();
            }

        }

         static void Win_closed(object sender, EventArgs e)
        {
            ((RenderWindow)sender).Close();
        }
    }
}
