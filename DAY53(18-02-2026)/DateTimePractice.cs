using System;
using System.Globalization;
class HelloWorld {
  static void Main() {
    // DateTime before= new DateTime(2026,1,2);
    // DateTime now =DateTime.Now;
    // Console.WriteLine(before.Month);
    //  Console.WriteLine(before.Day);
    //   Console.WriteLine(before.Hour);
    //   Console.WriteLine(before.Minute);
    // Console.WriteLine(DateTime.Today);
    // Console.WriteLine(DateTime.Now.ToString("MMMM"));
//     string input="19/02/2026 14:12:10";
//     DateTime date;
//   DateTime.TryParseExact(input,"dd/MM/yyyy HH:mm:ss",CultureInfo.InvariantCulture,DateTimeStyles.None ,out date);
// //   date=date.AddHours(14).AddMinutes(5).AddSeconds(23);
//     Console.WriteLine(date);
// Console.WriteLine(date.ToString("dd/MM/yyyy HH:mm:ss tt"));
// Console.WriteLine(date.ToString("dd/MM/yyyy h:m:s tt"));

// DateTime dob = DateTime.ParseExact(
//             "19/02/2004",
//             "dd/MM/yyyy",
//             CultureInfo.InvariantCulture
//         );

//         DateTime today = DateTime.Today;

//         TimeSpan diff = today - dob;

//         Console.WriteLine("Total Days: " + diff.TotalDays);
//         Console.WriteLine("Total Years approx: " + diff.TotalDays / 365);
DateTime dob = new DateTime(2004, 2, 19);

DateTime nextYearBirthday = dob.AddYears(DateTime.Now.Year - dob.Year + 1);

Console.WriteLine(nextYearBirthday);


  }
}
