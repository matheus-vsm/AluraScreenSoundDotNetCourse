using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal abstract class DAL<T> where T : class //define que os TIPOS são CLASSES
                                                   //nao cria nenhum objeto, apenas define o que deve ser implementado nas classes que herdam dela
    {
        protected readonly ScreenSoundContext context; //para conseguir ser acessado pelas classes que herdam dela, o contexto do banco de dados deve ser protegido (protected) e somente leitura (readonly)

        protected DAL(ScreenSoundContext context)
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
    }
}
