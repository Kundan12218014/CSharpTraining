using CodeFirstApproach.Models;
using CodeFirstApproach.Models.Context;

namespace CodeFirstApproach
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Insertion operation!");
            //using (var context = new SchoolContext())
            //{
            //    var std = new Student()
            //    {
            //        Name = "Bill",
            //        BranchId = 001,
            //        Email = "BillClinton@America.com",
            //        PhoneNumber = 1234564223
            //    };
            //    context.Students.Add(std);
            //    context.SaveChanges();
            //    Console.WriteLine("Name add sucessfully");
            //}


            //using (var context = new SchoolContext())
            //{
            //    Console.WriteLine("GettingRecord.....");
            //    var StudentWithSameName = context.Students.Where(s => s.Name == GetName()).ToList();
            //    foreach (var item in StudentWithSameName)
            //    {
            //        Console.WriteLine(item.Id);
            //        Console.WriteLine(item.Name);
            //        Console.WriteLine(item.Email);
            //        Console.WriteLine(item.BranchId);
            //        Console.WriteLine(item.PhoneNumber);
            //    }
            //    Console.WriteLine("Reacord fetched Sucessfully");
            //}
            using (var context = new SchoolContext())
            {
                Console.WriteLine("GettingAllRecord.....");
                var allStudents= context.Students.ToList();
                foreach (var item in allStudents)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Email);
                    Console.WriteLine(item.BranchId);
                    Console.WriteLine(item.PhoneNumber);
                }
                Console.WriteLine("Reacord fetched Sucessfully");
            }


            //Console.WriteLine("Updation operation!");
            //using (var context = new SchoolContext())
            //{
            //    var std = context.Students.Find(4);
            //    std.Name = "Kumar Kundan";
            //    std.Email = "KumarKundan@gmail.com";
            //    std.BranchId = 2;
            //    context.SaveChanges();
            //    Console.WriteLine("Data Updated Sucessfully");
            //}

            //using (var context = new SchoolContext())
            //{
            //    var std = context.Students.Find(4);
            //    if(std!=null)
            //    context.Students.Remove(std);
            //    else
            //    {
            //        Console.WriteLine("No Record Found");
            //        return;
            //    }

            //        //or
            //        //context.Remove<Student>(std);
            //        context.SaveChanges();
            //    Console.WriteLine("Record Deleted Sucessfully");
            //}
        }
        public static string GetName()
        {
            return "Kundan";
        }
    }
}
