
using _3_uzdoutis.projektas;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ProjektaiApp
{
    public class ProjektasRepository
    {
        public List<Projektas> NuskaitytiProjektusIsFailo(string failoKelias)
        {
            var projektai = new List<Projektas>();

            try
            {
                using (var reader = new StreamReader(failoKelias))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var dalys = line.Split(',');

                        if (dalys.Length != 6)
                        {
                            Console.WriteLine($"Klaida: netinkama eilutė '{line}'");
                            continue;
                        }

                       
                        try
                        {
                            int projektoID = int.Parse(dalys[0]);
                            string projektoPavadinimas = dalys[1];
                            string vadovoVardas = dalys[2];
                            double biudzetas = double.Parse(dalys[3], CultureInfo.InvariantCulture);
                            DateTime pradziosData = DateTime.Parse(dalys[4]);
                            DateTime pabaigosData = DateTime.Parse(dalys[5]);

                            projektai.Add(new Projektas(projektoID, projektoPavadinimas, vadovoVardas, biudzetas, pradziosData, pabaigosData));
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine($"Klaida analizuojant eilutę '{line}': {ex.Message}");
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Klaida: failas '{failoKelias}' nerastas.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Klaida skaitant failą: {ex.Message}");
            }

            return projektai;
        }

        public void IrasytiProjektusIFaila(string failoKelias, List<Projektas> projektai)
        {
            using (var writer = new StreamWriter(failoKelias))
            {
                foreach (var projektas in projektai)
                {
                    writer.WriteLine($"{projektas.ProjektoID},{projektas.ProjektoPavadinimas},{projektas.VadovoVardas},{projektas.Biudzetas},{projektas.PradziosData:yyyy-MM-dd},{projektas.PabaigosData:yyyy-MM-dd}");
                }
            }
        }
    }
}
