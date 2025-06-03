using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class MusicaDAL : DAL<Musica>
    {
        public MusicaDAL(ScreenSoundContext context) : base(context) { } //recebe o contexto do banco de dados e passa para a classe base DAL

        public Musica? RecuperarPeloNome(string nome)
        {
            return context.Musicas.FirstOrDefault(a => a.Nome.Equals(nome));
        }
    }
}
