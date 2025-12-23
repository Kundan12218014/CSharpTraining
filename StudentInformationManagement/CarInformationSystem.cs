using System;
using System.Drawing;
namespace CarInformationSystem
{
  public class Car
  {
    public string Make { get; set; }
    public string Model{get; set;}
    public int Year { get; set; }
    public Car(String Make,string Model,int Year)
    {
      this.Make=Make;
      this.Model=Model;
      this.Year=Year;
    }
    public void DisplayDetails()
    {
      Console.WriteLine("Car Details:");
      Console.WriteLine($"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}");
    }
    public void DisplayAge()
    {
      Console.WriteLine($"Car Age: {DateTime.Now.Year-this.Year}");
    }
  }
}