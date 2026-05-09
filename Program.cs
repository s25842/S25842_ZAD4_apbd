using FluentValidation;
using FluentValidation.AspNetCore;
using S25842_ZAD4.Data;
using S25842_ZAD4.Validator;

namespace S25842_ZAD4;

public class Program
{
    public static void Main(string[] args)
    {
        TestData.createTestData();
        
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddValidatorsFromAssemblyContaining<RoomValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<ReservationValidator>();
        builder.Services.AddFluentValidationAutoValidation();
        
        
        
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}