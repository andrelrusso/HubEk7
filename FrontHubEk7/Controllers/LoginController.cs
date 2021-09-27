using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FrontHubEk7.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrontHubEk7.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(model);

            ModelState.Clear();
            var claims = new List<Claim>
                     {
                         //Atributos do usuário ...
                         new Claim(ClaimTypes.Name, model.Login),
                         new Claim(ClaimTypes.Role, "Admin"),
                         //new Claim("Nome", response.User.Nome),
                     };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var login = HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(identity)
                  );
            var isAuth = User.Identity.IsAuthenticated;
            return RedirectToLocal(returnUrl);

            //Thread.Sleep(2000);
            //Partitioner<Tuple<int, int>> customPartitioner = Partitioner.Create(0, 10000, 1);
            //var q = from x in customPartitioner.AsParallel()
            //    .WithDegreeOfParallelism(30)
            //    .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
            //        select x;
            //q.ForAll((i) =>
            //{
            //    Debug.WriteLine($"{i.Item1} - {authService.Teste().IdUsuario}");

            //});
            //ShowSuccessMessage("Concluido");

            /* try
             {
                 //throw new Exception("Usuário inválido");

                 var data = new AuthDataFromPassPhrase();
                 data.UserIdentity = model.Login;
                 data.KeyContent = model.Senha;

                 var response = await authService.LogIn(JsonConvert.SerializeObject(data), settings.KeyCrypto);
                 if (response != null && response.Logged)
                 {
                     response.Token = TokenHelper.GenerateJwtToken(response.User.IdUsuario, tokenConfigurations, signingConfigurations);
                     SharedValues.Session = SharedValues.Session ?? HttpContext.Session;
                     SharedValues.UsuarioLogado = response.User;
                     SharedValues.SuccessMessage = string.Empty;
                     SharedValues.ErrorMessage = string.Empty;

                     //Defina pelo menos um conjunto de claims...
                     var claims = new List<Claim>
                     {
                         //Atributos do usuário ...
                         new Claim(ClaimTypes.Name, response.User.Login),
                         new Claim(ClaimTypes.Role, "Admin"),
                         //new Claim("Nome", response.User.Nome),
                     };

                     var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                     //var authProperties = new AuthenticationProperties
                     //{
                     //    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(5),
                     //    IsPersistent = true
                     //};

                     ////Loga de fato
                     //var login = HttpContext.SignInAsync(
                     //      CookieAuthenticationDefaults.AuthenticationScheme,
                     //      new ClaimsPrincipal(identity), authProperties
                     //);

                     var login = HttpContext.SignInAsync(
                           CookieAuthenticationDefaults.AuthenticationScheme,
                           new ClaimsPrincipal(identity)
                     );
                     var isAuth = User.Identity.IsAuthenticated;
                     return RedirectToLocal(returnUrl);
                 }
                 else
                 {
                     throw new Exception(string.Join(" - ", response.Errors.Select(r => r.ToString())));
                 }
             }
             catch (Exception ex)
             {
                 ShowErrorMessage(ex);
             }

             return View();*/

        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            return Url.IsLocalUrl(returnUrl) ? Redirect(returnUrl) : (IActionResult)RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}