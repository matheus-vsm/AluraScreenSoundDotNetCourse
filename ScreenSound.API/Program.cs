using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ScreenSound.API.Endpoints;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.Modelos;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

//[FromBody]: recebe dados enviados pelo cliente no corpo da requisi��o (ex: JSON).

//[FromServices]: injeta servi�os do container de depend�ncia (ex: classes de neg�cio ou reposit�rios).

//MapGet , MapPost, MapPut, MapDelete: mapeiam rotas HTTP para m�todos espec�ficos (GET(CONSULTA), POST(INSER��O), PUT(ATUALIZA��O), DELETE(REMO��O)).

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScreenSoundContext>((options) =>
{
    options
          .UseSqlServer(builder.Configuration["ConnectionStrings:ScreenSoundDB"])
          .UseLazyLoadingProxies();
}); // Registra o contexto do banco de dados no cont�iner de inje��o de depend�ncia
builder.Services.AddTransient<DAL<Artista>>(); // Registra a classe DAL para o tipo Artista como um servi�o transit�rio
builder.Services.AddTransient<DAL<Musica>>(); // Registra a classe DAL para o tipo Musica como um servi�o transit�rio
builder.Services.AddTransient<DAL<Genero>>(); // Registra a classe DAL para o tipo Genero como um servi�o transit�rio

builder.Services.AddEndpointsApiExplorer(); // Adiciona suporte para explorar os endpoints da API
builder.Services.AddSwaggerGen(); // Adiciona o Swagger para documenta��o da API

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); // Configura o JsonOptions para ignorar ciclos de refer�ncia

var app = builder.Build();

app.AddEndPointsArtistas(); // Adiciona os endpoints relacionados a Artistas
app.AddEndPointsMusicas(); // Adiciona os endpoints relacionados a Musicas
app.AddEndPointsGeneros(); // Adiciona os endpoints relacionados a Generos

app.UseSwagger(); // Habilita o Swagger
app.UseSwaggerUI(); // Habilita a interface do usu�rio do Swagger

app.Run();