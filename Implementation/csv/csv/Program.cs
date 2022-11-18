using System;
using System.IO;

namespace csv
{
    class Program
    {
        static Methoden d = new Methoden();
        static void Main(string[] args)
        {
            int i = 0;
            d.ExistiertDatei();

            d.AddDaten("Auberginen", "Spanien", 3.99m);
            d.AddDaten("Bataviasalat", "Frankreich", 1.99m);
            d.AddDaten("Blumenkohl", "Deutschland", 3.79m);
            d.AddDaten("Koriander", "Deutschland", 5.49m);
            d.AddDaten("Kurkuma", "Peru", 9.00m);
            d.AddDaten("Lauch", "Deutschland", 3.99m);
            d.AddDaten("Möhren", "Deutschland", 2.19m);
            d.AddDaten("Möhren bunt", "Deutschland", 2.49m);
            d.AddDaten("Paprika Rot", "Spanien", 5.99m);
            d.AddDaten("Pastinaken", "Deutschland", 3.99m);
            d.AddDaten("Petersilie", "Deutschland", 8.99m);
            d.AddDaten("Rettich schwarz", "Deutschland", 2.99m);
            d.AddDaten("Rettich weiß", "Deutschland", 1.99m);
            d.AddDaten("Rote Bete", "Deutschland", 2.39m);
            d.AddDaten("Rote Bete gegart", "Deutschland", 4.38m);
            d.AddDaten("Rotkohl", "Deutschland", 2.49m);
            d.AddDaten("Salatgurke", "Spanien", 4.99m);
            d.AddDaten("Sellerie", "Deutschland", 2.99m);
            d.AddDaten("Snackmöhren", "Dänemark", 2.99m);
            d.AddDaten("Spitzkohl", "Deutschland", 2.69m);
            d.AddDaten("Spitzpaprika", "Spanien", 7.00m);
            d.AddDaten("Sprossem diverse", "Deutschland", 8.69m);

            d.GemüseSortiement();
            do
            {
                string f;
                string h;
                Console.WriteLine("Geben sie den Namen des Artikel ein den Sie kaufen möchten.");
                f = Console.ReadLine();
                Console.WriteLine("Wie viel gramm wollen sie kaufen?");
                h = Console.ReadLine();
                if (d.Gemüsefinden(f) == false)
                {
                    do
                    {
                        Console.WriteLine("Haben sie sich vertippt das Gemüse wurde nicht gefunden.");
                        Console.WriteLine("Bitte geben sie es erneut ein.");
                        f = Console.ReadLine();
                    } while (d.Gemüsefinden(f) == false);
                }

                d.GemüseAdd(f, Convert.ToDecimal(h));
                if(i == 5)
                {
                    Console.WriteLine("Wollen sie die Liste erneut sehen? Antworten Sie mit ja oder nein");
                    if(Console.ReadLine() == "ja" || Console.ReadLine() == "Ja")
                    {
                        d.GemüseSortiement();
                        i = -1;
                    }
                }
                Console.WriteLine("Wollen sie einen weitern Artikel Kaufen dann antworten sie mit ja, wenn sie nichts weiteres brauchen mit nein");
                i++;
            }
            while (Console.ReadLine() != "nein");
            d.PrintEinkaufszettel();

            Console.ReadLine();
        }
    }
}
