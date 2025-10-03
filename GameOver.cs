using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madu_Uss
{
    class GameOver //kasutaja failist lugemine rekordite tabeli kuvamiseks
    {
        public static List<string> ReadFile()
        {
            List<string> kasutaja_top = new List<string>();
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\kasutaja.txt");
                kasutaja_top = File.ReadAllLines(path).ToList();
                var sorted = kasutaja_top
                .OrderByDescending(kasutaja => int.Parse(kasutaja.Split(';')[1])) 
                .ToList();

                return sorted;
            }
            catch (Exception)
            {
                Console.WriteLine("Viga failiga!");
                return kasutaja_top;
            }
        }
        public void WriteGameOver(string nimi, int punktid) //Mängu lõpu väljund
        {

            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("====================================================", xOffset, yOffset++);
            WriteText("                   M Ä N G   L Õ P P                ", xOffset + 1, yOffset++);
            WriteText($"   K A S U T A J A : {nimi}  P U N K T I D : {punktid}    ", xOffset + 2, yOffset++);
            WriteText($"           T U L E M U S T E  T A B E L            ", xOffset + 3, yOffset++); //tulemuste tabel
            List<string> top = GameOver.ReadFile();
            int count = Math.Min(5, top.Count);
            for (int i = 0; i < count; i++)
            {
                WriteText($"{i + 1}.  {top[i]}  ", xOffset + 4, yOffset++); //Parimate 5 mängija kuvamine
            }
            WriteText("=====================================================", xOffset, yOffset++);
        }

        public void WriteText(string text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}
