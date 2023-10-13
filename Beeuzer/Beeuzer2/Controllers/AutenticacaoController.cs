using Beeuzer2.Models;
using Beeuzer2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beeuzer2.Controllers
{
    public class AutenticacaoController : Controller
    {
        [HttpGet]
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(CadastroViewModel viewModel)
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

            return RedirectToAction("Index", "Home");
        }
    }
}