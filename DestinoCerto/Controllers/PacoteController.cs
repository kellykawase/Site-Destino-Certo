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
    public class PacoteController : Controller
    {
        public IActionResult ListaPacote()
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");
                
            PacoteBanco pacoteBanco = new PacoteBanco();
            List<Pacote> ListaPacote = pacoteBanco.ListarPacote();
            return View(ListaPacote);
        }

        public IActionResult CadastroPacote()
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");

            return View();
        }

        [HttpPost]
        public IActionResult CadastroPacote(Pacote pacote)
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");            
            PacoteBanco pacoteBanco = new PacoteBanco();
            pacoteBanco.InserirPacote(pacote);
            ViewBag.Mensagem = "Cadastro realizado com sucesso!";
            return View();            
        }

        public IActionResult EditarPacote(int IdP)
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");
            PacoteBanco pacoteBanco = new PacoteBanco();
            Pacote pacote = pacoteBanco.BuscarPorIdPacote(IdP);
            return View(pacote);
        }

        [HttpPost]
        public IActionResult EditarPacote(Pacote pacote)
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");            
            PacoteBanco pacoteBanco = new PacoteBanco();
            pacoteBanco.AtualizarPacote(pacote);
            ViewBag.Mensagem = "Usuario atualizado com sucesso!";
            return RedirectToAction("ListaPacote");
        }

        public IActionResult RemoverPacote(int IdP)
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");
            PacoteBanco pacoteBanco = new PacoteBanco();
            pacoteBanco.RemoverPacote(IdP);
            return RedirectToAction("ListaPacote");           
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


