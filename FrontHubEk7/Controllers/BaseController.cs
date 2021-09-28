using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrontHubEk7.Controllers
{
    //[HandleJsonException]
    [Authorize]
    public class BaseController : Controller
    {
        //protected const int PAGE_SIZE = 5;
        //protected const string DESCRIPTION_ALL = "Todos";
        //private readonly IHttpClientFactory _clientFactory;

        //public BaseController(IHttpContextAccessor httpContextAccessor, IHttpClientFactory clientFactory)
        //{
        //    SharedValues.Session = httpContextAccessor.HttpContext.Session;
        //    _clientFactory = clientFactory;
        //}

        public void PopupMessageError(string mensagem)
        {
            ModelState.AddModelError("Error", mensagem);
        }

        public void PopupMessageError(Exception ex)
        {
            PopupMessageError(ex.Message);
        }
        public void PopupMessageSuccess(string mensagem)
        {
            ViewBag.SuccessMessage = mensagem;
        }
    }
}