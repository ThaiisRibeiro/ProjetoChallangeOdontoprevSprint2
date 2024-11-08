using Aplication.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjetoChallangeOdontoprevSprint1.Controllers
{
    public class ContasPagarWebController : Controller
    {
        private readonly InterfaceContasPagarApp _InterfaceContasPagarApp;

        public ContasPagarWebController(InterfaceContasPagarApp InterfaceContasPagarApp)
        {
            _InterfaceContasPagarApp = InterfaceContasPagarApp;
        }


        //Lista de carro para simular o banco de dados
        //  private static List<Paciente> _lista = new List<Paciente>();

        private static int _id = 0; //Controla o IDc 


        // GET: PacienteWebController
        public async Task<ActionResult> Index()
        {

            // return View(_InterfacePacienteApp);
            return View(await _InterfaceContasPagarApp.Listar());
        }



        // GET: PacienteWebController/Create
        public async Task<ActionResult> Adcionar()
        {
            return View(new ContasPagar());
        }

        // POST: PacienteWebController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Adcionar(ContasPagar contaspagar)
        {
            if (ModelState.IsValid)
            {
                //Setar o código do carro
                contaspagar.id_conta_pagar = ++_id;
                //Adicionar o carro na lista
                await _InterfaceContasPagarApp.Adcionar(contaspagar);
                //Mandar uma mensagem de sucesso para a view
                TempData["msg"] = "Contas a Pagar cadastrada!";
                //Redireciona para o método Cadastrar
                return RedirectToAction("Index");
            }
            return View(new ContasPagar());

        }


        // GET: PacienteWebController/Edit/5
        [HttpGet] //Abrir o formulário com os dados preenchidos
        public async Task<ActionResult> Atualizar(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var contaspagar = await _InterfaceContasPagarApp.ObterPorId((int)id);
            if (contaspagar == null)
            {
                return NotFound();
            }
            return View(contaspagar);

        }




        // POST: PacienteWebController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Atualizar(int id, ContasPagar contaspagar)
        {
            if (id != contaspagar.id_conta_pagar)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _InterfaceContasPagarApp.Atualizar(contaspagar);
                }
                catch (DbUpdateConcurrencyException)
                {

                    ModelState.AddModelError(string.Empty, "Erro de concorrência ao atualizar as contas pagar. Tente novamente.");
                    return View(contaspagar);
                }

                return RedirectToAction(nameof(Index));
            }

            //Mensagem de sucesso
            TempData["msg"] = "Contas a Pagar atualizado!";


            return View(contaspagar);
        }






        [HttpGet] //Abrir o formulário com os dados preenchidos
        public async Task<ActionResult> Excluir(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var contaspagar = await _InterfaceContasPagarApp.ObterPorId((int)id);
            if (contaspagar == null)
            {
                return NotFound();
            }

            return View(contaspagar);


        }


        // POST: PacienteWebController/Delete/5
        [HttpPost]

        public async Task<ActionResult> Excluir(int id)
        {

            var contaspagar = await _InterfaceContasPagarApp.ObterPorId(id);
            await _InterfaceContasPagarApp.Excluir(contaspagar);

            return RedirectToAction(nameof(Index));

        }


    }


}
