using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
   // public interface InterfacePacienteApp : InterfaceGenericApp<Paciente>
    
        public interface InterfacePacienteApp
        {
            Task Adcionar(Paciente Objeto);

            Task Atualizar(Paciente Objeto);

            Task Excluir(Paciente Objeto);

        Task <Paciente> ObterPorId(int Id);

            Task <List<Paciente>> Listar();
        }

    }

