using System;
using System.Security.Cryptography.X509Certificates;
namespace Greatest
{
  public class GreatestOfThree
  {
    public static void CheckGreatestusingIf()
    {
      Console.WriteLine("Enter The value of a,b,c: ");
      int a = Convert.ToInt32(Console.ReadLine());
      int b = Convert.ToInt32(Console.ReadLine());
      int c = Convert.ToInt32(Console.ReadLine());
      if (a > b)
      {
        if (a > c)
        {
          Console.WriteLine("Greatest is : {0}",a);
        }
        else
        {
          Console.WriteLine("Greatest is : {0}",c);
        }
      }
      else
      {
        if (b > c)
        {
          Console.WriteLine("Greatest is : {0}",b);
        }
        else
        {
          Console.WriteLine("Greatest is : {0}",c);
        }
      }
    }
    public static void CheckGreatestConditional()
    {
      Console.WriteLine("Enter The value of a,b,c: ");
      int a = Convert.ToInt32(Console.ReadLine());
      int b = Convert.ToInt32(Console.ReadLine());
      int c = Convert.ToInt32(Console.ReadLine());

      int greatest=(a>b&&a>c)?a:(b>c)?b:c;
      Console.WriteLine("Greatest is : {0}",greatest);
    }
  }
}