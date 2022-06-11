using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchung_2
{
    public class AuswahlsMenue
    {

        

 

        public static int Menue(string title, params string[] options)
        {
            Console.SetWindowSize(60, 30);
            Console.SetBufferSize(60, 30);
            int startY = 8, currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            do
            {
                Console.Clear();
                color(1);
                Console.SetCursorPosition(Convert.ToInt32(Console.WindowWidth * 0.2), 3);
                Console.WriteLine(title);
                Console.SetCursorPosition(Convert.ToInt32(Console.WindowWidth * 0.2), 4);
                Console.WriteLine(string.Empty.PadLeft(title.Length, '='));
                Console.SetCursorPosition(0, Console.WindowHeight - 2);
                Console.Write(string.Empty.PadLeft(Console.WindowWidth - Console.CursorLeft, '─'));
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                string textToEnter = "Enter - Auswählen | ↑ - Hoch | ↓ - Runter | ESC - Beenden";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));

                Console.ResetColor();


                for (int i = 0, z = 0; i < options.Length; i++, z = z + 2)
                {
                        Console.SetCursorPosition(((Console.WindowWidth / 2) - ("X. Option: " + options[0]).Length / 2), startY + z);
                        if (i == currentSelection)
                        {
                            color(0);
                        }

                   
                            string currentOption = (i + 1) + ". Option: " + options[i] + " ";
                            Console.WriteLine(currentOption);

                            Console.ResetColor();
                            color(1);
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection == 0)
                            {
                                currentSelection = options.Length - 1;
                            }
                            else
                            {
                                currentSelection--;
                            }
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {

                            if (currentSelection == options.Length - 1)
                            {
                                currentSelection = 0;
                            }
                            else
                            {
                                currentSelection++;
                            }
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            return -1;
                        }
                }
            } while (key != ConsoleKey.Enter );

            Console.CursorVisible = true;

            return currentSelection;
        }

        static int color(int choice)
        {
            if (choice == 0)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            else if (choice == 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.DarkGray;
            }
            return 0;
        }



    }
}
