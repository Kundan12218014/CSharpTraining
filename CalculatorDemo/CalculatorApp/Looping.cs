using System;
namespace Loop
{
  public class Looping
  {
    public void looping()
    {
      for (int i = 0; i <= 10; i++)
      {
        Console.WriteLine($"Numer is {i}");
      }
      for (int i = 10; i > 0; i--)
      {
        Console.WriteLine($"Reverse Numbers are {i}");
      }
      int[] collection = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

      foreach (var item in collection)
      {
        Console.WriteLine($"Array item  is {item}");
      }

      int j = 0;
      while (j < collection.Length)
      {
        Console.WriteLine($"While array index at {j} is {collection[j]}");
        j++;
      }
      do
      {
        Console.WriteLine($"Do While array index at {j} is {collection[j - 10]}");
        j++;
      } while (j - 10 < 10);

    }
  }
}