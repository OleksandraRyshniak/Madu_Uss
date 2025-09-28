using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using WMPLib;


namespace Snake
{
    class Sound
    {
        public void EatSound()
        {
            try
            {
                WindowsMediaPlayer player = new WindowsMediaPlayer();
                player.URL = "eat.mp3";
                player.controls.play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing sound: " + ex.Message);
            }
        }
        public void GameOverSound()
        {
            try
            {
                WindowsMediaPlayer player = new WindowsMediaPlayer();
                player.URL = "gameover.mp3";
                player.controls.play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing sound: " + ex.Message);
            }
        }
    }
}