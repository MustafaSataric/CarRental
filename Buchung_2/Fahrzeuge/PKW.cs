using System;
using System.Collections.Generic;
using System.Text;

namespace Buchung_2
{
    class PKW : Fahrzeug // siehe Kommentar GiroKonto!
    {
        private char karosserieform;
        private int leistung;


        public char Karosserieform { get => karosserieform; set => karosserieform = value; }

        public override void FahrzeugEinrichten() //siehe Kommentar GiroKonto!
        {
            double betrag;
            Console.WriteLine("\n\n\n Ausstatung ihres PKWs");
            Console.Write("\n\tKarosserieform           : ");
            int wahl = AuswahlsMenue.Menue("Wählen sie eine Karosserie-form:", "Coupe", "Mittelklasse", "Limousine", "SUV");
            if (wahl != -1)
            {
                if (wahl == 0) { karosserieform = Convert.ToChar("C"); }
                else if (wahl == 1) { karosserieform = Convert.ToChar("M"); }
                else if (wahl == 2) { karosserieform = Convert.ToChar("i"); }
                else { karosserieform = Convert.ToChar("S"); }
                Console.Write("\n\tLeistung           : ");
                leistung = Convert.ToInt32(m.validitationVonDoubles(20, 600));
                Console.Write("\n\tKm Stand           : ");
                kmStand = m.validitationVonDoubles(0, 999999);
                Console.Write("\n\tGrundpreis          : ");
                grundpreis = m.validitationVonDoubles(0, 999999);
                Console.Write("\n\tPreis pro KM          : ");
                preisProKm = m.validitationVonDoubles(0, 10);
                Console.Write("\n\tMarke und Modell          : ");
                markeModell = Console.ReadLine();

                using (StreamWriter sw = File.AppendText(@"C:\_IAH11\MustafaSataric\Fahrzeuge.txt"))
                {
                    sw.WriteLine(karosserieform + ";" + markeModell + ";" + kmStand + ";" + grundpreis + ";" + preisProKm + ";" + leistung);
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
                auswahl = AuswahlsMenue.Menue("Bitte Wählen Sie ihren gewünschten Aufbau:", "(C)oupe", "(M)itelklasse", "L(i)mousine", "(S)uv");

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
                    case 3:

                        markeModell = "BMW E70";
                        kmStand = 1500;
                        Grundpreis = 89;
                        preisProKm = 0.20;
                        break;
                }
                auswahl = AuswahlsMenue.Menue("Bitte Wählen Sie ihren gewünschten Aufbau:", "(C)oupe", "(M)itelklasse", "L(i)mousine", "(S)uv");
            } while (auswahl != -1);
        }

    
        public override void KonfigurationsDaten()
        {
            Console.WriteLine("PKW:");
            Console.WriteLine("\n\tIhre Marke lautet: {0}", markeModell);
            Console.WriteLine("\tIhr Karosserieform lautet : {0}", karosserieform);
            Console.WriteLine("\tIhr KM Stand lautet    : {0}", kmStand);
            Console.WriteLine("\tIhr Leistung lautet    : {0}", leistung);
            Console.WriteLine("\tDer Grundpreis beträgt: {0}", grundpreis);
            Console.WriteLine("\tDer Preis pro Km beträgt: {0}", preisProKm);
        }

    }
}