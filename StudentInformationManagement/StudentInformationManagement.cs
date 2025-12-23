using System;
using System.Diagnostics.Contracts;
namespace StudentInformationManagement
{
  public class Student
  {
    public string Name { get; set; }
    public int Age { get; set; }
    public string Grade  { get; set; }
    public Student()
    {
      Name="Hellen Doe";
      Age=21;
      Grade="A";
    }
    public Student(string Name,int Age,string Grade)
    {
      this.Name=Name;
      this.Age=Age;
      this.Grade=Grade;
    }
  }
}