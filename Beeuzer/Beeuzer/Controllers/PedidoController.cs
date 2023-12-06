using Beeuzer.Models;
using Beeuzer.ViewModel;
using Microsoft.SqlServer.Server;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Beeuzer.Controllers
{
    public class PedidoController : Controller
    {
        Carrinho carrinho = new Carrinho();
        Cliente cliente = new Cliente();
        Pedido pedido = new Pedido();   

        public ActionResult Cartao()
        {
            var identity = User.Identity as ClaimsIdentity;
            var login = identity.Claims.FirstOrDefault(l => l.Type == "Nome");

            if (login == null)
            {
                return RedirectToAction("Login", "Autenticacao");
            }
            return View();
        }

        public ActionResult Endereco()
        {
            return View();
        }

        public ActionResult NotaFiscal()
        {
            return View();
        }

        public ActionResult Pedido(string NomeCli)
        {
            Int64 CodCli = cliente.SelectCodCli(NomeCli);
            pedido.InsertPed(carrinho.SelectCar(CodCli), CodCli);
            return RedirectToAction("Cartao", "Pedido");
        }

        [HttpPost]
        public ActionResult Cartao(PagamentoViewModel pagamento)
        {
            if (!ModelState.IsValid)
                return View(pagamento);

            TipoPaga novoPed = new TipoPaga()
            {
                NomeTitular = pagamento.NomeCli,
                NumCartao = pagamento.NumCartao,
                DataValida = pagamento.DataVali,
                TipoCartao = pagamento.TipoCartao
            };
            novoPed.InsertTipoCart(novoPed);

            return RedirectToAction("Endereco", "Pedido");
        }

        [HttpPost]
        public ActionResult Endereco(EnderecoViewModel endereco)
        {
            if (!ModelState.IsValid)
                return View(endereco);

            Endereco novoEnd = new Endereco()
            {
                Cep = endereco.Cep,
                Logradouro = endereco.Logradouro,
                NomeBairro = endereco.NomeBairro,
                NomeCidade = endereco.NomeCidade,
                NumEndereco = endereco.NumEndereco,
                CompEndereco = endereco.CompEndereco
            };
            novoEnd.InsertEnd(novoEnd);

            return RedirectToAction("NotaFiscal", "Pedido");
        }

        [HttpPost]
        public ActionResult NotaFiscal(NotaViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            NotaFiscal novaNota = new NotaFiscal()
            {
                NomeCli = viewModel.NomeCli,
                TotalNota = viewModel.TotalNota,
                DataEmissao = viewModel.DataEmissao
            };
            novaNota.InsertNotaFiscal(novaNota);

            return View(novaNota);
        }
    }
}