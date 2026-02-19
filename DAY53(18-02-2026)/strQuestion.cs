
using System;
using System.Linq;
class Program {
    public string Invert(string input){
        if(!string.IsNullOrWhiteSpace(input)||input.Length<6||!input.All(char.IsLetter)){
            return string.Empty;
        }
        var result=input.ToLower()
                        .Where(c=>c%2!=0)
                        .Reverse()
                        .ToArray();
        for(int i=0;i<result.Length;i++){
            if(i%2==0){
                result[i]=char.ToUpper(result[i]);
            }
        }
            return new String(result);            
    }
  static void Main() {
//     Console.WriteLine("Enter the word");
//     string input = Console.ReadLine();
//   string output=new Program().Invert(input);
//   Console.WriteLine(output);
int []arr={1,2,3,4,5};
int sum=arr.Sum();
int min=arr.Min();
int max=arr.Max();
int avg=arr.Average();

int []even=arr.Where(x=>x%2==0).ToArray();
Console.WriteLine(string.Join(", ",even));
  }
}
