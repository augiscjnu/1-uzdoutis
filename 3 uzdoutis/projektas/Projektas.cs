namespace _3_uzdoutis.projektas
{
    public class Projektas
    {
        public int ProjektoID { get; private set; }
        public string Pavadinimas { get; private set; }
        public string VadovoVardas { get; private set; }
        public double Biudzetas { get; private set; }
        public DateTime PradziosData { get; private set; }
        public DateTime PabaigosData { get; private set; }
        public object ProjektoPavadinimas { get; internal set; }

        public Projektas(int projektoID, string pavadinimas, string vadovoVardas, double biudzetas, DateTime pradziosData, DateTime pabaigosData)
        {
            ProjektoID = projektoID;
            Pavadinimas = pavadinimas;
            VadovoVardas = vadovoVardas;
            Biudzetas = biudzetas;
            PradziosData = pradziosData;
            PabaigosData = pabaigosData;
        }
    }
}
