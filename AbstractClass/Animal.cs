using System;
namespace AbstractClassNamespace
{
   public abstract class Animal
  {
    public void Eat()
    {
      Console.WriteLine("Animal is Eating");
    }
    public abstract void Speak();
  }

}