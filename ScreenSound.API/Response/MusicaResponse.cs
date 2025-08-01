namespace ScreenSound.API.Response
{
    public record MusicaResponse(int Id, string Nome, int ArtistaId, string NomeArtista, int? anoLancamento); // Define a record type for MusicaResponse with properties Id, Nome, ArtistaId, NomeArtista and anoLancamento
}
