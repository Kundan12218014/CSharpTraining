using System;
namespace Sign
{
  public class SignOfNumber
  {
    public static void CheckSign()
    {
       Console.WriteLine("Enter the value of N: ");
       int n=Convert.ToInt32(Console.ReadLine());
      if (n > 0)
      {
        Console.WriteLine("Number is Negative");
      }
      else if (n == 0)
      {
        Console.WriteLine("Number is Zero");
      }
      else
      {
        Console.WriteLine("Number is Positive");
      }
    }


  }
}