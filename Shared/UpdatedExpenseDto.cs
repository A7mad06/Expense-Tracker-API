using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class UpdatedExpenseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public Guid CategoryId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
