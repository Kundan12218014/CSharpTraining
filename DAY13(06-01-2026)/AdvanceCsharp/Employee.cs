using System;
class Employee
{
  public int Id { get; set; }
  public string Name { get; set; }

  string []str=new string[5];
  public string this[int index]
  {
    get{return str[index];}
    set{str[index]=value;}
  }
  public int this[string st]
  {
    get
    {
      int index=0;
      while (index < 5)
      {
        if (str[index] == st)
        {
          return index;
        }
        i++;
      }
      return index;
    }
  }
}