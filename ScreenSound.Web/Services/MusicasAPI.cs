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
        public async Task<ICollection<MusicaResponse>?> GetArtistasAsync()
        {
            //O método GetFromJsonAsync<T>() já faz o GET e converte a resposta JSON para objetos C#.
            return await _httpClient.GetFromJsonAsync<ICollection<MusicaResponse>>("musicas");
        }
    }
}
