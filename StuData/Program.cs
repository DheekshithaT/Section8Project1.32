using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StuData
{
    class StudentData
    {
        static void Main()
        {
            string studentDataFilePath = "C:\\Users\\91807\\Desktop\\December\\StuData\\StudentData.txt";

            List<Student> students = ReadData(studentDataFilePath);

            students = students.OrderBy(s => s.Name).ToList();

            DisplayData(students);

            Console.Write("Enter the name to search: ");
            string searchName = Console.ReadLine();
            SearchAndDisplayStudent(students, searchName);
        }

        static List<Student> ReadData(string studentDataFilePath)
        {
            List<Student> students = new List<Student>();

            try
            {
                string[] studentDataLines = File.ReadAllLines(studentDataFilePath);
                foreach (string line in studentDataLines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        students.Add(new Student { Name = parts[0].Trim(), Class = parts[1].Trim() });
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found. Please check the file path.");
            }

            return students;
        }

        static void DisplayData(List<Student> students)
        {
            Console.WriteLine("===================================");
            Console.WriteLine("Sorted Student Data:");
            Console.WriteLine("===================================");
            foreach (var student in students)
            {
                Console.WriteLine($"Student Name: {student.Name}, Class: {student.Class}");
            }
            Console.WriteLine();
        }

        static void SearchAndDisplayStudent(List<Student> students, string searchName)
        {
            var matchingStudents = students.Where(s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

            if (matchingStudents.Any())
            {
                Console.WriteLine($"Student with name '{searchName}' FOUND:");
                foreach (var student in matchingStudents)
                {
                    Console.WriteLine($"Name: {student.Name}, Class: {student.Class}");
                }
            }
            else
            {
                Console.WriteLine($" NAME NOT FOUND '{searchName}':");
            }
        }
    }

    class Student
    {
        public string Name { get; set; }
        public string Class { get; set; }
    }
}
