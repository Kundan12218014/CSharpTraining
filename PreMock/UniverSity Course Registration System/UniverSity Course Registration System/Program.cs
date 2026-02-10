using System;
using System.Collections.Generic;
using System.Linq;

namespace University_Course_Registration_System
{
     // =========================
    // Program (Menu-Driven)
    // =========================
    class Program
    {
        static void Main()
        {
            UniversitySystem system = new UniversitySystem();
            bool exit = false;

            Console.WriteLine("Welcome to University Course Registration System");

            while (!exit)
            {
                Console.WriteLine("\n1. Add Course");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Register Student for Course");
                Console.WriteLine("4. Drop Student from Course");
                Console.WriteLine("5. Display All Courses");
                Console.WriteLine("6. Display Student Schedule");
                Console.WriteLine("7. Display System Summary");
                Console.WriteLine("8. Exit");

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                try
                {
                    // TODO:
                    // Implement menu handling logic using switch-case
                    // Prompt user inputs
                    // Call appropriate UniversitySystem methods
                    switch (choice)
                    {
                        case "1": 
                            Console.Write("Course Code: ");
                            string code = Console.ReadLine();
                            Console.Write("Course Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Credits: ");
                            int credits = int.Parse(Console.ReadLine());
                            Console.Write("Max Capacity: ");
                            int maxCapacity = int.Parse(Console.ReadLine());
                            Console.Write("Prerequisites (comma-separated course codes): ");
                            List<string> prerequisites = Console.ReadLine().Split(',').Select(p => p.Trim()).ToList();
                            system.AddCourse(code, name, credits, maxCapacity, prerequisites);
                            break;
                        case "2":
                            Console.Write("ID: ");
                            string id = Console.ReadLine();
                            Console.Write("Name: ");
                            string nam = Console.ReadLine();
                            Console.Write("Major: ");
                            string major = Console.ReadLine();
                            system.AddStudent(id, nam, major);
                            break;
                        case "3":
                            Console.Write("Student ID: ");
                            string studentId = Console.ReadLine();
                            Console.Write("Course Code: ");
                            string courseCode = Console.ReadLine();
                            system.RegisterStudentForCourse(studentId, courseCode); 
                            break;
                        case "4":
                            Console.Write("Student ID: ");
                            string studentIdDrop = Console.ReadLine();
                            Console.Write("Course Code: ");
                            string courseCodeDrop = Console.ReadLine();
                            system.DropStudentFromCourse(studentIdDrop, courseCodeDrop); 
                            break;
                        case "5":
                            system.DisplayAllCourses();
                            break;
                        case "6":
                            Console.Write("Student ID: ");
                            string studentIdSchedule = Console.ReadLine();
                            system.DisplayStudentSchedule(studentIdSchedule);
                            break;
                        case "7":
                            system.DisplaySystemSummary();
                            break;
                        case "8":
                            exit = true;
                            Console.WriteLine("Exiting... Goodbye!");
                            break;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}

