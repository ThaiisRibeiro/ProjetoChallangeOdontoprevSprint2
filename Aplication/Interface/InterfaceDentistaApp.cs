using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
   // public interface InterfaceDentistaApp : InterfaceGenericApp<Dentista>
    
        public interface InterfaceDentistaApp
        {
        Task Adcionar(Dentista Objeto);

        Task Atualizar(Dentista Objeto);

        Task Excluir(Dentista Objeto);

        Task <Dentista> ObterPorId(int Id);

        Task<List<Dentista>> Listar();
        }

    }
