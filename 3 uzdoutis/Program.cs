using _3_uzdoutis.projektas;
using System;
using System.Collections.Generic;
using ProjektaiApp;

namespace ProjektaiApp
{
    public class Program
    {
        public static List<Projektas> projektai = new List<Projektas>();
        public static string filePath = "projektas.cvs";
        public static ProjektasRepository repository = new ProjektasRepository();

        public static void Main(string[] args)
        {
            projektai = repository.NuskaitytiProjektusIsFailo(filePath);
            ShowMenu();
        }

        public static void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\nMeniu:");
                Console.WriteLine("1. Peržiūrėti visus projektus");
                Console.WriteLine("2. Peržiūrėti projektą pagal ID");
                Console.WriteLine("3. Pridėti naują projektą");
                Console.WriteLine("4. Ištrinti projektą pagal ID");
                Console.WriteLine("5. Išsaugoti visus pakeitimus į failą");
                Console.WriteLine("0. Išeiti");

                Console.Write("Pasirinkite veiksmą: ");
                string pasirinkimas = Console.ReadLine();

                switch (pasirinkimas)
                {
                    case "1":
                        PerziuretiVisusProjektus();
                        break;
                    case "2":
                        PerziuretiProjektaPagalID();
                        break;
                    case "3":
                        PridetiNaujaProjektą();
                        break;
                    case "4":
                        IstrintiProjektąPagalID();
                        break;
                    case "5":
                        repository.IrasytiProjektusIFaila(filePath, projektai);
                        Console.WriteLine("Visi pakeitimai išsaugoti į failą.");
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Neteisingas pasirinkimas, bandykite dar kartą.");
                        break;
                }
            }
        }

        public static void PerziuretiVisusProjektus()
        {
            foreach (var projektas in projektai)
            {
                Console.WriteLine($"ID: {projektas.ProjektoID}, Pavadinimas: {projektas.ProjektoPavadinimas}, Vadovas: {projektas.VadovoVardas}, Biudžetas: {projektas.Biudzetas}, Pradžios data: {projektas.PradziosData.ToShortDateString()}, Pabaigos data: {projektas.PabaigosData.ToShortDateString()}");
                FiltruotiPagalKriterijus(projektas);
            }
        }

        public static void FiltruotiPagalKriterijus(Projektas projektas)
        {
            if (projektas.PabaigosData > DateTime.Now && projektas.Biudzetas > 30000)
            {
                Console.WriteLine($"Projektas {projektas.ProjektoPavadinimas} vadovaujamas {projektas.VadovoVardas} yra tęsiamas su aukštu biudžetu.");
            }
            else if (projektas.Biudzetas < 10000 && (DateTime.Now - projektas.PradziosData).TotalDays > 365)
            {
                Console.WriteLine($"Projektas {projektas.ProjektoPavadinimas} yra su mažu biudžetu ir ilgai trunka.");
            }
            else if (projektas.PabaigosData < DateTime.Now)
            {
                Console.WriteLine($"Projektas {projektas.ProjektoPavadinimas} jau užbaigtas.");
            }
        }

        public static void PerziuretiProjektaPagalID()
        {
            Console.Write("Įveskite projekto ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var projektas = projektai.Find(p => p.ProjektoID == id);
                if (projektas != null)
                {
                    Console.WriteLine($"ID: {projektas.ProjektoID}, Pavadinimas: {projektas.ProjektoPavadinimas}, Vadovas: {projektas.VadovoVardas}, Biudžetas: {projektas.Biudzetas}, Pradžios data: {projektas.PradziosData.ToShortDateString()}, Pabaigos data: {projektas.PabaigosData.ToShortDateString()}");
                }
                else
                {
                    Console.WriteLine($"Projektas su ID {id} nerastas.");
                }
            }
            else
            {
                Console.WriteLine("Neteisingas ID. Prašome įvesti skaičių.");
            }
        }



        public static void PridetiNaujaProjektą()
        {
            Console.Write("Įveskite projekto ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Įveskite projekto pavadinimą: ");
                string pavadinimas = Console.ReadLine();
                Console.Write("Įveskite vadovo vardą: ");
                string vadovas = Console.ReadLine();
                Console.Write("Įveskite biudžetą: ");
                if (double.TryParse(Console.ReadLine(), out double biudzetas))
                {
                    Console.Write("Įveskite projekto pradžios datą (yyyy-MM-dd): ");
                    DateTime pradziosData = DateTime.Parse(Console.ReadLine());
                    Console.Write("Įveskite projekto pabaigos datą (yyyy-MM-dd): ");
                    DateTime pabaigosData = DateTime.Parse(Console.ReadLine());

                    var naujasProjektas = new Projektas(id, pavadinimas, vadovas, biudzetas, pradziosData, pabaigosData);
                    projektai.Add(naujasProjektas);
                    Console.WriteLine("Projektas pridėtas sėkmingai!");
                }
                else
                {
                    Console.WriteLine("Neteisingas biudžetas. Prašome įvesti skaičių.");
                }
            }
            else
            {
                Console.WriteLine("Neteisingas ID. Prašome įvesti skaičių.");
            }
        }

        public static void IstrintiProjektąPagalID()
        {
            Console.Write("Įveskite projekto ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var projektas = projektai.Find(p => p.ProjektoID == id);
                if (projektas != null)
                {
                    projektai.Remove(projektas);
                    Console.WriteLine("Projektas pašalintas sėkmingai!");
                }
                else
                {
                    Console.WriteLine("Projektas nerastas.");
                }
            }
            else
            {
                Console.WriteLine("Neteisingas ID. Prašome įvesti skaičių.");
            }
        }
    }
}
