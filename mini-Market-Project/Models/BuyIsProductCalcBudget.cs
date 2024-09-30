namespace mini_Market_Project.Models;

public static class ProductCalcuationReceived
{
    public static bool BudgetCalc(int count, double price) => count * price <= SuperMarketBudget.budget ? true : false;
}
