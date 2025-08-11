using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.Response;
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
                var listaDeArtistas = dal.Listar();
                if (listaDeArtistas is null)
                {
                    return Results.NotFound();
                }
                var listaDeArtistaResponse = EntityListToResponseList(listaDeArtistas);
                return Results.Ok(listaDeArtistaResponse);
            });

            //Listar Artistas
            app.MapGet("/Artistas/{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
            {
                var artista = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
                if (artista is null)
                {
                    return Results.NotFound($"O Artista {nome} não foi encontrado.");
                }
                return Results.Ok(EntityToResponse(artista));
            });

            //Cadastrar Artista
            app.MapPost("/Artistas", async ([FromServices] IHostEnvironment env, [FromServices] DAL<Artista> dal, [FromBody] ArtistaRequest artistaRequest) =>
            {
                var caminhoImagem = await SalvarImagemBase64Async(env, artistaRequest.fotoPerfil!, artistaRequest.nome);

                var artista = new Artista(artistaRequest.nome, artistaRequest.bio) { FotoPerfil = caminhoImagem };
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
            app.MapPut("Artistas", async ([FromServices] IHostEnvironment env, [FromServices] DAL<Artista> dal, [FromBody] ArtistaRequestEdit artistaRequestEdit) =>
            {
                var artistaAtualizar = dal.RecuperarPor(a => a.Id == artistaRequestEdit.id);
                if (artistaAtualizar is null)
                {
                    return Results.NotFound($"O Artista com ID {artistaAtualizar!.Id} não foi encontrado.");
                }
                var caminhoImagem = await SalvarImagemBase64Async(env, artistaRequestEdit.fotoPerfil!, artistaRequestEdit.nome);
                artistaAtualizar.Nome = artistaRequestEdit.nome;
                artistaAtualizar.Bio = artistaRequestEdit.bio;
                artistaAtualizar.FotoPerfil = caminhoImagem;

                dal.Atualizar(artistaAtualizar);
                return Results.Ok();
            });
        }

        private static ICollection<ArtistaResponse> EntityListToResponseList(IEnumerable<Artista> listaDeArtistas)
        {
            return listaDeArtistas.Select(a => EntityToResponse(a)).ToList();
        }

        private static ArtistaResponse EntityToResponse(Artista artista)
        {
            return new ArtistaResponse(artista.Id, artista.Nome, artista.Bio, artista.FotoPerfil);
        }
        public static async Task<string> SalvarImagemBase64Async(IHostEnvironment env, string base64Imagem, string nomeBase)
        {
            if (string.IsNullOrWhiteSpace(base64Imagem))
                throw new ArgumentException("Imagem em base64 está vazia.");

            // Remove espaços e caracteres especiais do nome
            var nomeLimpo = nomeBase.Replace(" ", "").Trim();
            var nomeArquivo = $"{DateTime.Now:ddMMyyyyHHmmss}.{nomeLimpo}.jpeg";

            var caminhoPasta = Path.Combine(env.ContentRootPath, "wwwroot", "FotosPerfil");

            // Garante que a pasta existe
            if (!Directory.Exists(caminhoPasta))
                Directory.CreateDirectory(caminhoPasta);

            var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

            using MemoryStream ms = new(Convert.FromBase64String(base64Imagem));
            using FileStream fs = new(caminhoCompleto, FileMode.Create);
            await ms.CopyToAsync(fs);

            // Retorna caminho relativo usado na URL
            return $"/FotosPerfil/{nomeArquivo}";
        }
    }
}
