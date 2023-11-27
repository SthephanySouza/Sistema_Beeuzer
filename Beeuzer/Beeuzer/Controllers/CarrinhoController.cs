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
        private static Cliente cliente;

        [HttpGet]
        public ActionResult Carrinho()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Carrinho(FormCollection carrinho)
        {
            Produto produto = new Produto();
            string Cor = carrinho["Cor"];
            string Tamanho = carrinho["Tamanho"];
            int Qtd = Convert.ToInt32(carrinho["Qtd"]);
            string Nome = carrinho["Caixa"];

            Int64 Cod = produto.SelectCod(Nome, Cor, Tamanho);

            ViewBag.CodBarras = Cod;

            return View();
        }

        [HttpPost]
        public JsonResult InsertCarrinho(Carrinho carrinho)
        {
            carrinho.Cliente = new Cliente() 
            {
                IdCli = cliente.IdCli
            };
            int respostas = 0;

            respostas = CarrinhoViewModel.Instancia.InsertCar(carrinho);

            return Json(new { resposta = respostas }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult Quantidade()
        {
            int respostas = 0;
            respostas = CarrinhoViewModel.Instancia.Quantidade(cliente.IdCli);
            return Json(new { resposta = respostas }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult SelectCarrinho()
        {
            List<Carrinho> lista = new List<Carrinho>();
            lista = CarrinhoViewModel.Instancia.SelectCar(cliente.IdCli);

            if (lista.Count != 0)
            {
                lista = (from d in lista
                         select new Carrinho()
                          {
                              IdCar = d.IdCar,
                              Produto = new Produto()
                              {
                                  CodigoBarras = d.Produto.CodigoBarras,
                                  NomeProd = d.Produto.NomeProd,
                                  Cor = d.Produto.Cor,
                                  Tamanho = d.Produto.Tamanho,
                                  ValorUnitario = d.Produto.ValorUnitario
                              }
                          }).ToList();
            }


            return Json(new { list = lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeletCarrinho(string idCar, string codigoBarras)
        {
            bool resposta = false;
            resposta = CarrinhoViewModel.Instancia.DeletCar(idCar, codigoBarras);
            return Json(new { resultado = resposta }, JsonRequestBehavior.AllowGet);
        }

        /* public ActionResult Carrinho(string urlRetorno)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = ObterCarrinho(),
                UrlRetorno = urlRetorno
            });
        } */

        /* private Produto produto;

        public RedirectToRouteResult Adicionar(int codigoBarras, string urlRetorno)
        {
            produto = new Produto();

            Produto produtos = produto.NomeProd.FirstOrDefault(p => p.CodigoBarras == codigoBarras);

            if (produtos != null)
            {
                ObterCarrinho().AdicionarItem(produto, 1);
            }

            return RedirectToAction("Index", new { urlRetorno });
        } */

        /* private Carrinho ObterCarrinho()
        {
            Carrinho carrinho = (Carrinho)Session["Carrinho"];

            if (carrinho == null)
            {
                carrinho = new Carrinho();
                Session["Carrinho"] = carrinho;
            }
            return carrinho;
        } */

        /* public RedirectToRouteResult Remover(int codigoBarras, string urlRetorno)
        {
            produto = new Produto();

            Produto produtos = produto.NomeProd.FirstOrDefault(p => p.CodigoBarras == codigoBarras);

            if (produtos != null)
            {
                ObterCarrinho().RemoverItem(produtos);
            }
            return RedirectToAction("Index", new { urlRetorno });
        } */
    }
}