using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarMusicas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[]
            {
                "Tattos On My Face", 2024
            });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[]
            {
                "Paris", 2016
            });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[]
            {
                "Máquina do Tempo", 2019
            });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[]
            {
                "Ilusão (Cracolândia)", 2021
            });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[]
            {
                "Olho de Tigre", 2019
            });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[]
            {
                "Hat-Trick", 2020
            });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[]
            {
                "Vai Malandra", 2017
            });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[]
            {
                "Envolver", 2022
            });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[]
            {
                "Freio da Blazer", 2020
            });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[]
            {
                "Perdição", 2021
            });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[]
            {
                "Joga Pra Lua", 2018
            });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[]
            {
                "Necessário", 2020
            });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[]
            {
                "Infiel", 2015
            });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[]
            {
                "De Quem É a Culpa?", 2017
            });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[]
            {
                "A Bela e a Fera", 2020
            });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[]
            {
                "Leão", 2022
            });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[]
            {
                "Modo Turbo", 2020
            });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[]
            {
                "Sentadona", 2022
            });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[]
            {
                "AmarElo", 2019
            });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[]
            {
                "Passarinhos", 2015
            });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[]
            {
                "Antes", 2020
            });

            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento" }, new object[]
            {
                "Quer Voar", 2021
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
