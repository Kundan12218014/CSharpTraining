let marks = [45, 78, 90, 66, 58];
let GraceMarks = marks.map(x => x + 5);
let Above60 = marks.filter(x => x > 60);
let Total = marks.reduce((acc, curr) => acc + curr, 0);
console.log("Grace Marks: ", GraceMarks);
console.log("Above 60: ", Above60);
console.log("Total: ", Total);
