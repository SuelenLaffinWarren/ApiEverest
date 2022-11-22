using ApiEverest.Entities;
using CustomerApi.Services;
using CustomerApi.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;

        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddFluentValidationAutoValidation();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<ICustomerService, CustomerService>();
        builder.Services.AddScoped<IValidator<CustomerEntity>, CustomerRulesValidator>();
     

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}