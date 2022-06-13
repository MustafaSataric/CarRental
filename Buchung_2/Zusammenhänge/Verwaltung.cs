using Buchung_2.Zusammenhänge;
using System;

namespace Buchung_2
{
    public class Verwaltung
    {
        List<Kunde> testKunde = new List<Kunde>();
        List<Fahrzeug> testFahrzeug = new List<Fahrzeug>();
        Methoden m = new Methoden();

        // ´Falls ihre Zielordner abweichen nur hier ändern
        public const string benutzerDb = "C:\\_UNDERFOLDER\\SemirSljiivic\\Benutzer.txt";
        public const string fahrzeugDb = "C:\\_UNDERFOLDER\\SemirSljiivic\\Fahrzeuge.txt";
        public const string buchungsDb = "C:\\_UNDERFOLDER\\SemirSljiivic\\Buchungen.txt";
        public void KundenVerwalten()
        {
            Console.Title = "Rent-a-Car V1.0 © Mustafa Sataric";


            int auswahl = 0;

            do
            {
                PrivatKunde privatKunde = new PrivatKunde();
                FirmenKunde firmenKunde = new FirmenKunde();
                auswahl = AuswahlsMenue.Menue("Kunden Verwaltungs Software", "Kunden Bestand", "Kunden Anlegen");

                switch (auswahl)
                {
                    case 0:
                        Console.Clear();
                        KundenlisteAusgeben();
                        Console.ReadKey();
                        break;
                    case 1:
                        Console.Clear();
                        KundeEingeben();
                        break;
                    case -1:
                        auswahl = -1;
                        break;
                    default:
                        auswahl = AuswahlsMenue.Menue("Kunden Verwaltungs Software", "Kunden Bestand", "Kunden Anlegen");
                        break;
                }
            } while (auswahl != -1);
        }
        public int KundenLesen()
        {
            using (StreamReader sr = new StreamReader(benutzerDb))
            {
                string line;
                int iLfdNr = 0;
                // Read and display lines from the file until the end of
                // the file is reached.
                while (!sr.EndOfStream)
                {

                    string[] zeile = sr.ReadLine().Split(';');
                    if (zeile[0] == "f")
                    {
                        FirmenKunde firmenKunde = new FirmenKunde();
                        firmenKunde.Name = zeile[1];
                        firmenKunde.VorName = zeile[2];
                        firmenKunde.GebDatum = Convert.ToDateTime(zeile[4]);
                        firmenKunde.Firma = zeile[5];
                        firmenKunde.AnzahlBuchungen = Convert.ToInt32(zeile[6]);
                        testKunde.Add(firmenKunde);
                        iLfdNr++;
                    }
                    if (zeile[0] == "p")
                    {
                        PrivatKunde privatKunde = new PrivatKunde();
                        privatKunde.Name = zeile[1];
                        privatKunde.VorName = zeile[2];
                        privatKunde.GebDatum = Convert.ToDateTime(zeile[3]);
                        privatKunde.Fuehrerschein = Convert.ToChar(zeile[4]);
                        privatKunde.AutomobilclubMitglied = Convert.ToChar(zeile[5]);
                        testKunde.Add(privatKunde);
                        iLfdNr++;
                    }
                }
                return iLfdNr;

            }
        }



        public void KundeEingeben()
        {
            int auswahl = 0;

            PrivatKunde pk = new PrivatKunde();
            testKunde.Add(pk);
            do
            {

                int iLfdNr = KundenLesen();
                auswahl = AuswahlsMenue.Menue("Kundendateneingabe", "<P>rivatkunde", "<F>irmenkunde");
                Console.Clear();
                switch (auswahl)
                {
                    case 0:
                        testKunde[iLfdNr] = new PrivatKunde();
                        testKunde[iLfdNr].KundeAufnehmen(); // hier Polymorphie !!
                        break;
                    case 1:
                        testKunde[iLfdNr] = new FirmenKunde();
                        testKunde[iLfdNr].KundeAufnehmen(); // hier auch Polymorphie!!
                        break;
                    case -1:
                        auswahl = -1;
                        break;
                    default:
                        auswahl = AuswahlsMenue.Menue("Kundendateneingabe", "<P>rivatkunde", "<F>irmenkunde");
                        break;
                }
                Console.WriteLine("Benutzer: " + testKunde[iLfdNr].kurzekonfi() + " wurde erfolgreich zur Datenbank hinzugefügt.");
            } while (auswahl != -1);
        }

