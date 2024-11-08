using Aplication.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjetoChallangeOdontoprevSprint1.Controllers
{
    public class FraudeWebController : Controller
    {

        private readonly InterfaceFraudeApp _InterfaceFraudeApp;

        public FraudeWebController(InterfaceFraudeApp InterfaceFraudeApp)
        {
            _InterfaceFraudeApp = InterfaceFraudeApp;
        }


        //Lista de carro para simular o banco de dados
        //  private static List<Paciente> _lista = new List<Paciente>();

        private static int _id = 0; //Controla o IDc 


        // GET: PacienteWebController
        public async Task<ActionResult> Index()
        {

            // return View(_InterfacePacienteApp);
            return View(await _InterfaceFraudeApp.Listar());
        }



        // GET: PacienteWebController/Create
        public async Task<ActionResult> Adcionar()
        {
            return View(new Fraude());
        }

        // POST: PacienteWebController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Adcionar(Fraude fraude)
        {
            if (ModelState.IsValid)
            {
                //Setar o código do carro
                fraude.id_fraude = ++_id;
                //Adicionar o carro na lista
                await _InterfaceFraudeApp.Adcionar(fraude);
                //Mandar uma mensagem de sucesso para a view
                TempData["msg"] = "Fraude cadastrada!";
                //Redireciona para o método Cadastrar
                return RedirectToAction("Index");
            }
            return View(new Fraude());

        }


        // GET: PacienteWebController/Edit/5
        [HttpGet] //Abrir o formulário com os dados preenchidos
        public async Task<ActionResult> Atualizar(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var fraude = await _InterfaceFraudeApp.ObterPorId((int)id);
            if (fraude == null)
            {
                return NotFound();
            }
            return View(fraude);

        }




        // POST: PacienteWebController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Atualizar(int id, Fraude fraude)
        {
            if (id != fraude.id_fraude)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _InterfaceFraudeApp.Atualizar(fraude);
                }
                catch (DbUpdateConcurrencyException)
                {

                    ModelState.AddModelError(string.Empty, "Erro de concorrência ao atualizar a fraude. Tente novamente.");
                    return View(fraude);
                }

                return RedirectToAction(nameof(Index));
            }

            //Mensagem de sucesso
            TempData["msg"] = "Fraude atualizada!";


            return View(fraude);
        }






        [HttpGet] //Abrir o formulário com os dados preenchidos
        public async Task<ActionResult> Excluir(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var fraude = await _InterfaceFraudeApp.ObterPorId((int)id);
            if (fraude == null)
            {
                return NotFound();
            }

            return View(fraude);


        }


        // POST: PacienteWebController/Delete/5
        [HttpPost]

        public async Task<ActionResult> Excluir(int id)
        {

            var fraude = await _InterfaceFraudeApp.ObterPorId(id);
            await _InterfaceFraudeApp.Excluir(fraude);

            return RedirectToAction(nameof(Index));

        }



    }
}