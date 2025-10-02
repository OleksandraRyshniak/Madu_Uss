using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Madu_Uss
{
    class Tase //Tasemed
    {
        public static (int speed, int sizeX, int sizeY) Vali_Tase()
        {
            Console.WriteLine("Vali tase \n1.Lihtne; \n2.Keskmine \n3.Raske : ");
            int tase = 0;
            while (tase < 1 || tase > 3)
            {
                try
                {
                    tase = int.Parse(Console.ReadLine());
                    if (tase < 1 || tase > 3)
                    {
                        Console.WriteLine("Palun vali tase vahemikus 1 kuni 3.");
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
                3 => 70,
                _ => 100
            };

            int sizeX = tase switch
            {
                1 => 100,
                2 => 80,
                3 => 55,
                _ => 100
            };
            int sizeY = tase switch
            {
                1 => 30,
                2 => 25,
                3 => 20,
                _ => 30
            };
            return (speed, sizeX, sizeY);
        }
    }
}
