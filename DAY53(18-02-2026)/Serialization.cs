using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    // [JsonIgnore]
    [JsonPropertyName("StudentMarks")]
    public int Marks { get; set; }
}


class HelloWorld {
  static void Main() {
//   Student s= new Student(){
//       Id=1,
//       Name="Kundan Kumar",
//       Marks=100
//   };
//   string js=JsonSerializer.Serialize(s);
//   Console.WriteLine(js);
//   Student s1=JsonSerializer.Deserialize<Student>(js);
//   Console.WriteLine(s1.Name); 
   List<Student> students = new List<Student>
{
    new Student { Id = 1, Name = "A", Marks = 90 },
    new Student { Id = 2, Name = "B", Marks = 85 }
};

string json = JsonSerializer.Serialize(students,new JsonSerializerOptions{WriteIndented=true});
 Console.WriteLine(json);


 File.WriteAllText("student.json",json);
 string js= File.ReadAllText("student.json");
 Console.WriteLine(js);
  }
}
