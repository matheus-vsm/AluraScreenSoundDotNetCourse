using ScreenSound.Web.Requests;
using ScreenSound.Web.Response;
using System.Net.Http.Json;

namespace ScreenSound.Web.Services
{
    public class MusicasAPI
    {
        private readonly HttpClient _httpClient; //É o cliente HTTP usado pra fazer requisições (GET, POST etc.).
        public MusicasAPI(IHttpClientFactory factory) //Usa o IHttpClientFactory para criar um HttpClient já configurado.
        {
            _httpClient = factory.CreateClient("API"); //"API" é o nome do cliente HTTP registrado no Program.cs.
        }

        //Método assíncrono (async) que retorna uma lista de musicas (MusicasResponse).
        //Faz uma requisição GET para o endpoint musicas da API.
        public async Task<ICollection<MusicaResponse>?> GetMusicasAsync()
        {
            //O método GetFromJsonAsync<T>() já faz o GET e converte a resposta JSON para objetos C#.
            return await _httpClient.GetFromJsonAsync<ICollection<MusicaResponse>>("musicas");
        }

        public async Task AddMusicaAsync(MusicaRequest musica)
        {
            await _httpClient.PostAsJsonAsync("musicas", musica);
        }

        public async Task DeleteMusicaAsync(int id)
        {
            //Deleta um Musica específico pelo ID.
            await _httpClient.DeleteAsync($"musicas/{id}");
        }

        public async Task AtualizarMusicaAsync(MusicaRequestEdit musica)
        {
            //Atualiza um Musica específico pelo ID.
            await _httpClient.PutAsJsonAsync($"artistas", musica);
        }

        public async Task<MusicaResponse?> GetMusicaPorNomeAsync(string nome)
        {
            //Busca um Musica específico pelo ID.
            return await _httpClient.GetFromJsonAsync<MusicaResponse>($"musicas/{nome}");
        }
    }
}
