using System;
using System.Collections.Generic;
using System.Text;

namespace Buchung_2
{
    // Die Basisklasse Konto soll die gemeinsamen Attribute bereithalten, so dass die Kindklassen darüber verfügen
    class LKW : Fahrzeug// abstract bedeutet: diese Klasse kann nicht instanziiert werden! Wir können nur von den 
                        // Kindklassen Objekte/Instanzen erzeugen!
    {
        private char ladeform;
        private int zulaessigesGesamtgewicht;

        public char Ladeform { get => ladeform; set => ladeform = value; }

        public override void FahrzeugEinrichten() //siehe Kommentar GiroKonto!
        {
            double betrag;
            Console.WriteLine("\n\n\n Ausstatung ihres PKWs");
            Console.Write("\n\tLadeform:           : ");
            int wahl = AuswahlsMenue.Menue("Wählen sie eine Ladeform:", "Kasten", "Pritsche", "Plane");
            if (wahl != -1) {
                if (wahl == 0) { ladeform = Convert.ToChar("K"); }
                else if (wahl == 1) { ladeform = Convert.ToChar("P"); }
                else { ladeform = Convert.ToChar("l"); }
                    Console.Write("\n\tMarke und Modell:           : ");
                    markeModell = Console.ReadLine();
                    Console.Write("\n\tKm stand          : ");
                    kmStand = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\n\tPreis pro KM        : ");
                    preisProKm = Convert.ToDouble(Console.ReadLine());
                    Console.Write("\n\tZulässiges Gesamtgewicht           : ");
                    zulaessigesGesamtgewicht = Convert.ToInt32(Console.ReadLine());


                    using (StreamWriter sw = File.AppendText(@"C:\_IAH11\TestDaten_2.txt"))
                    {
                        sw.WriteLine(ladeform + ";" + markeModell + ";" + kmStand + ";" + grundpreis + ";" + preisProKm + ";" + zulaessigesGesamtgewicht);
                    }


                Console.Write("Fahrzeug:" + markeModell + " wurde erfolgreich zur Datenbank hinzugefügt.");
                Console.ReadKey();

            }
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
                    case 2:

                        markeModell = "BMW E70";
                        kmStand = 1500;
                        Grundpreis = 89;
                        preisProKm = 0.20;
                        break;
                    default:
                        auswahl = AuswahlsMenue.Menue("Bitte Wählen Sie ihren gewünschten Aufbau:", "(K)asten", "(P)ritsche", "P(l)ane");
                        break;
                }
                auswahl = -1;
            } while (auswahl != -1);

        }

        public override void KonfigurationsDaten()
        {
            Console.WriteLine("LKW:");
            Console.WriteLine("\n\tIhre Marke lautet: {0}", markeModell);
            Console.WriteLine("\tIhre Ladeform lautet    : {0}", ladeform);
            Console.WriteLine("\tIhr KM Stand lautet    : {0}", kmStand);
            Console.WriteLine("\tDer Grundpreis beträgt: {0}", grundpreis);
            Console.WriteLine("\tDer Preis pro Km beträgt: {0}", preisProKm);
        }

    }


}

