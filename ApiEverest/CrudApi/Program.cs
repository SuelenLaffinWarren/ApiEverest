using ApiEverest.Context;
using AppServices.Services;
using DomainServices.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<ICustomerService, CustomerService>();
        builder.Services.AddTransient<ICustomerAppService, CustomerAppService>();
        builder.Services.AddValidatorsFromAssembly(Assembly.Load(nameof(AppServices)));
        builder.Services.AddAutoMapper(Assembly.Load(nameof(AppServices)));

        builder.Services.AddDbContext<CustomerContext>
            (options => options.UseMySql(
                "server=localhost;initial catalog=CUSTOMER_DATABASE;uid=root;pwd=admin",
                Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql")));
     
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();