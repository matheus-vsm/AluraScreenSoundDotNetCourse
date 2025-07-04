//Encapsula o artista em uma classe ArtistaAPI que será responsável por interagir com a API de Artistas
using ScreenSound.Web.Response;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace ScreenSound.Web.Services
{
    public class ArtistaAPI
    {
        private readonly HttpClient _httpClient; //É o cliente HTTP usado pra fazer requisições (GET, POST etc.).
        public ArtistaAPI(IHttpClientFactory factory) //Usa o IHttpClientFactory para criar um HttpClient já configurado.
        {
            _httpClient = factory.CreateClient("API"); //"API" é o nome do cliente HTTP registrado no Program.cs.
        }

        //Método assíncrono (async) que retorna uma lista de artistas (ArtistaResponse).
        //Faz uma requisição GET para o endpoint artistas da API.
        public async Task<ICollection<ArtistaResponse>?> GetArtistasAsync()
        {
            //O método GetFromJsonAsync<T>() já faz o GET e converte a resposta JSON para objetos C#.
            return await _httpClient.GetFromJsonAsync<ICollection<ArtistaResponse>>("artistas");
        }
    }
}
