
using _2_uzdoutis.Uzsakymas;
using System;
using System.Collections.Generic;

namespace UzsakymasApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "uzsakymai.csv";
            FileRepository repository = new FileRepository(filePath);
            List<Uzsakymas> uzsakymai = repository.NuskaitytiUzsakymusIsFailo();
            int prioritetiniuUzsakymuKiekis = 0;

            foreach (var uzsakymas in uzsakymai)
            {
                if ((DateTime.Now - uzsakymas.UzsakymoData).TotalDays <= 7 && uzsakymas.BendraSuma >= 100)
                {
                    Console.WriteLine($"Užsakymas {uzsakymas.UzsakymoNumeris} iš kliento {uzsakymas.KlientoVardas} yra prioritetinis.");
                    prioritetiniuUzsakymuKiekis++;
                }
                else if (uzsakymas.PrekiuKiekis >= 10 && uzsakymas.BendraSuma < 50)
                {
                    Console.WriteLine($"Užsakymas {uzsakymas.UzsakymoNumeris} iš kliento {uzsakymas.KlientoVardas} turi didelį kiekį, bet žemą vertę.");
                }
                else
                {
                    Console.WriteLine($"Užsakymas {uzsakymas.UzsakymoNumeris} iš kliento {uzsakymas.KlientoVardas} neatitinka specialių kriterijų ir nėra prioritetinis.");
                }
            }

            Console.WriteLine($"Prioritetinių užsakymų kiekis: {prioritetiniuUzsakymuKiekis}");
        }
    }
}
