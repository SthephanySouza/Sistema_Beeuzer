using Beeuzer.Models;
using Beeuzer.ViewModel;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Beeuzer.Controllers
{
    public class CarrinhoController : Controller
    {
        Produto produto = new Produto();
        Cliente cliente = new Cliente();
        Carrinho car = new Carrinho();

        [HttpGet]
        public ActionResult Carrinho(string NomeCli)
        {
            Int64 CodCli = cliente.SelectCodCli(NomeCli);
            return View(car.SelectCar(CodCli));
        }

        [HttpPost]
        public ActionResult Carrinho(FormCollection carrinho)
        {
            string Cor = carrinho["Cor"];
            string Tamanho = carrinho["Tamanho"];
            Int16 Qtd = Convert.ToInt16(carrinho["Qtd"]);
            string NomeProd = carrinho["Caixa"];
            string Nome = carrinho["NomeCli"];

            Int64 CodProd = produto.SelectCod(NomeProd, Cor, Tamanho);
            Int64 CodCli = cliente.SelectCodCli(Nome);

            if (CodCli != 0 && CodProd != 0)
            {
                car.InsertCar(CodCli, Qtd, CodProd);
                return View(car.SelectCar(CodCli));
            }

            ViewBag.Texto = "Não aconteceu nada";
            return View();
        }

        public ActionResult DeletaCarinho(int id, string NomeCli)
        {
            car.DeleteCar(id);
            return RedirectToAction("Carrinho", "Carrinho", new {NomeCli = NomeCli});
        }

        public ActionResult UpdateCarrinho(string IdCar, string Qtd, decimal TotalProd, string NomeCli)
        {
            Int64 CodCli = cliente.SelectCodCli(NomeCli);
            int Car = Convert.ToInt32(IdCar);
            int QtdNova = Convert.ToInt32(Qtd);

            car.UpdateCar(Car, QtdNova, TotalProd, CodCli);
            return RedirectToAction("Carrinho", "Carrinho", new { NomeCli = NomeCli});
        }
    }
}