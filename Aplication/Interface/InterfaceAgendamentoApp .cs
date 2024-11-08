using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    //public interface InterfaceAgendamentoApp : InterfaceGenericApp<Agendamento>
    public interface InterfaceAgendamentoApp
    {
        Task Adcionar(Agendamento Objeto);

        Task Atualizar(Agendamento Objeto);

        Task Excluir(Agendamento Objeto);

        Task <Agendamento> ObterPorId(int Id);

       Task <List<Agendamento>> Listar();
    }
}
