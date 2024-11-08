using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    //public interface IPacienteRepository : InterfaceGeneric<Paciente>
        public interface IFraudeRepository
    {
        Task Adcionar(Fraude Objeto);

        Task Atualizar(Fraude Objeto);

        Task Excluir(Fraude Objeto);

        Task <Fraude> ObterPorId(int Id);

        Task<List<Fraude>> Listar();
    }
}
