using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madu_Uss
{
    class GameOver //loemine faili
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
    }
}
