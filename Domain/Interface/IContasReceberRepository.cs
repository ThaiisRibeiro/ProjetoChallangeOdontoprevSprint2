using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    //public interface IPacienteRepository : InterfaceGeneric<Paciente>
        public interface IContasReceberRepository
    {
        Task Adcionar(ContasReceber Objeto);

        Task Atualizar(ContasReceber Objeto);

        Task Excluir(ContasReceber Objeto);

        Task <ContasReceber> ObterPorId(int Id);

        Task<List<ContasReceber>> Listar();
    }
}
