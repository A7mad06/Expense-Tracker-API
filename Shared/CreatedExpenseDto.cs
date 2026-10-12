using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class CreatedExpenseDto
    {
        public string Title { get; set; } = null!;
        public decimal Amount { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
