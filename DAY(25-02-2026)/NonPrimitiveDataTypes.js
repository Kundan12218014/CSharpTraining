const chalk = require('chalk').default;
console.log("!.Creating Arrays: \n");
var color=["RED","GREEN","BLUE"];
var fruits=["apple",'banana','mango','orange'];
var cities=['london','wick',32];
console.log('Color: ',color);
console.log('fruits',fruits);
console.log("Cities: ",cities);

var myArray=new Array("html","css",'javascript');
console.log(myArray);

//accessing array
console.log('first fruits: ',fruits[0]);
console.log("Second Color: ",color[1]);
console.log("Last Element: ",fruits[fruits.length-1]);

const red = "\x1b[31m";
const green = "\x1b[32m";
const yellow = "\x1b[33m";
const blue = "\x1b[34m";
const reset = "\x1b[0m";

// console.log(chalk.red('Hello in Red!'));
// console.log(chalk.green.bold('Success in Bold Green!'));
// console.log(chalk.blue.bgYellow('Blue Text on Yellow Background'));
// Use the codes like this:
console.log(yellow + 'Hello in Red!' + reset);
console.log(green + 'Success in Bold Green!' + reset);
console.log(green+"This is green");
console.log(blue + 'Blue Text' + reset);

fruits.push("pineapple");
console.log(red+fruits);
last=fruits.pop();
console.log(reset+last);

//example to inset in middle 
fruits.splice(2,0,'pineapple');
console.log(yellow+fruits);
console.log(reset);
//TwoDimensional array
console.log("Two dimensional array (matrix Fromat)\n");
var TwoDimensionalArray=[
  [1,2,3],
  [4,5,6],
  [7,8,9]
];
console.log("Element of the two dimensional array");
for(let i =0;i<TwoDimensionalArray.length;i++){
  let row="";
  for(let j=0;j<TwoDimensionalArray[i].length;j++){
    row+=TwoDimensionalArray[i][j]+" ";
  }
  console.log(row);
}

console.log(chalk.red("this is the end"));
