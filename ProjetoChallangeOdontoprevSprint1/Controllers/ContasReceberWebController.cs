using Aplication.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjetoChallangeOdontoprevSprint1.Controllers
{
    public class ContasReceberWebController : Controller
    {
        private readonly InterfaceContasReceberApp _InterfaceContasReceberApp;

        public ContasReceberWebController(InterfaceContasReceberApp InterfaceContasReceberApp)
        {
            _InterfaceContasReceberApp = InterfaceContasReceberApp;
        }


        //Lista de carro para simular o banco de dados
        //  private static List<Paciente> _lista = new List<Paciente>();

        private static int _id = 0; //Controla o IDc 


        // GET: PacienteWebController
        public async Task<ActionResult> Index()
        {

            // return View(_InterfacePacienteApp);
            return View(await _InterfaceContasReceberApp.Listar());
        }



        // GET: PacienteWebController/Create
        public async Task<ActionResult> Adcionar()
        {
            return View(new ContasReceber());
        }

        // POST: PacienteWebController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Adcionar(ContasReceber contasreceber)
        {
            if (ModelState.IsValid)
            {
                //Setar o código do carro
                contasreceber.id_conta_receber = ++_id;
                //Adicionar o carro na lista
                await _InterfaceContasReceberApp.Adcionar(contasreceber);
                //Mandar uma mensagem de sucesso para a view
                TempData["msg"] = "Contas a Receber cadastrada!";
                //Redireciona para o método Cadastrar
                return RedirectToAction("Index");
            }
            return View(new ContasReceber());

        }


        // GET: PacienteWebController/Edit/5
        [HttpGet] //Abrir o formulário com os dados preenchidos
        public async Task<ActionResult> Atualizar(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var contasreceber = await _InterfaceContasReceberApp.ObterPorId((int)id);
            if (contasreceber == null)
            {
                return NotFound();
            }
            return View(contasreceber);

        }




        // POST: PacienteWebController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Atualizar(int id, ContasReceber contasreceber)
        {
            if (id != contasreceber.id_conta_receber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _InterfaceContasReceberApp.Atualizar(contasreceber);
                }
                catch (DbUpdateConcurrencyException)
                {

                    ModelState.AddModelError(string.Empty, "Erro de concorrência ao atualizar as contas receber. Tente novamente.");
                    return View(contasreceber);
                }

                return RedirectToAction(nameof(Index));
            }

            //Mensagem de sucesso
            TempData["msg"] = "Contas a Receber atualizado!";


            return View(contasreceber);
        }






        [HttpGet] //Abrir o formulário com os dados preenchidos
        public async Task<ActionResult> Excluir(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var contasreceber = await _InterfaceContasReceberApp.ObterPorId((int)id);
            if (contasreceber == null)
            {
                return NotFound();
            }

            return View(contasreceber);


        }


        // POST: PacienteWebController/Delete/5
        [HttpPost]

        public async Task<ActionResult> Excluir(int id)
        {

            var contasreceber = await _InterfaceContasReceberApp.ObterPorId(id);
            await _InterfaceContasReceberApp.Excluir(contasreceber);

            return RedirectToAction(nameof(Index));

        }


    }




}
