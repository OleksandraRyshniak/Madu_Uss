using System;
using System.IO;
using System.Media;
using NAudio;
using NAudio.Wave;

namespace Snake
{
    class Sound
    {
        private IWavePlayer fonOutputDevice;
        private AudioFileReader fonAudioReader;

        private IWavePlayer eatOutputDevice;
        private AudioFileReader eatAudioReader;

        private IWavePlayer gameOverOutputDevice;
        private AudioFileReader gameOverAudioReader;

        public Sound()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            string fonPath = Path.Combine(basePath, "fon.wav");
            string eatPath = Path.Combine(basePath, "eat.wav");
            string gameOverPath = Path.Combine(basePath, "gameover1.wav");



            if (File.Exists(fonPath))
            {
                fonAudioReader = new AudioFileReader(fonPath);
                fonOutputDevice = new WaveOutEvent();
                //fonOutputDevice.Init(eatAudioReader);
            }
            else
            {
                Console.WriteLine("Fon sound не найден: " + fonPath);
            }


            if (File.Exists(eatPath))
            {
                eatAudioReader = new AudioFileReader(eatPath);
                eatOutputDevice = new WaveOutEvent();
                //eatOutputDevice.Init(eatAudioReader);
            }
            else
            {
                Console.WriteLine("Eat sound не найден: " + eatPath);
            }

            if (File.Exists(gameOverPath))
            {
                gameOverAudioReader = new AudioFileReader(gameOverPath);
                gameOverOutputDevice = new WaveOutEvent();
                //gameOverOutputDevice.Init(gameOverAudioReader);
            }
            else
            {
                Console.WriteLine("GameOver sound не найден: " + gameOverPath);
            }
        }

        public void FonSound()
        {
            if (fonOutputDevice != null && fonAudioReader != null)
            {
                fonAudioReader.Position = 0; 
                // fonOutputDevice.Play();
            }
        }

        public void EatSound()
        {
            if (eatOutputDevice != null && eatAudioReader != null)
            {
                eatAudioReader.Position = 0; // Сброс позиции
               // eatOutputDevice.Play();
            }
        }

        public void GameOverSound()
        {
            if (gameOverOutputDevice != null && gameOverAudioReader != null)
            {
                gameOverAudioReader.Position = 0; // Сброс позиции
               // gameOverOutputDevice.Play();
            }
        }
    }
}