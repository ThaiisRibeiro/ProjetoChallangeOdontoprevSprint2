using Aplication.Interface;
using Domain.Entities;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Aplication
{
    public class AppPaciente : InterfacePacienteApp
    {

        IPacienteRepository _InterfacePaciente;

        public AppPaciente(IPacienteRepository InterfacePaciente)
        {
            _InterfacePaciente = InterfacePaciente;
        }

        public async Task Adcionar(Paciente Objeto)
        {
           await _InterfacePaciente.Adcionar(Objeto);
        }


        public async Task Atualizar(Paciente Objeto)
        {
            await _InterfacePaciente.Atualizar(Objeto);
        }

        public async Task Excluir(Paciente Objeto)
        {
            await _InterfacePaciente.Excluir(Objeto);
        }

        public async Task<Paciente> ObterPorId(int Id)
        {
            return await _InterfacePaciente.ObterPorId(Id);
        }
        public async Task<List<Paciente>> Listar()
        {
            return await _InterfacePaciente.Listar();
        }

    }
}
