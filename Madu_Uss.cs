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
            string nimi = Kasutaja.Parkasutaja(); //kasutaja nimi

            bool kasutajaLeitud = Kasutaja.KasutajaKontroll(nimi); //kontrolli kasutaja
            var (speed, sizeX, sizeY) = Tase.Vali_Tase(); //taseme valik 
            Console.WriteLine("Vajuta ükskõik millist klahvi, et alustada mängu...");

            Console.ReadKey();
            Console.Clear();
            
            //new Sound().PlayFonSound(); //fon muusika
            Console.CursorVisible = false;
            Punktid punktid = new Punktid(); //punktide loendur
            punktid.LisaPunkte(0);

            Walls walls = new Walls(sizeX, sizeY); //seinte joonistamine
            walls.Draw();


            Food_SpeedCreator foodCreator = new Food_SpeedCreator(sizeX, sizeY, '@'); // toit joonistamine
            Point food = foodCreator.CreateFood_Speed();
            food.Draw();

            Obstacles obstacles = null;
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT); //madu joonistamine
            snake.Draw();

            Elu elu = new Elu(); //elud
            elu.Draw();
            Console.ResetColor();
            int eluarv = 3;
            int pun = 0;
            int kogusspeed = 0;
            Food_SpeedCreator speedCreator = new Food_SpeedCreator(sizeX, sizeY, '%');
            Point speed1 = speedCreator.CreateFood_Speed(); //täiendava kiirenduse joonistamine
            Console.ForegroundColor = ConsoleColor.Green;
            speed1.Draw();
            Console.ResetColor();

            if (sizeX == 55)
            {
                obstacles = new Obstacles(sizeX-10, sizeY-10, 7, '#'); //3. taseme tõkete joonistamine
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
                        speed += kogusspeed;
                    }
                }

                if (snake.Eat(food)) 
                {
                    //new Sound().PlayEatSound();
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
                if (snake.Eat(speed1)) //kui madu sööb täiendava kiiruse
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
            //new Sound().StopFonSound();
            Console.Clear();
            //new Sound().PlayGameOverSound(); //lõpp mäng
            Kasutaja.SalvestaKasutaja(new Kasutaja(nimi), punktid.PunktideArv());
            new GameOver().WriteGameOver(nimi, punktid.PunktideArv());
            Console.ReadLine();
        }
    }
}

