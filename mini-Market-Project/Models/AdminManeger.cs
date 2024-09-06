namespace mini_Market_Project;

public static class AdminManager
{
    public static void SignIn<T>(in string path) where T : Admin
    {
        Console.Write("Gmail:  ");
        string? gmail = Console.ReadLine();
        Console.Write("Password:  ");
        string? password = Console.ReadLine();


        try
        {
            if (!File.Exists(path))
                throw new FileNotFoundException(nameof(path));

            else
            {
                var jsonReadResult = DB.JsonRead<T>(path) ?? new List<T>();

                foreach (var item in jsonReadResult)
                {
                    if (item.GmailService.gmail == gmail || item.GmailService.password == password)
                    {
                        break;
                        throw new ArgumentException(nameof(item));
                    }
                    Console.WriteLine("Wrong");
                    return;
                }
            }
        }
        catch (FileNotFoundException fnfe)
        {
            Console.WriteLine($"{fnfe.Message}");
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine($"{ae.Message}");
        }




        //try
        //{
        //    _ = DB.JsonRead<T>(path)!.FirstOrDefault(a => a.GmailService.gmail == gmail && a.GmailService.password == password) is null ? throw new ArgumentNullException("Is null") : (object)null!;
        //}
        //catch (ArgumentNullException ane)
        //{
        //    Console.WriteLine($"{ane.Message}");
        //}

        #region Code
        //try
        //{
        //    if (!File.Exists(path)) throw new FileNotFoundException(nameof(path));
        //    else
        //    {
        //        var readJson = DB.JsonRead<T>(path)!.FirstOrDefault(a => a.GmailService.gmail == gmail && a.GmailService.password == password);

        //        if (readJson is null) throw new ArgumentNullException(nameof(readJson));

        //        return;
        //    }
        //}
        //catch (FileNotFoundException ex)
        //{
        //    Console.WriteLine($"{ex.Message}");
        //}
        //catch (ArgumentNullException ane)
        //{
        //    Console.WriteLine($"{ane.Message}");
        //}
        #endregion
    }

    public static void SignUp(in string jsonPath)
    {
        Console.Write("Name:  ");
        string? name = Console.ReadLine();
        Console.Write("Surname:  ");
        string? surname = Console.ReadLine();
        Console.Write("Gmail:  ");
        string? gmail = Console.ReadLine();
        Console.Write("Password:  ");
        string? password = Console.ReadLine();

        DB.JsonWrite(jsonPath, new Admin(name, surname, new GmailService(gmail, password)));
    }

    public static void HelpFunc()
    {
        Console.ReadKey();
        Console.Clear();
    }

    public static void ExitFunc()
    {
        Console.Clear();
        for (int i = 3; i >= 0; --i)
        {
            Console.Write("Second:  ");
            Console.Write($"{i}");
            Thread.Sleep(1000);
            Console.Clear();

            if (i == 0)
            {
                Console.WriteLine("Bye Bye...");
                Thread.Sleep(500);
            }
        }
    }
}