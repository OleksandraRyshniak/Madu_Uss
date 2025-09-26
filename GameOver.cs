using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madu_Uss
{
    class GameOver
    {
        public static void ShowGameOver(string nimi, int punktid)
        {
            Console.Clear();
            WriteGameOver(nimi, punktid);
            Console.ResetColor();
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        static void WriteGameOver(string nimi, int punktid)
        {

            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("=================================", xOffset, yOffset++);
            WriteText("     G A M E   O V E R   ", xOffset + 1, yOffset++);
            WriteText($"KASUTAJA: {nimi} Punktid: {punktid}", xOffset + 2, yOffset++);
            WriteText($"Т А Б Л И Ц А   Р Е К О Р Д О В", xOffset + 3, yOffset++);
            List<string> top = ReadFile();
            int count = Math.Min(5, top.Count);
            for (int i = 0; i < count; i++)
            {
                WriteText($"{i + 1}. {top[i]}", xOffset + 4, yOffset++);
            }
            WriteText("=================================", xOffset, yOffset++);
        }

        static void WriteText(string text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
        public static List<string> ReadFile()
        {
            List<string> kasutaja_top = new List<string>();
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\kasutaja.txt");
                kasutaja_top = File.ReadAllLines(path).ToList();

                // сортируем по очкам (0 тоже учитывается)
                kasutaja_top.Sort((a, b) =>
                {
                    int pointsA = int.Parse(a.Split("Punktid=")[1]);
                    int pointsB = int.Parse(b.Split("Punktid=")[1]);
                    return pointsB.CompareTo(pointsA); // убывание
                });
            }
            catch (Exception)
            {
                Console.WriteLine("Viga failiga!");
            }
            return kasutaja_top;
        }
    }
}
