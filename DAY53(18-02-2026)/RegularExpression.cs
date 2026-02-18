using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        
        // bool isValidEmail=Regex.IsMatch("Kudna.23323@lpu.in",@"^[a-zA-Z0-9.%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        // Console.WriteLine(isValidEmail);
        
        // string replacedString=Regex.Replace("Hello@123#World!",@"[^a-zA-Z0-9]","");
        // Console.WriteLine(replacedString);
        
        // bool isStrong=Regex.IsMatch("Kudan@123",@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).{8,}$");
        // Console.WriteLine(isStrong);
        
        // string text = "scatter catalog cat";
        // MatchCollection matches=Regex.Matches(text,@"cat");
        // foreach(Match match in matches){
        //     Console.WriteLine(match);
        // }
         string input = "50kg 30m 70kg ";

        MatchCollection matches = Regex.Matches(input, @"\d+(?=kg)");

        foreach (Match m in matches)
            Console.WriteLine(m.Value);

    }
}


