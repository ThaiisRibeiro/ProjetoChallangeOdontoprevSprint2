using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    //public interface IPacienteRepository : InterfaceGeneric<Paciente>
        public interface IDentistaRepository
    {
        Task Adcionar(Dentista Objeto);

        Task Atualizar(Dentista Objeto);

        Task Excluir(Dentista Objeto);

        Task <Dentista> ObterPorId(int Id);

        Task<List<Dentista>> Listar();
    }
}
