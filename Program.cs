using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Autor_Books_Api.Data;
using Autor_Books_Api.Autors.Repository;
using Autor_Books_Api.Autors.Service;
using System.Windows.Input;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("autor-books-api", domain => domain.WithOrigins("")
                .AllowAnyHeader()
                .AllowAnyMethod());
        });

        builder.Services.AddDbContext<AppDbContext>(options =>
           options.UseMySql(builder.Configuration.GetConnectionString("Default")!,
               new MySqlServerVersion(new Version(8, 0, 21))));



        builder.Services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddMySql5()
                .WithGlobalConnectionString(builder.Configuration.GetConnectionString("Default"))
                .ScanIn(typeof(Program).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole());

        builder.Services.AddScoped<IAutorRepo, AutorRepo>();
        builder.Services.AddScoped<ICommandService, CommandService>();
        builder.Services.AddScoped<IQueryService, QueryService>();





        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapControllers();

        using (var scope = app.Services.CreateScope())
        {
            try
            {
                var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
                runner.MigrateUp();
                Console.WriteLine("Migration successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Migration failed: {ex.Message}");
            }
        }

        app.UseCors("autor-books-api");
        app.Run();
    }
}