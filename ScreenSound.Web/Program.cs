using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ScreenSound.Web;
using ScreenSound.Web.Services;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.X86;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<ArtistaAPI>();
builder.Services.AddTransient<MusicaAPI>();

//Registra um HttpClient com nome "API" no sistema de injeção de dependência.
builder.Services.AddHttpClient("API", client => {
    //Define a URL base da API. Esse valor vem do appsettings.json ou appsettings.Development.json.
    client.BaseAddress = new Uri(builder.Configuration["APIServer:Url"]!);
    //Adiciona um header em todas as requisições feitas com esse HttpClient. Aceita respostas em JSON.
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

await builder.Build().RunAsync();
