using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class DAL<T> where T : class //define que os TIPOS são CLASSES
    {
        protected readonly ScreenSoundContext context; //para conseguir ser acessado pelas classes que herdam dela, o contexto do banco de dados deve ser protegido (protected) e somente leitura (readonly)

        public DAL(ScreenSoundContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> Listar()
        {
            return context.Set<T>().ToList();
        }

        public void Adicionar(T objeto)
        {
            context.Set<T>().Add(objeto);
            context.SaveChanges();
        }

        public void Deletar(T objeto)
        {
            context.Set<T>().Remove(objeto);
            context.SaveChanges();
        }

        public void Atualizar(T objeto)
        {
            context.Set<T>().Update(objeto);
            context.SaveChanges();
        }

        public T? RecuperarPor(Func<T, bool> condicao)
        {
            return context.Set<T>().FirstOrDefault(condicao); //retorna o primeiro objeto que atende a condição especificada ou null se nenhum objeto atender
        }

        public IEnumerable<T> ListarPorAno(Func<T, bool> condicao)
        {
            return context.Set<T>().Where(condicao).ToList(); 
        }
    }
}
