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
    public class AppTabelaPreco : InterfaceTabelaPrecoApp
    {


        ITabelaPrecoRepository _InterfaceTabelaPreco;

        public AppTabelaPreco(ITabelaPrecoRepository InterfaceTabelaPreco)
        {
            _InterfaceTabelaPreco = InterfaceTabelaPreco;
        }

        public async Task Adcionar(TabelaPreco Objeto)
        {
            await _InterfaceTabelaPreco.Adcionar(Objeto);
        }


        public async Task Atualizar(TabelaPreco Objeto)
        {
            await _InterfaceTabelaPreco.Atualizar(Objeto);
        }

        public async Task Excluir(TabelaPreco Objeto)
        {
            await _InterfaceTabelaPreco.Excluir(Objeto);
        }

        public async Task<TabelaPreco> ObterPorId(int Id)
        {
            return await _InterfaceTabelaPreco.ObterPorId(Id);
        }
        public async Task<List<TabelaPreco>> Listar()
        {
            return await _InterfaceTabelaPreco.Listar();
        }
    }
}
