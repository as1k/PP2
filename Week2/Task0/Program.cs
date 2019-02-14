using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task0
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "ababa"; // Creating a file with string to check is text polyndrome or not in Task1.
            File.WriteAllText(@"C:\Users\User\source\repos\Week2\TestFolder\input1.txt", text);
        }
    }
}
