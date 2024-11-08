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
    public class AppAgendamento : InterfaceAgendamentoApp
    {
     

            IAgendamentoRepository _InterfaceAgendamento;

        public AppAgendamento(IAgendamentoRepository InterfaceAgendamento)
        {
            _InterfaceAgendamento = InterfaceAgendamento;
        }

        public async Task Adcionar(Agendamento Objeto)
        {
            await _InterfaceAgendamento.Adcionar(Objeto);
        }


        public async Task Atualizar(Agendamento Objeto)
        {
            await _InterfaceAgendamento.Atualizar(Objeto);
        }

        public async Task Excluir(Agendamento Objeto)
        {
            await _InterfaceAgendamento.Excluir(Objeto);
        }

        public async Task<Agendamento> ObterPorId(int Id)
        {
            return await _InterfaceAgendamento.ObterPorId(Id);
        }
        public async Task<List<Agendamento>> Listar()
        {
            return await _InterfaceAgendamento.Listar();
        }

    }
    }

