using Snake;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using System.Data;

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
            string nimi = "";
            while (true)
            {

                try
                {
                    nimi = Console.ReadLine();
                    if (nimi.Length < 3)
                    {
                        Console.WriteLine("Kasutajanimi peab olema 3 tähemarki pikk. Proovi uuesti:");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }


            bool kasutajaLeitud = Kasutaja.KasutajaKontroll(nimi);
            var (speed, sizeX, sizeY) = Tase.Vali_Tase();
            Console.WriteLine("Vajuta ükskõik millist klahvi, et alustada mängu...");

            Console.ReadKey();
            Console.Clear();
            
            new Sound().PlayFonSound();
            
            int kogusspeed = 0;


            Console.CursorVisible = false;
            Punktid punktid = new Punktid();
            punktid.LisaPunkte(0);

            Walls walls = new Walls(sizeX, sizeY);
            walls.Draw();


            Food_SpeedCreator foodCreator = new Food_SpeedCreator(sizeX, sizeY, '@');
            Point food = foodCreator.CreateFood_Speed();
            food.Draw();

            Obstacles obstacles = null;
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            Elu elu = new Elu();
            elu.Draw();
            Console.ResetColor();
            int eluarv = 3;
            int pun = 0;
            Food_SpeedCreator speedCreator = new Food_SpeedCreator(sizeX, sizeY, '%');
            Point speed1 = speedCreator.CreateFood_Speed();
            Console.ForegroundColor = ConsoleColor.Green;
            speed1.Draw();
            Console.ResetColor();

            if (sizeX == 55)
            {
                obstacles = new Obstacles(sizeX-10, sizeY-10, 7, '#');
                obstacles.Draw();
            }

            while (true)
            {

                if (walls.IsHit(snake) || snake.IsHitTail() || (obstacles != null && obstacles.IsHit(snake.GetNextPoint().x, snake.GetNextPoint().y)))
                {
                    if (eluarv == 0)
                    {
                        break;
                    }
                    else
                    {
                        elu.LoseLife();
                        snake.Clear();
                        eluarv--;
                        snake = new Snake(p, 4+pun, Direction.RIGHT);
                        snake.Draw();
                        walls = new Walls(sizeX, sizeY);
                        walls.Draw();
                        speed +=kogusspeed;
                    }
                }

                if (snake.Eat(food))
                {
                    new Sound().PlayEatSound();
                    pun++;
                    punktid.LisaPunkte(10);
                    food = foodCreator.CreateFood_Speed();
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
                if (snake.Eat(speed1))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    kogusspeed += 10;
                    speed -= 10;
                    speed1 = speedCreator.CreateFood_Speed();
                    speed1.Draw();
                    Console.ResetColor();
                }
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Punktid: {punktid.PunktideArv()}");
                Console.ResetColor();
            }
            
            new Sound().StopFonSound();
            Console.Clear();
            new Sound().PlayGameOverSound();
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
                    WriteText($"{i + 1}.  {top[i]}  ", xOffset + 4, yOffset++);
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

