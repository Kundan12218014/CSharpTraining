*******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
class HelloWorld {
    public static List<float> ParsedValue(string input){
        if(string.IsNullOrWhiteSpace(input))
             return new List<float>();
        var result=new List<float>();
        string[]tokens=input.Split(',');
        foreach(var token in tokens){
            string cleaned = token.Trim();
            if(string.IsNullOrWhiteSpace(cleaned)||cleaned.Equals("null",StringComparison.OrdinalIgnoreCase)){
                continue;
            }
            if(float.TryParse(cleaned,out float value)){
                if(!float.IsNaN(value)){
                    result.Add((float)Math.Round(value,2,MidpointRounding.AwayFromZero));
                }
            }
        }
        return result;
        
    }
  static void Main() {
    string input = " 24.5678, 18.9, null, , 31.0049, error, 29, 17.999, NaN ";
    List<float>result=ParsedValue(input);
   Console.Write("{ ");

for (int i = 0; i < result.Count; i++)
{
    Console.Write(result[i].ToString("F2"));

    if (i < result.Count - 1)
        Console.Write(", ");
}

Console.WriteLine(" }");

  }
}
