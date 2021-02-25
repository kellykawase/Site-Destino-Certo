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
    public class UsuarioController : Controller
    {
        public IActionResult ListaUsuario()
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");

            UsuarioBanco usuarioBanco = new UsuarioBanco();
            List<Usuario> ListaUsuario = usuarioBanco.ListarUsuario();
            return View(ListaUsuario);
        }

        public IActionResult CadastroUsuario()
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");

            return View();
        }

        [HttpPost]
        public IActionResult CadastroUsuario(Usuario usuario)
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");            
            UsuarioBanco usuarioBanco = new UsuarioBanco();
            usuarioBanco.InserirUsuario(usuario);
            ViewBag.Mensagem = "Cadastro realizado com sucesso!";
            return View();            
        }


        public IActionResult EditarUsuario(int Id)
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");
            UsuarioBanco usuarioBanco = new UsuarioBanco();
            Usuario usuario = usuarioBanco.BuscarPorIdUsuario(Id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult EditarUsuario(Usuario usuario)
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");            
            UsuarioBanco usuarioBanco = new UsuarioBanco();
            usuarioBanco.AtualizarUsuario(usuario);
            ViewBag.Mensagem = "Usuario atualizado com sucesso!";
            return RedirectToAction("ListaUsuario");
        }

        public IActionResult RemoverUsuario(int Id)
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");
            UsuarioBanco usuarioBanco = new UsuarioBanco();
            usuarioBanco.RemoverUsuario(Id);
            return RedirectToAction("ListaUsuario");           
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
                ViewBag.Mensagem="Você está logado";
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


