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
    public class AppClinica : InterfaceClinicaApp
    {




        IClinicaRepository _InterfaceClinica;

        public AppClinica(IClinicaRepository InterfaceClinica)
        {
            _InterfaceClinica = InterfaceClinica;
        }

        public async Task Adcionar(Clinica Objeto)
        {
            await _InterfaceClinica.Adcionar(Objeto);
        }


        public async Task Atualizar(Clinica Objeto)
        {
            await _InterfaceClinica.Atualizar(Objeto);
        }

        public async Task Excluir(Clinica Objeto)
        {
            await _InterfaceClinica.Excluir(Objeto);
        }

        public async Task<Clinica> ObterPorId(int Id)
        {
            return await _InterfaceClinica.ObterPorId(Id);
        }
        public async Task<List<Clinica>> Listar()
        {
            return await _InterfaceClinica.Listar();
        }

    }
    }

