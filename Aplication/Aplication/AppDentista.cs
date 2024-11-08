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
    public class AppDentista : InterfaceDentistaApp
    {
        IDentistaRepository _InterfaceDentista;

        public AppDentista(IDentistaRepository InterfaceDentista)
        {
            _InterfaceDentista = InterfaceDentista;
        }

        public async Task Adcionar(Dentista Objeto)
        {
            await _InterfaceDentista.Adcionar(Objeto);
        }


        public async Task Atualizar(Dentista Objeto)
        {
            await _InterfaceDentista.Atualizar(Objeto);
        }

        public async Task Excluir(Dentista Objeto)
        {
            await _InterfaceDentista.Excluir(Objeto);
        }

        public async Task<Dentista> ObterPorId(int Id)
        {
            return await _InterfaceDentista.ObterPorId(Id);
        }
        public async Task<List<Dentista>> Listar()
        {
            return await _InterfaceDentista.Listar();
        }

    }
}

