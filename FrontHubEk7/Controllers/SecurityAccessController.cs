using System;
using System.Threading.Tasks;
using FrontEk7.Domain.Interfaces;
using FrontHubEk7.Models;
using Microsoft.AspNetCore.Mvc;
using FrontEk7.Domain;

namespace FrontHubEk7.Controllers
{
    public class SecurityAccessController : BaseController
    {
        private readonly ISecurityAccessRepository repository;
        public SecurityAccessController(ISecurityAccessRepository _repository)
        {
            repository = _repository;
        }
        public async Task<IActionResult> Index()
        {
            var model = new SecurityAccessModel
            {
                Itens = await repository.ListarAsync()
            };
            return View(model);
        }
        
        public async Task<IActionResult> Pesquisar(int? rassId, string stsClientId, string endPoint)
        {
            if (rassId != null || !string.IsNullOrEmpty(stsClientId) || !string.IsNullOrEmpty(endPoint))
            {
                return PartialView("_ListaItens", await repository.ListarAsync(p => p.RaasID == rassId || p.STSClientId == stsClientId || p.Endpoint == endPoint));
            }
            return PartialView("_ListaItens", await repository.ListarAsync());
        }



        public async Task<IActionResult> Detalhes(Guid? id)
        {
            ViewBag.propertydisable = id != null ? false : true;
            var model = new SecurityAccessModel
            {
                Detalhe = new SecurityAccess()
            };
            if (id != null)
            {
                model.Detalhe = await repository.ConsultarAsync(p=> p.ID  == id);
                if (model.Detalhe == null) return NotFound();
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Detalhes(SecurityAccessModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                model.Detalhe.DataCadastro = DateTime.Now;
                if (model.Detalhe.ID != null)
                {
                    await repository.AtualizarAsync(model.Detalhe);
                    PopupMessageSuccess("Registro atualizado com sucesso");
                }
                else
                {
                    await repository.AdicionarAsync(model.Detalhe);
                    PopupMessageSuccess("Registro inserido com sucesso");

                }
                //return Json(new {success = true });
                return View(model);
            }
            catch (Exception ex)
            {
                PopupMessageError(ex);
                return View(model);
            }

            //return RedirectToAction(nameof(Detalhes), new { id = model.Detalhe.ID });
            //return RedirectToAction(nameof(Index));
        }
    }
}