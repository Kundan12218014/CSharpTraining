
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ_Assignment_BoilerPlateCode.Repos;
using LINQ_Assignment_BoilerPlateCode.DTOs;
using LINQ_Assignment_BoilerPlateCode.Models;
using System.Security.Cryptography;

namespace LINQ_Assignment_BoilerPlateCode
{
    class Program
    {
        static void Main(string[] args)
        {
            // =======================
            // SAMPLE DATA
            // =======================
            var employees = EmployeeRepo.SeedEmployees();
            var projects = ProjectRepo. SeedProjects();
            //custom testing
            Employee highestPaidEmployees = GetHighestPaidEmployee(employees);
            Console.WriteLine(highestPaidEmployees.Name+" "+highestPaidEmployees.Salary);

            List<Employee> highEarningEmployees = GetHighEarningEmployees(employees);
            for(int i=0;i< highEarningEmployees.Count;i++)
            {
                Console.WriteLine(highEarningEmployees[i].Name+" "+ highEarningEmployees[i].Salary);
            }

            List<string> employeeNames = GetEmployeeNames(employees);
            for(int i=0;i< employeeNames.Count;i++)
            {
                Console.WriteLine(employeeNames[i]);
            }

            bool hasHREmployees = HasHREmployees(employees);
            Console.WriteLine("Has HR Employees: " + hasHREmployees);

            List<DepartmentCount> departmentWiseCount = GetDepartmentWiseCount(employees);
            for(int i=0;i< departmentWiseCount.Count;i++)
            {
                Console.WriteLine(departmentWiseCount[i].Department+" "+ departmentWiseCount[i].Count);
            }

            List<EmployeeProject> employeeProjectMappings = GetEmployeeProjectMappings(employees, projects);
            for(int i=0;i< employeeProjectMappings.Count;i++)
            {
                Console.WriteLine(employeeProjectMappings[i].EmployeeName+" "+ employeeProjectMappings[i].ProjectName);
            }
             
            List<Employee> sortedEmployees = SortEmployeesBySalaryAndName(employees);
            for(int i=0;i< sortedEmployees.Count;i++)
            {
                Console.WriteLine(sortedEmployees[i].Name+" "+ sortedEmployees[i].Salary);
            }


            Console.WriteLine("LINQ Scenario Boilerplate Loaded");
        }

        // =====================================================
        // 🟢 SECTION 1 – HR ANALYTICS
        // =====================================================

        // TODO 1.1: Get employees earning more than 60,000
        static List<Employee> GetHighEarningEmployees(List<Employee> employees)
        {
            // TODO: Write LINQ query here
            List<Employee> employeeList = (from emp in employees
                       where emp.Salary > 60000
                       select emp).ToList();

            return employeeList;

            throw new NotImplementedException();
        }

        // TODO 1.2: Get list of employee names only
        static List<string> GetEmployeeNames(List<Employee> employees)
        {
            // TODO: Write LINQ query here
            List<string> employeeList = (from emp in employees
                                         select emp.Name).ToList();
            return employeeList;
            throw new NotImplementedException();
        }

        // TODO 1.3: Check if any employee belongs to HR department
        static bool HasHREmployees(List<Employee> employees)
        {
            // TODO: Write LINQ query here
            var hasHrEmployeeCount = (from emp in employees
                                      where emp.Department == "HR"
                                      select emp).Count();
            if (hasHrEmployeeCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            //bool hasHrEmployee = employees.Any(emp => emp.Department == "HR");
            //return hasHrEmployee;
            throw new NotImplementedException();
        }

        // =====================================================
        // 🟡 SECTION 2 – MANAGEMENT INSIGHTS
        // =====================================================

        // TODO 2.1: Get department-wise employee count
        static List<DepartmentCount> GetDepartmentWiseCount(List<Employee> employees)
        {
            // TODO: Write LINQ query here
            List<DepartmentCount> deptCountList = (from emp in employees
                                                group emp by emp.Department into deptGroup
                                                select new DepartmentCount
                                                {
                                                    Department = deptGroup.Key,
                                                    Count = deptGroup.Count()
                                                }).ToList();
            return deptCountList;
            throw new NotImplementedException();
        }

        // TODO 2.2: Find the highest paid employee
        static Employee GetHighestPaidEmployee(List<Employee> employees)
        {
            // TODO: Write LINQ query here

            var highestPaidEmployee = (from emp in employees
                                       orderby emp.Salary descending
                                       select emp).FirstOrDefault();
            return highestPaidEmployee;

            throw new NotImplementedException();
        }

        // TODO 2.3: Sort employees by Salary (DESC), then Name (ASC)
        static List<Employee> SortEmployeesBySalaryAndName(List<Employee> employees)
        {
            // TODO: Write LINQ query here
            List<Employee> sortedEmployee= (from emp in employees
                                           orderby emp.Salary descending, emp.Name ascending
                                           select emp).ToList();
            return sortedEmployee;
            throw new NotImplementedException();
        }

        // =====================================================
        // 🔵 SECTION 3 – PROJECT & SKILL INTELLIGENCE
        // =====================================================

        // TODO 3.1: Join employees with projects
        static List<EmployeeProject> GetEmployeeProjectMappings(
            List<Employee> employees,
            List<Project> projects)
        {
            // TODO: Write LINQ query here
            var employeeProjectList = (from emp in employees
                                       join proj in projects
                                       on emp.Id equals proj.EmployeeId
                                       select new EmployeeProject
                                       {
                                           EmployeeName = emp.Name,
                                           ProjectName = proj.ProjectName
                                       }).ToList();
            return employeeProjectList;
            throw new NotImplementedException();
        }

        // TODO 3.2: Find employees who are NOT assigned to any project
        static List<Employee> GetUnassignedEmployees(
            List<Employee> employees,
            List<Project> projects)
        {
            // TODO: Write LINQ query here
            throw new NotImplementedException();
        }

        // TODO 3.3: Get all unique skills across the organization
        static List<string> GetAllUniqueSkills(List<Employee> employees)
        {
            // TODO: Write LINQ query here
            throw new NotImplementedException();
        }

        // =====================================================
        // 🔴 SECTION 4 – ADVANCED WORKFORCE ANALYTICS
        // =====================================================

        // TODO 4.1: Get top 3 highest-paid employees per department
        static List<DepartmentTopEmployees> GetTopEarnersByDepartment(
            List<Employee> employees)
        {
            // TODO: Write LINQ query here
            throw new NotImplementedException();
        }

        // TODO 4.2: Remove duplicate employees based on Id
        static List<Employee> RemoveDuplicateEmployees(List<Employee> employees)
        {
            // TODO: Write LINQ query here
            throw new NotImplementedException();
        }

        // TODO 4.3: Implement pagination
        static List<Employee> GetEmployeesByPage(
            List<Employee> employees,
            int pageNumber,
            int pageSize = 5)
        {
            // TODO: Write LINQ query here
            throw new NotImplementedException();
        }


    }
}
