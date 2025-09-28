using Snake;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace Madu_Uss
{
    internal class Madu_Uss
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Kas tahad mängida madu?");
            string vastus = Console.ReadLine().ToLower();
            if (vastus != "jah" && vastus != "yes")
            {
                Console.WriteLine("Ok, head aega!");
                return;
            }

            Console.Write("Sisesta oma kasutajanimi: ");
            string nimi = Console.ReadLine();

            bool kasutajaLeitud = Kasutaja.KasutajaKontroll(nimi);
            var (speed, sizeX, sizeY) = Tase.Vali_Tase();
            Console.WriteLine("Vajuta ükskõik millist klahvi, et alustada mängu...");

            Console.ReadKey();
            Console.Clear();
            

            Console.CursorVisible = false;
            Punktid punktid = new Punktid();
            punktid.LisaPunkte(0);

            Walls walls = new Walls(sizeX, sizeY);
            walls.Draw();

            
            FoodCreator foodCreator = new FoodCreator(sizeX, sizeY, '@');
            Point food = foodCreator.CreateFood();
            food.Draw();

            Obstacles obstacles = null;
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            

            if (sizeX == 55)
            {
                obstacles = new Obstacles(sizeX, sizeY, 10, '#');
                obstacles.Draw();
            }


            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail() || (obstacles != null && obstacles.IsHit(snake.GetNextPoint().x, snake.GetNextPoint().y)))
                {
                    break;
                }

                if (snake.Eat(food))
                {
                    new Sound().EatSound();
                    punktid.LisaPunkte(10);
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(speed);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.HandleKey(key.Key);
                }

                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Punktid: {punktid.PunktideArv()}");
                Console.ResetColor();
            }

            Console.Clear();
            new Sound().GameOverSound();
            Kasutaja.SalvestaKasutaja(new Kasutaja(nimi), punktid.PunktideArv());
            WriteGameOver(nimi, punktid.PunktideArv());
            Console.ReadLine();

            static void WriteGameOver(string nimi, int punktid)
            {

                int xOffset = 25;
                int yOffset = 8;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(xOffset, yOffset++);
                WriteText("====================================================", xOffset, yOffset++);
                WriteText("                   M Ä N G   L Õ P P                ", xOffset + 1, yOffset++);
                WriteText($"   K A S U T A J A : {nimi}  P U N K T I D : {punktid}    ", xOffset + 2, yOffset++);
                WriteText($"           T U L E M U S T E  T A B E L            ", xOffset + 3, yOffset++);
                List<string> top = GameOver.ReadFile();
                int count = Math.Min(5, top.Count);
                for (int i = 0; i < count; i++)
                {
                    WriteText($"{i + 1 }.  {top[i]}  ", xOffset + 4, yOffset++);
                }
                WriteText("=====================================================", xOffset, yOffset++);
            }

            static void WriteText(string text, int xOffset, int yOffset)
            {
                Console.SetCursorPosition(xOffset, yOffset);
                Console.WriteLine(text);
            }
        }
    }
}
