using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madu_Uss

//добавить звук при столкновении
//добавить уровни сложности
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

            Console.WriteLine("Нажмите любую клавишу, чтобы начать игру...");
            Console.ReadKey();
            Console.Clear();

            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(80, 25);

            Walls walls = new Walls(80, 25);
            walls.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            Punktid punktid = new Punktid();

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

                Thread.Sleep(100);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.HandleKey(key.Key);
                }
            }

            WriteGameOver(nimi, punktid.PunktideArv());
            Kasutaja.SalvestaKasutaja(new Kasutaja(nimi), punktid.PunktideArv());

            Console.ReadLine();
        }

        static void WriteGameOver(string nimi, int punktid)
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("     G A M E   O V E R   ", xOffset + 1, yOffset++);
            WriteText($"KASUTAJA: {nimi} Punktid: {punktid}", xOffset + 2, yOffset++);
            WriteText("============================", xOffset, yOffset++);
        }

        static void WriteText(string text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }

}
