using System;
namespace Loop
{
  public class AreaOfCircle
  {
    public static void CircleArea()
    {
      Console.WriteLine("---Area of cirle Program");
      Console.Write("Enter The Radius of circle");
      double radius=Convert.ToDouble(Console.ReadLine());
      double area=Math.PI*radius*radius;
      Console.WriteLine($"Area of the radius {radius}the Circle: {area:F2}");
    }
  }
}