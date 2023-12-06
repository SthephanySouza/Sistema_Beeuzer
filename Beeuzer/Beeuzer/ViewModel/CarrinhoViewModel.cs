using Beeuzer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;

namespace Beeuzer.ViewModel
{
    public class CarrinhoViewModel
    {
        //private static CarrinhoViewModel instancia = null;

        public CarrinhoViewModel()
        {

        }

        //public static CarrinhoViewModel Instancia
        //{
        //    get
        //    {
        //        if (instancia == null)
        //        {
        //            instancia = new CarrinhoViewModel();
        //        }
        //        return instancia;
        //    }
        //}

        //public int InsertCar(Carrinho carrinho)
        //{
        //    int resposta = 0;
        //    using (MySqlConnection Conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString))
        //    {
        //        try
        //        {
        //            MySqlCommand cmd = new MySqlCommand("spInsertCarrinho", Conexao);
        //            cmd.Parameters.AddWithValue("IdCli", carrinho.Cliente.IdCli);
        //            cmd.Parameters.AddWithValue("CodigoBarras", carrinho.Produto.CodigoBarras);
        //            cmd.Parameters.Add("Result", MySqlDbType.Int32).Direction = ParameterDirection.Output;
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            Conexao.Open();
        //            cmd.ExecuteNonQuery();
        //            resposta = Convert.ToInt32(cmd.Parameters["Result"].Value);
        //        }
        //        catch (Exception ex)
        //        {
        //            resposta = 0;
        //        }
        //    }
        //    return resposta;
        //}

        //public int Quantidade(int idCli)
        //{
        //    int resposta = 0;
        //    using (MySqlConnection Conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString))
        //    {
        //        try
        //        {
        //            MySqlCommand cmd = new MySqlCommand("select count(*) from tbl_carrinho where IdCli = @IdCli", Conexao);
        //            cmd.Parameters.AddWithValue("@IdCli", idCli);
        //            cmd.CommandType = CommandType.Text;

        //            Conexao.Open();
        //            resposta = Convert.ToInt32(cmd.ExecuteScalar().ToString());

        //        }
        //        catch (Exception ex)
        //        {
        //            resposta = 0;
        //        }
        //    }
        //    return resposta;
        //}

        //public List<Carrinho> SelectCar(int idCli)
        //{
        //    List<Carrinho> list = new List<Carrinho>();
        //    using (MySqlConnection Conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString))
        //    {
        //        try
        //        {
        //            MySqlCommand cmd = new MySqlCommand("spSelectCar", Conexao);
        //            cmd.Parameters.AddWithValue("IdCli", idCli);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            Conexao.Open();

        //            using (MySqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {
        //                    list.Add(new Carrinho()
        //                    {
        //                        IdCar = Convert.ToInt32(dr["IdCar"].ToString()),
        //                        Produto = new Produto()
        //                        {
        //                            CodigoBarras = Convert.ToInt32(dr["CodigoBarrass"].ToString()),
        //                            NomeProd = dr["NomeProd"].ToString(),
        //                            Cor = dr["Cor"].ToString(),
        //                            Tamanho = dr["Tamanho"].ToString(),
        //                            ValorUnitario = Convert.ToDecimal(dr["ValorUnitario"].ToString(), new CultureInfo("pt-BR"))
        //                        },
        //                    });
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            list = new List<Carrinho>();
        //        }
        //    }
        //    return list;
        //}

        //public bool DeletCar(string idCar, string codigoBarras)
        //{
        //    bool resposta = true;
        //    using (MySqlConnection Conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString))
        //    {
        //        try
        //        {
        //            StringBuilder query = new StringBuilder();
        //            query.AppendLine("delete from tbl_carrinho where IdCar = @IdCar");
        //            query.AppendLine("update tbl_produto set Qtd = Qtd + 1 where CodigoBarras = @CodigoBarras");

        //            MySqlCommand cmd = new MySqlCommand(query.ToString(), Conexao);
        //            cmd.Parameters.AddWithValue("@IdCar", idCar);
        //            cmd.Parameters.AddWithValue("@CodigoBarras", codigoBarras);
        //            cmd.CommandType = CommandType.Text;

        //            Conexao.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch (Exception ex)
        //        {
        //            resposta = false;
        //        }
        //    }
        //    return resposta;
        //}

        /* public string NomeProd { get; set; }
        public int Qtd { get; set; }
        public decimal ValorItem { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal TotalCar { get; set; }

        public Carrinho Carrinho { get; set; }

        public string UrlRetorno { get; set; } */
    }
}