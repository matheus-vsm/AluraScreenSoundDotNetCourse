using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

//[FromBody]: recebe dados enviados pelo cliente no corpo da requisição (ex: JSON).

//[FromServices]: injeta serviços do container de dependência (ex: classes de negócio ou repositórios).

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScreenSoundContext>(); // Registra o contexto do banco de dados no contêiner de injeção de dependência
builder.Services.AddTransient<DAL<Artista>>(); // Registra a classe DAL para o tipo Artista como um serviço transitório

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); // Configura o JsonOptions para ignorar ciclos de referência

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
        return Results.NotFound($"O Artista {nome} não foi encontrado.");
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