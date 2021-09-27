using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontHubEk7.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontHubEk7.Controllers
{
    public class SecurityAccessController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var model = new SecurityAccessModel
            {
               // Itens = await incidenteFacade.ToListAsync(null).ToPagedListAsync(PAGE_SIZE, 1)
            };
            //model.Estado = CodeUtil.PopulaComboComEnum(model.Detalhe.EstadoIncidente);
            //model.NaoConformidades = naoConformidades.AddAllToList(nameof(NaoConformidade.Descricao));
            return View(model);
        }

        /// <summary>
        /// Filtra os Usuários
        /// </summary>
        /// <param name="i">Id</param>
        /// <param name="d">Descrição</param>
        /// <param name="s">Status</param>
        /// <param name="p">Pagina atual</param>
        /// <param name="pz">Tamanho da página</param>
        /// <returns>Partial com a lista dos registros</returns>
        //public async Task<IActionResult> Pesquisar(int i, string d, int? idps, int s, int? p, int pz = 100)
        //{
        //    var itens = await incidenteFacade.ToListAsync(new Incidente
        //    {
        //        IdIncidente = i,
        //        Descricao = d,
        //        EstadoIncidente = (enumEstadoIncidente)s,
        //        NaoConformidade = idps != null ? new NaoConformidade { IdNaoConformidade = (int)idps } : null
        //    }).ToPagedListAsync(pz, p ?? 1);

        //    return PartialView("_ListaItens", itens);
        //}



        public async Task<IActionResult> Detalhes(int? id)
        {
            ViewBag.propertydisable = id > 0 ? false : true;
            var model = new SecurityAccessModel
            {
                Detalhe = new SecurityAccess()
};
            // model.Estado = CodeUtil.PopulaComboComEnum(model.Detalhe.EstadoIncidente, enumEstadoIncidente.Todos);
            //model.NaoConformidades = naoConformidades.AddAllToList(nameof(NaoConformidade.Descricao));
            if (id.HasValue)
            {

                //model.Detalhe = await incidenteFacade.Get(id.Value);
                //if (model.Detalhe == null) return NotFound();
            }
            return View(model);
        }


        //[HttpPost]
        //public IActionResult Detalhes(SecurityAccessModel model)
        //{
        //    //model.Estado = CodeUtil.PopulaComboComEnum(model.Detalhe.EstadoIncidente, enumEstadoIncidente.Todos);
        //    //model.NaoConformidades = naoConformidades.AddAllToList(nameof(NaoConformidade.Descricao));
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return View(model);
        //    //}
        //    //try
        //    //{
        //    //    model.Detalhe.IdUsuarioOperacao = SharedValues.UsuarioLogado.IdUsuario;
        //    //    incidenteFacade.Gerenciar(model.Detalhe);
        //    //    ShowSuccessMessage("Registros processado com sucesso");
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    ShowErrorMessage(ex);
        //    //    return View(model);
        //    //}

        //    return RedirectToAction(nameof(Detalhes), new { id = model.Detalhe.IdIncidente });
        //}
    }
}