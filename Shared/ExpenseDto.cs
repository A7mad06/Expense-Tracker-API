using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public record ExpenseDto
    {
        public string Title { get; init; } = null!;
        public string Category { get; init; }=null!;
        public decimal Amount { get; init; }
        public DateTime CreatedAt { get; set; }
    }
}
