using System;
namespace Week2Practice
{
  public class Program
  {
    public static void Main()
    {
      Program program = new Program();
      //Queston 1
      // int []arr=program.ReturnArray();
      // program.PrintArray(arr);

      //Question 2
      // int []arr=program.ReturnArray();
      // program.ReverseArray(arr);

      //Question 3
      // int[] arr = program.ReturnArray();
      // program.sumOfArray(arr);

      //Queston 4
      // int[] arr = program.ReturnArray();
      // Console.WriteLine("Array Element Before copy : \n");
      // program.PrintArray(arr);
      // int [] returnedArray=program.CopyArray(arr);
      // Console.WriteLine();
      // Console.WriteLine("Array Element After copy : ");
      // program.PrintArray(returnedArray);

      //  int [] source={1,2,3,4,5,6};
      //  int [] destination=new int[source.Length];
      //  Array.Copy(source,destination,arr.Length);

      //Question 5 
      //  int[] arr = program.ReturnArray();
      // Console.WriteLine($"Count of duplicate Element : {program.CountDuplicate(arr)}");

      //Queston 6
      // int[] arr = program.ReturnArray();
      // Console.WriteLine($"Unique Element : \n");
      // program.AllUniqueElement(arr);
      // program.PrintArray(arr);
      // Console.WriteLine($"Count of Unique Element : {arr.Distinct().Count()}");
      // program.PrintArray(arr.Distinct());


      //Questoin 7
      // int [] arr= program.ReturnArray();
      // program.PrintFrequency(arr);

      //Queston 9
      // int []arr=program.ReturnArray();
      // program.FindMaxMin(arr,out int min,out int max);
      // Console.WriteLine($"max : {max}, min : {min}");

      //Queston 10
      // int[] arr = program.ReturnArray();
      // program.EvenOddElement(arr,out int [] odd,out int []even);
      // program.PrintArray(odd);
      // Console.WriteLine();
      // program.PrintArray(even);

      //Question 11
      // int[] arr = program.ReturnArray();
      // Array.Sort(arr);
      // Console.WriteLine("Elements of array in sorted ascending order: ")
      // program.PrintArray();

      //Question 12
      // int[] arr = program.ReturnArray();
      // var result = arr.OrderByDescending(x=>x).ToArray();
      // program.PrintArray(result);

      //Question 13
      // int[] arr = program.ReturnArray();
      // Array.Sort(arr);
      // var result = program.AddElement(arr);
      // program.PrintArray(result);

      //Question 14
      // int[] arr = program.ReturnArray();
      // Console.WriteLine("Enter the position which you want to insert: ");
      // int.TryParse(Console.ReadLine(), out int position);
      // Console.WriteLine("Enter the value which you want to insert: ");
      // int.TryParse(Console.ReadLine(), out int value);
      // var result = program.AddElementAtPos(arr, position, value);
      // Console.WriteLine("The current list of the array :");
      // program.PrintArray(arr);
      // Console.WriteLine("\nAfter Insert the element the new list is :");
      // program.PrintArray(result);

      //question 15
      int[] arr = program.ReturnArray();
      Console.WriteLine("Enter the position which you want to delete: ");
      int.TryParse(Console.ReadLine(), out int position);
      Console.WriteLine("The current list of the array :");
      program.PrintArray(arr);
      var result = program.DeleteElementAtPos(arr, position);
      Console.WriteLine("\nAfter Insert the element the new list is :");
      program.PrintArray(result);



    }

