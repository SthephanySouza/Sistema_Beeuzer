using Beeuzer.Models;
using Beeuzer.ViewModel;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beeuzer.Controllers
{
    public class CarrinhoController : Controller
    {
        // GET: Carrinho
        public ActionResult Carrinho()
        {
            return View();
        }

        public ActionResult Carrinho(Carrinho viewModel)
        {
            if (Session[@User.Identity.Name] != null)
            {
                if (!string.IsNullOrEmpty(Session[@User.Identity.Name].ToString()))
                {
                    return RedirectToAction("Login", "Altenticação");
                }
            }

            if (!string.IsNullOrEmpty(Request.QueryString[viewModel.CodigoBarras].ToString()))
            {
                Carrinho novoCar = new Carrinho
                {
                    NomeProd = viewModel.NomeProd,
                    Qtd = viewModel.Qtd,
                    ValorUnitario = viewModel.ValorUnitario,
                    TotalProd = viewModel.TotalProd,
                    TotalCar = viewModel.TotalCar
                };
                novoCar.InsertCad(novoCar);
            }

            return View();
        }


    }
}