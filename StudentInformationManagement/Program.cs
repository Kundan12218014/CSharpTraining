using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CarInformationSystem;
using PersonInformationSystem;
using StringConverter;
namespace StudentInformationManagement

{
  class StudentMain()
  {

    public static void Main()
    {
      // Student student = new Student();
      // Console.WriteLine($"Default Details : \n Name : {student.Name}\nAge : {student.Age},\nGrade : {student.Grade}");
      // Console.WriteLine("Enter Name: ");
      // string Name = Convert.ToString(Console.ReadLine());
      // Console.WriteLine("Enter Age: ");
      // int Age = Convert.ToInt32(Console.ReadLine());
      // Console.WriteLine("Enter Grade: ");
      // string Grade = Convert.ToString(Console.ReadLine());

      // Student student2 = new Student(Name, Age, Grade);
      // Console.WriteLine($"New Details : \nName : {student2.Name}\nAge : {student2.Age},\nGrade : {student2.Grade}");


      //2nd Question

      // Console.WriteLine("Enter the Make Details :");
      // string Make = Console.ReadLine();
      // Console.WriteLine("Enter the Name Details :");
      // string Name = Console.ReadLine();
      // Console.WriteLine("Enter the Year Details :");
      // int Year = Convert.ToInt32(Console.ReadLine());

      // Car car = new Car(Make, Name, Year);
      // car.DisplayDetails();
      // car.DisplayAge();

      //3rd Question

      // Console.WriteLine("Enter the Name Details :");
      // string Name = Console.ReadLine();
      // Console.WriteLine("Enter the Age Details :");
      // int Age = Convert.ToInt32(Console.ReadLine());
      // Console.WriteLine("Enter the Address Details :");
      // string Address = Console.ReadLine();
      // Person person=new Person(Name,Age,Address);
      // person.DisplayDetails();

      // 4th Question
      ConverterString converterString = new ConverterString();
      while (true)
      {
        Console.WriteLine("Enter the value : \n1.ToUpperCase\n2.ToLowerCase\n3.ToTitleCase");
        int.TryParse(Console.ReadLine(), out int value1);
        if (value1 < 1 || value1 > 3)
        {
          Console.WriteLine("Thank You");
          break;
        } 
        Console.WriteLine("Enter the String");
        string userInput = Console.ReadLine();

        switch (value1)
        {
          case 1: Console.WriteLine($"To UpperCase : {converterString.ToUpperCase(userInput)}"); break;
          case 2:
            Console.WriteLine($"To LowerCase : {converterString.ToLowerCase(userInput)}");
            break;
          case 3:
            Console.WriteLine($"To TitleCase : {converterString.ToTitleCase(userInput, 1)}");
            break;
          default:
            Console.WriteLine("Invalid Operation");
            break;
        }

      }

    }
  }
}