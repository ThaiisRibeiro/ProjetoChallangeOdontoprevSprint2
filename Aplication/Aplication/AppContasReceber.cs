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
    public class AppContasReceber : InterfaceContasReceberApp
    {
        




            IContasReceberRepository _InterfaceContasReceber;

        public AppContasReceber(IContasReceberRepository InterfaceContasReceber)
        {
            _InterfaceContasReceber = InterfaceContasReceber;
        }

        public async Task Adcionar(ContasReceber Objeto)
        {
            await _InterfaceContasReceber.Adcionar(Objeto);
        }


        public async Task Atualizar(ContasReceber Objeto)
        {
            await _InterfaceContasReceber.Atualizar(Objeto);
        }

        public async Task Excluir(ContasReceber Objeto)
        {
            await _InterfaceContasReceber.Excluir(Objeto);
        }

        public async Task<ContasReceber> ObterPorId(int Id)
        {
            return await _InterfaceContasReceber.ObterPorId(Id);
        }
        public async Task<List<ContasReceber>> Listar()
        {
            return await _InterfaceContasReceber.Listar();
        }

    }
    }

