using BlazorCrud.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using BlazorCrud.Client.Services;
using CurrieTechnologies.Razor.SweetAlert2;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorCrud.Client.Extenciones;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5125") });
builder.Services.AddMudServices();

builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IAuthService, AuthService>();


builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider, AutenticacionExtension>();
builder.Services.AddAuthorizationCore();

builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
