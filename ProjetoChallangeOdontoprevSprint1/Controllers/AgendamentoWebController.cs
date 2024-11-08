using Aplication.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjetoChallangeOdontoprevSprint1.Controllers
{
        public class AgendamentoWebController : Controller
        {
        private readonly InterfaceAgendamentoApp _InterfaceAgendamentoApp;

        public AgendamentoWebController(InterfaceAgendamentoApp InterfaceAgendamentoApp)
        {
            _InterfaceAgendamentoApp = InterfaceAgendamentoApp;
        }


        //Lista de carro para simular o banco de dados
        //  private static List<Paciente> _lista = new List<Paciente>();

        private static int _id = 0; //Controla o IDc 


        // GET: AgendamentoWebController
        public async Task<ActionResult> Index()
        {

            // return View(_InterfacePacienteApp);
            return View(await _InterfaceAgendamentoApp.Listar());
        }



        // GET: PacienteWebController/Create
        public async Task<ActionResult> Adcionar()
        {
            return View(new Agendamento());
        }

        // POST: PacienteWebController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Adcionar(Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                //Setar o código do carro
                agendamento.id_agendamento = ++_id;
                //Adicionar o carro na lista
                await _InterfaceAgendamentoApp.Adcionar(agendamento);
                //Mandar uma mensagem de sucesso para a view
                TempData["msg"] = "Agendamento cadastrado!";
                //Redireciona para o método Cadastrar
                return RedirectToAction("Index");
            }
            return View(new Agendamento());

        }


        // GET: PacienteWebController/Edit/5
        [HttpGet] //Abrir o formulário com os dados preenchidos
        public async Task<ActionResult> Atualizar(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var agendamento = await _InterfaceAgendamentoApp.ObterPorId((int)id);
            if (agendamento == null)
            {
                return NotFound();
            }
            return View(agendamento);

        }




        // POST: PacienteWebController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Atualizar(int id, Agendamento agendamento)
        {
            if (id != agendamento.id_agendamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _InterfaceAgendamentoApp.Atualizar(agendamento);
                }
                catch (DbUpdateConcurrencyException)
                {

                    ModelState.AddModelError(string.Empty, "Erro de concorrência ao atualizar o agendamento. Tente novamente.");
                    return View(agendamento);
                }

                return RedirectToAction(nameof(Index));
            }

            //Mensagem de sucesso
            TempData["msg"] = "Agendamento atualizado!";


            return View(agendamento);
        }






        [HttpGet] //Abrir o formulário com os dados preenchidos
        public async Task<ActionResult> Excluir(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var agendamento = await _InterfaceAgendamentoApp.ObterPorId((int)id);
            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);


        }


        // POST: PacienteWebController/Delete/5
        [HttpPost]

        public async Task<ActionResult> Excluir(int id)
        {

            var agendamento = await _InterfaceAgendamentoApp.ObterPorId(id);
            await _InterfaceAgendamentoApp.Excluir(agendamento);

            return RedirectToAction(nameof(Index));

        }




    }
}
