using System;
class HelloWorld {
public static int [,] MultiplyMatrix(int[,]A,int[,]B){
    int rowA=A.GetLength(0);
    int colA=A.GetLength(1);
    int rowB=B.GetLength(0);
    int colB=B.GetLength(1);
    
    int [,]C =new int[rowA,colB];
    if(colA!=rowB){
        return new int[0,0];
    }else{
        for(int i=0;i<rowA;i++){
            for(int j=0;j<colB;j++){
                C[i,j]=0;
                for(int k=0;k<colA;k++){
                    C[i,j]+=A[i,k]*B[k,j];
                }
            }
        }
    }
    return C;
}
  static void Main() {
    int[,] A={
        {1,2,3},
        {4,5,6}
    };
    int[,] B={
        {7,8},
        {9,10},
        {11,12}
    };
    
    int [,]result=MultiplyMatrix(A,B);
    Console.WriteLine("Result Matrix:"); for (int i = 0; i < result.GetLength(0); i++) { for (int j = 0; j < result.GetLength(1); j++) { Console.Write(result[i, j] + "\t"); } Console.WriteLine(); }
  }
}
