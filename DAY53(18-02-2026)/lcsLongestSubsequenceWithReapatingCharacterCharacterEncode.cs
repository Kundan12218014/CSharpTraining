
using System;
using System.Text;
using System.Collections.Generic;
class HelloWorld {
    public static string GetRunEncode(string s){
        if(String.IsNullOrWhiteSpace(s)){
            return string.Empty;
        }
        StringBuilder sb=new StringBuilder();
        int count=1;
        for(int i=1;i<s.Length;i++){
            if(s[i]==s[i-1]){
                count++;
            }else{
                sb.Append(s[i-1]);
                sb.Append(count);
                count=1;
            }
        }
        sb.Append(s[s.Length-1]);
        sb.Append(count);
        
        return sb.ToString();
    }
    public static string LongestSubsequenceWithoutRepeatingCharacter(string input){
        if(string.IsNullOrWhiteSpace(input)){
            return string.Empty;
        }
        Dictionary<char,int>map=new Dictionary<char,int>();
        int maxLength=0;
        int left=0;
        int startIndex=0;
        for(int right=0;right<input.Length;right++){
            char ch=input[right];
            if(map.ContainsKey(ch)&&map[ch]>=left){
                left=map[ch]+1;
            }
            map[ch]=right;
            if(right-left+1>maxLength){
                maxLength=right-left+1;
                startIndex=left;
            }
            // maxLength=Math.Max(maxLength,right-left+1);
        }
        return input.Substring(startIndex,maxLength);
    }
    
    public static string LCSLength(string s1,string s2){
        if(string.IsNullOrWhiteSpace(s1)||string.IsNullOrWhiteSpace(s2)){
            return string.Empty;
        }
        int n=s1.Length;
        int m=s2.Length;
        int [,]dp=new int[n+1,m+1];
        
        for(int i=1;i<=n;i++){
            for(int j=1;j<=m;j++){
                if(s1[i-1]==s2[j-1]){
                    dp[i,j]=dp[i-1,j-1]+1;
                }
                else{
                    dp[i,j]=Math.Max(dp[i-1,j],dp[i,j-1]);
                }
            }
        }
        // return dp[n,m];
        StringBuilder lcs=new StringBuilder();
        int x=n,y=m;
        while(x>0&& y>0){
            if(s1[x-1]==s2[y-1]){
                lcs.Append(s1[x-1]);
                x--;
                y--;
            }
            else if(dp[x-1,y]>dp[x,y-1]){
                x--;
            }else{
                y--;
            }
        }
        char []arr=lcs.ToString().ToCharArray();
        Array.Reverse(arr);
        return new String(arr);
        
    }
  static void Main() {
    //  string input = "aaabbcccc";
    //  Console.WriteLine(GetRunEncode(input));
    // Console.WriteLine(LongestSubsequenceWithoutRepeatingCharacter(input));
    // string s1 = "abcde";
    // string s2 = "ace";

    // Console.WriteLine("LCS Length: " + LCSLength(s1, s2));
    
    string line;
    while(!string.IsNullOrEmpty(line=Console.ReadLine())){
        Console.WriteLine("You Have enterned: "+line);
    }
  }
}
