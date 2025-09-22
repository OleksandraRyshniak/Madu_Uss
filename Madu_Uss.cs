using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madu_Uss
{
    internal class Madu_Uss
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);

            HorizontalLine upline = new HorizontalLine(0, 78, 0, '+');
            HorizontalLine downline = new HorizontalLine(0, 78, 24, '+');
            VerticalLine vline = new VerticalLine(0, 24, 0, '+');
            VerticalLine vline2 = new VerticalLine(0, 24, 78, '+');
            upline.Drow();
            downline.Drow();
            vline.Drow();
            vline2.Drow();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Drow();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(100);

                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        snake.HandleKey(key.Key);
                    }
                    snake.Move();
                    Thread.Sleep(100);
                //Console.ReadLine();
            }
            }

        }
    }
}
