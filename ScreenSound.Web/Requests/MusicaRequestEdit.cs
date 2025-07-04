namespace ScreenSound.Web.Requests
{
    public record MusicaRequestEdit(int Id, string nome, int ArtistaId, int anoLancamento)
    : MusicaRequest(nome, ArtistaId, anoLancamento); // Define a record type for MusicaRequestEdit that inherits from MusicaRequest and adds an id property
}
