using System;
public class Program
{
  public static void Main()
  {
    // int num1 = 0;
    // int num2 = 0;
    // int result = 0;
    // int[] arr = new int[6] { 10, 20, 30, 40, 50, 60 };
    // try
    // {
    //   System.Console.WriteLine("Enter the first Number");
    //   num1 = Convert.ToInt32(Console.ReadLine());
    //   System.Console.WriteLine("Enter the second Number");
    //   num2 = Convert.ToInt32(Console.ReadLine());
    //   result = num1 / num2;
    //   for (int i = 0; i < 9; i++)
    //   {
    //     System.Console.WriteLine(arr[i]);
    //   }
    // }
    // catch (IndexOutOfRangeException e)
    // {
    //   System.Console.WriteLine(e.Message);
    // }
    // catch (DivideByZeroException e)
    // {
    //   System.Console.WriteLine(e.Message);
    // }
    // catch (FormatException e)
    // {
    //   System.Console.WriteLine(e.Message);
    // }
    // finally
    // {
    //   Console.WriteLine("This is final");
    //   System.Console.WriteLine($"Dividon of two Number: {result}");
    // }
    try
    {
      throw new MyException("user defined exception");
    }
    catch(Exception e)
    {
      System.Console.WriteLine("Exception caught here : "+e.Message);
    }
    System.Console.WriteLine("LAST STATEMENT");
  }
}