using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static bool Prime(int a) // Making a function that allows to find Prime numbers.
        {
            if (a == 1)
            {
                return false; // As number "1" is not a prime number, we return false if it's equal to 1.
            }
            int cnt = 0; // Creating a variable using what we will count prime numbers.
            for (int i = 1; i <= a; i++)
            {
                if (a % i == 0) cnt++; // We wil divide a number starting from 1 till this number to check how many times it will be divided.
            }
            if (cnt == 2) // We know that a Prime number is divisible by 1 and by ownself only, so we check is the number was divided only twice.
            {
                return true;
            }
            return false; // Otherwise, if the number was divided more than twice, we return false.
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine()); // Entering a length of an array

            string s = Console.ReadLine(); // Entering an array which is string yet.
            string[] ss = s.Split(); // Getting rid from a spaces between elements of array.

            int[] arr = new int[n]; // Creating another array that includes integers.

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(ss[i]); // Using cycle "for" to convert a string elements into integers.
            }

            int sum = 0; // Creating a new variable to count prime numbers.
            for (int i = 0; i < n; i++)
            {
                if (Prime(arr[i])) // Using created function Prime we check does the function return true.
                {
                    sum++; // Every time it returns true, we count.
                }
            }
            Console.WriteLine(sum);

            for (int i = 0; i < n; i++)
            {
                if (Prime(arr[i])) // Using function again we list all the prime numbers in one string.
                {
                    Console.Write(arr[i] + " "); // While listing prime numbers, we paste a space between elements.
                }
            }
        }
    }
}
