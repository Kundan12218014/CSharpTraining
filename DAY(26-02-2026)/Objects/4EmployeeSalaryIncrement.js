let employees = [
  { name: "Ravi", salary: 30000 },
  { name: "Priya", salary: 40000 },
  { name: "Amit", salary: 35000 }
];

let updatedSalaries=employee.map((emp)=>{
  return {
    name:emp.name,
    salary:emp.salary*1.10,
  };
});

console.log("1. Updated Salaries (10% increase):", updatedSalaries);

let names = employees.map(emp => emp.name);
console.log("2. Employee Names:", names);

let highSalaryEmployees = employees.filter(emp => emp.salary > 35000);
console.log("3. Employees with Salary > 35000:", highSalaryEmployees);
