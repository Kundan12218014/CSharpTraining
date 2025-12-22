using System;
namespace Multiple
{
  public class SumOfMultiple
  {
    public void SumMultiple()
    {
      Console.WriteLine("Enter the value of N:");
      int n = Convert.ToInt32(Console.ReadLine());
      long sum = 0;
      for (int i = 3; i < n; i++)
      {
        if (i % 3 == 0 && i % 5 == 0)
        {
          sum += i;
          Console.WriteLine(i);
        }
      }
      Console.WriteLine("Sum of multiple of 3 and 5 are :{0}",sum);
    }
  }
}