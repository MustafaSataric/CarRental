using Buchung_2.Zusammenhänge;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buchung_2
{
    // Die Basisklasse Konto soll die gemeinsamen Attribute bereithalten, so dass die Kindklassen darüber verfügen
    abstract class Fahrzeug // abstract bedeutet: diese Klasse kann nicht instanziiert werden! Wir können nur von den 
                            // Kindklassen Objekte/Instanzen erzeugen!
    {
        protected string markeModell, kennzeichen ,  fahrzeugTyp; // die gemeinsamen Attribute
        protected double kmStand, grundpreis, preisProKm;
        protected int leistung;

        public Methoden m = new Methoden();
        // protected-Attribute sind die Attribute der Basisklasse
        // nur die Kindklassen können über diese Attribute verfügen!

        // es gibt in der abstrakten Klassen keinen frei programmierbaren Konstruktor -> weil ja von ihr kein Objekt erzeugt werden kann!

        public string MarkeModell { get => markeModell; set => markeModell = value; }
        public string Kennzeichen { get => kennzeichen; set => kennzeichen = value; }
        public int Leistung { get => leistung; set => leistung = value; }
        public string FahrzeugTyp { get => fahrzeugTyp; set => fahrzeugTyp = value; }
        public double Grundpreis { get => grundpreis; set => grundpreis = value; }
        public double PreisProKm { get => preisProKm; set => preisProKm = value; }
        public double KmStand { get => kmStand; set => kmStand = value; } // getter und setter in der Kurzform!

        public abstract void FahrzeugEinrichten(); // abstract: muss überschrieben werden! Die Methoden können hier nicht
                                                   // mit Leben erfüllt werden, sondern erst in den Kindklassen!
                                                   // Die Entsprechung in den Kindklassen: override!

        //        public abstract void KonfigurationsDaten(string ladeform);
        public abstract void KategorieWaehlen();
        public abstract void KonfigurationsDaten();


        public string KurzeKonfi()
        {
            return markeModell;
        }

    }
}
