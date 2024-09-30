using mini_Market_Project.Exceptions;

namespace mini_Market_Project;

public class Product
{
    private static int ID = 0;

    public Product() { Id = Interlocked.Increment(ref ID); }

    public Product(string? name, string? code, int count, decimal price)
    {
        if (count < 0) throw new InvalidProductException("The number is less than zero");
        if (price < 0) throw new InvalidProductException("The price is less than zero");

        Id = Interlocked.Increment(ref ID);
        Name = name;
        Code = code;
        Count = count;
        Price = price;
    }

    public int Id { get; private set; } = default!;
    public string? Name { get; set; } = default!;
    public string? Code { get; set; } = default!;
    public int Count { get; set; } = default!;
    public decimal Price { get; set; } = default!;

    public override string ToString() => $"{Id} {Name} {Code} {Count} {Price}";

}