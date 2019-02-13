using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Student // Implementing a class Student
    {
        public string name; // Student's name
        public string id; // Student's ID
        public int year; // Student's year of study

        public Student(string name, string id) // Providing a constructor with parameters
        {
            this.name = name;
            this.id = id;
            this.year = 0;
        }

        public string Accessname() // Creating a method to access name.
        {
            return name;
        }

        public string Accessid() // Creating a method to access student ID.
        {
            return id;

        }
        public void Print()
        {
            year++; // Incrementing a year of study.
            Console.WriteLine(this.Accessname() + " " + this.Accessid() + " " + this.year); // Printing a Student's information.
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine(); // Entering a name of student.
            string i = Console.ReadLine(); // Entering a student ID.

            Student a = new Student(n, i); // Creating a new student who's name is written in string n, and i is student's ID.
            Student b = new Student("Assylanbek Nurmukhambet", "18BD110824"); // Creating another student who's name and ID is already written.
            a.Print(); // Calling a function that prints Student "a"'s information.
            a.Print(); // Calling Print function for Student "a" second time to check does the year of study increment.
            b.Print(); // Calling function to print Student "b"'s information.
            b.Print(); // Calling a function print for Student "b" second time.
        }
    }
}
