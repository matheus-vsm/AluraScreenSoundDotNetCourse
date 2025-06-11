using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

//[FromBody]: recebe dados enviados pelo cliente no corpo da requisi��o (ex: JSON).

//[FromServices]: injeta servi�os do container de depend�ncia (ex: classes de neg�cio ou reposit�rios).

//MapGet , MapPost, MapPut, MapDelete: mapeiam rotas HTTP para m�todos espec�ficos (GET(CONSULTA), POST(INSER��O), PUT(ATUALIZA��O), DELETE(REMO��O)).

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScreenSoundContext>(); // Registra o contexto do banco de dados no cont�iner de inje��o de depend�ncia
builder.Services.AddTransient<DAL<Artista>>(); // Registra a classe DAL para o tipo Artista como um servi�o transit�rio
builder.Services.AddTransient<DAL<Musica>>(); // Registra a classe DAL para o tipo Musica como um servi�o transit�rio

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); // Configura o JsonOptions para ignorar ciclos de refer�ncia

var app = builder.Build();

#region Endpoints para Artistas
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

//Deletar Artista
app.MapDelete("/Artistas/{id}", ([FromServices] DAL<Artista> dal, int id) =>
{
    var artista = dal.RecuperarPor(a => a.Id == id);
    if (artista == null)
    {
        return Results.NotFound($"O Artista com ID {id} n�o foi encontrado.");
    }
    dal.Deletar(artista);
    return Results.Ok();
});

//Atualizar Artista
app.MapPut("Artistas", ([FromServices] DAL<Artista> dal, [FromBody] Artista artista) =>
{
    var artistaExistente = dal.RecuperarPor(a => a.Id == artista.Id);
    if (artistaExistente == null)
    {
        return Results.NotFound($"O Artista com ID {artista.Id} n�o foi encontrado.");
    }
    artistaExistente.Nome = artista.Nome;
    artistaExistente.FotoPerfil = artista.FotoPerfil;
    artistaExistente.Bio = artista.Bio;

    dal.Atualizar(artistaExistente);
    return Results.Ok();
});
#endregion

#region Endpoints para Musicas
//Listar Todas as Musicas
app.MapGet("/Musicas", ([FromServices] DAL<Musica> dal) =>
{
    return Results.Ok(dal.Listar());
});

//Listar Musicas
app.MapGet("/Musicas/{nome}", ([FromServices] DAL<Musica> dal, string nome) =>
{
    var musica = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
    if (musica is null)
    {
        return Results.NotFound($"A M�sica {nome} n�o foi encontrada.");
    }
    return Results.Ok(musica);
});

//Cadastrar Musica
app.MapPost("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] Musica musica) =>
{
    dal.Adicionar(musica);
    return Results.Ok();
});

//Deletar Musica
app.MapDelete("/Musicas/{id}", ([FromServices] DAL<Musica> dal, int id) =>
{
    var musica = dal.RecuperarPor(a => a.Id == id);
    if (musica is null)
    {
        return Results.NotFound($"A M�sica com ID {id} n�o foi encontrada.");
    }
    dal.Deletar(musica);
    return Results.Ok();
});

//Atualizar Musica
app.MapPut("Musicas", ([FromServices] DAL<Musica> dal, [FromBody] Musica musica) =>
{
    var musicaExistente = dal.RecuperarPor(a => a.Id == musica.Id);
    if (musica is null)
    {
        return Results.NotFound($"A Musica com ID {musica.Id} n�o foi encontradA.");
    }
    musicaExistente.Nome = musica.Nome;
    musicaExistente.AnoLancamento = musica.AnoLancamento;

    dal.Atualizar(musicaExistente);
    return Results.Ok();
});
#endregion

app.Run();