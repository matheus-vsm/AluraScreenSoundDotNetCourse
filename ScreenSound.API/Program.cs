using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ScreenSound.API.Endpoints;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.Modelos;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

//[FromBody]: recebe dados enviados pelo cliente no corpo da requisição (ex: JSON).

//[FromServices]: injeta serviços do container de dependência (ex: classes de negócio ou repositórios).

//MapGet , MapPost, MapPut, MapDelete: mapeiam rotas HTTP para métodos específicos (GET(CONSULTA), POST(INSERÇÃO), PUT(ATUALIZAÇÃO), DELETE(REMOÇÃO)).

var builder = WebApplication.CreateBuilder(args);

//AULA DE DEPLOY AZURE ASHP.NET CORE BLAZOR
//builder.Host.ConfigureAppConfiguration(config =>
//{
//    var settings = config.Build(); // Constrói a configuração da aplicação
//    config.AddAzureAppConfiguration("String"); // Adiciona a configuração do Azure App Configuration, permitindo que a aplicação busque suas configurações de lá
//});

//builder.Services.AddCors(); // Adiciona suporte a CORS (Cross-Origin Resource Sharing) para permitir requisições de diferentes origens

//Aumentamos a restrição de acesso entre a aplicação Web e a API através da configuração CORS, nomeada abaixo como wasm. O projeto anterior permitia qualquer acesso, enquanto o código abaixo somente permite origens apontadas pelas URLs dos dois projetos.
builder.Services.AddCors(options => 
        options.AddPolicy("wasm", policy => 
        policy.WithOrigins([builder.Configuration["BackendUrl"] ?? "https://localhost:7122",
            builder.Configuration["FrontendUrl"] ?? "https://localhost:7015"])
            .AllowAnyMethod()
            .SetIsOriginAllowed(pol => true)
            .AllowAnyHeader()
            .AllowCredentials()));

builder.Services.AddDbContext<ScreenSoundContext>((options) =>
{
    options
          .UseSqlServer(builder.Configuration["ConnectionStrings:ScreenSoundDB"])
          .UseLazyLoadingProxies();
}); // Registra o contexto do banco de dados no contêiner de injeção de dependência
builder.Services.AddTransient<DAL<Artista>>(); // Registra a classe DAL para o tipo Artista como um serviço transitório
builder.Services.AddTransient<DAL<Musica>>();  // Registra a classe DAL para o tipo Musica como um serviço transitório
builder.Services.AddTransient<DAL<Genero>>();  // Registra a classe DAL para o tipo Genero como um serviço transitório

builder.Services.AddEndpointsApiExplorer(); // Faz com que o Swagger consiga descobrir automaticamente os endpoints definidos na sua API.
builder.Services.AddSwaggerGen(); // Adiciona o Swagger para documentação da API

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); // Configura o JsonOptions para ignorar ciclos de referência

var app = builder.Build();

// Configura a política de CORS (Cross-Origin Resource Sharing)
//app.UseCors(options =>
//{     options.AllowAnyOrigin() // Permite qualquer origem
//           .AllowAnyMethod() // Permite qualquer método HTTP (GET, POST, PUT, DELETE etc.)
//           .AllowAnyHeader(); // Permite qualquer cabeçalho na requisição
//});

app.UseCors("wasm"); // Aplica a política de CORS definida anteriormente, permitindo que o Blazor WebAssembly acesse a API

// Habilita o uso de arquivos estáticos na aplicação
// Isso torna acessível o conteúdo da pasta "wwwroot" diretamente pela URL
app.UseStaticFiles(); // Habilita o uso de arquivos estáticos, como imagens, CSS e JavaScript

app.AddEndPointsArtistas(); // Adiciona os endpoints relacionados a Artistas
app.AddEndPointsMusicas();  // Adiciona os endpoints relacionados a Musicas
app.AddEndPointsGeneros();  // Adiciona os endpoints relacionados a Generos

app.UseSwagger();   // Habilita o Swagger
app.UseSwaggerUI(); // Habilita a interface do usuário do Swagger

//app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials()); // Configura o CORS para permitir qualquer método, cabeçalho e origem

app.Run();