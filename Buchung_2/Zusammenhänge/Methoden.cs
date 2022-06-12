using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace Buchung_2.Zusammenhänge
{

    public class Methoden
    {


        const uint MB_OK = 0x00000000;
        const uint MB_ICONWARNING = 0x00000030;

        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        static extern int MessageBoxW(IntPtr hWnd, string lpText, string lpCaption, uint uType);

        public double validitationVonDoubles(double min, double max)
        {
            ConsoleKeyInfo tastenDruck;
            StringBuilder meineEingabe = new StringBuilder { };

            double zahl = 0;
            do
            {
                tastenDruck = Console.ReadKey(true);
                switch (tastenDruck.Key)
                {
                    default:
                        if (char.IsDigit(tastenDruck.KeyChar))
                        {
                            meineEingabe.Append(tastenDruck.KeyChar);
                            Console.Write(tastenDruck.KeyChar);
                        }
                        break;
                }

            } while (tastenDruck.Key != ConsoleKey.Enter);

            if (meineEingabe.Length == 0)
            {
                return validitationVonDoubles(max, min);
            }
            meineEingabe.Insert(meineEingabe.Length, "\n");

            zahl = Convert.ToDouble(meineEingabe.ToString());

            if (zahl > max | zahl < min)
            {
                MessageBoxW(IntPtr.Zero, "Bitte Validen Wert eingeben:", "Warnung", MB_OK | MB_ICONWARNING);

                return validitationVonDoubles(max, min);
            }

            return zahl;
        }

    }
}
