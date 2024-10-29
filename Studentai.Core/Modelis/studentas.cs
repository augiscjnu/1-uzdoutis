
namespace StudentaiApp
{
    public class Studentas
    {
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public int Amzius { get; set; }
        public double Vidurkis { get; set; }

        public Studentas(string vardas, string pavarde, int amzius, double vidurkis)
        {
            Vardas = vardas;
            Pavarde = pavarde;
            Amzius = amzius;
            Vidurkis = vidurkis;
        }
    }
}
