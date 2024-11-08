using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
   // public interface InterfaceContasPagarApp : InterfaceGenericApp<ContasPagar>
    
     public interface InterfaceContasPagarApp
    {
        Task Adcionar(ContasPagar Objeto);

        Task Atualizar(ContasPagar Objeto);

        Task Excluir(ContasPagar Objeto);

        Task <ContasPagar> ObterPorId(int Id);

        Task <List<ContasPagar>>  Listar();
    }

}

