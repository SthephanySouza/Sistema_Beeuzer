using Beeuzer.Models;
using Beeuzer.ViewModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
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

                using (MySqlCommand cmd = new MySqlCommand("select * from vwProduto", connection))
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

        public ActionResult CadastrarProd()
        {
            return View();
        }
    }
}