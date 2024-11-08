using Aplication.Aplication;
using Aplication.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjetoChallangeOdontoprevSprint1.Controllers
{
    public class PacienteWebController : Controller
    {
        private readonly InterfacePacienteApp _InterfacePacienteApp;

        public PacienteWebController(InterfacePacienteApp InterfacePacienteApp)
        {
            _InterfacePacienteApp = InterfacePacienteApp;
        }


        //Lista de carro para simular o banco de dados
      //  private static List<Paciente> _lista = new List<Paciente>();

        private static int _id = 0; //Controla o IDc 
        

        // GET: PacienteWebController
        public async Task<ActionResult> Index()
        {
            
           // return View(_InterfacePacienteApp);
            return View(await _InterfacePacienteApp.Listar());
        }



        // GET: PacienteWebController/Create
        public async Task<ActionResult> Adcionar()
        {
            return View(new Paciente());
        }

        // POST: PacienteWebController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Adcionar(Paciente paciente)
        {

            if (ModelState.IsValid)
            {

                //Setar o código do carro
                paciente.id_paciente = ++_id;
                //Adicionar o carro na lista
                await _InterfacePacienteApp.Adcionar(paciente);
                //Mandar uma mensagem de sucesso para a view
                TempData["msg"] = "Paciente cadastrado!";
                //Redireciona para o método Cadastrar
                return RedirectToAction("Index");
            }
            return View(paciente);

      
        }


        // GET: PacienteWebController/Edit/5
        [HttpGet] //Abrir o formulário com os dados preenchidos
        public async Task<ActionResult> Atualizar(int? id)
        {
            
                if (id == null)
                {
                    return NotFound();
                }

                var paciente = await _InterfacePacienteApp.ObterPorId((int)id);
                if (paciente == null)
                {
                    return NotFound();
                }
                return View(paciente);
            
        }




        // POST: PacienteWebController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Atualizar(int id, Paciente paciente)
        {
            if (id != paciente.id_paciente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _InterfacePacienteApp.Atualizar(paciente);
                }
                catch (DbUpdateConcurrencyException)
                {

                    ModelState.AddModelError(string.Empty, "Erro de concorrência ao atualizar o paciente. Tente novamente.");
                    return View(paciente);
                }

                return RedirectToAction(nameof(Index));
            }

            //Mensagem de sucesso
            TempData["msg"] = "Paciente atualizado!";


            return View(paciente);
        }


       
                 


                [HttpGet] //Abrir o formulário com os dados preenchidos
                public async Task<ActionResult> Excluir(int? id)
                {
           
                    if (id == null)
                    {
                      return NotFound();
                    }

                    var paciente = await _InterfacePacienteApp.ObterPorId((int)id);
                    if (paciente == null)
                    {
                         return NotFound();
                    }

                    return View(paciente);
            

                }


    // POST: PacienteWebController/Delete/5
    [HttpPost]

                public async Task<ActionResult> Excluir(int id)
                {
            
                      var paciente = await _InterfacePacienteApp.ObterPorId(id);
                      await _InterfacePacienteApp.Excluir(paciente);

                        return RedirectToAction(nameof(Index));
            
                }
            
        
        }
    }
