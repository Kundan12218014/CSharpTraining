using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace E_CommerceOrderManagementSystem02
{

    public class OutOfStockException : Exception
    {
        public OutOfStockException(string msg) : base(msg) { }
    }

    public class OrderAlreadyShippedException : Exception
    {
        public OrderAlreadyShippedException(string msg) : base(msg) { }
    }

    public class CustomerBlacklistedException : Exception
    {
        public CustomerBlacklistedException(string msg) : base(msg) { }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Product(int id, string name, decimal price, int stock)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }
    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsBlacklisted { get; set; }
        public Customer(int id,string name,bool blacklisted = false)
        {
            Id = id;
            Name = name;
            IsBlacklisted = blacklisted;
        }
    }

    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }


        public OrderItem(Product product,int qty)
        {
            Product = product;
            Quantity = qty;
        }
        public decimal TotalPrice()
        {
            return Product.Price * Quantity;
        }
    }

    public enum OrderStatus
    {
        Pending,
        Shipped,
        Cancelled
    }

    public class Order
    {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItem> Item { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public decimal FinalAmount { get; set; }
        public Order (int id,Customer customer)
        {
            OrderId = id;
            Customer = customer;
            Item = new List<OrderItem>();
            OrderDate = DateTime.Now;
            Status = OrderStatus.Pending;
        }

        public decimal CalculateTotal()
        {
            return Item.Sum(i => i.TotalPrice());
        }
        public void ApplyDiscount(IDiscountStrategy strategy)
        {
            FinalAmount = strategy.ApplyDiscount(CalculateTotal());
        }
        public void Cancel()
        {
            if (Status == OrderStatus.Shipped)
                throw new OrderAlreadyShippedException("Order already shipped");
            Status = OrderStatus.Cancelled;
            foreach(var item in Item)
            {
                item.Product.Stock += item.Quantity;
            }
        }
    }
    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(decimal totalAmount);
    }
    public class PercentageDiscount: IDiscountStrategy
    {
        private decimal percentage;
        public PercentageDiscount(decimal percent)
        {
            percentage = percent;
        }
        public decimal ApplyDiscount(decimal totalAmount)
        {
            return totalAmount - (totalAmount * percentage / 100);
        }
    }

    public class FlatDiscount: IDiscountStrategy
    {
        private decimal flatAmount;
        public FlatDiscount(decimal amount)
        {
            flatAmount = amount;
        }
        public decimal ApplyDiscount(decimal totalAmount)
        {
            return totalAmount - flatAmount;
        }
    }

    public class FestivalDiscount:IDiscountStrategy{
            public decimal ApplyDiscount(decimal totalAmount)
        {
            return totalAmount * 0.85m;
        }
    }
    public class OrderManager
    {
        public List<Product> Products = new List<Product>();
        public Dictionary<int, Product> ProductDictionary = new Dictionary<int, Product>();
        public List<Customer> Customers = new List<Customer>();
        public List<Order> Orders = new List<Order>();
        public void AddProduct(Product product)
        {
            Products.Add(product);
            ProductDictionary[product.Id] = product;
        }
        public void PlaceOrder(Order order)
        {
            if (order.Customer.IsBlacklisted)
            {
                throw new CustomerBlacklistedException("Customer is blackListed");
            }
            foreach(var item in order.Item)
            {
                if (item.Product.Stock < item.Quantity)
                {
                    throw new OutOfStockException("Insufficient stock for {item.Product.Name");
                }
                item.Product.Stock -= item.Quantity;
            }

            Orders.Add(order);
        }
        public void RunLINQQueries()
        {
            Console.WriteLine("\nOrders in last 7 days:");
            var recent = Orders.Where(o => o.OrderDate >= DateTime.Now.AddDays(-7));
            foreach (var o in recent)
                Console.WriteLine(o.OrderId);

            Console.WriteLine("\nTotal Revenue:");
            Console.WriteLine(Orders.Sum(o => o.FinalAmount));

            Console.WriteLine("\nMost Sold Product:");
            var mostSold = Orders
                .SelectMany(o => o.Item)
                .GroupBy(i => i.Product.Name)
                .OrderByDescending(g => g.Sum(i => i.Quantity))
                .FirstOrDefault();

            Console.WriteLine(mostSold?.Key);

            Console.WriteLine("\nTop 5 Customers:");
            var topCustomers = Orders
                .GroupBy(o => o.Customer.Name)
                .OrderByDescending(g => g.Sum(o => o.FinalAmount))
                .Take(5);

            foreach (var c in topCustomers)
                Console.WriteLine(c.Key);

            Console.WriteLine("\nGroup Orders By Status:");
            var grouped = Orders.GroupBy(o => o.Status);
            foreach (var g in grouped)
                Console.WriteLine(g.Key + " : " + g.Count());

            Console.WriteLine("\nLow Stock Products:");
            var lowStock = Products.Where(p => p.Stock < 10);
            foreach (var p in lowStock)
                Console.WriteLine(p.Name);
        }
    }
    class Program
    {
        static void Main()
        {
            var manager = new OrderManager();

            var p1 = new Product(1, "Laptop", 60000, 20);
            var p2 = new Product(2, "Phone", 30000, 5);

            manager.AddProduct(p1);
            manager.AddProduct(p2);

            var c1 = new Customer(1, "Rahul");
            manager.Customers.Add(c1);

            var order = new Order(101, c1);
            order.Item.Add(new OrderItem(p1, 1));
            order.Item.Add(new OrderItem(p2, 1));

            order.ApplyDiscount(new PercentageDiscount(10));

            manager.PlaceOrder(order);

            manager.RunLINQQueries();
        }
    }

}
