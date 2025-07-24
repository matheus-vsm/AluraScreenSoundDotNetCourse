using System.ComponentModel.DataAnnotations;

namespace ScreenSound.Web.Requests
{
    public record ArtistaRequest([Required] string nome, [Required] string bio, string? fotoPerfil); // Define a record type for ArtistaRequest with properties nome, bio and fotoPerfil
}
