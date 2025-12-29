using System;
namespace ArrayDemoNamespace
{
  public class Employee : IComparable<Employee>
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public override string ToString()
    {
      return $"Employee Id is : {Id} and Name is : {Name}";
    }
    public int CompareTo(Employee other)
    {
      return this.Id.CompareTo(other.Id);
    }
    public int CompareTo(Employee other)
    {
      return string.Compare(this.Name,other.Name,StringComparison.OrdinalIgnoreCase);
    }
  }
}