global using System;

namespace mini_Market_Project.Models
{
    public static class MainDisplay
    {
        public static void StartMenu()
        {
            string? pathAccount = "adminaccount.json";
            string? productPath = "products.json";
            string? marketBudgetPath = "marketBudget.json";
            string? pathLog = "run.log";

            var product = new Product("sugar", "#012989812", 100, 1.8m);

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            //SuperMarket.Delete(productPath, pathLog, product);
            AdminManeger.SignIn<Admin>(pathAccount, new GmailService("admin", "admin"));

            //SuperMarket.Add(productPath, pathLog, product);
            //SuperMarket.AllShow<Product>(productPath);
            //SuperMarket.Find(productPath, "b");

            Console.ReadKey();

            #region Main

            //    while (true)
            //    {
            //        Console.WriteLine("1. Admin \n2. User");
            //        string? mainChoice = Console.ReadLine();

            //        if (!found)
            //        {
            //            if (mainChoice == "1")
            //            {
            //                Console.Clear();
            //                if (!isSignedIn)
            //                {
            //                    Console.WriteLine("1. Sign in \n2. Sign up \n0. Exit");
            //                    string? choiceMain = Console.ReadLine();

            //                    if (choiceMain == "1")
            //                    {
            //                        Console.Clear();
            //                        isSignedIn = AdminManager.SignIn<Admin>(in pathAccount);
            //                    }

            //                    else if (choiceMain == "2")
            //                    {
            //                        Console.Clear();
            //                        AdminManager.SignUp(in pathAccount);
            //                        Console.Clear();
            //                    }

            //                    else if (choiceMain == "0")
            //                    {
            //                        AdminManager.ExitFunc();
            //                        break;
            //                    }
            //                    else Console.Clear();
            //                }

            //                if (isSignedIn)
            //                {
            //                    Console.Clear();
            //                    Console.WriteLine("1. Add \n2. Delete \n3. Find \n4. All Show Product \n5. Log Out");
            //                    string? choiceThree = Console.ReadLine();
            //                    Console.Clear();

            //                    switch (choiceThree)
            //                    {
            //                        case "1":
            //                            SuperMarket.Add<Product, SuperMarketBudget>(in productPath, marketBudgetPath, pathLog,product);
            //                            AdminManager.HelpFunc();
            //                            break;
            //                        case "2":
            //                            SuperMarket.Delete();
            //                            AdminManager.HelpFunc();
            //                            break;
            //                        case "3":
            //                            SuperMarket.Find(in productPath);
            //                            AdminManager.HelpFunc();
            //                            break;
            //                        case "4":
            //                            SuperMarket.AllShowProduct(in productPath);
            //                            AdminManager.HelpFunc();
            //                            break;
            //                        case "5":
            //                            isSignedIn = false;
            //                            AdminManager.HelpFunc();
            //                            break;
            //                        default:
            //                            break;
            //                    }
            //                }
            //            }

            //            else if (mainChoice == "2")
            //            {
            //                AdminManager.HelpFunc();

            //                Console.WriteLine("1. Sales  \n2. Looking at what they bought \n[1,2] Another Any button in press. Log out");
            //                string? userChoice = Console.ReadLine();

            //                if (userChoice == "1")
            //                {
            //                    UserSystem.Sales(in productPath);
            //                    AdminManager.HelpFunc();
            //                }
            //                else if (userChoice == "2")
            //                {
            //                    AdminManager.HelpFunc();
            //                }
            //                found = false;
            //                AdminManager.HelpFunc();
            //            }
            //        }
            //    }
            //}
            #endregion

        }
    }
}