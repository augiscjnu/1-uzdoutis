
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace StudentaiApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "studentai.csv";
            var repository = new StudentRepository();
            List<Studentas> studentai = repository.NuskaitytiStudentusIsFailo(filePath);

            
            foreach (var studentas in studentai)
            {
                if (studentas.Amzius > 20 && studentas.Vidurkis > 7.0)
                {
                    Console.WriteLine($"Studentas {studentas.Vardas} {studentas.Pavarde} atitinka kriterijus.");
                }
                else
                {
                    Console.WriteLine($"Studentas {studentas.Vardas} {studentas.Pavarde} neatitinka kriterijų.");
                }
            }

            
            Console.WriteLine("Ar norite pridėti naują studentą? (taip/ne)");
            string atsakymas = Console.ReadLine()?.ToLower();
            if (atsakymas == "taip")
            {
                PridetiNaujaStudenta(filePath);
            }
        }

        public static void PridetiNaujaStudenta(string failoKelias)
        {
            Console.WriteLine("Įveskite studento vardą:");
            string vardas = Console.ReadLine();

            Console.WriteLine("Įveskite studento pavardę:");
            string pavarde = Console.ReadLine();

            Console.WriteLine("Įveskite studento amžių:");
            int amzius = int.Parse(Console.ReadLine());

            Console.WriteLine("Įveskite studento vidurkį:");
            double vidurkis = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            
            var naujasStudentas = new Studentas(vardas, pavarde, amzius, vidurkis);

            
            using (var writer = new StreamWriter(failoKelias, true))
            {
                writer.WriteLine($"{naujasStudentas.Vardas},{naujasStudentas.Pavarde},{naujasStudentas.Amzius},{naujasStudentas.Vidurkis}");
            }

            Console.WriteLine("Studentas pridėtas sėkmingai!");
        }
    }
}
