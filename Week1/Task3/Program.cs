using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            // Entering a length of first array. For example: 3.

            string s = Console.ReadLine();    // Entering an array that is string yet. For example: 1 2 3.
            string[] ss = s.Split();    // Getting rid from spaces between elements. For example: 123.

            int[] arr = new int[n];    // Creating a first array(arr) which length is equal to n.
            int[] arr2 = new int[n * 2];    // Creating second array(arr2), where every element will be repeated. His length is equal to n*2.

            for (int i = 0; i < n; i++)    // Creating a cycle to convert and fill the second array(arr2).
            {
                arr[i] = int.Parse(ss[i]);    // Converting a elements form string into integer using function "Parse" and filling the first array.
                arr2[i * 2] = arr2[i * 2 + 1] = arr[i];    // Filling a second array by getting data from first array and repeating elements.
            }

            for (int i = 0; i < n * 2; i++)    // Creating a new cycle to run through second array(arr2).
            {
                Console.Write(arr2[i] + " ");    // Outputting all elements of second array with spaces between them. For example: 1 1 2 2 3 3.
            }
        }
    }
}
