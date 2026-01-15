[DebugInfo(45, "Kunda Kumar", "12/08/2024", Message = "Return type mismatch")]
[DebugInfo(23, "Nuha jha", "11/08/2024", Message = "Unused Variable")]
public class Rectangle
{
  protected double length;
  protected double width;
  public Rectangle(double l, double w)
  {
    length = l;
    width = w;
  }
  [DebugInfo(55, "Zara Ali", "19/10/2024", Message = "Return Types Mismatch")]
  public double GetArea()
  {
    return length * width;
  }
  [DebugInfo(55, "Zara Ali", "19/10/2024")]
  public void Display()
  {
    System.Console.WriteLine("Length: {0}", length);
    System.Console.WriteLine("Width: {0}", width);
    System.Console.WriteLine("Area: {0}", GetArea());

  }
}