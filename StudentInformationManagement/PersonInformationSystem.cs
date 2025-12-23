using System;
using System.Drawing;
namespace PersonInformationSystem
{
  public class Person
  {
    public string Name { get; set; }
    public int Age{get; set;}
    public string Address { get; set; }
    public Person(String Name,int Age,string Address)
    {
      this.Name=Name;
      this.Age=Age;
      this.Address=Address;
    }
    public void DisplayDetails()
    {
      Console.WriteLine("Persons Details:");
      Console.WriteLine($"Name: {this.Name}\nAge: {this.Age}\nAddress : {this.Address}");
    }
  }
}