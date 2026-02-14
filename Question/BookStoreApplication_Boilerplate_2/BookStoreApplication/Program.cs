using System;
using System.Runtime.InteropServices.Marshalling;

namespace BookStoreApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO:
            // 1. Read initial input
            // Format: BookID Title Price Stock
            
            string detail= Console.ReadLine();
            string[] result = detail.Split(' ');

            int.TryParse(result[2], out int Price);
            int.TryParse(result[3], out int Stock);

            Book book = result.Length > 4 
                ? new Book(result[0], result[1], Price, Stock, result[4]) 
                : new Book(result[0], result[1], Price, Stock);

            BookUtility utility = new BookUtility(book);

            while (true)
            {
                Console.WriteLine("1 -> Display book details");
                Console.WriteLine("2 -> Update book price");
                Console.WriteLine("3 -> Update book stock");
                Console.WriteLine("4 -> Exit");

                int.TryParse(Console.ReadLine(), out int choice);

                switch (choice)
                {
                    case 1:
                        utility.GetBookDetails();
                        break;

                    case 2:
                        // TODO:
                        // Read new price
                        int.TryParse(Console.ReadLine(), out int newPrice);
                       utility.UpdateBookPrice(newPrice);
                        break;

                    case 3:
                        // TODO:
                        // Read new stock
                        // Call UpdateBookStock
                        int.TryParse(Console.ReadLine(), out int newStock);
                        utility.UpdateBookStock(newStock);
                        break;

                    case 4:
                        Console.WriteLine("Thank You");
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
