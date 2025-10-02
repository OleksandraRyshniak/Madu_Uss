using System;
using System.IO;
using System.Media;
using NAudio;
using NAudio.Wave;

namespace Snake
{
    using System;
    using System.IO;
    using NAudio.Wave;
    using System.Threading;

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

            // Инициализация фонового звука
            if (File.Exists(fonPath))
            {
                fonAudioReader = new AudioFileReader(fonPath);
                fonOutputDevice = new WaveOutEvent();
                fonOutputDevice.Init(fonAudioReader);
            }
            else
            {
                Console.WriteLine("Файл fon.wav не найден: " + fonPath);
            }

            // Инициализация звука еды
            if (File.Exists(eatPath))
            {
                eatAudioReader = new AudioFileReader(eatPath);
                eatOutputDevice = new WaveOutEvent();
                eatOutputDevice.Init(eatAudioReader);
            }
            else
            {
                Console.WriteLine("Файл eat.wav не найден: " + eatPath);
            }

            // Инициализация звука game over
            if (File.Exists(gameOverPath))
            {
                gameOverAudioReader = new AudioFileReader(gameOverPath);
                gameOverOutputDevice = new WaveOutEvent();
                gameOverOutputDevice.Init(gameOverAudioReader);
            }
            else
            {
                Console.WriteLine("Файл gameover1.wav не найден: " + gameOverPath);
            }
        }

        // 🔊 Отдельные функции для воспроизведения

        public void PlayFonSound()
        {
            if (fonOutputDevice != null && fonAudioReader != null)
            {
                fonAudioReader.Position = 0;
                fonOutputDevice.Play();
            }
        }

        public void PlayEatSound()
        {
            if (eatOutputDevice != null && eatAudioReader != null)
            {
                eatAudioReader.Position = 0;
                eatOutputDevice.Play();
            }
        }

        public void PlayGameOverSound()
        {
            if (gameOverOutputDevice != null && gameOverAudioReader != null)
            {
                gameOverAudioReader.Position = 0;
                gameOverOutputDevice.Play();
            }
        }

        public void StopFonSound()
        {
            fonOutputDevice?.Stop();
        }
    }
}
