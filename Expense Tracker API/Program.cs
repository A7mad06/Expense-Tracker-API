using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Presistence.Data;
using Services;
using Services.Abstraction;
using Shared;

namespace Expense_Tracker_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            builder.Services.AddDbContext<TrackerContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.Configure<JwtOptions>(
                builder.Configuration.GetSection("JwtOptions"));
            builder.Services.AddIdentity<User, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<TrackerContext>()
            .AddDefaultTokenProviders();


            builder.Services.AddControllers().AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
