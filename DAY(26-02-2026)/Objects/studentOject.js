
console.log("Creating an objects");
var person = {
  name: "Kudan",
  age: 28,
  gender: "Male",
  dispalyName: function () {
    console.log("Inside Methods => name: ", this.name);
  }
};
console.log("Person Object: ", person);
console.table(person);
console.log("Accessing Object properties");
//dotnotation
console.log("Name(DotNotation)", person.name);
//bracket notation
console.log("age (bracketNotation) : ", person["age"]);
console.log("\nBook object example: ");
var book = {
  "name": "Harry potter and the globlet of fire",
  "author": "J K Rowling",
  "year": 2000
};
console.log("Author: ", book.author);
console.log("Year: ", book["year"]);
console.log("Looping through object properties(for ... in ");
for (var key in person) {
  console.log(key + " " + person[key]);
}
console.log("Calling Object Methods");
person.dispalyName();
person["dispalyName"]();

console.log("Complex Object Example");
var student = {
  name: "Kundan",
  age: 22,
  skills: ["javascript", "c#", ".NET"],
  address: {
    city: "Hyderabad",
    country: "India"
  }
};

console.log("\n Looping using for loop");
for (let i = 0; i < student; i++) {
  console.log("Student", student);
  console.log("First Skill: ", student.skills[0]);
  console.log("City", student.address.city);
  console.log("\n------")
}
var student = [
  {
    id: 1,
    name: "Kundan Kumar",
    age: 22,
    grade: "A",
  },
  {
    id: 2,
    name: "Priya",
    age: 21,
    grade: "B",
  },
  {
    id: 3,
    name: "Amit",
    age: 23,
    grade: "A+"
  }
];
console.log("Student Array created Sucessfully");
console.log("accessing First Student");
console.log("Name",students[0],name);
console.log("Grade",students[0].grade);

console.log("Looping using for loop: ");

for(let i=0;i<students.length;i++){
  console.log("Student",i+1);
  cons
}
console.log("Looping using for...of : ");
for (let student of student) {
  console.log("Id : ", student.id);
  console.log("Name: ", student.name);
  console.log("Age: ", student.age);
  console.log("Grade", student.grade);
  console.log("-------------------")
}
