using System;
using System.Collections.Generic;
using System.Text;

namespace Buchung_2
{
    class PKW : Fahrzeug // siehe Kommentar GiroKonto!
    {
        private string karosserieform;
        private double leistung;


        public override void FahrzeugEinrichten() //siehe Kommentar GiroKonto!
        {
            double betrag;
            Console.WriteLine("\n\n\n Ausstatung ihres PKWs");
            Console.Write("\n\tKarosserieform           : ");
            karosserieform = Console.ReadLine();
            Console.Write("\n\tLeistung           : ");
            leistung = Convert.ToDouble(Console.ReadLine());

        }

        public override void KategorieWaehlen()
        {

            int auswahl = 0;
            do
            {
                Console.Clear();
                auswahl = AuswahlsMenue.Menue("Bitte Wählen Sie ihren gewünschten Aufbau:", "(K)asten", "(P)ritsche", "P(l)ane");

                switch (auswahl)
                {
                    case 0:

                        markeModell = "BMW E70";
                        kmStand = 1500;
                        Grundpreis = 89;
                        preisProKm = 0.20;
                        break;
                    case 1:

                        markeModell = "BMW E70";
                        kmStand = 1500;
                        Grundpreis = 89;
                        preisProKm = 0.20;
                        break;
                }
                auswahl = AuswahlsMenue.Menue("Bitte Wählen Sie ihren gewünschten Aufbau:", "(K)asten", "(P)ritsche", "P(l)ane");
            } while (auswahl != -1);
        }

    
        public override void KonfigurationsDaten()
        {
            Console.WriteLine("PKW:");
            Console.WriteLine("\n\tIhre Marke lautet: {0}", markeModell);
            Console.WriteLine("\tIhr Karosserieform lautet : {0}", karosserieform);
            Console.WriteLine("\tIhr KM Stand lautet    : {0}", kmStand);
            Console.WriteLine("\tIhr Leistung lautet    : {0}", leistung);
            Console.WriteLine("\tIhr Kennzeichen lauten    : {0}", kennzeichen);
            Console.WriteLine("\tIhr Fahrzeugtyp lauten    : {0}", fahrzeugTyp);
            Console.WriteLine("\tDer Grundpreis beträgt: {0}", grundpreis);
            Console.WriteLine("\tDer Preis pro Km beträgt: {0}", preisProKm);
            Console.ReadKey();
        }

    }
}