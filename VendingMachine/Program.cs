using System;
using System.Collections.Generic;

namespace VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Liste over tilgængelige produkter
            List<Produkt> produkter = new List<Produkt>
            {
                new Produkt("Cola", 15.50, 10),
                new Produkt("Pepsi", 15.50, 5),
                new Produkt("Vand", 10.00, 20)
            };

            // Liste over accepterede mønter
            List<double> accepteredeMønter = new List<double> { 0.5, 1, 2, 5, 10, 20 };

            // Opretter en ny automat med produkterne og mønterne
            Automat automat = new Automat(produkter, accepteredeMønter);

            // Løkke til at vise menuen og håndtere brugerens valg
            while (true)
            {
                Console.WriteLine("\nAutomat");
                Console.WriteLine("1. Indsæt Mønt");
                Console.WriteLine("2. Vælg Produkt");
                Console.WriteLine("3. Afslut");
                Console.Write("Vælg en mulighed: ");
                string valg = Console.ReadLine();

                // Håndtering af brugerens valg
                switch (valg)
                {
                    case "1":
                        // Indsætte en mønt i automaten
                        Console.Write("Indtast møntværdi (f.eks., 0.5, 1, 2, 5, 10, 20): ");
                        if (double.TryParse(Console.ReadLine(), out double mønt))
                        {
                            automat.IndsætMønt(mønt);
                        }
                        else
                        {
                            Console.WriteLine("Ugyldigt input");
                        }
                        break;

                    case "2":
                        // Vise produkter og vælge et produkt
                        automat.VisProdukter();
                        Console.Write("Indtast produktnavn: ");
                        string produktNavn = Console.ReadLine();
                        automat.VælgProdukt(produktNavn);
                        break;

                    case "3":
                        // Afslutter programmet
                        return;

                    default:
                        Console.WriteLine("Ugyldigt valg");
                        break;
                }
            }
        }
    }
}
