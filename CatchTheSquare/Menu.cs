using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheSquare
{
    class Menu
    {
        
        private Font mainFont;
        private Text menuText;
        public bool menuFlag = true;
        public int gameSetting;

        public Menu() 
        {
            mainFont = new Font("comic.ttf");
            menuText = new Text();
            menuText.FillColor = Color.Black;
            menuText.Font = mainFont;
        }

        public void ShowMenu(RenderWindow win) 
        {
            menuText.CharacterSize = 28;
            menuText.Color = Color.Black;
            menuText.DisplayedString = "Select figures";
            menuText.Position = new Vector2f(300, 200);
            win.Draw(menuText);
            //----------
            menuText.CharacterSize = 22;
            menuText.Color = Color.Blue;
            menuText.DisplayedString = "F - selecting a Foursquare";
            menuText.Position = new Vector2f(300, 250);
            win.Draw(menuText);
            //----------
            menuText.CharacterSize = 22;
            menuText.Color = Color.Red;
            menuText.DisplayedString = "C - selecting Circles";
            menuText.Position = new Vector2f(300, 300);
            win.Draw(menuText);
            //----------
            menuText.CharacterSize = 22;
            menuText.Color = Color.Green;
            menuText.DisplayedString = "S - selecting Sprites";
            menuText.Position = new Vector2f(300, 350);
            win.Draw(menuText);
        }

        public void ChooseMenu() 
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.F) == true)
            {
                menuFlag = false;
                gameSetting = 1;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.C) == true)
            {
                menuFlag = false;
                gameSetting = 2;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.S) == true)
            {
                menuFlag = false;
                gameSetting = 3;
            }

        }



    }
}
