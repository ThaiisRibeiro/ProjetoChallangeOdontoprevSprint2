using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface InterfaceGeneric<T> where T : class
    {
        void Adcionar(T Objeto);

        void Atualizar(T Objeto);

        void Excluir(T Objeto);

        T ObterPorId(int Id);

        IList<T> Listar();
    }
}
