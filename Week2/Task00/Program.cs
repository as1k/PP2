using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task00
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "5 3 6 2 8 11 27"; 
            File.WriteAllText(@"C:\Users\User\source\repos\Week2\TestFolder\input2.txt", text); // Creating a file with text for Task2.
        }
    }
}
