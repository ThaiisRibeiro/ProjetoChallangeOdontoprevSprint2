using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    //public interface IPacienteRepository : InterfaceGeneric<Paciente>
    public interface IAgendamentoRepository
    {
        Task Adcionar(Agendamento Objeto);

        Task Atualizar(Agendamento Objeto);

        Task Excluir(Agendamento Objeto);

        Task <Agendamento> ObterPorId(int Id);

       Task <List<Agendamento>> Listar();
    }
}
