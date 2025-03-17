using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FrontEnd;
using FrontEnd.Repository.Interface;
using FrontEnd.Repository;
using Blazing.Mvvm;
using FrontEnd.ViewModel;
using Syncfusion.Blazor;
using FrontEnd.ViewModel.Component;

//Register Syncfusion license 
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NRAiBiAaIQQuGjN/V05+XU9HdVRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS3tTdERlWX9fdnZcT2FZUg==;MzcyMTgwNkAzMjM4MmUzMDJlMzBuMVNMM2ptWmVjS25FNlVFOUh0VXp3SEJwRmh3WTh1MXVFTXk3N3U2Q2JNPQ==");

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(typeof(IApiRepository<>), typeof(ApiRepository<>));

builder.Services.AddMvvm();

builder.Services.AddTransient<PopupComponentViewModel>();
builder.Services.AddTransient<SoftDebuteQuizViewModel>();
builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();