        public void KundenlisteAusgeben()
        {
            int Anzahl = KundenLesen(), auswahl = 0;
            string[] kunden = new string[Anzahl];
            Console.Clear();
            for (int i = 0; i < Anzahl; i++)
            {
                kunden[i] = testKunde[i].Name + " " + testKunde[i].VorName;
            }
            auswahl = AuswahlsMenue.Menue("Fahrzeugliste", kunden);
            if (auswahl != -1 && testKunde.Count > 0)
            {
                Console.Clear();
                testKunde[auswahl].KundeAusgeben();
                Console.ReadKey();

            }
        }


        //Verwaltung der Fahrzeuge

        public int FahrzeugeLesen()
        {
            using (StreamReader sr = new StreamReader(fahrzeugDb))
            {
                string line;
                int iFahrzeugNr = 0;
                // Read and display lines from the file until the end of
                // the file is reached.
                while (!sr.EndOfStream)
                {

                    string[] zeile = sr.ReadLine().Split(';');
                    if (zeile[0] == "C" || zeile[0] == "M" || zeile[0] == "S" || zeile[0] == "i")
                    {
                        PKW pkw = new PKW();
                        pkw.Karosserieform = Convert.ToChar(zeile[0]);
                        pkw.MarkeModell = zeile[1];
                        pkw.KmStand = Convert.ToDouble(zeile[2]);
                        pkw.Grundpreis = Convert.ToDouble(zeile[3]);
                        pkw.PreisProKm = Convert.ToDouble(zeile[4]);
                        pkw.Leistung = Convert.ToInt32(zeile[5]);
                        testFahrzeug.Add(pkw);
                        iFahrzeugNr++;
                    }
                    else if (zeile[0] == "K" || zeile[0] == "P" || zeile[0] == "l")
                    {
                        LKW lkw = new LKW();
                        lkw.Ladeform = Convert.ToChar(zeile[0]);
                        lkw.MarkeModell = zeile[2];
                        lkw.KmStand = Convert.ToInt32(zeile[3]);
                        lkw.Grundpreis = Convert.ToDouble(zeile[4]);
                        lkw.PreisProKm = Convert.ToDouble(zeile[5]);
                        lkw.Leistung = Convert.ToInt32(zeile[5]);
                        testFahrzeug.Add(lkw);
                        iFahrzeugNr++;
                    }
                }
                return iFahrzeugNr;

            }
        }


        public void FahrzeugeVerwalten()
        {
            Console.Title = "Rent-a-Car V1.0 © Mustafa Sataric";

            Console.Clear();
            int auswahl = 0;
            do
            {
                auswahl = AuswahlsMenue.Menue("Fahrzeug Verwaltungs Software", "Fahrzeug Bestand", "Fahrzeug Ankaufen", "Vermietete Fahrzeuge", "Fahrzeug Abrechnen", "Fahrzeug Vermieten");

                switch (auswahl)
                {
                    case 0: FahrzeugBestand(); break;
                    case 1: FahrzeugAnkaufen(); break;
                    case 2: FahrzeugAbrechnen(false); break;//Das selbe da in beiden fällen jeweils erst einmal die ausgliehenen fahrzeuge angezeigt werden
                    case 3: FahrzeugAbrechnen(true); break;
                    case 4: FahrzeugVerleihen(); break;
                    case -1: break;
                    default:
                        auswahl = AuswahlsMenue.Menue("Fahrzeug Verwaltungs Software", "Fahrzeug Bestand", "Fahrzeug Ankaufen", "Vermietete Fahrzeuge", "Fahrzeug Abrechnen", "Fahrzeug Vermieten");
                        break;
                }


            } while (auswahl != -1);


        }



