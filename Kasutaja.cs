using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madu_Uss
{
    class Kasutaja
    {
        public string Nimi {  get; set; }
        public int Punktid { get; set; } = 0;
        public Kasutaja(string kasutaja)
        {
            Nimi = kasutaja;
        }
        public static bool KasutajaKontroll(string fail, string kasutaja)
        {
            List<string> kasutaja_list = new List<string>();
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fail);
                kasutaja_list = File.ReadAllLines(path).ToList();
            }
            catch (Exception)
            {
                Console.WriteLine("Viga failiga!");
                return false;
            }

            if (kasutaja_list.Count == 0)
            {
                Console.WriteLine("Kasutajate nimekiri on tühi.");
                return false;
            }

            foreach (string rida in kasutaja_list)
            {
                var osad = rida.Split(';');
                if (osad.Length == 2)
                {
                    string nimi = osad[0];
                    string punktidStr = osad[1];

                    if (nimi == kasutaja)
                    {
                        Console.WriteLine($"Kasutaja {kasutaja} viimane mäng oli {punktidStr} punkti.");
                        return true;
                    }
                }
            }

            Console.WriteLine("ЭТО ВАША ПЕРВАЯ ИГРА! ДАВАЙТЕ НАЧНЕМ.");
            return false;
        }
        public static void SalvestaKasutaja(string fail, Kasutaja kasutaja)
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fail);
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine($"{kasutaja.Nimi};{kasutaja.Punktid}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Viga faili salvestamisel!");
            }
        }

    }
}
