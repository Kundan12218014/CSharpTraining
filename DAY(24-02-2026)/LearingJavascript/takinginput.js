var readline = require('readline').createInterface({
  input: process.stdin,
  output: process.stdout,
});
readline.question("please enter you name: ", name => {
  console.log(`Hello , ${name}`);
  readline.close();
})

var x=10;
var y=20;
var sum =x+y;
console.log(sum);