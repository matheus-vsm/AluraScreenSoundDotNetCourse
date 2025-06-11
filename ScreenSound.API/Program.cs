using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

//[FromBody]: recebe dados enviados pelo cliente no corpo da requisi��o (ex: JSON).

//[FromServices]: injeta servi�os do container de depend�ncia (ex: classes de neg�cio ou reposit�rios).

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScreenSoundContext>(); // Registra o contexto do banco de dados no cont�iner de inje��o de depend�ncia
builder.Services.AddTransient<DAL<Artista>>(); // Registra a classe DAL para o tipo Artista como um servi�o transit�rio

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); // Configura o JsonOptions para ignorar ciclos de refer�ncia

var app = builder.Build();

//Listar Todos os Artistas
app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) =>
{
    return Results.Ok(dal.Listar());
});

//Listar Artistas
app.MapGet("/Artistas/{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
{
    var artista = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
    if (artista == null)
    {
        return Results.NotFound($"O Artista {nome} n�o foi encontrado.");
    }
    return Results.Ok(artista);
});

//Cadastrar Artista
app.MapPost("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody]Artista artista) =>
{
    dal.Adicionar(artista);
    return Results.Ok();
});

app.Run();