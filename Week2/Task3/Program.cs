using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    class Program
    {
        static void Print(DirectoryInfo folder, string s) // Creating a new recursive function.
        {
            Console.WriteLine(s + folder.Name); // Outputting main folder first.
            s = s + "   "; // Each time function calls himself again output will start with some spaces.
            FileSystemInfo[] x = folder.GetFileSystemInfos(); // Getting infos from folder.
            for(int i = 0; i < x.Length; i++)
            {
                if (x[i].GetType() == typeof(DirectoryInfo)) Print(x[i] as DirectoryInfo, s); //Checking type of object: if it's a folder the function will be called again.
                else Console.WriteLine(s + x[i].Name); // Else it shows files' names.
            }
        }

        static void Main()
        {
            DirectoryInfo folder = new DirectoryInfo(@"C:\Users\User\source\repos\Week2"); // Getting info about folder.
            Print(folder, ""); // Calling print function and printing all objects inside the folder.
        }
    }
}