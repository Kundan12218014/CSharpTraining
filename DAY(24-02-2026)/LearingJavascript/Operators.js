//write a program to demostrate Arithematic opeations
let a = 10;
let b = 20;
let add = a + b;
let sub = a - b;
let mul = a * b;
let div = a / b;
console.log(`Addition: ${add} Subtration: ${sub} Multiplication: ${mul} Divison: ${div}`);

//find out the greatest of twonumber usign if else statement
let num1 = 10;
let num2 = 20;
if (num1 > num2) {
  result = num1;
} else {
  result = num2;
}
console.log(result);

//find out the greatest of three numer using if else if statement
var num3 = 30;
if (num1 > num2 && num1 > num3) {
  console.log(num1 + " is the greateset");
}
else if (num2 > num3 && num2 > num3) {
  console.log(num2 + " is greatest");
}
else {
  console.log(num3 + " is greatest");
}

//find out the greatest of theree number using nested if else statement
if(num1>num2){
  if(num1>num3){
    console.log(num1+ " is greatest");
  }
  else{
    console.log(num3 + "is greatest");
  }
}else{
  if(num2>num3){
    console.log(num2+ " is greatest");
  }
  else{
    console.log(num3 + " is greatest");
  }
}

//arithematic opeartion using swithc case
var op="+";
switch(op){
  case '+':
    console.log("addition : "+ a+b);
    break;
  case '-':
    console.log("subtration: "+a-b);
    break;
  case '*':
    console.log("multiplication: "+a* b);
    break;
  case '/':
    console.log("division: "+a/b);
    break;
  default:
    console.log('invalid operation');
    break;
}

