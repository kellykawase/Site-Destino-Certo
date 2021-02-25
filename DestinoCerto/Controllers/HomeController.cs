using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DestinoCerto.Models;
using Microsoft.AspNetCore.Http;

namespace DestinoCerto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
                public IActionResult Vitrine()
        {
            PacoteBanco pacoteBanco = new PacoteBanco();
            List<Pacote> ListaPacote = pacoteBanco.ListarPacote();
            return View(ListaPacote);
        }

                public IActionResult Home()
        {
            PacoteBanco pacoteBanco = new PacoteBanco();
            List<Pacote> ListaPacote = pacoteBanco.ListarPacote();
            return View(ListaPacote);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            UsuarioBanco usuarioBanco = new UsuarioBanco();
            Usuario usuarioSessao = usuarioBanco.ValidarLogin(usuario);

            if(usuarioSessao != null) 
            {
                ViewBag.Mensagem="Você está logado!";
                HttpContext.Session.SetInt32("IdUsuario", usuarioSessao.Id);
                HttpContext.Session.SetString("NomeUsuario", usuarioSessao.Nome);

                 return View();
            } else {
                ViewBag.Mensagem = "Falha no login!";
                return View();
            }
        }
               public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
           }
}


