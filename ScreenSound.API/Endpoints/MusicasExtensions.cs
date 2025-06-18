using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.Response;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.API.Endpoints
{
    public static class MusicasExtensions
    {
        public static void AddEndPointsMusicas(this WebApplication app)
        {
            //Listar Todas as Musicas
            app.MapGet("/Musicas", ([FromServices] DAL<Musica> dal) =>
            {
                var musicaList = dal.Listar();
                if (musicaList is null)
                {
                    return Results.NotFound();
                }
                var musicaListResponse = EntityListToResponseList(musicaList);
                return Results.Ok(musicaListResponse);
                //return Results.Ok(dal.Listar());
            });

            //Listar Musicas
            app.MapGet("/Musicas/{nome}", ([FromServices] DAL<Musica> dal, string nome) =>
            {
                var musica = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
                if (musica is null)
                {
                    return Results.NotFound($"A Música {nome} não foi encontrada.");
                }
                return Results.Ok(EntityToResponse(musica));
            });

            //Cadastrar Musica
            app.MapPost("/Musicas", ([FromServices] DAL<Musica> dalMusica, [FromServices] DAL<Genero> dalGenero, [FromBody] MusicaRequest musicaRequest) =>
            {
                var musica = new Musica(musicaRequest.nome)
                {
                    ArtistaId = musicaRequest.ArtistaId,
                    AnoLancamento = musicaRequest.anoLancamento,
                    Generos = musicaRequest.Generos is not null ? GeneroRequestConverter(musicaRequest.Generos, dalGenero) : new List<Genero>()
                };
                dalMusica.Adicionar(musica);
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
            app.MapPut("Musicas", ([FromServices] DAL<Musica> dal, [FromBody] MusicaRequestEdit musicaRequestEdit) =>
            {
                var musicaAtualizar = dal.RecuperarPor(a => a.Id == musicaRequestEdit.Id);
                if (musicaAtualizar is null)
                {
                    return Results.NotFound($"A Musica com ID {musicaAtualizar.Id} não foi encontradA.");
                }
                musicaAtualizar.Nome = musicaRequestEdit.nome;
                musicaAtualizar.AnoLancamento = musicaRequestEdit.anoLancamento;

                dal.Atualizar(musicaAtualizar);
                return Results.Ok();
            });
        }

        private static ICollection<Genero> GeneroRequestConverter(ICollection<GeneroRequest> generos, DAL<Genero> dalGenero)
        {
            var listaGeneros = new List<Genero>();
            foreach (var genero in generos)
            {
                var generoEntity = RequestToEntity(genero);
                var generoo = dalGenero.RecuperarPor(g => g.Nome.ToUpper().Equals(genero.Nome.ToUpper()));
                if (generoo is not null)
                {
                    listaGeneros.Add(generoo);
                }
                else
                {
                    listaGeneros.Add(generoEntity);
                }
            }
            return listaGeneros;
        }

        private static Genero RequestToEntity(GeneroRequest genero)
        {
            return new Genero() { Nome = genero.Nome, Descricao = genero.Descricao };
        }

        private static ICollection<MusicaResponse> EntityListToResponseList(IEnumerable<Musica> musicaList)
        {
            return musicaList.Select(a => EntityToResponse(a)).ToList();
        }

        private static MusicaResponse EntityToResponse(Musica musica)
        {
            return new MusicaResponse(musica.Id, musica.Nome!, musica.Artista!.Id, musica.Artista.Nome);
        }
    }
}
