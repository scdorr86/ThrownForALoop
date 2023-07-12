// See https://aka.ms/new-console-template for more information
string greeting = @"Welcome to Thrown For a Loop
Your one-stop shop for used sporting equipment";

Console.WriteLine(greeting);

List<Product> products = new List<Product>()
{
      new Product()
    { 
        Name = "Football", 
        Price = 15, 
        Sold = false,
        Condition = "fair",
        StockDate = new DateTime(2022, 5, 20),
        ManufactureYear = 2010
    },
    new Product() 
    { 
        Name = "Hockey Stick", 
        Price = 12, 
        Sold = false,
        Condition = "good",
        StockDate = new DateTime(2023, 4, 20),
        ManufactureYear = 2019
    },
    new Product()
    {
        Name = "Putter",
        Price = 10,
        Sold = false,
        Condition = "new",
        StockDate = new DateTime(2020, 10, 20),
        ManufactureYear = 2018
    },
    new Product()
    {
        Name = "Driver",
        Price = 20,
        Sold = false,
        Condition = "fair",
        StockDate = new DateTime(2018, 10, 20),
        ManufactureYear = 2013
    },
    new Product()
    {
        Name = "Boxing Gloves",
        Price = 12,
        Sold = false,
        Condition = "new",
        StockDate = new DateTime(2023, 7, 12),
        ManufactureYear = 2023
    },
    new Product()
    {
        Name = "Hockey Skates",
        Price = 17,
        Sold = false,
        Condition = "good",
        StockDate = new DateTime(2022, 1, 20),
        ManufactureYear = 2021
    }
};
Console.WriteLine("Products:");
for (int i = 0; i < products.Count; i++)
{
    Console.WriteLine($"{i + 1}. {products[i].Name}");
}
Console.WriteLine("Please enter a product number: ");
int response = int.Parse(Console.ReadLine().Trim());

while (response > products.Count || response < 1)
{
     Console.WriteLine("Choose a number between 1 and 5!");
     response = int.Parse(Console.ReadLine().Trim());
}

Product chosenProduct = products[response - 1];
DateTime now = DateTime.Now;
TimeSpan timeInStock = now - chosenProduct.StockDate;
Console.WriteLine(@$"You chose:
{chosenProduct.Name}, which costs {chosenProduct.Price} dollars.
It is {now.Year - chosenProduct.ManufactureYear} years old and is in {chosenProduct.Condition} condition! It {(chosenProduct.Sold ? "is not available." : $"has been in stock for {timeInStock.Days} days.")}");
Console.WriteLine($"this is the: {chosenProduct}");
