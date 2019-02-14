using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        static bool Poli(string text) // New function to check polindrome.
        {
            for (int i = 0; i < text.Length / 2; i++)
            {
                if (text[i] != text[text.Length - 1 - i]) // Checking is the symmetric located symbol similar.
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"C:\Users\User\source\repos\Week2\TestFolder\input1.txt"); // Reading a text from txt file.
            if(!Poli(text)) Console.WriteLine("No"); // Calling a function.
            else Console.WriteLine("Yes"); 
        }
    }
}
