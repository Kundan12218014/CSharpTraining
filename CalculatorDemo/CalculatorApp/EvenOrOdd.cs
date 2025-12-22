using System;
namespace EvenOdd
{
  public class EvenOddClass()
  {
    public static void CheckEvenOdd()
    {
      Console.WriteLine("Enter the value of N:");
      int n=Convert.ToInt32(Console.ReadLine());
      if ((n & 1 )== 0)
      {
        Console.WriteLine($"Entered Number is Odd");
      }
      else
      {
        Console.WriteLine($"Entered Number is Even");
      }
      Console.WriteLine();
    }
  }
  
}