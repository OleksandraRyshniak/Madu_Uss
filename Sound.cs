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

        public Sound() //muusika
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            string fonPath = Path.Combine(basePath, "fon.wav");
            string eatPath = Path.Combine(basePath, "eat.wav");
            string gameOverPath = Path.Combine(basePath, "gameover1.wav");

            if (File.Exists(fonPath))
            {
                fonAudioReader = new AudioFileReader(fonPath);
                fonOutputDevice = new WaveOutEvent();
                //fonOutputDevice.Init(fonAudioReader);
            }
            else
            {
                Console.WriteLine("Faili ei leitud" + fonPath);
            }

            if (File.Exists(eatPath))
            {
                eatAudioReader = new AudioFileReader(eatPath);
                eatOutputDevice = new WaveOutEvent();
                //eatOutputDevice.Init(eatAudioReader);
            }
            else
            {
                Console.WriteLine("Faili ei teitud " + eatPath);
            }

            if (File.Exists(gameOverPath))
            {
                gameOverAudioReader = new AudioFileReader(gameOverPath);
                gameOverOutputDevice = new WaveOutEvent();
                //gameOverOutputDevice.Init(gameOverAudioReader);
            }
            else
            {
                Console.WriteLine("Faili ei teitud " + gameOverPath);
            }
        }

        public void PlayFonSound()
        {
            if (fonOutputDevice != null && fonAudioReader != null)
            {
                fonAudioReader.Position = 0;
                //fonOutputDevice.Play();
            }
        }

        public void PlayEatSound()
        {
            if (eatOutputDevice != null && eatAudioReader != null)
            {
                eatAudioReader.Position = 0;
               // eatOutputDevice.Play();
            }
        }

        public void PlayGameOverSound()
        {
            if (gameOverOutputDevice != null && gameOverAudioReader != null)
            {
                gameOverAudioReader.Position = 0;
                //gameOverOutputDevice.Play();
            }
        }

        public void StopFonSound()
        {
            fonOutputDevice?.Stop();
        }

        public void ReplayFonSound()
        {
            if (fonOutputDevice != null && fonAudioReader != null)
            {
                fonAudioReader.Position = 0;
                //fonOutputDevice.Play();
            }
        }
    }
}