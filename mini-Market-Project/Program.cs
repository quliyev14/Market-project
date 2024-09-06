global using System;
global using System.Text;
global using System.Text.Json;
using mini_Market_Project;
using mini_Market_Project.Models;

internal class Program
{
    public static void Main(string[] args)
    {
        string? pathAccount = "adminaccount.json";
        string? path = "products.json";
        string? pathLog = "run.log";
        bool isSignedIn = false;
        bool found = false;

        Console.ForegroundColor = ConsoleColor.DarkGreen;

        while (true)
        {
            Console.WriteLine("1. Admin \n2. User");
            string? mainChoice = Console.ReadLine();
             
            if (!found)
            {
                if (mainChoice == "1")
                {
                    Console.Clear();
                    if (!isSignedIn)
                    {
                        Console.WriteLine("1. Sign in \n2. Sign up \n0. Exit");
                        string? choiceMain = Console.ReadLine();

                        if (choiceMain == "1")
                        {
                            Console.Clear();
                            AdminManager.SignIn<Admin>(in pathAccount);
                            isSignedIn = true;
                        }

                        else if (choiceMain == "2")
                        {
                            Console.Clear();
                            AdminManager.SignUp(in pathAccount);
                            Console.Clear();
                        }

                        else if (choiceMain == "0")
                        {
                            AdminManager.ExitFunc();
                            break;
                        }
                        else Console.Clear();
                    }

                    if (isSignedIn)
                    {
                        Console.Clear();
                        Console.WriteLine("1. Add \n2. Delete \n3. Find \n4. All Show Product \n5. Log Out");
                        string? choiceThree = Console.ReadLine();
                        Console.Clear();

                        switch (choiceThree)
                        {
                            case "1":
                                SuperMarket.Add(in path, pathLog);
                                AdminManager.HelpFunc();
                                break;
                            case "2":
                                SuperMarket.Delete(in path);
                                AdminManager.HelpFunc();
                                break;
                            case "3":
                                SuperMarket.Find(in path);
                                AdminManager.HelpFunc();
                                break;
                            case "4":
                                SuperMarket.AllShowProduct(in path);
                                AdminManager.HelpFunc();
                                break;
                            case "5":
                                isSignedIn = false;
                                AdminManager.HelpFunc();
                                break;
                            default:
                                break;
                        }
                    }
                }

                else if (mainChoice == "2")
                {
                    AdminManager.HelpFunc();

                    Console.WriteLine("1. Sales  \n2. Looking at what they bought \n[1,2] Another Any button in press. Log out");
                    string? userChoice = Console.ReadLine();

                    if (userChoice == "1")
                    {
                        UserSystem.Sales(in path);
                        AdminManager.HelpFunc();
                    }
                    else if (userChoice == "2")
                    {
                        AdminManager.HelpFunc();
                    }
                    found = false;
                    AdminManager.HelpFunc();
                }
            }
        }
    }
}