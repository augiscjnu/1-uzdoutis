
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace StudentaiApp
{
    public class StudentRepository
    {
        public List<Studentas> NuskaitytiStudentusIsFailo(string failoKelias)
        {
            var studentai = new List<Studentas>();

            try
            {
                using (var reader = new StreamReader(failoKelias))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var dalys = line.Split(',');

                        if (dalys.Length != 4)
                        {
                            Console.WriteLine($"Klaida: netinkama eilutė '{line}'");
                            continue; 
                        }

                        string vardas = dalys[0];
                        string pavarde = dalys[1];
                        int amzius = int.Parse(dalys[2]);
                        double vidurkis = double.Parse(dalys[3], CultureInfo.InvariantCulture);

                        studentai.Add(new Studentas(vardas, pavarde, amzius, vidurkis));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Klaida skaitant failą: {ex.Message}");
            }

            return studentai;
        }
    }
}
