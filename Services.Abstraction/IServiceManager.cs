using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstraction
{
    public interface IServiceManager
    {
        public IAuthenticationServices AuthenticationServices { get; }
        public IExpenseServices ExpenseServices { get; }
    }
}
