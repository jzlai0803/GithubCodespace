 
 


using Xunit;
using Microsoft.EntityFrameworkCore;
using ExpenseAPI.Models;
using ExpenseAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseAPITest;

//  這是測試 ExpenseAPI\Controllers\ExpenseController.cs 的單元測試
//  使用 InMemoryDatabase 來測試
//  這個測試會測試 ExpenseController.cs 的 GetExpenses 方法
// 使用ExpenseAPI\Models\Expense.cs 和 ExpenseAPI\Models\ExpenseContext.cs
//  AAA 模式
// 每個方法測試，有三個測試案例，分別是正常，異常，邊界

/// <summary>
/// 這是測試 ExpenseAPI\Controllers\ExpenseController.cs 的單元測試
/// 使用 InMemoryDatabase 來測試
/// 這個測試會測試 ExpenseController.cs 的 GetExpenses 方法
/// 使用ExpenseAPI\Models\Expense.cs 和 ExpenseAPI\Models\ExpenseContext.cs
/// AAA 模式
/// 每個方法測試，有三個測試案例，分別是正常，異常，邊界
/// 這個測試會測試 GetExpenses 方法
/// 這個測試會測試 GetExpenses 方法的異常情況
/// 這個測試會測試 GetExpenses 方法的邊界情況
/// 這個測試會測試 GetExpenses 方法的正常情況
/// 
/// </summary>
/// <remarks>
/// 這是測試 ExpenseAPI\Controllers\ExpenseController.cs 的單元測試
/// 使用 InMemoryDatabase 來測試
/// 這個測試會測試 ExpenseController.cs 的 GetExpenses 方法
/// 使用ExpenseAPI\Models\Expense.cs 和 ExpenseAPI\Models\ExpenseContext.cs
/// AAA 模式
/// 每個方法測試，有三個測試案例，分別是正常，異常，邊界
/// </remarks>
/// <example>
/// 這是測試 GetExpenses 方法的單元測試
/// <code>
/// [Fact]
/// public async Task GetExpensesTest()
/// {
///    // Arrange
///    var options = new DbContextOptionsBuilder<ExpenseContext>()
///     
///     .UseInMemoryDatabase(databaseName: "GetExpensesTest")
///     .Options;
///     using (var context = new ExpenseContext(options))
///     {
///     context.Expenses.Add(new Expense
///     {
///     Id = 1,
///     Description = "Test1",
///     Amount = 10.0F,
///     Date = DateTime.Now
///     });
///     context.Expenses.Add(new Expense
///     {
///     Id = 2,
///     Description = "Test2",
///     Amount = 20.0F,
///     Date = DateTime.Now
///     });
///     context.SaveChanges();
///     }
///     using (var context = new ExpenseContext(options))
///     {
///     var controller = new ExpenseController(context);
///     // Act
///     var result = await controller.GetExpenses();
///     // Assert
///     var actionResult = Assert.IsType<ActionResult<IEnumerable<Expense>>>(result);
///     var model = Assert.IsAssignableFrom<IEnumerable<Expense>>(actionResult.Value);
///     Assert.Equal(2, model.Count());
///     context.SaveChanges();
///     }
///     using (var context = new ExpenseContext(options))
///     {   
///     var controller = new ExpenseController(context);
///     // Act
///     var result = await controller.GetExpenses();
///     // Assert
///     var actionResult = Assert.IsType<ActionResult<IEnumerable<Expense>>>(result);
///     var model = Assert.IsAssignableFrom<IEnumerable<Expense>>(actionResult.Value);
///     Assert.Equal(2, model.Count());
///     }
///     }
///     </code>
///     
/// </example>

public class ExpenseControllerTest
{
   
   // 這是測試 GetExpenses 方法的單元測試

    [Fact]
    public async Task GetExpensesTest()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ExpenseContext>()
            .UseInMemoryDatabase(databaseName: "GetExpensesTest")
            .Options;
        using (var context = new ExpenseContext(options))
        { 
            context.Expenses.Add(new Expense
            {
                Id = 1,
                Description = "Test1",
                Amount = 10.0F,
                Date = DateTime.Now
            });
            context.Expenses.Add(new Expense
            {
                Id = 2,
                Description = "Test2",
                Amount = 20.0F,
                Date = DateTime.Now
            });
            context.SaveChanges();
        }

        using (var context = new ExpenseContext(options))
        {
            var controller = new ExpenseController(context);

            // Act
            var result = await controller.GetExpenses();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Expense>>>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Expense>>(actionResult.Value);
            Assert.Equal(2, model.Count());
       
    
            context.SaveChanges();
         }


        using (var context = new ExpenseContext(options))
        {
            var controller = new ExpenseController(context);

            // Act
            var result = await controller.GetExpenses();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Expense>>>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Expense>>(actionResult.Value);
            Assert.Equal(2, model.Count());
        }
    }

    [Fact]
    public async Task GetExpensesExceptionTest()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ExpenseContext>()
            .UseInMemoryDatabase(databaseName: "GetExpensesExceptionTest")
            .Options;
        using (var context = new ExpenseContext(options))
        {
            context.Expenses.Add(new Expense
            {
                Id = 1,
                Description = "Test1",
                Amount = 10.0F,
                Date = DateTime.Now
            });
            context.Expenses.Add(new Expense
            {
                Id = 2,
                Description = "Test2",
                Amount = 20.0F,
                Date = DateTime.Now
            });
            context.SaveChanges();
        }

        using (var context = new ExpenseContext(options))
        {
            var controller = new ExpenseController(context);
            context.Dispose();
            // Act
            var result = await controller.GetExpenses();

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }

    [Fact]
    public async Task GetExpensesBoundaryTest()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ExpenseContext>()
            .UseInMemoryDatabase(databaseName: "GetExpensesBoundaryTest")
            .Options;
        using (var context = new ExpenseContext(options))
        {
            context.Expenses.Add(new Expense
            {
                Id = 1,
                Description = "Test1",
                Amount = 10.0F,
                Date = DateTime.Now
            });
            context.Expenses.Add(new Expense
            {
                Id = 2,
                Description = "Test2",
                Amount = 20.0F,
                Date = DateTime.Now
            });
            context.SaveChanges();
        }

        using (var context = new ExpenseContext(options))
        {
            var controller = new ExpenseController(context);

            // Act
            var result = await controller.GetExpenses();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Expense>>>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Expense>>(actionResult.Value);
            Assert.Equal(2, model.Count());
        }
    }







    

}