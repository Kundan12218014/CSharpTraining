using System;
namespace Patterns
{
  public class PrintPattern
  {
    public void PrintPyrimid()
    {
      Console.WriteLine("Enter the Value of n");
      int n=Convert.ToInt32(Console.ReadLine());
      for(int i = 1; i <= n; i++)
      {
        for(int j = i; j < n; j++)
        {
          Console.Write(" ");
        }
        for(int j = 1; j <= i; j++)
        {
          Console.Write($" {j}");
        }
      Console.WriteLine();
      }
    }
  }
}