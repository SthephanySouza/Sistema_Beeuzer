using Beeuzer.Models;
using Beeuzer.ViewModel;
using Hash = Beeuzer.Utils.Hash;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace Beeuzer.Controllers
{
    public class AutenticacaoController : Controller
    {
        // GET: Autenticacao
        [HttpGet]
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(CadastroViewModel viewModel)
        {
            if(!ModelState.IsValid)
                return View(viewModel);

            Cadastro novoCad = new Cadastro
            {
                Nome = viewModel.Nome,
                Email = viewModel.Email,
                Cpf = viewModel.Cpf,
                Telefone = viewModel.Telefone,
                Senha = Hash.GerarHash(viewModel.Senha),
                TipoAcesso = viewModel.TipoAcesso
            };
            novoCad.InsertCad(novoCad);

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

        [HttpPost]
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
                return RedirectToAction("Error", new { mensagem = e.Message });
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                    conexao.Close();
            }

            Cadastro cadastro = new Cadastro();
            cadastro = cadastro.SelectCad(viewmodel.Email);

            if (cadastro == null | cadastro.Email != viewmodel.Email)
            {
                ModelState.AddModelError("Login", "Login incorreto");
                return View(viewmodel);
            }
            if (cadastro.Senha != Hash.GerarHash(viewmodel.Senha))
            {
                ModelState.AddModelError("Senha", "Senha incorreta");
                return View(viewmodel);
            }

            var identity = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, cadastro.Email),
                new Claim("Login", cadastro.Email)
            }, "AppAplicationCookie");

            Request.GetOwinContext().Authentication.SignIn(identity);

            if (!String.IsNullOrWhiteSpace(viewmodel.UrlRetorno) || Url.IsLocalUrl(viewmodel.UrlRetorno))
                return Redirect(viewmodel.UrlRetorno);
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("AppAplicationCookie");
            return RedirectToAction("Login", "Autenticacao");
        }
    }
}