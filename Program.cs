// See https://aka.ms/new-console-template for more information
List<Product> products = new List<Product>()
{
      new Product()
    { 
        Name = "Football", 
        Price = 15.00M, 
        Sold = false,
        Condition = 4.2,
        StockDate = new DateTime(2022, 5, 20),
        ManufactureYear = 2010
    },
    new Product() 
    { 
        Name = "Hockey Stick", 
        Price = 12.50M, 
        Sold = false,
        Condition = 3.5,
        StockDate = new DateTime(2023, 4, 20),
        ManufactureYear = 2019
    },
    new Product()
    {
        Name = "Putter",
        Price = 10.00M,
        Sold = false,
        Condition = 4.0,
        StockDate = new DateTime(2020, 10, 20),
        ManufactureYear = 2018
    },
    new Product()
    {
        Name = "Driver",
        Price = 20.00M,
        Sold = true,
        Condition = 3.7,
        StockDate = new DateTime(2018, 10, 20),
        ManufactureYear = 2013
    },
    new Product()
    {
        Name = "Boxing Gloves",
        Price = 12.75M,
        Sold = true,
        Condition = 5.0,
        StockDate = new DateTime(2023, 7, 12),
        ManufactureYear = 2023
    },
    new Product()
    {
        Name = "Hockey Skates",
        Price = 17.50M,
        Sold = false,
        Condition = 3.2,
        StockDate = new DateTime(2022, 1, 20),
        ManufactureYear = 2021
    }
};

string greeting = @"Welcome to Thrown For a Loop
Your one-stop shop for used sporting equipment";

Console.WriteLine(greeting);
string? choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. View All Products
                        2. View Product Details
                        3. View Latest Products");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ListProducts();
    }
    else if (choice == "2")
    {
        ViewProductDetails();
    }
    else if (choice == "3")
    {
    ViewLatestProducts();
    }
}

void ViewProductDetails()
{
  ListProducts();

Product? chosenProduct = null;

while (chosenProduct == null)
{
    Console.WriteLine("Please enter a product number: ");
    try
    {
        int response = int.Parse(Console.ReadLine().Trim());
        chosenProduct = products[response - 1];
    }
    catch (FormatException)
    {
        Console.WriteLine("Please type only integers!");
    }
    catch (ArgumentOutOfRangeException)
    {
        Console.WriteLine("Please choose an existing item only!");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        Console.WriteLine("Do better!");
    }
}

DateTime now = DateTime.Now;
TimeSpan timeInStock = now - chosenProduct.StockDate;
Console.WriteLine(@$"You chose:
{chosenProduct.Name}, which costs {chosenProduct.Price} dollars.
It is {now.Year - chosenProduct.ManufactureYear} years old and is rated {chosenProduct.Condition} out of five in condition! It {(chosenProduct.Sold ? "is not available." : $"has been in stock for {timeInStock.Days} days.")}");

}

void ListProducts()
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        if (!product.Sold)
        {
            totalValue += product.Price;
        }
    }
    Console.WriteLine($"Total inventory value: ${totalValue}");
    Console.WriteLine("Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}

void ViewLatestProducts()
{
      // create a new empty List to store the latest products
    List<Product> latestProducts = new List<Product>();
    // Calculate a DateTime 90 days in the past
    DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90);
    //loop through the products
    foreach (Product product in products)
    {
        //Add a product to latestProducts if it fits the criteria
        if (product.StockDate > threeMonthsAgo && !product.Sold)
        {
            latestProducts.Add(product);
        }
    }
    // print out the latest products to the console 
    for (int i = 0; i < latestProducts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {latestProducts[i].Name}");
    }
}
