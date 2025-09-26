using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Madu_Uss
{
     class Tase
    {
        public static (int speed, int sizeX, int sizeY) Vali_Tase()
        {
            Console.WriteLine("Vali tase (1-5): ");
            int tase = 0;
            while (tase < 1 || tase > 5)
            {
                try
                {
                    tase = int.Parse(Console.ReadLine());
                    if (tase < 1 || tase > 5)
                    {
                        Console.WriteLine("Palun vali tase vahemikus 1 kuni 5.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Palun sisesta kehtiv number.");
                }
            }
            int speed = tase switch
            {
                1 => 100,
                2 => 90,
                3 => 80,
                4 => 70,
                5 => 60,
                _ => 100
            };

            int sizeX = tase switch
            {
                1 => 100,
                2 => 80,
                3 => 60,
                4 => 50,
                5 => 50,
                _ => 100
            };
            int sizeY = tase switch
            {
                1 => 30,
                2 => 25,
                3 => 20,
                4 => 20,
                5 => 20,
                _ => 30
            };
            return (speed, sizeX, sizeY);
        }
     }
}
