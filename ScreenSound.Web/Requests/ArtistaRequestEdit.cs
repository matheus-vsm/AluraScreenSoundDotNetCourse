namespace ScreenSound.Web.Requests
{
    public record ArtistaRequestEdit(int Id, string nome, string bio, string? fotoPerfil)
    : ArtistaRequest(nome, bio, fotoPerfil); // Define a record type for ArtistaRequestEdit that inherits from ArtistaRequest and adds an id property
}
