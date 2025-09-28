using System;
using System.Collections.Generic;

namespace Snake
    {
        class Obstacles //Takistuste lisamine 5. tasemel

    {
        private List<(int x, int y)> blocks; 
            private int width;
            private int height;
            private char symbol; 

            public Obstacles(int width, int height, int count, char symbol = 'X')
            {
                this.width = width;
                this.height = height;
                this.symbol = symbol;
                blocks = new List<(int, int)>();

                Random rand = new Random();

                for (int i = 0; i < count; i++)
                {
                    int x, y;
                    do
                    {
                        x = rand.Next(1, width - 1);
                        y = rand.Next(1, height - 1);
                    } while (blocks.Contains((x, y))); 

                    blocks.Add((x, y));
                }
            }
            public void Draw()
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                foreach (var (x, y) in blocks)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(symbol);
                }
                Console.ResetColor();
            }

            public bool IsHit(int x, int y)
            {
                return blocks.Contains((x, y));
            }
        }
    }

