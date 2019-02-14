using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    class Program
    {
        static bool Prime(int x) // A new Prime function
        {
            int cnt = 0; 
            for(int i = 1; i <= x; i++) // If number = 1, it's not prime.
            {
                if(x % i == 0) { cnt++; } // If number divisible to numbers from 1 to x, it is counting.
            }
            if (cnt == 2) { return true; } // If the number was divisible only twice it's a prime.
            return false; // Else not prime.
        }
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"C:\Users\User\source\repos\Week2\TestFolder\input2.txt"); // Reading string from File.
            string[] s = text.Split(); // Getting rid from spaces.
            int[] a = new int[s.Length]; // Creating new array of integers.
            
            for(int i = 0; i < s.Length; i++)
            {
                a[i] = int.Parse(s[i]); // Converting string symbols into integers.
            }

            List<int> l = new List<int>(); // Creating new List.

            for(int i = 0; i < a.Length; i++)
            {
                if (Prime(a[i])) // Calling function Prime.
                {
                    l.Add(a[i]); // If it's prime number, adding into list l.
                }
            }

            StreamWriter sw = new StreamWriter(@"C:\Users\User\source\repos\Week2\TestFolder\output.txt"); // Creating a txt file.
            for(int i = 0; i < l.Count; i++)
            {
                sw.Write(l[i] + " "); // Writing into created txt file.
            }
            sw.Close(); // Closing StreamWriter.

            /*
            for (int i = 0; i < l.Count; i++)
            {
                Console.Write(l[i] + " ");
            }*/
        }
    }
}
