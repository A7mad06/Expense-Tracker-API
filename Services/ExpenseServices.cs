using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Presistence.Data;
using Services.Abstraction;
using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ExpenseServices(TrackerContext context) : IExpenseServices
    {
        private readonly TrackerContext _context=context;
        public async Task<ExpenseDto> AddExpense(CreatedExpenseDto createdExpenseDto)
        {
            var expense = new Expense
            {
                Amount=createdExpenseDto.Amount,
                Title=createdExpenseDto.Title,
                CategoryId=createdExpenseDto.CategoryId
            };
            await _context.AddAsync(expense);
            await _context.SaveChangesAsync();
            return new ExpenseDto
            {
                Title = expense.Title,
                Amount = expense.Amount,
                Category =expense.Category.Name,
                CreatedAt=expense.CreatedAt
            };
        }

        public async Task<bool> DeleteExpense(Guid id)
        {
            var expense = await _context.Expense.Where(e => e.Id == id).FirstOrDefaultAsync();
            var result = _context.Expense.Remove(expense);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ExpenseDto>> GetAllExpensesFromTo(DateTime From, DateTime To)
        {
            var expenses = await _context.Expense.Where(e => e.CreatedAt.Date >= From.Date && e.CreatedAt < To.Date).Select(e=>new ExpenseDto
            {
                Amount=e.Amount,
                Title=e.Title,
                CreatedAt=e.CreatedAt,
                Category=e.Category.Name
            }).ToListAsync();
            return expenses;
        }

        public async Task<ExpenseDto> UpdateExpense(UpdatedExpenseDto updatedExpenseDto)
        {
            var expense = new Expense
            {
                Id = updatedExpenseDto.Id,
                Title = updatedExpenseDto.Title,
                Amount = updatedExpenseDto.Amount,
                CategoryId = updatedExpenseDto.CategoryId,
                CreatedAt=updatedExpenseDto.CreatedAt
            };
            var updatedExpense = _context.Update(expense);
            await _context.SaveChangesAsync();
            return new ExpenseDto
            {
                Title = expense.Title,
                Amount = expense.Amount,
                Category = expense.Category.Name,
                CreatedAt=expense.CreatedAt
            };
        }
    }
}
