using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.API.Endpoints
{
    public static class MusicasExtensions
    {
        public static void AddEndPointsMusicas(this WebApplication app)
        {
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
                    return Results.NotFound($"A Música {nome} não foi encontrada.");
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
                    return Results.NotFound($"A Música com ID {id} não foi encontrada.");
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
                    return Results.NotFound($"A Musica com ID {musica.Id} não foi encontradA.");
                }
                musicaExistente.Nome = musica.Nome;
                musicaExistente.AnoLancamento = musica.AnoLancamento;

                dal.Atualizar(musicaExistente);
                return Results.Ok();
            });

        }
    }
}
