//define a class student
using System.ComponentModel.Design.Serialization;

public class Student
{
  //properties definition
  public int RollNo { get; set; } 
  public string Name { get; set; }
  //No Argument Constructor
  public Student()
  {
    RollNo=0;
    Name=string.Empty;
  }
  //parametrized Constructor
  public Student(int rno,string n)
  {
    RollNo=rno;
    Name=n;
  }
  //Method to Display Studnet Data
  public void DisplayData()
  {
    System.Console.WriteLine("Roll Number : {0}",RollNo);
    System.Console.WriteLine("Name : {0}",Name);
  }

}