        public void FahrzeugAnkaufen()
        {
            //Array.Resize(ref meineFahrzeuge, fahrzeugNr + 1);

            //Konsole.ClrLines(5,20)
            Console.SetCursorPosition(0, 4);
            int auswahl = 0, iFahrzeugNr = 0;
            PKW pkwchen = new PKW();
            testFahrzeug.Add(pkwchen);
            do
            {
                iFahrzeugNr = FahrzeugeLesen();
                auswahl = AuswahlsMenue.Menue("Ihre Fahrzeug Klasse:", "PKW", "LKW");
                //           Console.WriteLine(iFahrzeugNr + " " +testFahrzeug.Count()); 
                //           Console.ReadKey();
                switch (auswahl)
                {
                    case 0:
                        testFahrzeug[iFahrzeugNr] = new PKW();
                        testFahrzeug[iFahrzeugNr].FahrzeugEinrichten();

                        break;
                    case 1:
                        testFahrzeug[iFahrzeugNr] = new LKW();
                        testFahrzeug[iFahrzeugNr].FahrzeugEinrichten();
                        break;
                    case -1: break;
                }
            } while (auswahl != -1);




        }
        public void FahrzeugLoeschen()
        {
            int iFahrzeugNr = FahrzeugeLesen(), auswahl = 0, zeile = 0;
            string[] array1 = new string[iFahrzeugNr + 1];
            string line = null;

            for (int i = 0; i < iFahrzeugNr; i++)
            {
                array1[i] = testFahrzeug[i].KurzeKonfi();
            }
            auswahl = AuswahlsMenue.Menue("Welches Fahrzeug möchten sie Löschen?", array1);


            List<string> lines = File.ReadAllLines(fahrzeugDb).ToList();
            if (lines.Count >= iFahrzeugNr + 1)
            {
                lines.RemoveAt(iFahrzeugNr + 1);
                File.WriteAllLines(fahrzeugDb, lines);
            }
            Console.ReadKey();

        }

        public void FahrzeugBestand()
        {
            int iFahrzeugNr = FahrzeugeLesen(), auswahl = 0;
            string[] fahrzeuge = new string[iFahrzeugNr];
            Console.Clear();
            for (int i = 0; i < iFahrzeugNr; i++)
            {
                fahrzeuge[i] = testFahrzeug[i].MarkeModell;
            }
            auswahl = AuswahlsMenue.Menue("Fahrzeugliste", fahrzeuge);
            if (auswahl != -1 && testFahrzeug.Count > 0)
            {
                Console.Clear();
                testFahrzeug[auswahl].KonfigurationsDaten();
                Console.ReadKey();

            }
        }

        public string[] FahrzeugeAusgeben(string x)
        {
            using (StreamReader sr = new StreamReader(fahrzeugDb))
            {
                int i = 0;
                string line;
                string[] iFahrzeuge = null;
                // Read and display lines from the file until the end of
                // the file is reached.
                while (!sr.EndOfStream)
                {

                    string[] zeile = sr.ReadLine().Split(';');
                    if (zeile[0] == "C" && zeile[0] == x || zeile[0] == "M" && zeile[0] == x || zeile[0] == "S" && zeile[0] == x || zeile[0] == "i" && zeile[0] == x)
                    {
                        Array.Resize(ref iFahrzeuge, i + 1);
                        iFahrzeuge[i] = zeile[1];
                        i++;
                    }
                    if (zeile[0] == "K" && zeile[0] == x || zeile[0] == "P" && zeile[0] == x || zeile[0] == "l" && zeile[0] == x)
                    {
                        Array.Resize(ref iFahrzeuge, i + 1);
                        iFahrzeuge[i] = zeile[1];
                        i++;

                    }
                }
                return iFahrzeuge;

            }
        }

