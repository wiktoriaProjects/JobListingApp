
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using NLog;
using NLog.Web;
using JobListingApp.Domain.Contracts;
using JobListingApp.Infrastructure;
using JobListingApp.Infrastructure.Repositories;
using JobListingApp.Application.Validators;
using JobListingApp.SharedKernel.Dto;
using JobListingApp.Application.Services;
using JobListingApp.Web.API.Middleware;
using AutoMapper;
using Microsoft.Extensions.Configuration;




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
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    // rejestracja automappera w kontenerze IoC
    //builder.Services.AddAutoMapper(typeof(Program));
    // With layered !!!
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
    // rejestruje w kontenerze zależności politykę CORS o nazwie SaleKiosk,
    // która zapewnia dostęp do API z dowolnego miejsca oraz przy pomocy dowolnej metody
    builder.Services.AddCors(o => o.AddPolicy("JobBoard", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    }));
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
    app.UseCors("JobBoard");
    // uruchomienie seedera
    using (var scope = app.Services.CreateScope())
    {
        var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
        dataSeeder.Seed();
    }
    
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

