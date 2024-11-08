using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    //public interface InterfaceClinicaApp : InterfaceGenericApp<Clinica>
    
        public interface InterfaceClinicaApp
        {
        Task Adcionar(Clinica Objeto);

        Task Atualizar(Clinica Objeto);

        Task Excluir(Clinica Objeto);

        Task <Clinica> ObterPorId(int Id);

        Task<List<Clinica>> Listar();
        }

    }