        public void FahrzeugVerleihen()
        {
            int fahrzeugArt = AuswahlsMenue.Menue("Bitte Wählen Sie ihren gewünschten Fahrzeug Typen:", "PKW", "Lkw"), auswahl = 0, auswahl0 = 0, Anzahl = KundenLesen(), benutzer = -1;
            string[] ausleihender = new string[Anzahl], fahrzeuge = null;
            bool verliehen = false;
            Console.Clear();
            if (fahrzeugArt != -1)
            {
                for (int z = 0; z < Anzahl; z++) ausleihender[z] = testKunde[z].kurzekonfi();
                benutzer = AuswahlsMenue.Menue("Welchen Benutzer möchten sie ein Fahrzeug Ausleihen?", ausleihender);
            }
            if (fahrzeugArt == 0 && benutzer != -1)
            {
                do
                {
                    Console.Clear();
                    auswahl = AuswahlsMenue.Menue("Bitte Wählen Sie ihren gewünschten Aufbau:", "(C)oupe", "(M)itelklasse", "L(i)mousine", "(S)uv");
                    switch (auswahl)
                    {
                        case 0:
                            fahrzeuge = FahrzeugeAusgeben("C");
                            if (fahrzeuge != null)
                            {
                                auswahl0 = AuswahlsMenue.Menue("Bitte Wählen Sie ihr gewünschtes Fahrzeug:", fahrzeuge);
                                auswahl = -1; verliehen = true;
                            }
                            else
                            {
                                Console.WriteLine("Keine Coupes im Bestand vorhanden");
                                Console.ReadKey();
                            }
                            break;
                        case 1:
                            fahrzeuge = FahrzeugeAusgeben("M");
                            if (fahrzeuge != null)
                            {
                                auswahl0 = AuswahlsMenue.Menue("Bitte Wählen Sie ihr gewünschtes Fahrzeug:", fahrzeuge);
                                auswahl = -1; verliehen = true;
                            }
                            else
                            {
                                Console.WriteLine("Keine Mittelklassen im Bestand vorhanden");
                                Console.ReadKey();
                            }
                            break;
                        case 2:
                            fahrzeuge = FahrzeugeAusgeben("i");
                            if (fahrzeuge != null)
                            {
                                auswahl0 = AuswahlsMenue.Menue("Bitte Wählen Sie ihr gewünschtes Fahrzeug:", fahrzeuge);
                                auswahl = -1; verliehen = true;
                            }
                            else
                            {
                                Console.WriteLine("Keine Limousinen im Bestand vorhanden");
                                Console.ReadKey();
                            }

                            break;
                        case 3:
                            fahrzeuge = FahrzeugeAusgeben("S");
                            if (fahrzeuge != null)
                            {
                                auswahl0 = AuswahlsMenue.Menue("Bitte Wählen Sie ihr gewünschtes Fahrzeug:", fahrzeuge);
                                auswahl = -1; verliehen = true;
                            }
                            else
                            {
                                Console.WriteLine("Keine SUVs im Bestand vorhanden");
                                Console.ReadKey();
                            }

                            break;
                    }
                } while (auswahl != -1);
            }
            else if (fahrzeugArt == 1 && benutzer != -1)
            {
                do
                {
                    Console.Clear();
                    auswahl = AuswahlsMenue.Menue("Bitte Wählen Sie ihren gewünschten Aufbau:", "(K)asten", "(P)ritsche", "P(l)ane");

                    switch (auswahl)
                    {
                        case 0:
                            fahrzeuge = FahrzeugeAusgeben("K");
                            if (fahrzeuge != null)
                            {
                                auswahl0 = AuswahlsMenue.Menue("Bitte Wählen Sie ihr gewünschtes Fahrzeug:", fahrzeuge);
                                auswahl = -1; verliehen = true;
                            }
                            else
                            {
                                Console.WriteLine("Keine Kasten LKWs im Bestand vorhanden");
                                Console.ReadKey();
                            }
                            break;
                        case 1:
                            fahrzeuge = FahrzeugeAusgeben("P");
                            if (fahrzeuge != null)
                            {
                                auswahl0 = AuswahlsMenue.Menue("Bitte Wählen Sie ihr gewünschtes Fahrzeug:", fahrzeuge);
                                auswahl = -1; verliehen = true;
                            }
                            else
                            {
                                Console.WriteLine("Keine Pritschen LKWs im Bestand vorhanden");
                                Console.ReadKey();
                            }
                            break;
                        case 2:
                            fahrzeuge = FahrzeugeAusgeben("l");
                            if (fahrzeuge != null)
                            {
                                auswahl0 = AuswahlsMenue.Menue("Bitte Wählen Sie ihr gewünschtes Fahrzeug:", fahrzeuge);
                                auswahl = -1; verliehen = true;
                            }
                            else
                            {
                                Console.WriteLine("Keine Planen LKWs im Bestand vorhanden");
                                Console.ReadKey();
                            }
                            break;
                    }
                } while (auswahl != -1);

            }
            if (verliehen)
            {

                Console.WriteLine("Das Fahrzeug " + fahrzeuge[auswahl0] + ", wurde an: " + ausleihender[benutzer] + " verliehen.");
                using (StreamWriter sw = File.AppendText(buchungsDb))
                {
                    sw.WriteLine(auswahl0 + ";" + benutzer);
                }
                Console.ReadKey();
            }

        }


