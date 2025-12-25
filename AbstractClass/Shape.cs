using System;
namespace AbstractClassNamespace
{
  public abstract class Shape
  {
    public string Name;
    public Shape(string Name)
    {
      this.Name=Name;
    }
    public abstract double Area();
  } 
}