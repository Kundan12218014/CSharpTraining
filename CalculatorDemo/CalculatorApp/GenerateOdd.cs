using System;
namespace Generator
{
  public class OddInRange
  {
    public void GenerateOdd()
    {
      Console.WriteLine("Enter the Value of Start: ");
      int start = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("Enter the Value of End: ");
      int end = Convert.ToInt32(Console.ReadLine());

      for (int i = start; i <= end; i++)
      {
        if ((i & 1) != 0) Console.WriteLine(i);
      }

    }
  }
}