        // Fahrzeug Abrechnen


        public void FahrzeugAbrechnen(bool selbe)
        {
            FahrzeugeLesen();
            KundenLesen();
            Console.Clear();
            int leserpos = 0, auswahl = 0;
            double rabattsatzprofahrzeug = 0.05, rabattADACMittglied = 0.95;
            string[] ausleihenderNr = { };
            string[] fahrzeugNr = { };
            string[] zsm = { };
            using (StreamReader sr = new StreamReader(buchungsDb))
            {
                // Read and display lines from the file until the end of
                // the file is reached.
                while (!sr.EndOfStream)
                {

                    Array.Resize(ref fahrzeugNr, fahrzeugNr.Length + 1);
                    Array.Resize(ref ausleihenderNr, ausleihenderNr.Length + 1);
                    Array.Resize(ref zsm, zsm.Length + 1);
                    string[] zeile = sr.ReadLine().Split(';');
                    fahrzeugNr[fahrzeugNr.Length - 1] = zeile[0];
                    ausleihenderNr[ausleihenderNr.Length - 1] = zeile[1];
                }
            }
            for (int i = 0; i < fahrzeugNr.Length; i++)
            {
                zsm[i] = testFahrzeug[Convert.ToInt32(fahrzeugNr[i])].MarkeModell + " -> " + testKunde[Convert.ToInt32(ausleihenderNr[i])].Name;
            }
                auswahl = AuswahlsMenue.Menue("Abrechnungs Software", zsm);
                if (auswahl != -1 && selbe && fahrzeugNr.Length > 0)
                {
                    double derzeiterKmStand = 0, gefahreneKm, rabatt = testKunde[Convert.ToInt32(ausleihenderNr[auswahl])].rabatt(); ;
                    Console.Clear();
                    Console.WriteLine("Geben sie denn derzeitigen KM stand des Fahrzeuges an: " + testFahrzeug[Convert.ToInt32(fahrzeugNr[auswahl])].KmStand);
                    derzeiterKmStand = m.validitationVonDoubles(testFahrzeug[Convert.ToInt32(fahrzeugNr[auswahl])].KmStand, 999999);
                    gefahreneKm = derzeiterKmStand - testFahrzeug[Convert.ToInt32(fahrzeugNr[auswahl])].KmStand;
                    Console.WriteLine("\nIhr Rabattsatz: " + ((1 - rabatt) * 100) + " %");
                    Console.WriteLine("\nKosten:" + (gefahreneKm * testFahrzeug[Convert.ToInt32(fahrzeugNr[auswahl])].PreisProKm + testFahrzeug[Convert.ToInt32(fahrzeugNr[auswahl])].Grundpreis) + "€");
                    Console.WriteLine("\nKosten mit rabatt:" + (gefahreneKm * testFahrzeug[Convert.ToInt32(fahrzeugNr[auswahl])].PreisProKm + testFahrzeug[Convert.ToInt32(fahrzeugNr[auswahl])].Grundpreis) * rabatt + "€");
                    Console.WriteLine("Preis für gefahrene Strecke: " + gefahreneKm * testFahrzeug[Convert.ToInt32(fahrzeugNr[auswahl])].PreisProKm + "€ (Pro Km: " + testFahrzeug[Convert.ToInt32(fahrzeugNr[auswahl])].PreisProKm + "€ )");
                    Console.WriteLine("Preis für gefahrene Strecke mit Rabatt: " + gefahreneKm * testFahrzeug[Convert.ToInt32(fahrzeugNr[auswahl])].PreisProKm * rabatt + "€ (Pro Km: " + testFahrzeug[Convert.ToInt32(fahrzeugNr[auswahl])].PreisProKm * rabatt + "€ )");
                    Console.WriteLine("Grundpreis: " + testFahrzeug[Convert.ToInt32(fahrzeugNr[auswahl])].Grundpreis + "€");
                    Console.WriteLine("Grundpreis mit Rabatt: " + testFahrzeug[Convert.ToInt32(fahrzeugNr[auswahl])].Grundpreis * rabatt + "€");
                    testFahrzeug[Convert.ToInt32(fahrzeugNr[auswahl])].KmStand = derzeiterKmStand;
                    Console.WriteLine("Fahrzeug: " + testFahrzeug[Convert.ToInt32(fahrzeugNr[auswahl])].MarkeModell + " steht nun, \nmit " + testFahrzeug[Convert.ToInt32(fahrzeugNr[auswahl])].KmStand + " Km wieder zur verfügung, vorher:" + (testFahrzeug[Convert.ToInt32(fahrzeugNr[auswahl])].KmStand - gefahreneKm) + "Km.");
                    Console.ReadKey();
                }


            }
        }
    }
























