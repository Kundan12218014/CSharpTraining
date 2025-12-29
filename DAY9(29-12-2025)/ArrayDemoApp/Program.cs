using System;
namespace ArrayDemoNamespace
{
  public class ArrayDemo
  {
    public static void Main()
    {
      // int []arr;
      // arr=new int[6];
      // arr[0]=10;
      // arr[1]=20;
      // arr[2]=30;
      // arr[3]=40;
      // arr[4]=50;
      // arr[5]=60;

      // int length=arr.Length;
      // Console.WriteLine("Enter teh value of the n");
      // int length=Convert.ToInt32(Console.ReadLine());
      // int []arr;
      // arr = new int[length];
      // for(int i = 0; i < length; i++)
      // {
      //   Console.WriteLine($"Enter the value at index : {i} : ");
      //   int.TryParse(Console.ReadLine(),out int value);
      //   arr[i] =value;
      // }
      // Console.WriteLine($"Length of an Array is {length}");
      // for(int i = 0; i < arr.Length; i++)
      // {
      //   Console.WriteLine($"Element at {i} index is {arr[i]}");

      // }


      // char []ch =new char[]{'h','e','l','l','o','\0'};
      // char[] ch1=new char[10];

      // Console.WriteLine("Enter the charactedr");
      // for(int i = 0; i < ch1.Length; i++)
      // {
      //   char.TryParse(Console.ReadLine(),out char value);
      //   ch1[i]=value;
      // }
      // Console.WriteLine("The Character Element is ");
      // for(int i = 0; i < ch1.Length; i++)
      // {
      //   Console.WriteLine($"{ch1[i]}");
      // }

      // string[]empName =new string[6];
      // Console.WriteLine("Enter the Employee Name");
      // for(int i = 0; i < empName.Length; i++)
      // {
      //   empName[i]=Console.ReadLine();
      // }
      // Console.WriteLine("Employee Names are");
      // for(int i = 0; i < empName.Length; i++)
      // {
      //   Console.WriteLine($"Emplyee name at index {i} is: {empName[i]}");
      // }

      // int []arr={10,20,30,40,50,60};
      // program.PassArrayDemo(arr);


      ArrayDemo program = new ArrayDemo();
      // Console.WriteLine("Enter the size of the array : ");
      // int n=Convert.ToInt32(Console.ReadLine());
      // int []arr1 =program.ReturnArray(n);
      // program.PrintArrayElement(arr1);

      // int [,] arr=new int[3,3];
      // arr[0,0]=10;
      // arr[0,1]=20;
      // arr[0,2]=30;
      // arr[1,0]=40;
      // arr[1,1]=50;
      // arr[1,2]=60;
      // arr[2,0]=70;
      // arr[2,1]=80;
      // arr[2,2]=90;


      // int[,]arr=program.GetTwoDimArray();
      // Console.WriteLine($"Element is {arr.GetLength(0)} x {arr.GetLength(1)} ");
      // program.printTwoDimArray(arr);


      //learning Inbuilt function in Array

      // int [] arr=program.ReturnArray();

      // int[] arr = { 10, 20, 30, 40, 50, 60, 70 };
      // Console.WriteLine($"Array value at index {Array.IndexOf(arr, 60)}");
      // Console.WriteLine($"Array value at index 3 :  {arr.GetValue(3)}");
      // Console.WriteLine($"Array is fixedSize: {arr.IsFixedSize}");
      // Console.WriteLine($"Array is ReadOnly:  {arr.IsReadOnly}");
      // Console.WriteLine($"Array is Rank : {arr.Rank}");


      // Console.WriteLine($"Array Before Sorting : ");
      // program.PrintArrayElement(arr);
      // Array.Sort(arr);
      // Console.WriteLine($"Array After Sorting : ");
      // program.PrintArrayElement(arr);
      // Array.Reverse(arr);
      // Console.WriteLine($"Array After Reversing : ");
      // program.PrintArrayElement(arr);

      // ArrayDemo prog =new ArrayDemo();
      // Employee employee=new Employee()
      // {
      //   Id=100,
      //   Name="Gaurav Kumar"
      // };
      // prog.PassObject(employee);
      // Employee employee2=prog.ReturnObject();
      // Console.WriteLine(employee2);

      Employee emp1 = new Employee() { Id = 10, Name = "Kundan Kumar" };
      Employee emp2 = new Employee() { Id = 11, Name = "Rohit Kumar" };
      Employee emp3 = new Employee() { Id = 15, Name = "Saurav Kumar" };
      Employee emp4 = new Employee() { Id = 13, Name = "Kundan Kumar" };
      Employee emp5 = new Employee() { Id = 14, Name = "Sonu Kumar" };

      Employee [] employeeList=new Employee[]{emp1,emp2,emp3,emp4,emp5};
      // Console.WriteLine("Before Sorting");
      // foreach(Employee e in employeeList)
      // {
      //   Console.WriteLine(e);
      // }
      // Console.WriteLine("After Sorting");
      Array.Sort(employeeList);
      Array.Reverse(employeeList);
      // foreach (Employee e in employeeList)
      // {
      //   Console.WriteLine(e);
      // }

      program.passObjectArray(employeeList);








    }
    public void passObjectArray(Employee[] employees)
    {
      foreach (Employee e in employees)
      {
        Console.WriteLine(e);
      }
    }
    public Employee ReturnObject()
    {
      Employee employee = new Employee
      {
        Id = 10000,
        Name = "Rajesh Kumar"
      };
      return employee;
    }
    public void PassObject(Employee employee)
    {
      Console.WriteLine(employee);
    }
    public int[] ReturnArray()
    {
      Console.WriteLine("Enter the value of array size");
      int n = Convert.ToInt32(Console.ReadLine());
      int[] arr = new int[n];
      for (int i = 0; i < n; i++)
      {
        arr[i] = Convert.ToInt32(Console.ReadLine());
      }
      return arr;
    }
    public int[,] GetTwoDimArray()
    {
      Console.WriteLine("Enter the value of n");
      int n = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("Enter the value of m");
      int m = Convert.ToInt32(Console.ReadLine());
      int[,] arr = new int[n, m];
      // int[][] jaggedArray = new int[3][];

      for (int i = 0; i < n; i++)
      {
        for (int j = 0; j < m; j++)
        {
          Console.WriteLine($"Enter element {i} of {j} : ");
          arr[i, j] = Convert.ToInt32(Console.ReadLine());
        }
      }
      return arr;

    }
    public void printTwoDimArray(int[,] arr)
    {
      for (int i = 0; i < arr.GetLength(0); i++)
      {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
          Console.Write(arr[i, j] + " ");
        }
        Console.WriteLine();
      }
    }
    // public int[] ReturnArray(int length)
    // {
    //   int [] arr=new int[length];
    //   Console.WriteLine($"Enter {length} Numbers of elements");
    //   for(int i = 0; i < length; i++)
    //   {
    //     int.TryParse(Console.ReadLine(),out int value);
    //     arr[i] = value;
    //   }
    //   return arr;
    // }

    public void PrintArrayElement(int[] arr)
    {
      for (int i = 0; i < arr.Length; i++)
      {
        Console.Write(arr[i] + " ");
      }
      Console.WriteLine();
    }
    public void PassArrayDemo(int[] arr)
    {
      int sum = 0;
      for (int i = 0; i < arr.Length; i++)
      {
        sum += arr[i];
      }
      Console.WriteLine("Sum of all Array is {0} is : ", sum);

    }
  }
}