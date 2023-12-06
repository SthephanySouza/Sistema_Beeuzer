using Beeuzer.Models;
using Beeuzer.ViewModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beeuzer.Areas.Funcionario.Controllers
{
    public class FuncionarioController : Controller
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["conexao"].ConnectionString;

        // GET: Funcionario/Funcionario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectProd()
        {
            List<ProdutoViewModel> produtoViewModels = new List<ProdutoViewModel>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("select * from vwProduto order by CodigoBarras", connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProdutoViewModel produtoViewModel = new ProdutoViewModel
                            {
                                CodigoBarras = Convert.ToInt64(reader["CodigoBarras"]),
                                NomeProd = reader["NomeProd"].ToString(),
                                Cor = reader["Cor"].ToString(),
                                Tamanho = reader["Tamanho"].ToString(),
                                ValorUnitario = Convert.ToDecimal(reader["ValorUnitario"]),
                                Qtd = Convert.ToInt16(reader["Qtd"])
                            };

                            produtoViewModels.Add(produtoViewModel);
                        }
                    }
                }
            }

            return View(produtoViewModels);
        }

        public ActionResult SelectPed()
        {
            List<Pedido> pedidos = new List<Pedido>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("select NumeroPedido, NomeCli, DataPedido, DataPrazo, TotalPedido from vwPedido", connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pedido pedido = new Pedido
                            {
                                //NumeroPedido = Convert.ToInt32(reader["NumeroPedido"]),
                                //NomeCli = reader["NomeCli"].ToString(),
                                //DataPedido = Convert.ToDateTime(reader["DataPedido"]),
                                //DataPrazo = Convert.ToDateTime(reader["DataPrazo"]),
                                //TotalPedido = Convert.ToDecimal(reader["TotalPedido"])
                            };

                            pedidos.Add(pedido);
                        }
                    }
                }
            }

            return View(pedidos);
        }

        [HttpGet]
        public ActionResult CadastrarProd()
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
        public ActionResult CadastrarProd(ProdutoViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            Produto novoProd = new Produto
            {
                CodigoBarras = viewModel.CodigoBarras,
                NomeProd = viewModel.NomeProd,
                Cor = viewModel.Cor,
                Tamanho = viewModel.Tamanho,
                ValorUnitario = viewModel.ValorUnitario,
                Qtd = viewModel.Qtd
            };
            novoProd.InsertProd(novoProd);

            return RedirectToAction("SelectProd", "Funcionario");
        }

        public ActionResult AtualizarProd([Bind(Prefix = "id")] Int64 CodigoBarras)
        {
            Produto produto = new Produto();
            var Produto = produto.SelectProd(CodigoBarras);
            return View(Produto);
        }

        [HttpPost]
        public ActionResult AtualizarProd(Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto.UpdateProd(produto);
                return RedirectToAction("SelectProd", "Funcionario");
            }
            return View(produto);
        }
    }
}