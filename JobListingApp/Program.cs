using JobListingApp.WebApi.Persistance;
using Microsoft.EntityFrameworkCore;
using JobListingApp.WebApi.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SQLitePCL;
using Microsoft.Data.Sqlite;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

// rejestracja repozytorium produktów w kontenerze IoC
var sqliteConnectionString = "Data Source= JobListingApp.db";
builder.Services.AddDbContext<BoardDbContext>(options =>
    options.UseSqlite(sqliteConnectionString));

builder.Services.AddScoped<IBoardUnitOfWork, BoardUnitOfWork>();
builder.Services.AddScoped<IListingRepository, ListingRepository>();
builder.Services.AddScoped<IListingService, ListingService>();
builder.Services.AddScoped<DataSeeder>();
var app = builder.Build();



// uruchomienie seedera
using (var scope = app.Services.CreateScope())
{
    var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    dataSeeder.Seed();
}


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