      public int [] DeleteElementAtPos(int[] arr,int position)
    {
      int[] ExtendedArray = new int[arr.Length -1];

      for (int i = 0; i < position - 1; i++)
      {
        ExtendedArray[i] = arr[i];
      }

      for (int i = position - 1; i < arr.Length-1; i++)
      {
        ExtendedArray[i] = arr[i+1];
      }
      return ExtendedArray;

    }
      public int[] AddElement(int[] arr)
    {
      int[] ExtendedArray = new int[arr.Length + 1];
      Console.WriteLine("Enter the element which you want to insert: ");
      int.TryParse(Console.ReadLine(), out int value);
      for (int i = 0; i < arr.Length; i++)
      {
        ExtendedArray[i] = arr[i];
      }
      ExtendedArray[arr.Length] = value;
      return ExtendedArray;
    }
    public int[] AddElementAtPos(int[] arr, int position, int value)
    {
      int[] ExtendedArray = new int[arr.Length + 1];

      for (int i = 0; i < position - 1; i++)
      {
        ExtendedArray[i] = arr[i];
      }

      ExtendedArray[position - 1] = value;

      for (int i = position - 1; i < arr.Length; i++)
      {
        ExtendedArray[i + 1] = arr[i];
      }
      return ExtendedArray;
    }
    public int[] ReturnArray()
    {
      Console.WriteLine("Enter the value of array size");
      int n = Convert.ToInt32(Console.ReadLine());
      int[] arr = new int[n];
      for (int i = 0; i < n; i++)
      {
        arr[i] = Convert.ToInt32(Console.ReadLine());
      }
      return arr;
    }
    public void PrintArray(int[] arr)
    {
      // Console.WriteLine("Array Element are: ");
      for (int i = 0; i < arr.Length; i++)
      {
        Console.Write(arr[i] + " ");
      }
    }
    public void ReverseArray(int[] arr)
    {
      Console.WriteLine("Array Element are: ");
      for (int i = arr.Length - 1; i >= 0; i--)
      {
        Console.Write(arr[i] + " ");
      }

    }

    public int[] ReturnSwapArray(int[] arr)

    {
      int left = 0;
      int right = arr.Length - 1;
      while (left < right)
      {
        Swap(ref arr[left], ref arr[right]);
        left++;
        right--;
      }
      return arr;
    }
    public static void Swap<T>(ref T a, ref T b)
    {
      T temp = a;
      a = b;
      b = temp;
    }
    public int sumOfArray(int[] arr)
    {
      int sum = 0;
      foreach (var item in arr)
      {
        sum += item;
      }
      return sum;
    }


    public int[] CopyArray(int[] arr)
    {
      int[] result = new int[arr.Length];
      for (int i = 0; i < arr.Length; i++)
      {
        result[i] = arr[i];
      }
      return result;
    }
    public int CountDuplicate(int[] arr)
    {
      int count = 0;
      for (int i = 0; i < arr.Length; i++)
      {
        for (int j = i + 1; j < arr.Length; j++)
        {
          if (arr[i] == arr[j])
          {
            count++;
          }
        }
      }
      return count;
    }
    public void AllUniqueElement(int[] arr)
    {
      for (int i = 0; i < arr.Length; i++)
      {
        int flag = 1;
        for (int j = 0; j < arr.Length; j++)
        {
          if (i == j) continue;
          if (arr[i] == arr[j])
          {
            flag = 0;
            break;
          }
        }
        if (flag == 1)
        {
          Console.Write(arr[i] + " ");
        }
      }
    }
    public void PrintFrequency(int[] arr)
    {
      bool[] visited = new bool[arr.Length];
      for (int i = 0; i < arr.Length; i++)
      {
        if (visited[i]) continue;
        int count = 1;
        for (int j = i + 1; j < arr.Length; j++)
        {
          if (!visited[j] && arr[i] == arr[j])
          {
            visited[j] = true;
            count++;
          }
        }
        Console.Write($"{arr[i]} : {count}\n");
      }
    }

    public void FindMaxMin(int[] arr, out int min, out int max)
    {
      min = arr[0];
      max = arr[0];
      for (int i = 0; i < arr.Length; i++)
      {
        if (arr[i] > max)
        {
          max = arr[i];
        }
        else if (arr[i] < min)
        {
          min = arr[i];
        }
      }
    }
    public void EvenOddElement(int[] arr, out int[] odd, out int[] even)
    {

      List<int> oddList = new List<int>();
      List<int> evenList = new List<int>();

      for (int i = 0; i < arr.Length; i++)
      {
        if ((arr[i] & 1) == 0)
        {
          evenList.Add(arr[i]);
        }
        else
        {
          oddList.Add(arr[i]);
        }
      }

      odd = oddList.ToArray();
      even = evenList.ToArray();
    }

  }
}