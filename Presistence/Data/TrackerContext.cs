using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presistence.Data
{
    public class TrackerContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public TrackerContext(DbContextOptions<TrackerContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Expense> Expense { get; set; }
    }
}
