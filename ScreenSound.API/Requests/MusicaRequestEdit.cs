namespace ScreenSound.API.Requests
{
    public record MusicaRequestEdit(int id, string nome, int anoLancamento) : MusicaRequest(nome, anoLancamento); // Define a record type for MusicaRequestEdit that inherits from MusicaRequest and adds an id property
}
