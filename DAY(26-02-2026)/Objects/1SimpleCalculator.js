let Addition = (a, b) => a + b;
let Subtration = (a, b) => a - b;
let Multiplication = (a, b) => a * b;
let Division = (a, b) => a / b;

const readline = require('readline').createInterface({
  input: process.stdin,
  output: process.stdout
});

let option = readline.question("Enter the operation (+,-,*,/) : ", (option) => {
  readline.question("Enter the a and b seprated by space: ", (valStr) => {
    const [num1, num2] = valStr.split(" ").map(Number);
    let result;
    if (isNaN(num1) || isNaN(num2)) {
      console.log("Invalid Input please enter correct input.");
      readline.close();
      return;
    } else {
      switch (option) {
        case "+":
          result = Addition(num1, num2);
          break;
        case "-":
          result = Subtration(num1, num2);
          break;
        case "*":
          result = Multiplication(num1, num2);
          break;
        case "/":
          if (num2 == 0) {
            console.log("Divide by Zero Exception");
            readline.close();
            return;
          }
          result = Division(num1, num2);
          break;
        default:
          console.log("Invalid operation");
          readline.close();
          return;
      }
      console.log("result", result);
      readline.close();
      return;
    }
  });
});


//Scenario 2: Square and Cube
