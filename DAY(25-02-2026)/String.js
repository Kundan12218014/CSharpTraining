console.log("Creating string");
const chalk=require('chalk').default;
var mystring="hello world";
var mystring2="hello world";
console.log("single: ",mystring);
console.log("double: ",mystring2);

//using quotes inside string
console.log("using Quotes inside string");
var str1="it's okay";
var str2="he said \"good bye!\"";
var str3='he is very good "guy"';
console.log(str3);
console.log(str2);
console.log(str1);
//escape sequance
console.log("\n Escape sequance");
var escape1="The quick brown fox \n jumps over the lazy dog.";
console.log(escape1);
var escape2="Hello\t world";
console.log(escape2);
var escape3="c:\\user\\downloads";
console.log(escape3);

console.log(escape3.length);
//indexof() and lastindexOf()
console.log("\nFinding Substring\n");
var strFind="if the fact don't fit the theory, change the facts";
var pos1=strFind.indexOf("fact");
console.log("First occurance : ",pos1);

// var pos2=strFind.lastindexOf("fact");
// console.log("last occurance: ",pos2);

//slice methods
console.log("slice(), methods");
var strslice="The quick brown fox jumps over the lazy dog";
var stubstr2=strslice.slice(4,15);
console.log("Slice (4,15) : ",stubstr2);

//substring mehtods
console.log("Substrin methods()");
console.log(strslice.substring(4,15));
console.log()