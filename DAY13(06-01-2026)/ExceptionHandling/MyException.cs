using System;
class MyException:Exception
{
  public MyException(string message)
  {
    Console.WriteLine(message);
  }
}