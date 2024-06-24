using JobListingApp.BlazorServer.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using JobListingApp.Infrastructure;
using JobListingApp.Application.Mappings;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using JobListingApp.Application.Services;
using JobListingApp.Domain.Contracts;
using JobListingApp.Infrastructure.Repositories;
using JobListingApp.Application.Validators;
using JobListingApp.SharedKernel.Dto;
using JobListingApp.BlazorServer.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddAutoMapper(typeof(BoardMappingProfile));
// rejestracja automatycznej walidacji (FluentValidation waliduje i przekazuje wynik przezModelState)
builder.Services.AddFluentValidationAutoValidation();

// rejestracja kontekstu bazy w kontenerze IoC
var sqliteConnectionString = "Data Source=JobListingApp.db";
builder.Services.AddDbContext<BoardDbContext>(options =>
 options.UseSqlite(sqliteConnectionString));
// rejestracja walidatora
builder.Services.AddScoped<IValidator<CreateListingDto>, RegisterCreateListingDtoValidator>();
builder.Services.AddScoped<IBoardUnitOfWork, BoardUnitOfWork>();
builder.Services.AddScoped<IListingRepository, ListingRepository>();
builder.Services.AddScoped<DataSeeder>();
builder.Services.AddScoped<IListingService, ListingService>();
builder.Services.AddScoped<IFileService, FileService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// seeding data
using (var scope = app.Services.CreateScope())
{
    var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    dataSeeder.Seed();
}
app.Run();
