using System;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
namespace BankingCalculator
{
  public class Calculator
  {
    //Case Study 6: Utility Service – Auto-Implemented Properties
    public int Number1 { get; set; }
    public int Number2 { get; set; }
    public int Result { get; set; }

    public Calculator(int Number1, int Number2)
    {
      this.Number1 = Number1;
      this.Number2 = Number2;
    }
    public Calculator()
    {
      Number1 = 10;
      Number2 = 5;
    }

    //Addition of two numbers
    public int Add(int number1, int number2)
    {
      return number1 + number2;
    }
    //Subtraction without user input
    public int Subtract()
    {
      return Number1 - Number2;
    }
    //	Multiplication with input parameters
    public int Multiplication(int number1, int number2)
    {
      return number1 * number2;
    }
    //Division using predefined values
    public int Divide()
    {
      return Number1 / Number2;
    }

    public void SwapByRef(ref int salary1,ref int salary2)
    {
      salary1=salary1^salary2;
      salary2=salary1^salary2;
      salary1=salary1^salary2;
    }
    public void SwapByValue(int salary1,int salary2)
    {
      salary1=salary1^salary2;
      salary2=salary1^salary2;
      salary1=salary1^salary2;
    }
  }
  class OnlineExaminationSystem
  {
    public void Addition(int n1, int n2, out int result, out int n3, out int n4)
    {
      result=n1+n2;
      n3=n1;
      n4=n2;
    }
  }
}