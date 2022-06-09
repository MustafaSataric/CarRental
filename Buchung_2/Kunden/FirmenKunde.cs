using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchung_2
{
    internal class FirmenKunde : Kunde
    {
        protected string firma;
        protected long anzahlBuchungen;
        protected double rabattsatz;

        public double Rabattsatz { get => rabattsatz; set => rabattsatz = value; }

        public FirmenKunde() { }

        public override void KundeAufnehmen()
        {

            Console.WriteLine("Firmen-Konto Erstellen:");
            Console.WriteLine("Name:");
            name = Console.ReadLine();
            Console.WriteLine("Vorname:");
            vorname = Console.ReadLine();
            Console.WriteLine("Firmenname:");
            firma = Console.ReadLine();
            Console.WriteLine("Führerschein:");
            fuehrerrschein = abfrage();
            Console.WriteLine("Geburtsjahr:");
            int jahr = Convert.ToInt32(Console.ReadLine()); ;
            gebDatum = new DateTime(jahr, 1, 1, 6, 32, 0);
            Console.WriteLine("Anzahl an Buchungen:");
            anzahlBuchungen = 1; //automatisieren !!!    
            using (StreamWriter sw = File.AppendText(@"C:\_IAH11\TestDaten_1.txt"))
            {
                sw.WriteLine("f;" + ";" + name + ";" + vorname + ";" + gebDatum + ";" + firma + ";" + anzahlBuchungen + ";" + rabattsatz);
            }
        }
        public override void KundeAusgeben()
        {
            Console.WriteLine("\n\n\tFirmen Konto Daten:");
            Console.WriteLine("Name : " + name);
            Console.WriteLine("Vorname : " + vorname);
            Console.WriteLine("Geburtsdatum : " + gebDatum);
            Console.WriteLine("Firmenname : " + firma);
            Console.WriteLine("Führerscheinstatus : " + fuehrerrschein);
            Console.ReadKey();
        }


    }
}
