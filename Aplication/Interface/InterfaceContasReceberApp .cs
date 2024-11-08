using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    //public interface InterfaceContasReceberApp : InterfaceGenericApp<ContasReceber>
    
     public interface InterfaceContasReceberApp
    {
        Task Adcionar(ContasReceber Objeto);

        Task Atualizar(ContasReceber Objeto);

        Task Excluir(ContasReceber Objeto);

        Task <ContasReceber> ObterPorId(int Id);

        Task<List<ContasReceber>> Listar();
    }

}

