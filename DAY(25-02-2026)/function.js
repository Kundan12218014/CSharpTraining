console.log("javascript function learning");
//what is function
console.log("1 Defining and calling a functoin");
//defining function 
function sayHello() {
  console.log("Hello , welcome to this website");
}
sayHello();
console.log("2 Functon with parameter");
function displaySum(num1, num2) {
  var total = num1 + num2;
  console.log("Sum: " + total);
}
displaySum(2, 3);

//default parameters (es6);
function greet(name="guest"){
  console.log("hello"+name);
}
greet();
greet('kundan');

//console.log("returning values");
function getSum(num1,num2){
  var total=num1+num2;
  return
}
console.log(getSum(45,5));
console.log(getSum(-5,17));

console.log("Return multiple values ");
function divideNumbers(dividend,divisor){
  var quotient=dividend/divisor;
  var arr=[dividend,divisor,quotient];
  return arr;
}
var all=divideNumbers(10,2);
console.log("Dividend: ",all[0]);
console.log("divisor: ",all[1]);
console.log("Quotient",all[2]);

//returning multiple values using object
function getValues(obj){
  return {x:20,y:50};
}
let result=getValues();
console.log("X: ",result.x);
console.log("Y: ",result.y);

//simulating the out parameter like in c#
console.log("Simulating C# out parameter\n");
function modifyObject(obj){
  obj.a=100;
  obj.b=200;
};
let resultobject={};
modifyObject(resultobject);
console.log("A:",resultobject.a);
console.log("B:", resultobject.b);
//8 es6 destructuring
function getCoordinates(){
  return  {x:50,y:75};
}
let {x,y}=getCoordinates();
console.log("X: ",x);
console.log("Y: ",y);

console.log("Function expression");
var sumExpression=function(num1,num2){
  var total=num1+num2;
  return total;
}
console.log(sumExpression(5,10));
var sum=sumExpression(7,10);
console.log("Sum: "+sum);