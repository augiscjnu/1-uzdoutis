
using _2_uzdoutis.Uzsakymas;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace UzsakymasApp
{
    public class FileRepository
    {
        private string _filePath;

        public FileRepository(string filePath)
        {
            _filePath = filePath;
        }

        public List<Uzsakymas> NuskaitytiUzsakymusIsFailo()
        {
            var uzsakymai = new List<Uzsakymas>();

            try
            {
                using (var reader = new StreamReader(_filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var dalys = line.Split(',');

                        if (dalys.Length != 5)
                        {
                            Console.WriteLine($"Klaida: netinkama eilutė '{line}'");
                            continue; 
                        }

                        int uzsakymoNumeris = int.Parse(dalys[0]);
                        string klientoVardas = dalys[1];
                        int prekiuKiekis = int.Parse(dalys[2]);
                        double bendraSuma = double.Parse(dalys[3], CultureInfo.InvariantCulture);
                        DateTime uzsakymoData = DateTime.Parse(dalys[4]);

                        uzsakymai.Add(new Uzsakymas(uzsakymoNumeris, klientoVardas, prekiuKiekis, bendraSuma, uzsakymoData));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Klaida skaitant failą: {ex.Message}");
            }

            return uzsakymai;
        }
    }
}
