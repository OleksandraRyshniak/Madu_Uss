using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madu_Uss
{
    public class Elu //elude klass
    {
        private int lives;

        public Elu(int lives = 3) 
        {
            this.lives = lives;
        }

        public void Draw() // elude joonistamine
        {
            for (int i = 0; i < lives; i++)
            {
                Console.SetCursorPosition(13 + i * 2, 0);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("♥");
            }
            Console.ResetColor();
        }

        public void LoseLife() //Viimase elu eemaldamine
        {
            if (lives > 0)
            {
                lives--;
                Clear(13 + lives * 2, 0); 
            }
        }

        private void Clear(int x, int y) //Tühikute eemaldamine
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" "); 
        }
    }

}
