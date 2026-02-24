/*

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