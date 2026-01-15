using System;
namespace CalculatorUsingDelegateApp
{
  public class Program
  {
    public static void Main()
    {
      Calculator cal = new Calculator();
      System.Console.Write("Enter the number 1: ");
      int.TryParse(Console.ReadLine(), out int num1);
      System.Console.Write("Enter the number 2: ");
      int.TryParse(Console.ReadLine(), out int num2);
      System.Console.Write("Enter operation (add, subtract, multiply, divide): ");
      string opt = Console.ReadLine();

      Calculator.ArithmeticOperation operation = null;
      try
      {
        switch (opt.ToLower())
        {
          case "add":
            operation = Calculator.Add;
            break;
          case "subtract":
            operation = Calculator.Subtract;
            break;
          case "multiply":
            operation = Calculator.Multiply;
            break;
          case "divide":
            operation = Calculator.Divide;
            break;
          default:
            System.Console.WriteLine("Invalid operation.");
            return;
        }

        double result = Calculator.Operation(operation, num1, num2);
        System.Console.WriteLine($"The result is: {result:F2}");
      }
      catch (DivideByZeroException e)
      {
        System.Console.WriteLine("Error: " + e.Message);
      }
      catch (Exception e)
      {
        System.Console.WriteLine("Error: " + e.Message);
      }

    }
  }
  public class Calculator
  {
    public delegate double ArithmeticOperation(double a, double b);
    public static double Add(double a, double b)
    {
      return a + b;
    }
    public static double Subtract(double a, double b)
    {
      return a - b;
    }
    public static double Multiply(double a, double b)
    {
      return a * b;
    }
    public static double Divide(double a, double b)
    {
      if (b == 0)
      {
        throw new DivideByZeroException("Division by zero is not allowed.");
      }
      else
      {
        return a / b;
      }
    }
    public static double Operation(ArithmeticOperation operation, double a, double b)
    {
      return operation(a, b);
    }
  }
}