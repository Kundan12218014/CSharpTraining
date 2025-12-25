using System;
namespace AbstractClassNamespace
{
  public class Program
    {
      public static void Main()
    {
      // Animal a;

      // a=new Dog();
      // a.Eat();
      // a.Speak();

      // a=new Cat();
      // a.Eat();
      // a.Speak();

      Shape s;
      s=new Square(5);
      Console.WriteLine($"Name of Shape : {s.Name},Area : {s.Area():F2}");
      
      s=new Circle(10);
      Console.WriteLine($"Name of Shape : {s.Name},Area : {s.Area():F2}");

    }
    }
}
