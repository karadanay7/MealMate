using LifeCoach.WasmClient;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI;
using OpenAI.Extensions;
using OpenAI.Interfaces;
using OpenAI.Managers;
using Blazored.SessionStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Load configuration

builder.Services.AddBlazoredSessionStorage();
// Register OpenAIService with configuration



// Register OpenAIService with configuration


await builder.Build().RunAsync();
