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
    class Game
    {
        public static int Scores;
        public static bool IsLost;

        private Font mainFont;
        private Text scoreText;
        private Text loseText;
        
        private SquareList squares;

        private int MaxScores;

        private int game;

        public Game(int gamesettings) 
        {
            mainFont = new Font("comic.ttf");
            
            squares = new SquareList();

            scoreText = new Text();
            scoreText.Font = mainFont;
            scoreText.FillColor = Color.Black;
            scoreText.CharacterSize = 16;
            scoreText.Position = new Vector2f(10, 10);

            loseText = new Text();
            loseText.Font = mainFont;
            loseText.FillColor = Color.Black;
            loseText.DisplayedString = "You Lost! To restar the game, press R !";
            loseText.Position = new Vector2f(20, 290);


            Reset(gamesettings);
        }

        private void Reset(int gamesettings) 
        {
            squares.Reset();
            Scores = 0;
            IsLost = false;

            if (gamesettings == 1)
            {
                squares.SpawnPlayerSquare();
                squares.SpawnPlayerSquare();

                squares.SpawnEnemySquare();
                squares.SpawnEnemySquare();
            }

            if (gamesettings == 2)
            {
                squares.SpawnPlayerCircle();
                squares.SpawnPlayerCircle();

                squares.SpawnEnemyCircle();
                squares.SpawnEnemyCircle();
            }

            this.game = gamesettings;


        }

        public void Update(RenderWindow win) 
        {
            if (IsLost == true)
            {
                win.Draw(loseText);

                if (Scores > MaxScores)
                {
                    MaxScores = Scores;
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.R) == true)
                {
                    Reset(game);
                }
            }

            if (IsLost == false)
            {
                squares.Update(win);

                if (squares.SquareHasRemoved == true)
                {
                    if (squares.RemovedSquare is PlayerSquare) squares.SpawnPlayerSquare();

                    if (squares.RemovedSquare is PlayerCircle) squares.SpawnPlayerCircle();

                }
            }

            scoreText.DisplayedString = "Score: " + Scores.ToString() + "\nMax: " + MaxScores.ToString(); 
            win.Draw(scoreText);
        }
    }
}
