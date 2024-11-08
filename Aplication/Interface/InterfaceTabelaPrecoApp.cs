using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
   // public interface InterfaceTabelaPrecoApp : InterfaceGenericApp<TabelaPreco>
    
        public interface InterfaceTabelaPrecoApp
    {
        Task Adcionar(TabelaPreco Objeto);

        Task Atualizar(TabelaPreco Objeto);

        Task Excluir(TabelaPreco Objeto);

        Task <TabelaPreco> ObterPorId(int Id);

        Task<List<TabelaPreco>> Listar();
        }

    }

