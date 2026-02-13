using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApproach.Models
{
    public class Student
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; }
        public int StudentId { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
        public int BranchId { get; set; } = 0;
        public int PhoneNumber  { get; set; }

    }
}
