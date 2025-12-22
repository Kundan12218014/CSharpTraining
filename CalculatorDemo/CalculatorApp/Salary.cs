using System;
namespace Salary
{
  /*program to read eno,ename,basic salary and calculate  
pf,hra,da,net salary and gross salary and print eno,ename,basic 
salary,
gross salary and net salary
pf= 12% of basic salary.
hra=20% of basic salary.
da= 15% of basic salary.
gross salary=pf+hra+da+basic salary;
net salary=gross salary - pf;
*/
  internal class CalculateSalary
  {
    public void showSalary()
    {
      Console.WriteLine("Please Enter Your Details: ");
      Console.WriteLine("Enter Your EmployeeId");
      int EmpId=Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("Enter Your Name: ");
      string EmpName=Convert.ToString(Console.ReadLine());
      Console.WriteLine("Enter Your Basic Salary: ");
      int BasicSalary=Convert.ToInt32(Console.ReadLine());
      int pf=(12*BasicSalary)/100;
      int hra=(20*BasicSalary)/100;
      int da=(12*BasicSalary)/100;
      int Grosssalary=pf+hra+da+BasicSalary;

      Console.WriteLine($"Gross Salary of Employee {EmpName} : {Grosssalary}");
      Console.WriteLine($"Net Salary of Employee {EmpName} is {Grosssalary-pf}");

    }
  } 
}