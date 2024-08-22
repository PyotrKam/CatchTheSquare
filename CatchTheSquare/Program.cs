using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections.Generic;


namespace CatchTheSquare
{
    class Program 
    {
        
        public static void Main(string[] args)
        {
            RenderWindow win = new RenderWindow(new VideoMode(800, 600), "Game");
            win.Closed += Win_closed;
            win.SetFramerateLimit(60);

            Game game = new Game();
                        
            while (win.IsOpen == true)
            {
                win.Clear(new Color(230, 230, 230));                     

                win.DispatchEvents();

                game.Update(win);

                win.Display();
            }

        }

         static void Win_closed(object sender, EventArgs e)
        {
            ((RenderWindow)sender).Close();
        }
    }
}
