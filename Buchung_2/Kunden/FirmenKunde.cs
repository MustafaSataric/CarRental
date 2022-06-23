using Buchung_2.Zusammenhänge;
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
        protected int anzahlBuchungen;
        protected double rabattsatz;
        Methoden m = new Methoden();

        public double Rabattsatz { get => rabattsatz; set => rabattsatz = value; }
        public string Firma { get => firma; set => firma = value; }
        public int AnzahlBuchungen { get => anzahlBuchungen; set => anzahlBuchungen = value; }

        public FirmenKunde() { }

        public override void KundeAufnehmen()
        {

            Console.WriteLine("Firmen-Konto Erstellen:");
            Console.WriteLine("\nName:");
            name = m.validationVonStrings();
            Console.WriteLine("\nVorname:");
            vorname = m.validationVonStrings();
            Console.WriteLine("\nFirmenname:");
            firma = m.validationVonStrings();
            Console.WriteLine("\nFührerschein (j/n):");
            fuehrerrschein = abfrage();
            Console.WriteLine("\nGeburtsjahr:");
            int jahr = m.validitationVonInts(1922, 2005);
            gebDatum = new DateTime(jahr, 1, 1, 6, 32, 0);
            Console.WriteLine("\nAnzahl an Buchungen:");
            anzahlBuchungen = m.validitationVonInts(0, 999); ; //automatisieren !!!    
            using (StreamWriter sw = File.AppendText(Verwaltung.benutzerDb))
            {
                sw.WriteLine("f" + ";" + name + ";" + vorname + ";" + gebDatum + ";" + firma + ";" + anzahlBuchungen + ";" + rabattsatz);
            }
            Console.WriteLine("\n\nNeue Benutzer " + name + " wurde anglegt.");
            Console.ReadKey();
        }
        public override void KundeAusgeben()
        {
            Console.WriteLine("\n\n\tFirmen Konto Daten:");
            Console.WriteLine("Name : " + name);
            Console.WriteLine("Vorname : " + vorname);
            Console.WriteLine("Geburtsdatum : " + gebDatum);
            Console.WriteLine("Firmenname : " + firma);
            Console.WriteLine("Anzahl Buchungen : " + anzahlBuchungen);
            Console.WriteLine("Rabatsatz : " + rabattsatz);
        }

        public override double rabatt() 
        {
            if(anzahlBuchungen == 0)
            {
                return 1;
            }
            rabattsatz = anzahlBuchungen * 0.02;
            if(rabattsatz > 0.50)
            {
                return 0.50;
            }
            return 1-rabattsatz;
        }

    }
}
