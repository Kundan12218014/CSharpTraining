using System;
namespace StringConverter
{
  public class ConverterString
  {
    public string UserString { get; set; }
    public int Value { get; set; }
    public string ToUpperCase(string UserString)
    {
      return UserString.ToUpper();
    }
    public string ToLowerCase(string UserString)
    {
      return UserString.ToLower();
    }
    public string ToTitleCase(string UserString,int toTitleNumber)
    {
      string [] Words= UserString.Split(' ');
      string resultString="";
      foreach(string word in Words)
      {
        resultString+=char.ToUpper(word[0])+ word.Substring(1).ToLower()+" ";
      }
      return resultString.Trim();
    }
  }
}