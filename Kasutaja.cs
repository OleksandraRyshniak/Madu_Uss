using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Madu_Uss
{
    class Kasutaja //kasutajate lisamine ja salvestamine koos nende tulemusega

    {
        public string Nimi { get; set; }
        public Kasutaja(string kasutaja)
        {
            Nimi = kasutaja;
        }
        public static bool KasutajaKontroll(string kasutaja) //kasutaja mängimise kontrollimine
        {  
            List<string> kasutaja_list = new List<string>();
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\kasutaja.txt");
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
                        Console.WriteLine($"Kasutaja {kasutaja} viimane mäng oli {punktidStr} punkti."); //kui kasutaja on juba mänginud, siis kuvada see rida
                        return true;
                    }
                }
            }

            Console.WriteLine("See on teie esimene mäng! Alustame"); //kui ei ole, siis see rida
            return false;
        }
        public static void SalvestaKasutaja(Kasutaja kasutaja, int punktid) //kasutaja salvestamine tema punktidega
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\kasutaja.txt");
            List<string> read = new List<string>();
            if (File.Exists(path))
            {
                read = new List<string>(File.ReadAllLines(path));
            }
            for (int i = 0; i < read.Count; i++)
            {
                if (read[i].StartsWith(kasutaja.Nimi + ";"))
                {
                    read.RemoveAt(i);
                    break;
                }
            }
            read.Add(kasutaja.Nimi + ";" + punktid);
            File.WriteAllLines(path, read);
        }
        public static string Parkasutaja() //kasutaja sisestab oma nime
        {
            Console.Write("Sisesta oma kasutajanimi: ");
            string nimi = "";
            while (true)
            {

                try
                {
                    nimi = Console.ReadLine(); 
                    if (nimi.Length < 3) // kontrolli: nimi vähemalt 3 tähemärki, palun uuesti
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
            return nimi;
        }
    }
}
