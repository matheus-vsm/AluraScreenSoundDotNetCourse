namespace ScreenSound.API.Requests
{
    public record ArtistaRequestEdit(int id, string nome, string bio, string? fotoPerfil)
    : ArtistaRequest(nome, bio, fotoPerfil); // Define a record type for ArtistaRequestEdit that inherits from ArtistaRequest and adds an id property
}
