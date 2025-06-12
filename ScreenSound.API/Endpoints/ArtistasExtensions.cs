using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.API.Endpoints
{
    public static class ArtistasExtensions
    {
        public static void AddEndPointsArtistas(this WebApplication app)
        {
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
            app.MapPost("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] ArtistaRequest artistaRequest) =>
            {
                var artista = new Artista(artistaRequest.nome, artistaRequest.bio);
                dal.Adicionar(artista);
                return Results.Ok();
            });

            //Deletar Artista
            app.MapDelete("/Artistas/{id}", ([FromServices] DAL<Artista> dal, int id) =>
            {
                var artista = dal.RecuperarPor(a => a.Id == id);
                if (artista == null)
                {
                    return Results.NotFound($"O Artista com ID {id} não foi encontrado.");
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
                    return Results.NotFound($"O Artista com ID {artista.Id} não foi encontrado.");
                }
                artistaExistente.Nome = artista.Nome;
                artistaExistente.FotoPerfil = artista.FotoPerfil;
                artistaExistente.Bio = artista.Bio;

                dal.Atualizar(artistaExistente);
                return Results.Ok();
            });

        }
    }
}
