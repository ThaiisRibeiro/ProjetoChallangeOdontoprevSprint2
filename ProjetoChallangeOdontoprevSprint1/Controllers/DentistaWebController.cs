using Aplication.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjetoChallangeOdontoprevSprint1.Controllers
{
    public class DentistaWebController : Controller
    {
        private readonly InterfaceDentistaApp _InterfaceDentistaApp;

        public DentistaWebController(InterfaceDentistaApp InterfaceDentistaApp)
        {
            _InterfaceDentistaApp = InterfaceDentistaApp;
        }


        //Lista de carro para simular o banco de dados
        //  private static List<Paciente> _lista = new List<Paciente>();

        private static int _id = 0; //Controla o IDc 


        // GET: PacienteWebController
        public async Task<ActionResult> Index()
        {

            // return View(_InterfacePacienteApp);
            return View(await _InterfaceDentistaApp.Listar());
        }



        // GET: PacienteWebController/Create
        public async Task<ActionResult> Adcionar()
        {
            return View(new Dentista());
        }

        // POST: PacienteWebController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Adcionar(Dentista dentista)
        {
            if (ModelState.IsValid)
            {
                //Setar o código do carro
                dentista.id_dentista = ++_id;
                //Adicionar o carro na lista
                await _InterfaceDentistaApp.Adcionar(dentista);
                //Mandar uma mensagem de sucesso para a view
                TempData["msg"] = "Dentista cadastrado!";
                //Redireciona para o método Cadastrar
                return RedirectToAction("Index");
            }
            return View(new Dentista());

        }


        // GET: PacienteWebController/Edit/5
        [HttpGet] //Abrir o formulário com os dados preenchidos
        public async Task<ActionResult> Atualizar(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var dentista = await _InterfaceDentistaApp.ObterPorId((int)id);
            if (dentista == null)
            {
                return NotFound();
            }
            return View(dentista);

        }




        // POST: PacienteWebController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Atualizar(int id, Dentista dentista)
        {
            if (id != dentista.id_dentista)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _InterfaceDentistaApp.Atualizar(dentista);
                }
                catch (DbUpdateConcurrencyException)
                {

                    ModelState.AddModelError(string.Empty, "Erro de concorrência ao atualizar o dentista. Tente novamente.");
                    return View(dentista);
                }

                return RedirectToAction(nameof(Index));
            }

            //Mensagem de sucesso
            TempData["msg"] = "Dentista atualizado!";


            return View(dentista);
        }






        [HttpGet] //Abrir o formulário com os dados preenchidos
        public async Task<ActionResult> Excluir(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var dentista = await _InterfaceDentistaApp.ObterPorId((int)id);
            if (dentista == null)
            {
                return NotFound();
            }

            return View(dentista);


        }


        // POST: PacienteWebController/Delete/5
        [HttpPost]

        public async Task<ActionResult> Excluir(int id)
        {

            var dentista = await _InterfaceDentistaApp.ObterPorId(id);
            await _InterfaceDentistaApp.Excluir(dentista);

            return RedirectToAction(nameof(Index));

        }


    }



}

