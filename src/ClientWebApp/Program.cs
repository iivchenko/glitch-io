using ClientWeb;
using ClientWeb.Clients.ProfileService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RestEase.HttpClientFactory;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddRestEaseClient<IProfileClient>(builder.Configuration["Services:ProfileServiceUrl"]);

await builder.Build().RunAsync();
