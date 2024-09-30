//#define Find
//#define Delete
using mini_Market_Project.Models;

namespace mini_Market_Project;

public static class SuperMarket
{
    public static void Add(in string path, in string logPath, Product product)
    {
        var budgetJsonReadresult = ProductCalcuationReceived.BudgetCalc(product.Count, (double)product.Price);

        if (budgetJsonReadresult is false)
            throw new ArgumentException(nameof(budgetJsonReadresult));
        else
            DB.JsonWrite<Product>(path, logPath, product);
    }

    //[Conditional("Delete")]
    public static void Delete(in string path, in string log, Product product)
    {
        AllShow<Product>(path);

        var jrr = DB.JsonRead<Product>(path) ?? new List<Product>();

        if (jrr is { })
            foreach (var i in jrr!)
            {
                if (i.Name == product.Name)
                {
                    jrr.Remove(i);
                    DB.JsonWrite<Product>(path, log, i);
                }
            }
        else
            Console.WriteLine();
    }

    public static void Edit(in string path)
    {

    }

    //[Conditional("Find")]
    public static void Find(in string path, string find)
    {
        var itemResult = DB.JsonRead<Product>(path)!.
                         Where(p => p.Name!.
                         Contains(find!)).
                         ToList(); // way 1
                                   //var itemResult2 = DB.JsonRead<Product>(path)!.Where(p => p.Name is not null && p.Name!.Contains(productName!)).ToList(); // way 2

        if (string.IsNullOrEmpty(itemResult.ToString())) throw new ArgumentException("Don't find."); //way 1
        //if (!itemResult.Any()) throw new ArgumentException("Don't find."); //way 2

        else
        {
            foreach (var i in itemResult)
                Console.WriteLine($"{i}");
        }
    }

    public static void AllShow<T>(in string path) => DB.JsonRead<T>(path)!.
                                                         ForEach(e => Console.WriteLine("{0}", e));

    public static double budget { get; set; } = 1000;
}