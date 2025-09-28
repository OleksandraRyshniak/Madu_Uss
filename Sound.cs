using System;
using System.IO;
using System.Media; 


namespace Snake
{
    class Sound //Muusika

    {
        private SoundPlayer eatPlayer;
        private SoundPlayer gameOverPlayer;

        public Sound()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            string eatPath = Path.Combine(basePath, "eat.wav");
            string gameOverPath = Path.Combine(basePath, "gameover1.wav");

            if (File.Exists(eatPath))
                eatPlayer = new SoundPlayer(eatPath);
            else
                Console.WriteLine("Eat sound не найден: " + eatPath);

            if (File.Exists(gameOverPath))
                gameOverPlayer = new SoundPlayer(gameOverPath);
            else
                Console.WriteLine("GameOver sound не найден: " + gameOverPath);
        }

        public void EatSound()
        {
            eatPlayer?.Play(); 
        }

        public void GameOverSound()
        {
            gameOverPlayer?.Play(); 
        }
    }
}
