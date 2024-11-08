using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    //public interface IPacienteRepository : InterfaceGeneric<Paciente>
        public interface IPacienteRepository 
    {
        Task Adcionar(Paciente Objeto);

        Task Atualizar(Paciente Objeto);

        Task Excluir(Paciente Objeto);

        Task <Paciente> ObterPorId(int Id);

        Task<List<Paciente>> Listar();
    }
}
