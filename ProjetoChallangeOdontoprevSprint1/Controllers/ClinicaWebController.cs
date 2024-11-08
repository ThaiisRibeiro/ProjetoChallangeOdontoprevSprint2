using Aplication.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjetoChallangeOdontoprevSprint1.Controllers
{
    public class ClinicaWebController : Controller
    {
        private readonly InterfaceClinicaApp _InterfaceClinicaApp;

        public ClinicaWebController(InterfaceClinicaApp InterfaceClinicaApp)
        {
            _InterfaceClinicaApp = InterfaceClinicaApp;
        }


        //Lista de carro para simular o banco de dados
        //  private static List<Paciente> _lista = new List<Paciente>();

        private static int _id = 0; //Controla o IDc 


        // GET: PacienteWebController
        public async Task<ActionResult> Index()
        {

            // return View(_InterfacePacienteApp);
            return View(await _InterfaceClinicaApp.Listar());
        }



        // GET: PacienteWebController/Create
        public async Task<ActionResult> Adcionar()
        {
            return View(new Clinica());
        }

        // POST: PacienteWebController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Adcionar(Clinica clinica)
        {
            if (ModelState.IsValid)
            {
                //Setar o código do carro
                clinica.id_clinica = ++_id;
                //Adicionar o carro na lista
                await _InterfaceClinicaApp.Adcionar(clinica);
                //Mandar uma mensagem de sucesso para a view
                TempData["msg"] = "Clinica cadastrado!";
                //Redireciona para o método Cadastrar
                return RedirectToAction("Index");
            }
            return View(new Clinica());

        }


        // GET: PacienteWebController/Edit/5
        [HttpGet] //Abrir o formulário com os dados preenchidos
        public async Task<ActionResult> Atualizar(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var clinica = await _InterfaceClinicaApp.ObterPorId((int)id);
            if (clinica == null)
            {
                return NotFound();
            }
            return View(clinica);

        }




        // POST: PacienteWebController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Atualizar(int id, Clinica clinica)
        {
            if (id != clinica.id_clinica)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _InterfaceClinicaApp.Atualizar(clinica);
                }
                catch (DbUpdateConcurrencyException)
                {

                    ModelState.AddModelError(string.Empty, "Erro de concorrência ao atualizar o clinica. Tente novamente.");
                    return View(clinica);
                }

                return RedirectToAction(nameof(Index));
            }

            //Mensagem de sucesso
            TempData["msg"] = "Clinica atualizado!";


            return View(clinica);
        }






        [HttpGet] //Abrir o formulário com os dados preenchidos
        public async Task<ActionResult> Excluir(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var clinica = await _InterfaceClinicaApp.ObterPorId((int)id);
            if (clinica == null)
            {
                return NotFound();
            }

            return View(clinica);


        }


        // POST: PacienteWebController/Delete/5
        [HttpPost]

        public async Task<ActionResult> Excluir(int id)
        {

            var clinica = await _InterfaceClinicaApp.ObterPorId(id);
            await _InterfaceClinicaApp.Excluir(clinica);

            return RedirectToAction(nameof(Index));

        }


    }


}
