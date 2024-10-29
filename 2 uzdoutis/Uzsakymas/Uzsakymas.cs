
using System;

namespace _2_uzdoutis.Uzsakymas
{
    public class Uzsakymas
    {
        public int UzsakymoNumeris { get; set; }
        public string KlientoVardas { get; set; }
        public int PrekiuKiekis { get; set; }
        public double BendraSuma { get; set; }
        public DateTime UzsakymoData { get; set; }

        public Uzsakymas(int uzsakymoNumeris, string klientoVardas, int prekiuKiekis, double bendraSuma, DateTime uzsakymoData)
        {
            UzsakymoNumeris = uzsakymoNumeris;
            KlientoVardas = klientoVardas;
            PrekiuKiekis = prekiuKiekis;
            BendraSuma = bendraSuma;
            UzsakymoData = uzsakymoData;
        }
    }
}
