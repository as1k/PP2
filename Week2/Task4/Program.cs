using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    class Program
    {
        public static void Main(String[] args)
        {
            string fileName = "test.txt"; // New file's name.
            string path = @"C:\Users\User\source\repos\Week2\TestFolder\text\" + fileName; // New file's path.
            string path1 = @"C:\Users\User\source\repos\Week2\TestFolder\" + fileName; // Second new path.
            StreamWriter sw = new StreamWriter(path); // Creating a file with directed path.
            sw.Close();
            File.Copy(path, path1); // Copying a file to another path.
            File.Delete(path); // Deleting first file.
        }
    }
}