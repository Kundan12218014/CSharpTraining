using System;
namespace TemperatureNamespace
{
  public class TemperatureConversion
  {
    public static void Demo()
    {
      try
      {

        double temperature = Convert.ToDouble(Console.ReadLine());
        string conversionType = Convert.ToString(Console.ReadLine());
        if (conversionType.ToUpper() == "F")
        {
          double convertedTemperature = (temperature - 32) * 5 / 9;
          Console.WriteLine("Temperature in Fahrenheit: {0:F2}", convertedTemperature);
        }
        else if (conversionType.ToUpper() == "C")
        {
          double convertedTemperature = temperature * 9 / 5 + 32;
          Console.WriteLine("Temperature in Celsius: {0:F2}", convertedTemperature);
        }
        else
        {
          throw new TypeException("Invalid conversion type.Please enter 'F' or 'C'.");
        }
      }
      catch (FormatException e)
      {
        Console.WriteLine("Error: Invalid input provided.");
        Console.WriteLine($"Exception Message: {e.Message}");
      }
      catch (TypeException e)
      {
        Console.WriteLine(e.Message);
      }
    }
  }
}