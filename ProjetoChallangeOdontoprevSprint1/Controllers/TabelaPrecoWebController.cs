using Aplication.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjetoChallangeOdontoprevSprint1.Controllers
{
    public class TabelaPrecoWebController : Controller
    {

        private readonly InterfaceTabelaPrecoApp _InterfaceTabelaPrecoApp;

        public TabelaPrecoWebController(InterfaceTabelaPrecoApp InterfaceTabelaPrecoApp)
        {
            _InterfaceTabelaPrecoApp = InterfaceTabelaPrecoApp;
        }


        //Lista de carro para simular o banco de dados
        //  private static List<Paciente> _lista = new List<Paciente>();

        private static int _id = 0; //Controla o IDc 


        // GET: PacienteWebController
        public async Task<ActionResult> Index()
        {

            // return View(_InterfacePacienteApp);
            return View(await _InterfaceTabelaPrecoApp.Listar());
        }



        // GET: PacienteWebController/Create
        public async Task<ActionResult> Adcionar()
        {
            return View(new TabelaPreco());
        }

        // POST: PacienteWebController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Adcionar(TabelaPreco tabelapreco)
        {
            if (ModelState.IsValid)
            {
                //Setar o código do carro
                tabelapreco.id_tabela_preco = ++_id;
                //Adicionar o carro na lista
                await _InterfaceTabelaPrecoApp.Adcionar(tabelapreco);
                //Mandar uma mensagem de sucesso para a view
                TempData["msg"] = "Tabela Preco cadastrada!";
                //Redireciona para o método Cadastrar
                return RedirectToAction("Index");
            }
            return View(new TabelaPreco());

        }


        // GET: PacienteWebController/Edit/5
        [HttpGet] //Abrir o formulário com os dados preenchidos
        public async Task<ActionResult> Atualizar(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var tabelapreco = await _InterfaceTabelaPrecoApp.ObterPorId((int)id);
            if (tabelapreco == null)
            {
                return NotFound();
            }
            return View(tabelapreco);

        }




        // POST: PacienteWebController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Atualizar(int id, TabelaPreco tabelapreco)
        {
            if (id != tabelapreco.id_tabela_preco)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _InterfaceTabelaPrecoApp.Atualizar(tabelapreco);
                }
                catch (DbUpdateConcurrencyException)
                {

                    ModelState.AddModelError(string.Empty, "Erro de concorrência ao atualizar a Tabela de Precos. Tente novamente.");
                    return View(tabelapreco);
                }

                return RedirectToAction(nameof(Index));
            }

            //Mensagem de sucesso
            TempData["msg"] = "Tabela Preco atualizada!";


            return View(tabelapreco);
        }






        [HttpGet] //Abrir o formulário com os dados preenchidos
        public async Task<ActionResult> Excluir(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var tabelapreco = await _InterfaceTabelaPrecoApp.ObterPorId((int)id);
            if (tabelapreco == null)
            {
                return NotFound();
            }

            return View(tabelapreco);


        }


        // POST: PacienteWebController/Delete/5
        [HttpPost]

        public async Task<ActionResult> Excluir(int id)
        {

            var tabelapreco = await _InterfaceTabelaPrecoApp.ObterPorId(id);
            await _InterfaceTabelaPrecoApp.Excluir(tabelapreco);

            return RedirectToAction(nameof(Index));

        }


    }
}