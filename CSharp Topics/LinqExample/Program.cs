using LinqExample;

List<Product> products = new List<Product>
{
    new Product {ProductId = 1, ProductName = "Laptop", Price = 15000},
    new Product {ProductId = 2, ProductName = "Desktop", Price = 20000},
    new Product {ProductId = 3, ProductName = "Tablet", Price = 10000},
    new Product {ProductId = 4, ProductName = "Smartphone", Price = 5000},
    new Product {ProductId = 5, ProductName = "Monitor", Price = 7000},
    new Product {ProductId = 6, ProductName = "Keyboard", Price = 2000},
    new Product {ProductId = 7, ProductName = "Mouse", Price = 1500},
    new Product {ProductId = 8, ProductName = "Printer", Price = 8000},
    new Product {ProductId = 9, ProductName = "Scanner", Price = 6000},
    new Product {ProductId = 10, ProductName = "External Hard Drive", Price = 12000}
};

List<Order> orders = new List<Order>
{
    new Order { OrderID = "O1", CustomerID = 1, Products = new List<Product> { products[0], products[1], products[3], products[4] } },
    new Order { OrderID = "O2", CustomerID = 2, Products = new List<Product> { products[1], products[5], products[6], products[7] } },
    new Order { OrderID = "O3", CustomerID = 1, Products = new List<Product> { products[2], products[8], products[9] } }
};



List<Customer> customers = new List<Customer>
{
    new Customer { CustomerID = 1, CustomerName = "Alice" },
    new Customer { CustomerID = 2, CustomerName = "Bob" }
};

var result = from order in orders
             join customer in customers on order.CustomerID equals customer.CustomerID
             select new
             {
                 OrderID = order.OrderID,
                 CustomerName = customer.CustomerName,
                 ProductCount = order.Products.Count,
                 ProductName = string.Join(", ", order.Products.Select(p => p.ProductName)),
                 TotalPrice = order.Products.Sum(p => p.Price)
             };

Console.WriteLine(string.Join("\n", result));


Console.WriteLine();
// Groupby example
int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

var groupedNumbers = from number in numbers
                     group number by number % 2 == 0 into g
                     select (IsEven: g.Key, Numbers: g.ToList()); // This is a Tuple with named elements

foreach (var group in groupedNumbers)
{
    Console.WriteLine($"IsEven: {group.IsEven}");
    Console.WriteLine($"Numbers: {string.Join(", ", group.Numbers)}");
    Console.WriteLine();
}
