using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madu_Uss

//добавить звук при столкновении
//добавить таблицу рекордов
{
    internal class Madu_Uss
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Kas tahad mängida madu?");
            string vastus = Console.ReadLine().ToLower();
            if (vastus != "jah" && vastus != "yes" && vastus != "да")
            {
                Console.WriteLine("Ok, head aega!");
                return;
            }

            Console.Write("Sisesta oma kasutajanimi: ");
            string nimi = Console.ReadLine();

            bool kasutajaLeitud = Kasutaja.KasutajaKontroll(nimi);
            var (speed, sizeX, sizeY) = Tase.Vali_Tase();
            Console.WriteLine("Нажмите любую клавишу, чтобы начать игру...");

            Console.ReadKey();
            Console.Clear();
            

            Console.CursorVisible = false;
            Punktid punktid = new Punktid();
            punktid.LisaPunkte(0);

            Walls walls = new Walls(sizeX, sizeY);
            walls.Draw();

            FoodCreator foodCreator = new FoodCreator(sizeX, sizeY, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();



            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();
            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
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
                ;
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Punktid: {punktid.PunktideArv()}");
                Console.ResetColor();

            }
            Console.Clear();
            GameOver.ShowGameOver(nimi, punktid.PunktideArv());
            Kasutaja.SalvestaKasutaja(new Kasutaja(nimi), punktid.PunktideArv());

            Console.ReadLine();

            //static void WriteGameOver(string nimi, int punktid)
            //{
                 
            //    int xOffset = 25;
            //    int yOffset = 8;
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.SetCursorPosition(xOffset, yOffset++);
            //    WriteText("=================================", xOffset, yOffset++);
            //    WriteText("     G A M E   O V E R   ", xOffset + 1, yOffset++);
            //    WriteText($"KASUTAJA: {nimi} Punktid: {punktid}", xOffset + 2, yOffset++);
            //    WriteText($"Т А Б Л И Ц А   Р Е К О Р Д О В", xOffset + 3, yOffset++);
            //    WriteText($"1. {nimi} {punktid} ", xOffset + 4, yOffset++);
            //    WriteText("=================================", xOffset, yOffset++);
            //}

            //static void WriteText(string text, int xOffset, int yOffset)
            //{
            //    Console.SetCursorPosition(xOffset, yOffset);
            //    Console.WriteLine(text);
            //}
        }
    }
}
