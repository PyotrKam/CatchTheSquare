using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Timers;
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

        private static Timer timer;
        public static int bonusSpawnTime = 10;

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

        

        static void SetTimer() 
        {
            timer = new Timer(1000);
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        
        }
        static void OnTimedEvent(object soruce, ElapsedEventArgs e)
        {
            bonusSpawnTime -= 1;
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

            if (gamesettings == 3)
            {
                squares.SpawnPlayerSprite();
                squares.SpawnPlayerSprite();

                squares.SpawnEnemySprite();
                squares.SpawnEnemySprite();
            }


            this.game = gamesettings;
            SetTimer();

        }

        public void Update(RenderWindow win) 
        {
            if (bonusSpawnTime < 0 && game == 1)
            {
                squares.SpawnBonusSquare();
                bonusSpawnTime = 10;
            }

            if (bonusSpawnTime < 0 && game == 2)
            {
                squares.SpawnBonusCircle();
                bonusSpawnTime = 10;
            }

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

                    if (squares.RemovedSquare is PlayerSprite) squares.SpawnPlayerSprite();

                    if (squares.RemovedSquare is BonusCircle) squares.SpawnBonusCircle();

                    if (squares.RemovedSquare is BonusSquare) squares.SpawnBonusSquare();

                }
            }


            scoreText.DisplayedString = "Score: " + Scores.ToString() + "\nMax: " + MaxScores.ToString(); 
            win.Draw(scoreText);
        }
    }
}
