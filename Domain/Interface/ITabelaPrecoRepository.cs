using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    //public interface IPacienteRepository : InterfaceGeneric<Paciente>
        public interface ITabelaPrecoRepository
    {
        Task Adcionar(TabelaPreco Objeto);

        Task Atualizar(TabelaPreco Objeto);

        Task Excluir(TabelaPreco Objeto);

        Task <TabelaPreco> ObterPorId(int Id);

        Task<List<TabelaPreco>> Listar();
    }
}
