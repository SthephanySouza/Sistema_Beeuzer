using Antlr.Runtime;
using AppLoginAutenticacao.Models;
using AppLoginAutenticacao.Utils;
using AppLoginAutenticacao.ViewModel;
using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AppLoginAutenticacao.Controllers
{
    public class AutenticacaoController : Controller
    {
        public ActionResult Error(string mensagem)
        {
            ViewBag.error = "Entre em contato com o TI e passe a seguinte mensagem: {" + mensagem + "}";
            return View();
        }

        [HttpGet]
        public ActionResult Insert()
        {
            MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
            try
            {
                conexao.Open();
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", new { mensagem = e.Message });
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                    conexao.Close();
            }

            return View();
        }

        [HttpPost]
        public ActionResult Insert(CadastroUsuarioViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            Cadastro novoCad = new Cadastro
            {
                Nome = viewModel.Nome,
                Email = viewModel.Email,
                Cpf = viewModel.Cpf,
                Telefone = viewModel.Telefone,
                Cep = viewModel.Cep,
                NumEnd = viewModel.NumEnd,
                CompleEnd = viewModel.CompleEnd,
                Logradouro = viewModel.Logradouro,
                NomeBairro = viewModel.NomeBairro,
                NomeCidade = viewModel.NomeCidade,
                Senha = viewModel.Senha,
                TipoAcesso = viewModel.TipoAcesso
            };
            novoCad.InsertCad(novoCad);

            TempData["MensagemLogin"] = "Cadastro realizado com sucesso! Faça o login.";
            return RedirectToAction("Login", "Autenticacao");
        }

        public ActionResult SelectLogin(string Login)
        {
            bool LoginExists;
            string login = new Cadastro().SelectLogin(Login);

            if (login.Length == 0)
                LoginExists = false;
            else
                LoginExists = true;

            return Json(!LoginExists, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Login(string ReturnUrl)
        {
            var viewmodel = new LoginViewModel
            {
                UrlRetorno = ReturnUrl
            };
            return View(viewmodel);
        }

        /* [HttpPost]
        public ActionResult Login(LoginViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
            try
            {
                conexao.Open();
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", new { mensagem = e.Message} );
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                    conexao.Close();
            }

            Cadastro usuario = new Cadastro();
            usuario = usuario.SelectUsuario(viewmodel.Login);

            if(usuario == null | usuario.Email != viewmodel.Login)
            {
                ModelState.AddModelError("Login", "Login incorreto");
                return View(viewmodel);
            }
            if(usuario.Senha != Hash.GerarHash(viewmodel.Senha))
            {
                ModelState.AddModelError("Senha", "Senha incorreta");
                return View(viewmodel);
            }

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, usuario.Email),
                new Claim("Email", usuario.Email)
            }, "AppAplicationCookie");

            Request.GetOwinContext().Authentication.SignIn(identity);

            if (!String.IsNullOrWhiteSpace(viewmodel.UrlRetorno) || Url.IsLocalUrl(viewmodel.UrlRetorno))
                return Redirect(viewmodel.UrlRetorno);
            else
                return RedirectToAction("Index", "Administrativo");
        }

        [Authorize]
        [HttpPost]
        public ActionResult AlterarSenha(AlterarSenhaViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var identity = User.Identity as ClaimsIdentity;
            var login = identity.Claims.FirstOrDefault(c => c.Type == "Login").Value;

            Cadastro usuario = new Cadastro();
            usuario = usuario.SelectUsuario(login);

            if (Hash.GerarHash(viewmodel.NovaSenha) == usuario.Senha)
            {
                ModelState.AddModelError("SenhaAtual", "Senha incorreta");
                return View();
            }

            usuario.Senha = Hash.GerarHash(viewmodel.NovaSenha);
            usuario.UpdateSenha(usuario);

            TempData["MensagemLogin"] = "Senha alterada com sucesso!";
            return RedirectToAction("Index", "Home");
        } */

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("AppAplicationCookie");
            return RedirectToAction("Index", "Home");
        }
    }
}