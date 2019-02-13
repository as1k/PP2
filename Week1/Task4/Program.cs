using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            /* // First method.
            int n = Convert.ToInt32(Console.ReadLine());
            var symbol = "[*]";
            var elka = "";

            for(int i = 0; i < n; i++)
            {
                elka = elka + symbol;
                Console.WriteLine(elka);
            }
            */

            // Second method.
            int n = Convert.ToInt32(Console.ReadLine()); // Entering a length of nxn 2D array.

            string[,] arr = new string[n, n]; // Creating a new 2D array which has n columns and n rows.

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i >= j) { Console.Write("[*]"); }; // I've created a cycle "for" for my 2D array.
                    // And wrote a function "if" to output string "[*]" that gets one more in each line.
                }
                Console.WriteLine(); // Here the output starts on a new line each time the value of i changes.
            }
        }
    }
}
