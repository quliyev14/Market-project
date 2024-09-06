//#define Find
//#define Delete
namespace mini_Market_Project;

public static class SuperMarket
{
    [Obsolete("This Method is work cannot", true)]
    public static void ADD(in string jsonPath, in string logPath)
    {
        Console.Write("Product code:  ");
        string? productCode = Console.ReadLine();
        Console.Write("Product name:  ");
        string? productName = Console.ReadLine();
        Console.Write("Product count:  ");
        string? productCount = Console.ReadLine();
        int count = Convert.ToInt32(productCount);
        Console.Write("Product price:  ");
        string? productPrice = Console.ReadLine();

        try
        {
            if (float.TryParse(productPrice, out float price))
            {
                if (count * price >= budget) throw new Exception(nameof(budget));
                else
                {
                    var product = new Product(productName, productCode, count, price);
                    DB.JsonWrite<Product>(jsonPath, product);
                    DB.ProductWriteLog(logPath, product);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Add(in string jsonPath, in string logPath)
    {
        Console.Write("Product code:  ");
        string? productCode = Console.ReadLine();
        Console.Write("Product name:  ");
        string? productName = Console.ReadLine();
        Console.Write("Product count:  ");
        string? productCount = Console.ReadLine();
        int count = Convert.ToInt32(productCount);
        Console.Write("Product price:  ");
        string? productPrice = Console.ReadLine();

        if (float.TryParse(productPrice, out float price))
        {
            if (count * price >= budget) throw new Exception(nameof(budget));
            else
            {
                var product = new Product(productName, productCode, count, price);
                DB.JsonWrite<Product>(jsonPath, product);
                DB.ProductWriteLog(logPath, product);
            }
        }
    }

    //[Conditional("Delete")]
    public static void Delete(in string jsonPath)
    {
        Console.Write("Product name:  ");
        string? productName = Console.ReadLine();

        if (string.IsNullOrEmpty(productName)) throw new ArgumentNullException(nameof(productName));
        else
        {
            var result = DB.JsonRead<Product>(jsonPath)!.FirstOrDefault(p => p.Name == productName);
            if (result is null) throw new ArgumentNullException(nameof(result));

            else DB.JsonWrite(jsonPath, DB.JsonRead<Product>(jsonPath)!.Remove(result));
        }
    }

    //[Conditional("Find")]
    public static void Find(in string path)
    {
        Console.Write("Product name:  ");
        string? productName = Console.ReadLine();

        try
        {
            var result = DB.JsonRead<Product>(path)!.FirstOrDefault(p => p.Name == productName);
            if (result is null) throw new ArgumentNullException(nameof(result));
            else Console.WriteLine($"{result}");
        }
        catch (ArgumentNullException ane)
        {
            Console.WriteLine(ane.Message);
        }
    }

    public static void AllShowProduct(in string path) => DB.JsonRead<Product>(path)!.ForEach(j => Console.WriteLine("{0} {1} {2}", j.Id, j.Name, j.Count));

    public static float budget { get; set; } = 1000;
}