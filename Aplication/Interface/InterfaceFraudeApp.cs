using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    //public interface InterfaceFraudeApp : InterfaceGenericApp<Fraude>
    
        public interface InterfaceFraudeApp
    {
        Task Adcionar(Fraude Objeto);

        Task Atualizar(Fraude Objeto);

        Task Excluir(Fraude Objeto);

        Task <Fraude> ObterPorId(int Id);

        Task<List<Fraude>> Listar();
        }

    }

