using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController(IServiceManager serviceManager):ControllerBase
    {
        [HttpPost("create")]
        public async Task<ActionResult<ExpenseDto>> CreateExpense(CreatedExpenseDto createdExpenseDto)
        {
            var result = await serviceManager.ExpenseServices.AddExpense(createdExpenseDto);
            return Ok(result);
        }
        [HttpPost("delete/{id}")]
        public async Task<ActionResult<bool>> DeleteExpense([FromRoute]Guid id)
        {
            var result = await serviceManager.ExpenseServices.DeleteExpense(id);
            return result is false ? NotFound() : Ok(true);
        }
        [HttpPut]
        public async Task<ActionResult<ExpenseDto>> UpdateExpense(UpdatedExpenseDto updatedExpenseDto)
        {
            var result = await serviceManager.ExpenseServices.UpdateExpense(updatedExpenseDto);
            return result is null ? NotFound() : Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetAllExpenseFromTo(DateTime From,DateTime To)
        {
            var result = await serviceManager.ExpenseServices.GetAllExpensesFromTo(From, To);
            return Ok(result);
        }
    }
}
