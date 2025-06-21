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

builder.Services.AddDbContext<ScreenSoundContext>((options) =>
{
    options
          .UseSqlServer(builder.Configuration["ConnectionStrings:ScreenSoundDB"])
          .UseLazyLoadingProxies();
}); // Registra o contexto do banco de dados no contêiner de injeção de dependência
builder.Services.AddTransient<DAL<Artista>>(); // Registra a classe DAL para o tipo Artista como um serviço transitório
builder.Services.AddTransient<DAL<Musica>>(); // Registra a classe DAL para o tipo Musica como um serviço transitório
builder.Services.AddTransient<DAL<Genero>>(); // Registra a classe DAL para o tipo Genero como um serviço transitório

builder.Services.AddEndpointsApiExplorer(); // Adiciona suporte para explorar os endpoints da API
builder.Services.AddSwaggerGen(); // Adiciona o Swagger para documentação da API

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); // Configura o JsonOptions para ignorar ciclos de referência

var app = builder.Build();

app.AddEndPointsArtistas(); // Adiciona os endpoints relacionados a Artistas
app.AddEndPointsMusicas(); // Adiciona os endpoints relacionados a Musicas
app.AddEndPointsGeneros(); // Adiciona os endpoints relacionados a Generos

app.UseSwagger(); // Habilita o Swagger
app.UseSwaggerUI(); // Habilita a interface do usuário do Swagger

app.Run();