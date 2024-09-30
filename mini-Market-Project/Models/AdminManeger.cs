namespace mini_Market_Project;

public static partial class AdminManeger
{
    public static bool SignIn<T>(in string path, GmailService gmailService) where T : Admin
    {
        if (!File.Exists(path))
            throw new FileNotFoundException(nameof(path));
        else
        {
            var jrr = DB.JsonRead<T>(path)!.Where(l => l.GmailService != null && l.GmailService.gmail == gmailService.gmail && l.GmailService.password == gmailService.password);
            if (jrr is not null)
            {
                foreach (var i in jrr) 
                {
                    Console.WriteLine("Sign in successful");
                    return true;
                }
            }
            AdminManeger.HelpFunc();
            return false;
        }
    }

    [Obsolete("This method is work cannot", true)]
    public static void SignUp(in string path, in string logPath, Admin obj) => DB.JsonWrite(path, logPath, obj);

    public static void SignUp<T>(in string path, in string logPath, T obj)
    {
        if (obj is null)
            throw new ArgumentException(nameof(obj));
        else
            DB.JsonWrite<T>(path, logPath, obj);
    }
}

public static partial class AdminManeger
{
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