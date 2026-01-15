using System;
using System.Reflection;
using System.Threading.Tasks.Dataflow;

// Rectangle rectangle = new Rectangle(20, 30);
// rectangle.GetArea();
// rectangle.Display();

// Type t=typeof(string);
// //use Reflection to find about any sort of data to t
// System.Console.WriteLine("Name: {0}",t.Name);
// System.Console.WriteLine("FullName: {0}",t.FullName);
// System.Console.WriteLine("Namespace: {0}",t.Namespace);
// System.Console.WriteLine("Base Type: {0}",t.BaseType);

Assembly executing = Assembly.GetExecutingAssembly();
Type[] type = executing.GetTypes();
foreach (var item in type)
{
  //display each type
  Console.WriteLine("Type: ", item.Name);
  //array to store methods of each type
  MethodInfo[] method = item.GetMethods();
  foreach (var met in method)
  {
    //display each method
    System.Console.WriteLine("\nmethod" + met.Name);
    //array to store Parameter list
    ParameterInfo[] parameterInfo = met.GetParameters();
    foreach (var para in parameterInfo)
    {
      System.Console.WriteLine($"Parameter name: {para.Name} paramterTypes: {para.GetType()}");
    }
  }
}
/*
Assembly executing = Assembly.GetExecutingAssembly();
Type[] types = executing.GetTypes();

foreach (var type in types)
{
    Console.WriteLine($"\n========================================");
    Console.WriteLine($"Type: {type.FullName}");
    Console.WriteLine($"========================================");

    // Using BindingFlags to show only methods declared in this class (ignoring inherited ones like ToString)
    MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly);
    
    foreach (var method in methods)
    {
        Console.WriteLine($"\n  Method: {method.ReturnType.Name} {method.Name}");

        ParameterInfo[] parameters = method.GetParameters();
        if (parameters.Length > 0)
        {
            foreach (var param in parameters)
            {
                Console.WriteLine($"    -> Parameter: {param.ParameterType.Name} {param.Name}");
            }
        }
        else
        {
            Console.WriteLine("    -> (No parameters)");
        }
    }
}*/