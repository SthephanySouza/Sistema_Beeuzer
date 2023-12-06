using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Ocsp;
using System.Globalization;
using System.Text;

namespace Beeuzer.Models
{
    public class Carrinho
    {
        MySqlConnection Conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();

        public int IdCar { get; set; }
        public string NomeProd { get; set; }
        public string Cor { get; set; }
        public string Tamanho { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal TotalProd { get; set; }
        public int Qtd { get; set; }
        public Int64 IdCli { get; set; }
        public Int64 CodigoBarras { get; set; }

        public void InsertCar(Int64 Id, Int16 Qtd, Int64 CodBarras)
        {
            Conexao.Open();
            comand.CommandText = "call spInsertCarrinho(@IdCli, @Qtd, @CodBarras)";
            comand.Parameters.Add("@IdCli", MySqlDbType.Int64).Value = Id;
            comand.Parameters.Add("@Qtd", MySqlDbType.Int16).Value = Qtd;
            comand.Parameters.Add("@CodBarras", MySqlDbType.Int64).Value = CodBarras;
            comand.Connection = Conexao;
            comand.ExecuteNonQuery();
            Conexao.Close();
        }

        public List<Carrinho> SelectCar(Int64 IdCli)
        {
            Conexao.Open();
            List<Carrinho> ListaCarrinho = new List<Carrinho>();
            comand.CommandText = "call spSelectCarrinho(@Id);";
            comand.Parameters.Add("@Id", MySqlDbType.Int64).Value = IdCli;
            comand.Connection = Conexao;

            MySqlDataReader readCarrinho = comand.ExecuteReader();

            while (readCarrinho.Read())
            {
                ListaCarrinho.Add(
                    new Carrinho
                    {
                        IdCar = Convert.ToInt32(readCarrinho["IdCar"]),
                        CodigoBarras = Convert.ToInt64(readCarrinho["CodigoBarras"]),
                        NomeProd = Convert.ToString(readCarrinho["NomeProd"]),
                        Cor = Convert.ToString(readCarrinho["Cor"]),
                        Tamanho = Convert.ToString(readCarrinho["Tamanho"]),
                        Qtd = Convert.ToInt32(readCarrinho["Qtd"]),
                        ValorUnitario = Convert.ToDecimal(readCarrinho["ValorUnitario"]),
                        TotalProd = Convert.ToDecimal(readCarrinho["TotalProd"]),
                    });
            }
            Conexao.Close();
            return ListaCarrinho;
        }

        public void DeleteCar(int Item)
        {
            Conexao.Open();
            comand.CommandText = "delete from tbl_carrinho where IdCar = @Id";
            comand.Parameters.Add("@Id", MySqlDbType.VarChar).Value = Item;
            comand.Connection = Conexao;
            comand.ExecuteNonQuery();
            Conexao.Close();
        }

        public void UpdateCar(int IdCar, int Qtd, decimal TotalProd, Int64 IdCli)
        {
            Conexao.Open();
            comand.CommandText = "update tbl_carrinho set Qtd = @Qtd, TotalProd = @Total where IdCar = @Car and IdCli = @Cli";
            comand.Parameters.Add("@Qtd", MySqlDbType.Int32).Value = Qtd;
            comand.Parameters.Add("@Total", MySqlDbType.Decimal).Value = TotalProd;
            comand.Parameters.Add("@Car", MySqlDbType.Int32).Value = IdCar;
            comand.Parameters.Add("@Cli", MySqlDbType.Int64).Value = IdCli;
            comand.Connection = Conexao;
            comand.ExecuteNonQuery();
            Conexao.Close();
        }
    }
}