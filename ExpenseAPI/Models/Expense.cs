// 這是一筆支出Entity (支出資料表的資料結構)
// 這個Entity的欄位有Id, Amount, Date, Description, Category
// Id是支出的唯一識別碼，整數，自動增加
// Amount是支出的金額，浮點數   
// Date是支出的日期，日期時間
// Description是支出的說明，字串
// Category是支出的類別，字串 
// 這個Entity的類別是public
// 這個Entity的名稱是Expense
// 這個Entity的命名空間是ExpenseAPI.Models
// 這個Entity有5個欄位 

namespace ExpenseAPI.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
    }
}