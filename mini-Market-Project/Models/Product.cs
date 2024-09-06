namespace mini_Market_Project;

public class Product
{
    private static int ID = 0;

    public Product() { Id = ID++; }

    public Product(string? name, string? code, int count, float price)
    {
        Id = ID++;
        Name = name;
        Code = code;
        Count = count;
        Price = price;
    }

    public int Id { get; set; } = default!;
    public string? Name { get; set; } = default!;
    public string? Code { get; set; } = default!;
    public int Count { get; set; } = default!;
    public float Price { get; set; } = default!;

    public override string ToString() => $"{Id} {Name} {Code} {Count} {Price}";
}