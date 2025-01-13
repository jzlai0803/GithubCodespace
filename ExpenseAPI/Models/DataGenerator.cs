// 使用ExpenseContext 來產生預設資料

using ExpenseAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace ExpenseAPI.Models
{
    public static class DataGenerator
    {
        public static void Initialize(ExpenseContext context)
        {
            if(context.Expenses.Any())
            {
                return;
            }

              //產生4筆資料, Category 要分別有食、衣、住、行
            context.Expenses.AddRange(
                new Expense
                {
                    Amount = 100,
                    Date = new System.DateTime(2021, 1, 1),
                    Description = "早餐",
                    Category = "食"
                },
                new Expense
                {
                    Amount = 200,
                    Date = new System.DateTime(2021, 1, 1),
                    Description = "衣服",
                    Category = "衣"
                },
                new Expense
                {
                    Amount = 300,
                    Date = new System.DateTime(2021, 1, 1),
                    Description = "房租",
                    Category = "住"
                },
                new Expense
                {
                    Amount = 400,
                    Date = new System.DateTime(2021, 1, 1),
                    Description = "機票",
                    Category = "行"
            }
            );   

            context.SaveChanges();
        }
    }
}