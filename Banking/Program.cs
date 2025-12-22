using System;
namespace BankingCalculator
{
  public class Banking
  {
    //Case Study 7: Console Application – Main Method Integration
    public static void Main(String[] args)
    {
      //Case Study 1: Banking System – Basic Arithmetic Operations
      Console.WriteLine("Enter the value of Number1");
      int number1 = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("Enter the value of Number2");
      int number2 = Convert.ToInt32(Console.ReadLine());
      Calculator calcultor1 = new Calculator(); //defuault constructor
      Console.WriteLine($"Additon of {number1} and {number2} is {calcultor1.Add(number1, number2)}");

      Calculator calcultor2 = new Calculator(number1, number2);//parametrized constructor
      Console.WriteLine($"Subtraction without user is {calcultor2.Subtract()}");

      Console.WriteLine($"Multiplication with input parameter with  number1{number1} and number2 {number2} is: {calcultor2.Multiplication(number1, number2)}");

      Console.WriteLine($"Using Predefined Value {calcultor1.Number1} and {calcultor2.Number2} is {calcultor1.Divide()}");

      //Case Study 3: Employee Payroll – Call by Value
      Calculator payroll = new Calculator();
      Console.WriteLine("Enter the salary1 : ");
      int salary1 = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("Enter the salary2 : ");
      int salary2 = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine($"The value before swap : {salary1} and {salary2}");
      payroll.SwapByValue(salary1, salary2);
      Console.WriteLine($"The value after swapByValue : {salary1} and {salary2}");


      //Case Study 4: HR System – Call by Reference
      Console.WriteLine($"The value before swap : {salary1} and {salary2}");
      payroll.SwapByRef(ref salary1, ref salary2);
      Console.WriteLine($"The value after swapByRef : {salary1} and {salary2}");

      //Case Study 5: Examination System – Output Parameters (out)
      Console.WriteLine("Enter the Marks1 : ");
      int Marks1 = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("Enter the Marks2 : ");
      int Marks2 = Convert.ToInt32(Console.ReadLine());
      int result, orig1, orig2;
      OnlineExaminationSystem onlineExaminationSystem = new OnlineExaminationSystem();
      onlineExaminationSystem.Addition(Marks1, Marks2, out result, out orig1, out orig2);
      Console.WriteLine($"Orignal Marks is {Marks1} {Marks2} result is {result} Outvalue1 {orig1} OutValue {orig2} ");



    }

  }
}
