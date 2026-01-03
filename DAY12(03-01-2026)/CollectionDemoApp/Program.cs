using System;
using System.Collections;
using Microsoft.VisualBasic;
internal class Program
{
  public static void Main()
  {
    // HashtableCollection();
    // SortedListCollection();
    StackCollection();
    // QueueCollection();
  }
  public static void Print(ICollection coll)
  {
    foreach (var item in coll)
    {
      Console.Write(item + " ");
    }
  }
  public static void HashtableCollection()
  {
    Hashtable ht = new Hashtable();
    ht.Add(1, "Kundan");
    ht.Add(2, "Kunal");
    ht.Add(3, "Romero");
    ICollection key = ht.Keys;
    Print(key);
    ICollection value = ht.Values;
    Print(value);

    if (ht.ContainsValue("kundan"))
    {
      Console.WriteLine("Yes it contain value ");
    }
    else
    {
      Console.WriteLine("Value not found");
    }
    Console.WriteLine("Enter the Key to search");
    int.TryParse(Console.ReadLine(), out int key1);
    if (ht.ContainsKey(key1))
    {
      Console.WriteLine($"{key1} found in hashtable");
    }
    else
    {
      Console.WriteLine($"{key1}not found");
    }
  }
  public static void SortedListCollection()
  {
    SortedList list = new SortedList();
    list.Add(500, "Kundan");
    list.Add(501, "Kunal");
    list.Add(502, "Kumar");
    list.Add(503, "Karthik");

    ICollection key = list.Keys;
    Console.WriteLine("All Keys are : ");
    Print(key);

    ICollection value = list.Values;
    Console.WriteLine("All Values are : ");
    Print(value);

    Console.WriteLine("All keys and values are");
    PrintKeysAndValue(list);

    Console.WriteLine($"Index of key 500: {list.IndexOfKey(500)}");
    list.Clear();
    Console.WriteLine("After Clear");
    Console.WriteLine("All Keys and values are : ");
    PrintKeysAndValue(list);

    Console.WriteLine($"Count of the {list.Count} : ");
  }
  public static void PrintKeysAndValue(IDictionary list)
  {
    foreach (DictionaryEntry entry in list)
    {
      Console.WriteLine($"Key :{entry.Key} , Value: {entry.Value}");
    }
  }

  public static void StackCollection()
  {
    Stack st = new Stack();
    st.Push('A');
    st.Push('B');
    st.Push('C');
    st.Push('D');
    st.Push('E');


    PrintStack(st);
    st.Push('G');
    st.Push('H');

    Console.WriteLine("Element are After Element insertion: ");
    PrintStack(st);

    Console.WriteLine($"Element at top is {st.Peek()}");

    st.Pop();//Remove H
    st.Pop();//Remove G
    st.Pop();//Remove F
    st.Pop();//Remove E

    Console.WriteLine("Element are After Element Removal: ");
    PrintStack(st);

    Console.WriteLine("Count is : " + st.Count);



    Console.WriteLine("Enter the element to Find");
    char ch = Convert.ToChar(Console.ReadLine());
    bool found = st.Contains('C');
    Console.Write("The value found : ");
    if (found)
    {
      Console.WriteLine(found);
      // st.Clear();
      Console.WriteLine("Stack Element After Clear : ");
      PrintStack(st);
      st.Clear();
      Console.WriteLine("Stack Element After Clear : ");
      PrintStack(st);
    }
  }
  public static void PrintStack(Stack stack)
  {
    foreach (var item in stack)
    {
      Console.WriteLine(item);
    }
  }
  public static void QueueCollection()
  {
    Queue queue = new Queue();
    queue.Enqueue('A');
    queue.Enqueue('B');
    queue.Enqueue('C');
    queue.Enqueue('D');
    Console.WriteLine("Queue Element are : ");
    PrintQueue(queue);

    queue.Dequeue();//Remove A
    queue.Dequeue();//Remove B
    Console.WriteLine("Queue Element are after Deque: ");
    PrintQueue(queue);

    Console.WriteLine($"front Element : {queue.Peek()}");//Peek shows the first item but does not remove it.
    Console.WriteLine("Count is :" + queue.Count);
    queue.Clear();
    Console.WriteLine("After Clear : ");
    PrintQueue(queue);
  }
  public static void PrintQueue(Queue queue)
  {
    foreach (var q in queue)
    {
      Console.Write(q + " ");
    }
  }

}