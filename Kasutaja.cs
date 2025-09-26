using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madu_Uss
{
    class Kasutaja
    {
        public string Nimi { get; set; }
        public Kasutaja(string kasutaja)
        {
            Nimi = kasutaja;
        }
        public static bool KasutajaKontroll(string kasutaja)
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
                        Console.WriteLine($"Kasutaja {kasutaja} viimane mäng oli {punktidStr} punkti.");
                        return true;
                    }
                }
            }

            Console.WriteLine("ЭТО ВАША ПЕРВАЯ ИГРА! ДАВАЙТЕ НАЧНЕМ.");
            return false;
        }
        public static void SalvestaKasutaja(Kasutaja kasutaja, int punktid)
        // string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "kasutaja.txt");
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\kasutaja.txt");
            List<string> read = new List<string>();

            try
            {
                // читаем всех старых пользователей, если файл существует
                if (File.Exists(path))
                {
                    read = File.ReadAllLines(path).ToList();
                }

                // удаляем старую запись этого же игрока (если была)
                read.RemoveAll(line => line.StartsWith($"Nimi={kasutaja.Nimi};"));

                // добавляем нового (даже если 0 очков)
                read.Add($"Nimi={kasutaja.Nimi};Punktid={punktid}");

                // сохраняем обратно всех
                File.WriteAllLines(path, read);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при сохранении пользователя: " + ex.Message);
            }
        }




    }
}

