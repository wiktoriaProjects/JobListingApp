using Blazored.LocalStorage;
using JobListingApp.BlazorClient;
using JobListingApp.BlazorClient.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddMudServices();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
// rejestracja ProductService w kontenerze zal
builder.Services.AddScoped<IListingService, ListingService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// modyfikacja klienta http aby pobieral dane z pliku konfiguracyjnego
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress =
 new Uri(builder.Configuration.GetValue<string>("JobBoardAPIUrl"))
});
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<ILikesService, LikesService>();


await builder.Build().RunAsync();
