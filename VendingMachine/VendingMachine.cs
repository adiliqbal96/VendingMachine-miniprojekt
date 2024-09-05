using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    // Repræsenterer selve automaten
    internal class Automat
    {
        private List<Produkt> produkter; // Liste over produkter i automaten
        private double samletPenge; // Samlet indsat beløb
        private List<double> accepteredeMønter; // Liste over accepterede møntværdier

        // Konstruktor til at oprette en automat med en liste af produkter og accepterede mønter
        public Automat(List<Produkt> produkter, List<double> accepteredeMønter)
        {
            this.produkter = produkter;
            this.accepteredeMønter = accepteredeMønter;
        }

        // Metode til at indsætte mønter i automaten
        public void IndsætMønt(double mønt)
        {
            if (accepteredeMønter.Contains(mønt))
            {
                samletPenge += mønt; // Tilføj mønten til det samlede beløb
                Console.WriteLine($"Indsat {mønt}");
            }
            else
            {
                Console.WriteLine("Mønt ikke accepteret"); // Afvis mønten, hvis den ikke er accepteret
            }
        }

        // Metode til at vælge et produkt fra automaten
        public void VælgProdukt(string produktNavn)
        {
            // Finder produktet baseret på navnet
            Produkt produkt = produkter.FirstOrDefault(p => p.Navn.Equals(produktNavn, StringComparison.OrdinalIgnoreCase));
            if (produkt != null)
            {
                // Tjekker om der er nok penge indsat til købet
                if (produkt.Pris <= samletPenge)
                {
                    // Tjekker om produktet er på lager
                    if (produkt.Antal > 0)
                    {
                        UdleverProdukt(produkt); // Udlever produktet
                    }
                    else
                    {
                        Console.WriteLine("Produkt ikke på lager"); // Giver besked, hvis produktet er udsolgt
                    }
                }
                else
                {
                    Console.WriteLine("Ikke nok penge"); // Besked om manglende penge til køb
                }
            }
            else
            {
                Console.WriteLine("Produkt ikke fundet"); // Besked hvis produktet ikke kan findes
            }
        }

        // Private metode til at udlevere produktet til kunden
        private void UdleverProdukt(Produkt produkt)
        {
            produkt.ReducerAntal(); // Reducerer antallet af produktet
            Console.WriteLine($"Udleveret {produkt.Navn}"); // Bekræftelse af udlevering

            double tilbage = samletPenge - produkt.Pris; // Beregn tilbagebetaling
            ReturnerPenge(tilbage); // Returnerer eventuel overskydende beløb

            samletPenge = 0; // Nulstil det samlede beløb efter køb
        }

        // Metode til at returnere overskydende beløb
        private void ReturnerPenge(double tilbage)
        {
            if (tilbage > 0)
            {
                Console.WriteLine($"Returnerer penge: {tilbage}"); // Besked om at penge returneres
            }
        }

        // Metode til at vise alle tilgængelige produkter i automaten
        public void VisProdukter()
        {
            Console.WriteLine("Tilgængelige Produkter:");
            foreach (var produkt in produkter)
            {
                Console.WriteLine($"{produkt.Navn} - {produkt.Pris} kr ({produkt.Antal} på lager)");
            }
        }
    }
}
