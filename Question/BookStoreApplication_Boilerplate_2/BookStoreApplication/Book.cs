using System;

namespace BookStoreApplication
{
    public class Book
    {
        // TODO: Create public properties
        // Id -> string
        // Title -> string
        // Author -> string (Optional)
        // Price -> int
        // Stock -> int
        public string  Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }

        public Book(string id, string title, int price, int stock, string author="Optional")
        {
            this.Author = author;
            this.Id = id;
            this.Price = price;
            this.Stock = stock;
            this.Title = title;
        }

    }
}
