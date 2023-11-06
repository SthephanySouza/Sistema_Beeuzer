using Beeuzer.Models;
using Beeuzer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beeuzer.Repository;

namespace Beeuzer.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutoRepo produtoRepo;

        public ActionResult Index()
        {
            produtoRepo = new ProdutoRepo();
            var produtos = produtoRepo.Produtos.Take(3);
            {
                return View(produtos);
            }
        }
    }
}