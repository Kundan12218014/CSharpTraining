using System;
using Loop;
using EvenOdd;
using Greatest;
using Sign;
using Salary;
using Generator;
using Multiple;
using Patterns;

class Program
{
  static int num1, num2, result;
  public static void Main(string[] args)
  {
    //   Console.WriteLine("Enter the first number");
    //   num1= Convert.ToInt32(Console.ReadLine());
    //   Console.WriteLine("Enter the second number");
    //   num2= Convert.ToInt32(Console.ReadLine());

    //   Console.WriteLine("Select option from following list: ");
    //   Console.WriteLine("1: for Addition");
    //   Console.WriteLine("2: for Substraction");
    //   Console.WriteLine("3: for Multiplication");
    //   Console.WriteLine("4: for Division");
    //   Console.WriteLine("5: for Remainder");
    //   Console.WriteLine("6: for Exit");

    //   int choice=Convert.ToInt32(Console.ReadLine());

    // Program program=new Program();

    // switch (choice)
    // {
    //   case 1 :Console.WriteLine(program.Add(num1,num2));
    //     break;
    //   case 2 :program.Subtract(num1,num2);
    //     break;
    //   case 3 :program.Multiply(num1,num2);
    //     break;
    //   case 4 :program.Divide(num1,num2);
    //     break;
    //   case 5 :program.Remainder(num1,num2);
    //     break;
    //   case 6: return;
    //   default: Console.WriteLine("Invalid Option Enter Option Between 1 to 5");
    //   break;
    // }

    // Looping looping=new Looping();
    // looping.looping();

    // AreaOfCircle.CircleArea();//static function
    // EvenOddClass.CheckEvenOdd();//static function
    // // GreatestOfThree.CheckGreatestusingIf();//static funtion
    // GreatestOfThree.CheckGreatestConditional();
    // SignOfNumber.CheckSign();
    // CalculateSalary emp1 = new CalculateSalary();
    // emp1.showSalary();

    // OddInRange oddInRange=new OddInRange();
    // oddInRange.GenerateOdd();

    // SumOfMultiple sumOfMultiple=new SumOfMultiple();
    // sumOfMultiple.SumMultiple();

    PrintPattern printPattern=new PrintPattern();
    printPattern.PrintPyrimid();




  }
  public int Add(int a, int b)
  {
    return a + b;
  }
  public int Subtract(int a, int b)
  {
    return Math.Abs(a - b);

  }
  public int Multiply(int a, int b)
  {
    return a * b;
  }
  public double Divide(double a, double b)
  {
    if (b == 0) return 0;
    return a / b;
  }
  public double Remainder(int a, int b)
  {
    if (b == 0) return 0;
    return a % b;
  }
}