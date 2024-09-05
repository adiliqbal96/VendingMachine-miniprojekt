using System;

namespace VendingMachine
{
    internal class Produkt
    {
        public string Navn { get; set; }
        public double Pris { get; set; }
        public int Antal { get; set; }

        public Produkt(string navn, double pris, int antal)
        {
            Navn = navn;
            Pris = pris;
            Antal = antal;
        }

        public void ReducerAntal()
        {
            if (Antal > 0)
            {
                Antal--;
            }
        }
    }
}
