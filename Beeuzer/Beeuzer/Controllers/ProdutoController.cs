using Beeuzer.Models;
using Beeuzer.ViewModel;
using System.Web.Mvc;

namespace Beeuzer.Controllers
{
    public class ProdutoController : Controller
    {
        /* public ActionResult Comprar(ProdutoViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            return View();
        } */

        /* public ActionResult Carrinho(ProdutoViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            Produto novoCar = new Produto
            {
                Nome = viewModel.NomeProd,
                Tamanho = viewModel.Tamanho,
                Cor = viewModel.Cor,
                ValorUnitario = viewModel.ValorUnitario,
                Qtd = viewModel.Qtd
            };
            novoCar.InsertCad(novoCar);

            RedirectToAction("Carrinho", "Carrinho");
        } */

        public ActionResult Caixa_Camisa()
        {
            return View();
        }

        public ActionResult Caixa_Calsa()
        {
            return View();
        }

        public ActionResult Caixa_Doacao()
        {
            return View();
        }

        /* public ActionResult Comprar(ProdutoViewModel viewModel)
        {
            RedirectToAction("Index", "Home");
        }

        public ActionResult Carrinho(ProdutoViewModel viewModel)
        {
            RedirectToAction("Carrinho", "Carrinho");
        } */
    }
}