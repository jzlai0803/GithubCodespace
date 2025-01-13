//Expense 的資料庫操作類別
//這個類別是public
//這個類別的名稱是ExpenseContext
//這個類別的命名空間是ExpenseAPI.Models
//這個類別繼承自DbContext

using Microsoft.EntityFrameworkCore;

namespace ExpenseAPI.Models
{
    public class ExpenseContext : DbContext
    {
        public ExpenseContext(DbContextOptions<ExpenseContext> options)
            : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }
    }
}