using System;
class Program
{
  public static void Main()
  {

    
    
    Employee employee=new Employee();
    employee[0]="string 1";
    employee[1]="string 2";
    employee[2]="string 3";
    employee[3]="string 4";
    employee[5]="string 5";
    for(int i = 0; i < 5; i++)
    {
      System.Console.WriteLine(employee[i]);
    }
    System.Console.WriteLine("Value at third index is {0}",employee[5]);
    System.Console.WriteLine("value string 4 is at Index is {0}",employee["string 4"]);

  }
}