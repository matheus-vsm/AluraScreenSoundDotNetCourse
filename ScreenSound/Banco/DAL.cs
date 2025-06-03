using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal abstract class DAL<T> //nao cria nenhum objeto, apenas define o que deve ser implementado nas classes que herdam dela
    {
        public abstract IEnumerable<T> Listar();

        public abstract void Adicionar(T objeto);

        public abstract void Deletar(T objeto);

        public abstract void Atualizar(T objeto);
    }
}
