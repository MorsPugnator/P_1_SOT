using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace csv
{
    class Methoden
    {
        static string Datei = @"C:\Users\yanre\Code\csv.txt";

        List<string> Einkaufszettel = new List<string>();
        List<decimal> Kilo = new List<decimal>();
        public void ExistiertDatei()
        {
            if (File.Exists(Datei))
            {
                File.Delete(Datei);
            }

            using (FileStream fs = File.Create(Datei))
            {

            }
        }
        public void AddDaten(string gemüse,string Herkunft, decimal preis)
        {
            string einfuegen = gemüse + ";" + Herkunft + ";" + preis.ToString() + ";";
            using (StreamWriter sw = File.AppendText(Datei))
            {
                sw.WriteLine(einfuegen);
            }
        }

        public void GemüseSortiement()
        {
            using (StreamReader sr = new StreamReader(Datei, Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var values = line.Split(";");
                    string a = values[0];
                    string b = values[1];
                    string c = values[2];
                    Console.WriteLine("{0,-20} {1,0} {2,-15} {3,0} {4,0}", a, " Herkunft: ", b, " Preis:", c);
                }
                
            }
            
        }

        public void GemüseAdd(string Gemüse, decimal KG)
        {
            Einkaufszettel.Add(Gemüse);
            Kilo.Add(KG/1000);
        }

        public bool Gemüsefinden(string gemüse)
        {
                using (StreamReader sr = new StreamReader(Datei, Encoding.UTF8))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var values = line.Split(";");
                        string a = values[0];
                        if (string.Equals(gemüse, a, StringComparison.OrdinalIgnoreCase))
                        {
                        return true;   
                        }
                    }
                }
            return false;
        }
        public void PrintEinkaufszettel()
        {
            decimal gesamtpreis = 0;
            var date = DateTime.Now;
            Console.WriteLine("{0,25}", "GemüseHandel Otto");
            Console.WriteLine("{0, 48}", date.ToString("dd,MM,yyyy"));
            Console.WriteLine();
            foreach (var item in Einkaufszettel)
            {
                int i = 0;
                string c;
                decimal g;
                
                using (StreamReader sr = new StreamReader(Datei, Encoding.UTF8))
                { 
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var values = line.Split(";");
                        string a = values[0];
                        c = values[2];
                        if (string.Equals(item, a, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("{0,-15} {1,0} {2,-5} {3,0} {4,0} {5,0}", a,  Kilo[i], "KG", " Preis pro KG:", c, "EUR");
                            g = Convert.ToDecimal(c);
                            g = Kilo[i] * g;
                            gesamtpreis = gesamtpreis + g;
                            break;
                        }
                        
                    }
                }
                i++;
            }
            Console.WriteLine();
            Console.WriteLine("{0,39} {1,0} {2,0}","Gesamtpreis:", gesamtpreis, "EUR");
        }
    }

}

