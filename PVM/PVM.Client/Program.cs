using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PVM.Client;
using PVM.Client.Service;
using PVM.Client.Service.Repository;



var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();





builder.Services.AddScoped(http => new HttpClient
{
	BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

builder.Services.AddScoped<IAccountRepository, AccountService>();
builder.Services.AddScoped<IDepartmentRepository,DepartmentService>();
builder.Services.AddScoped<IEntryRepository, EntryService>();

await builder.Build().RunAsync();
