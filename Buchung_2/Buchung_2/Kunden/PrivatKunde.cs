using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Buchung_2
{
    internal class PrivatKunde : Kunde
    {
        protected char automobilclubMitglied;

        public char AutomobilclubMitglied { get => automobilclubMitglied; set => automobilclubMitglied = value; }

        public PrivatKunde() { }

        public override void KundeAufnehmen()
        {
            Console.WriteLine("Privat Konto Erstellen:");
            Console.WriteLine("Name:");
            name = Console.ReadLine();
            Console.WriteLine("Vorname:");
            vorname = Console.ReadLine();
            Console.WriteLine("Geburtsjahr:");
            int jahr = Convert.ToInt32(Console.ReadLine()); ;
            gebDatum = new DateTime(jahr, 1, 1, 6, 32, 0);
            Console.WriteLine("Führerschein:");
            fuehrerrschein = abfrage();
            Console.WriteLine("AutoClub mitgliedsschaft (j/n):");
            automobilclubMitglied = abfrage();
            using (StreamWriter sw = File.AppendText(@"C:\_IAH11\TestDaten_1.txt"))
            {
                sw.WriteLine("p;" + name + ";" + vorname + ";" + gebDatum + ";" + fuehrerrschein + ";" + automobilclubMitglied + ";");
            }
        }
        public override void KundeAusgeben()
        {
            Console.WriteLine("\n\n\tPrivat-Konto Daten:");
            Console.WriteLine("Name : " + name);
            Console.WriteLine("Vorname : " + vorname);
            Console.WriteLine("Geburtsdatum : " + gebDatum);
            Console.WriteLine("Führerscheinstatus : " + fuehrerrschein);
            Console.WriteLine("Auromobliclub Mitgliedschafts Status : " + automobilclubMitglied);
        }
    }
}
