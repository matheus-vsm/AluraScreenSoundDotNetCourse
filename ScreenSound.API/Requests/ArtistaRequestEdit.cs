namespace ScreenSound.API.Requests
{
    public record ArtistaRequestEdit(int id, string nome, string bio) : ArtistaRequest(nome, bio); // Define a record type for ArtistaRequestEdit that inherits from ArtistaRequest and adds an id property
}
