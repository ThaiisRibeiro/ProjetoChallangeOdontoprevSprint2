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
    public class AppFraude : InterfaceFraudeApp
    {
       
            IFraudeRepository _InterfaceFraude;

        public AppFraude(IFraudeRepository InterfaceFraude)
        {
            _InterfaceFraude = InterfaceFraude;
        }

        public async Task Adcionar(Fraude Objeto)
        {
            await _InterfaceFraude.Adcionar(Objeto);
        }


        public async Task Atualizar(Fraude Objeto)
        {
            await _InterfaceFraude.Atualizar(Objeto);
        }

        public async Task Excluir(Fraude Objeto)
        {
            await _InterfaceFraude.Excluir(Objeto);
        }

        public async Task<Fraude> ObterPorId(int Id)
        {
            return await _InterfaceFraude.ObterPorId(Id);
        }
        public async Task<List<Fraude>> Listar()
        {
            return await _InterfaceFraude.Listar();
        }
    }
}
