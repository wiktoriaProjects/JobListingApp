using JobListingApp.WebApi.Persistance;
using JobListingApp.WebApi.Middleware;
using Microsoft.EntityFrameworkCore;
using JobListingApp.WebApi.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SQLitePCL;
using Microsoft.Data.Sqlite;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using FluentValidation;
using JobListingApp.Dto;
using JobListingApp.WebApi.Dto.Validators;
using FluentValidation.AspNetCore;
using NLog;
using NLog.Web;
using Microsoft.AspNetCore.Hosting;


// --- logger

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");
try
{


    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    // rejestracja automappera w kontenerze IoC
    builder.Services.AddAutoMapper(typeof(Program));

    //walidator
    builder.Services.AddFluentValidationAutoValidation();
    builder.Services.AddScoped<IValidator<CreateListingDto>, RegisterCreateListingDtoValidator>();
    // rejestracja repozytorium produktów w kontenerze IoC
    var sqliteConnectionString = "Data Source= JobListingApp.db";
    builder.Services.AddDbContext<BoardDbContext>(options =>
        options.UseSqlite(sqliteConnectionString));

    builder.Services.AddScoped<IBoardUnitOfWork, BoardUnitOfWork>();
    builder.Services.AddScoped<IListingRepository, ListingRepository>();
    builder.Services.AddScoped<DataSeeder>();
    // rejestracja exception middleware-a w kontenerze IoC
    builder.Services.AddScoped<IListingService, ListingService>();
    builder.Services.AddScoped<ExceptionMiddleware>();
    var app = builder.Build();




    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseStaticFiles();

    app.UseMiddleware<ExceptionMiddleware>();
    app.UseHttpsRedirection();
    app.UseAuthorization();

    app.MapControllers();
    // uruchomienie seedera
    using (var scope = app.Services.CreateScope())
    {
        var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
        dataSeeder.Seed();
    }
    // wstawienie exception middleware do potoku obsługi żądania
    //
    app.Run();

}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
   
 NLog.LogManager.Shutdown();
}

