let cube = (x) => x * x * x;
let square = (x) => x * x;
const readline = require('readline').createInterface({
  input: process.stdin,
  output: process.stdout
});
readline.question("Enter the option : ", (option) => {
  readline.question("enter the value of x : ", (xStr) => {
    let x = parseInt(xStr);
    if (isNaN(xStr)) {
      console.log("Invalid Input");
      readline.close();
      return;
    }
    let result;
    switch (option) {
      case "sq":
        result = square(x);
        break;
      case "cu":
        result = cube(x);
        break;
      default:
        console.log("Invalid Input");
        readline.close();
        return;
    }
    console.log("Result: ", result);
    readline.close();
    return;
  })
})