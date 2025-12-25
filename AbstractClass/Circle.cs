using System;
namespace AbstractClassNamespace
{
public class Circle:Shape
{
  public double radius;
  public Circle(double radius) : base("Circle")
  {
    this.radius=radius;
  }
  public override double Area()
  {
    return Math.PI*radius*radius;
  }
}
}