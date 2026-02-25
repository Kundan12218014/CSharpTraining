console.log("Arrow function");
//Normal Function
// console.log("Normal function: ");
function add(a,b){
  return a+b;
};
console.log("Normal function result: "+add(5,6));

//arrow function(basic)
// console.log("Arrow function basic");
const addArrow=(a,b)=>{
  return a+b;
}
console.log("Arrow function Example : ",addArrow(5,6));

console.log("Short Arrow function");
const multiply=(a,b)=>{
  return a*b;
}
console.log("Multiply result: ",multiply(1,2));
console.log("Arrow function without parameters");
const greet=()=>console.log("Hello kundan");
greet();

//arrow function with on parameter
const square=num=>{
  return num*num;
};
console.log("Square of 6",square(6));

console.log("Arrow function with array");
let numbers=[1,2,3,4,5,6];
numbers.forEach(num=>console.log("numbers: ",num));


console.log("arrow fundtion with map()");
let doubled=numbers.map(num=>num*2);
console.log(doubled);

//diffrence of this behavour
console.log("Difference in this");
let person1={
  name:"Kudnan",
  greet:function(){
    console.log("Normal function this.name",this.name);
  }
};
person1.greet();
//arrow functoin inside object (not recommanded)
let person2={
  name:"priya",
  greet:()=>{
    console.log("arrow function this.name",this.name);
  }
}
person2.greet();//undefined