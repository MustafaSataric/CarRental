using Buchung_2.Zusammenhänge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchung_2
{
    abstract class Kunde
    {
        protected string name, vorname;
        protected DateTime gebDatum;
        protected char fuehrerrschein;

        Methoden m = new Methoden();
        public string Name { get => name; set => name = value; }
        public string VorName { get => vorname; set => vorname = value; }
        public char Fuehrerschein { get => fuehrerrschein; set => fuehrerrschein = value; }
        public DateTime GebDatum { get => gebDatum; set => gebDatum = value; }

        public abstract double rabatt();
        public abstract void KundeAufnehmen();
        public abstract void KundeAusgeben();

        public void Kommentieren()
        {
            DateTime localDate = DateTime.Now;
            double alter = (((localDate - GebDatum).TotalDays)) / 365.25;

            if (alter < 21)
            {
                Console.WriteLine("\n\n\tUser Ist zu Jung um Fahrzeug auszumieten");
            }
            if (fuehrerrschein == Convert.ToChar("f"))
            {
                Console.WriteLine("\tUser muss Führerschein zum ausleihen besitzen");
            }
        }

        public char abfrage()
        {
            var eingabe = Console.ReadLine();
            if (eingabe == "y" || eingabe == "Y" || eingabe == "j" || eingabe == "J" || eingabe == "true" || eingabe == "TRUE")
            {
                return Convert.ToChar("j");
            }
            return Convert.ToChar("f");
        }

        public string kurzekonfi()
        {
            return name;
        }
    }
}
