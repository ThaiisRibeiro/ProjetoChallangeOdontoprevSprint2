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
    public class AppContasPagar : InterfaceContasPagarApp
    {
        



            IContasPagarRepository _InterfaceContasPagar;


        public AppContasPagar(IContasPagarRepository InterfaceContasPagar)
        {
            _InterfaceContasPagar = InterfaceContasPagar;
        }

        public async Task Adcionar(ContasPagar Objeto)
        {
            await _InterfaceContasPagar.Adcionar(Objeto);
        }


        public async Task Atualizar(ContasPagar Objeto)
        {
            await _InterfaceContasPagar.Atualizar(Objeto);
        }

        public async Task Excluir(ContasPagar Objeto)
        {
            await _InterfaceContasPagar.Excluir(Objeto);
        }

        public async Task<ContasPagar> ObterPorId(int Id)
        {
            return await _InterfaceContasPagar.ObterPorId(Id);
        }
        public async Task<List<ContasPagar>> Listar()
        {
            return await _InterfaceContasPagar.Listar();
        }

    }
    }

