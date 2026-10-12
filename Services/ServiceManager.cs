using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Presistence.Data;
using Services.Abstraction;
using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationServices> _authenticationServices;
        private readonly Lazy<IExpenseServices> _expenseServices;
        public ServiceManager(IOptions<JwtOptions> jwtOptions,IConfiguration configuration,UserManager<User> userManager,TrackerContext context)
        {
            _authenticationServices = new Lazy<IAuthenticationServices>(() => new AuthenticationServices(configuration,userManager,jwtOptions));
            _expenseServices = new Lazy<IExpenseServices>(() => new ExpenseServices(context));
        }
        public IAuthenticationServices AuthenticationServices => _authenticationServices.Value;

        public IExpenseServices ExpenseServices => _expenseServices.Value;
    }
}