/*
 public int[] FahrzeugeAusgeben(string x)
        {
            using (StreamReader sr = new StreamReader(@"C:\_IAH11\MustafaSataric\Fahrzeuge.txt"))
            {
                string line;
                int iFahrzeugNr = 0;
                // Read and display lines from the file until the end of
                // the file is reached.
                while (!sr.EndOfStream)
                {

                    string[] zeile = sr.ReadLine().Split(';');
                    if (zeile[0] == "C" && zeile[0] == x || zeile[0] == "M" && zeile[0] == x || zeile[0] == "S" && zeile[0] == x || zeile[0] == "i" && zeile[0] == x)
                    {
                        Console.WriteLine("Marke und Modell: " + zeile[1]);
                        Console.WriteLine("Km Stand" + zeile[2]);
                        Console.WriteLine("Grundpreis: " + zeile[3]);
                        Console.WriteLine("Preis pro Km" + zeile[4]);
                        Console.WriteLine("Leistung: "+zeile[5]);
                        iFahrzeugNr++;
                    }
                    if (zeile[0] == "K" && zeile[0] == x || zeile[0] == "P" && zeile[0] == x || zeile[0] == "l" && zeile[0] == x)
                    {
                        LKW lkw = new LKW();
                        Console.WriteLine( "Marke und Modell: " + zeile[2]);
                        Console.WriteLine( "Km stand" + zeile[3]);
                        Console.WriteLine("Grundpreis" + zeile[4]);
                        Console.WriteLine( "Preis pro Km" + zeile[5]);
                        Console.WriteLine("Leistung : " + zeile[5]);
                        iFahrzeugNr++;
                    }
                }
                return iFahrzeugNr;

            }
        }
*/
