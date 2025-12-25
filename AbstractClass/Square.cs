using System;
namespace AbstractClassNamespace
{
public class Square:Shape
{
  public double side;
  public Square(double side) : base("Square")
  {
    this.side=side;
  }
  public override double Area()
  {
    return side*side;
  }
}
}