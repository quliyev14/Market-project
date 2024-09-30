namespace mini_Market_Project.Models;

public static class UserSystem
{
    public static void Sales(in string path)
    {
        SuperMarket.AllShow<Product>(path);
        Console.WriteLine("Secim edin");

        //pass
    }
}