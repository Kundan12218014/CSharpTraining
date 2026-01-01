using System;
class Program
{
  public static void Main()
  {
    string fname, lname;
    fname = "Kuddan";
    lname = "Kumar";
    char[] letters = { 'H', 'e', 'l', 'l', 'o', '\0' };
    string[] salary = { "Hello", "From", "Tutorial ", "Point" };
    string fullName = fname + lname;
    Console.WriteLine("Full Name: {0}", fullName);
    //by using string Constructor
    string gretting = new string(letters);
    Console.WriteLine(gretting);

    //methods returning string {"hello","From", "Capgemini","World"};
    string message = String.Join(" ", salary);
    Console.WriteLine("Message : {0}", message);

    //formatting method to convert a value
    DateTime Waiting = new DateTime(2025, 12, 30, 10, 28, 1);
    string chat = String.Format("Message Sent at {0:t} on {0:D}", Waiting);
    Console.WriteLine("Chat: {0}", chat);

    string str1 = "This is Kundan Kumar";
    string str2 = "This is Kundan Kumar";
    if (String.Compare(str1, str2) == 0)
    {
      Console.WriteLine(str1 + " and " + str2 + " are equal");
    }
    else
    {
      Console.WriteLine(str1 + " and " + str2 + " are not  equal");
    }

    string str = "This is test string";
    if (str.Contains("Test"))
    {
      Console.WriteLine("String contain the test");
    }

    string str3 = "Last Night I dreamnt of San Fransisco";
    Console.WriteLine(str3);
    string substr = str3.Substring(24);
    Console.WriteLine(substr);

    //1.This will print World in next line
    Console.WriteLine("Hello\nWorld");
    //2.
    Console.WriteLine("\"Hello world\"");
    //3.
    Console.WriteLine("D:\\Projects\\csharp\\program.cs");
    //4.
    Console.WriteLine(@"D:\Projects\csharp\program.cs");
    //5.verbtism sign(@)
    string message1 = (@"Hello world
    good Morning ! 
    Your files have saved
    Thanks.
    ");
    Console.WriteLine(message1);

    var message2=@"heelo Kundan 
    this is your time to lean all the skills which is 
    required";
    Console.WriteLine($"Message1: {message2}");

    var name="kundan ";
    var greeting1=String.Format("Hello {0}",name,"Good Moring !");

    var num=5;
    Console.WriteLine($"Suare of {num} is {num*num}");

    var text2="hello Kundan";
    Console.WriteLine($"UpperCase: {text2.ToUpper()}");
    Console.WriteLine($"UpperCase: {text2.ToLower()}");

    var csv="apple,banana,cherry";
    var fruits=csv.Split(",");
    Console.WriteLine("Fruits");
    foreach (var fruit in fruits)
    {
      Console.WriteLine(fruit);
    }
    var greet3="Hello Alice. Welcome";
    var index=greet3.IndexOf("el");
    var lastindex=greet3.LastIndexOf("el");
    Console.WriteLine(index+" "+lastindex);




  }
}