/*
1)Sample  program to print a welcome message
2)program to read a number user and display it 
3)program to read a floating point number from user
//4)program to read a string from user and display it on the screen 
//5)program to perform all arithmetic operations
6) program to find the area of circle 
//7) program to find whether the given number is Even or Odd 
//8)program to find the greatest of 2 numbers 
//9) program to find whether a given number is positive ,negative or zero
//10) program to find the greatest of three numbers 
//10a) program to find the greatest of three numbers using nested if
11) program to find the greatest of 3 numbers
using conditional operator 
12) program to read student num, name, marks and calculate 
total and average and print result and division 
13)program to read eno, ename, basic salary and calculate
pf, hra, da, net salary and gross salary and print eno, ename, basic salary,
  gross salary and net salary 

pf = 12 % of basic salary.
  hra = 20 % of basic salary.
    da = 15 % of basic salary.
gross salary = pf + hra + da + basic salary;
net salary = gross salary - pf;
*/

// 1)Sample  program to print a welcome message
console.log("Hello world , good morning");
const readline = require('readline').createInterface({
  input: process.stdin,
  output: process.stdout
});
readline.question("Enter your name: ", (name) => {
  console.log("Your name is  : " + name);
  readline.close();
});
// 2)program to read a number user and display it 
const readline1 = require('readline').createInterface({
  input: process.stdin,
  output: process.stdout
});
readline1.question("Enter a number: ", (num) => {
  console.log("Your input number is  : " + parseInt(num));
  readline1.close();
});


// 3)program to read a floating point number from user
const readline2 = require('readline').createInterface({
  input: process.stdin,
  output: process.stdout
});
readline2.question("Enter a floating point number: ", (input) => {
  const floatNum = parseFloat(input);
  console.log("The floating point number is: " + floatNum);
  readline2.close();
});

// 4)program to read a string from user and display it on the screen 
const readline3 = require('readline').createInterface({
  input: process.stdin,
  output: process.stdout
});

readline3.question("Enter a string: ", (str) => {
  console.log("Your input string is: " + str);
  readline3.close();
});

//5)program to perform all arithmetic operations
let a = 10;
let b = 20;
let add = a + b;
let sub = a - b;
let mul = a * b;
let div = a / b;
console.log(`Addition: ${add} Subtration: ${sub} Multiplication: ${mul} Divison: ${div}`);

// 6) program to find the area of circle
const readlineArea = require('readline').createInterface({
  input: process.stdin,
  output: process.stdout
});

readlineArea.question("Enter the radius of the circle: ", (radius) => {
  const r = parseFloat(radius);
  const area = Math.PI * r * r;
  console.log(`The area of the circle is: ${area.toFixed(2)}`);
  readlineArea.close();
});

//7) program to find whether the given number is Even or Odd 
const readlinenumber = require('readline').createInterface({
  input: process.stdin,
  output: process.stdout
});

readlinenumber.question("Enter the number to check even or odd: ", (strnum) => {
  const num = parseInt(strnum);
  if (num % 2 == 0) {
    console.log("Number is even number");
  }
  else {
    console.log("Number is odd number");
  }
  readlinenumber.close();
});

//8 find out the greatest of twonumber usign if else statement
let num1 = 10;
let num2 = 20;
if (num1 > num2) {
  result = num1;
} else {
  result = num2;
}
console.log(result);

// 9) program to findwhether a given number is positive ,negative or zero
const readlinePnz = require('readline').createInterface({
  input: process.stdin,
  output: process.stdout
});

readlinePnz.question("Enter number to check positive, negative or zero: ", (input) => {
  const num = parseFloat(input);
  if (num > 0) {
    console.log("The number iss positive");
  } else if (num < 0) {
    console.log("The number is negative");
  } else {
    console.log("The number is zero");
  }
  readlinePnz.close();
});
// 10a) program to find the greatest of three numbers using nested if
if (x >= y) {
  if (x >= z) {
    console.log("Greatest is: " + x);
  } else {
    console.log("Greatest is: " + z);
  }
} else {
  if (y >= z) {

    console.log("Greatest is: " + y);
  } else {
    console.log("Greatest is: " + z);
  }
}

// 11) program to find the greatest of 3 numbers using conditional operator
let greatest = (x > y) ? ((x > z) ? x : z) : ((y > z) ? y : z);
console.log("Greatest using conditional operator: " + greatest);

// 12) program to read student num, name, marks and calculate 
// total and average and print result and division 
const rlStudent = require('readline').createInterface({
  input: process.stdin,
  output: process.stdout
});

rlStudent.question("Enter Student No: ", (sno) => {
  rlStudent.question("Enter Student Name: ", (sname) => {
    rlStudent.question("Enter Marks (3 subjects separated by space): ", (marksInput) => {
      const marks = marksInput.split(' ').map(Number);
      const total = marks.reduce((sum, m) => sum + m, 0);
      const average = total / marks.length;

      let result = marks.every(m => m >= 35) ? "pass" : "Fail";
      let division = "Fail";
      if (result === "pass") {
        if (average >= 60) division = "First Division";
        else if (average >= 50) division = "Second Division";
        else division = "Third Division";
      }

      console.log(`Total: ${total}, Average: ${average.toFixed(2)}, Result: ${result}, Division: ${division}`);
      rlStudent.close();
    });
  });
});

// 13) program to read eno, ename, basic salary and calculate
// pf, hra, da, net salary and gross salary
const rlEmployee = require('readline').createInterface({
  input: process.stdin,
  output: process.stdout
});

rlEmployee.question("Enter Employee No: ", (eno) => {
  rlEmployee.question("Enter Employee Name: ", (ename) => {
    rlEmployee.question("Enter Basic Salary: ", (basic) => {
      const basicSalary = parseFloat(basic);
      const pf = basicSalary * 0.12;
      const hra = basicSalary * 0.20;
      const da = basicSalary * 0.15;
      const grossSalary = pf + hra + da + basicSalary;
      const netSalary = grossSalary - pf;

      console.log(`\nEmployee No: ${eno}\nName: ${ename}\nBasic Salary: ${basicSalary}`);
      console.log(`Gross Salary: ${grossSalary}\nNet Salary: ${netSalary}`);
      rlEmployee.close();
    });
  });
});