using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstraction
{
    public interface IExpenseServices
    {
        public Task<ExpenseDto> AddExpense(CreatedExpenseDto createdExpenseDto);
        public Task<ExpenseDto> UpdateExpense(UpdatedExpenseDto updatedExpenseDto);
        public Task<bool> DeleteExpense(Guid id);
        public Task<IEnumerable<ExpenseDto>> GetAllExpensesFromTo(DateTime From, DateTime To);
    }
}
