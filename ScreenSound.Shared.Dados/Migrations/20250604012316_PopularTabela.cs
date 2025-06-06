using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[]
            {
                "Derek",
                "Trap the Fato",
                "https://Derekexample.com/foto1.jpg"
            });

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[]
            {
                "MC Hariel",
                "Funk consciente, letras marcantes e atitude.",
                "https://harielexample.com/foto2.jpg"
            });

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[]
            {
                "Djonga",
                "Rap nacional com críticas sociais e líricas afiadas.",
                "https://djongaexample.com/foto3.jpg"
            });

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[]
            {
                "Anitta",
                "Do funk ao pop internacional, uma estrela versátil.",
                "https://anittaexample.com/foto4.jpg"
            });

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[]
            {
                "L7NNON",
                "Rap e trap com estilo marcante e influências diversas.",
                "https://l7nnonexample.com/foto5.jpg"
            });

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[]
            {
                "Papatinho",
                "Produtor renomado, batidas inovadoras e colaborações únicas.",
                "https://papatinhoexample.com/foto6.jpg"
            });

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[]
            {
                "Marília Mendonça",
                "Rainha da sofrência, voz poderosa e letras marcantes.",
                "https://mariliaexample.com/foto7.jpg"
            });

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[]
            {
                "Xamã",
                "Mistura de poesia, rap e melodias envolventes.",
                "https://xamaexample.com/foto8.jpg"
            });

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[]
            {
                "Luísa Sonza",
                "Pop brasileiro com muita atitude e inovação.",
                "https://luisaexample.com/foto9.jpg"
            });

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[]
            {
                "Emicida",
                "Um dos maiores nomes do rap nacional, reflexivo e poético.",
                "https://emicidaexample.com/foto10.jpg"
            });

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[]
            {
                "Matuê",
                "Trap com pegada melódica e estilo único.",
                "https://matueexample.com/foto11.jpg"
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Artistas"); // Remove todos os registros da tabela Artistas durante o rollback da migração
        }
    }
}
