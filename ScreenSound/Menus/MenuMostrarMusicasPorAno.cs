using ScreenSound.Banco;
using ScreenSound.Modelos;
using System.Diagnostics.CodeAnalysis;

namespace ScreenSound.Menus;

internal class MenuMostrarMusicasPorAno : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Exibir músicas de um determinado ano");
        Console.Write("Digite o ano de lançamento desejado: ");
        int ano = int.Parse(Console.ReadLine())!;

        var musicaDAL = new DAL<Musica>(new ScreenSoundContext());
        var musicasAno = musicaDAL.ListarPorAno(a => a.AnoLancamento.Equals(ano));
        if (musicasAno.Any())
        {
            Console.WriteLine($"\nMúsicas de {ano}:");
            foreach (var musica in musicasAno)
            {
                musica.ExibirFichaTecnica(); 
            }
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        }
        else
        {
            Console.WriteLine($"\nNenhuma música registrada foi lançada em {ano}!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        }
        Console.ReadKey();
        Console.Clear();
    }
}
