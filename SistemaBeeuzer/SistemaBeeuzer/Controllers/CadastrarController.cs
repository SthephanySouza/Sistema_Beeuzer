using SistemaBeeuzer.Models;
using SistemaBeeuzer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaBeeuzer.Controllers
{
    public class CadastrarController : Controller
    {
        [HttpGet]
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(CadastrarViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            Entrar novoCad = new Entrar()
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

            return RedirectToAction("Insex", "Home");
        }

        public ActionResult Login(string ReturnUrl)
        {
            var viewmodel = new LoginViewModel
            {
                UrlRetorno = ReturnUrl
            };
            return View(viewmodel);
        }
    }
}