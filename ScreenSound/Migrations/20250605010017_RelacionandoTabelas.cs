using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class RelacionandoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 1 WHERE Id = 1");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 1 WHERE Id = 2");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 2 WHERE Id = 4");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 2 WHERE Id = 12");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 3 WHERE Id = 5");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 3 WHERE Id = 6");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 4 WHERE Id = 7");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 4 WHERE Id = 8");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 4 WHERE Id = 17");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 4 WHERE Id = 18");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 5 WHERE Id = 9");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 5 WHERE Id = 10");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 6 WHERE Id = 11");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 6 WHERE Id = 14");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 7 WHERE Id = 13");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 7 WHERE Id = 16");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 8 WHERE Id = 15");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 9 WHERE Id = 20");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 10 WHERE Id = 19");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 11 WHERE Id = 3");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 11 WHERE Id = 21");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 11 WHERE Id = 22");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
