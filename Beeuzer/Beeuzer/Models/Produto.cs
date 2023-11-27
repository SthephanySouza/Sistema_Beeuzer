using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Windows.Input;

namespace Beeuzer.Models
{
    public class Produto
    {
        MySqlConnection Conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();

        public Int64 CodigoBarras {  get; set; }

        [Required]
        [MaxLength(250)]
        public string NomeProd {  get; set; }

        [Required]
        [MaxLength(100)]
        public string Cor { get; set; }

        [Required]
        [MaxLength(100)]
        public string Tamanho { get; set; }

        [Required]
        public decimal ValorUnitario { get; set; }

        [Required]
        public int Qtd { get; set; }

        public void InsertProd(Produto produto)
        {
            Conexao.Open();
            comand.CommandText = "call spInserProd(@CodigoBarras, @NomeProd, @Cor, @Tamanho, @ValorUnitario, @Qtd)";
            comand.Parameters.Add("@CodigoBarras", MySqlDbType.Int64).Value = produto.CodigoBarras;
            comand.Parameters.Add("@NomeProd", MySqlDbType.VarChar).Value = produto.NomeProd;
            comand.Parameters.Add("@Cor", MySqlDbType.VarChar).Value = produto.Cor;
            comand.Parameters.Add("@Tamanho", MySqlDbType.VarChar).Value = produto.Tamanho;
            comand.Parameters.Add("@ValorUnitario", MySqlDbType.Decimal).Value = produto.ValorUnitario;
            comand.Parameters.Add("@Qtd", MySqlDbType.Int32).Value = produto.Qtd;
            comand.Connection = Conexao;
            comand.ExecuteNonQuery();
            Conexao.Close();
        }

        public void UpdateProd(Produto produto)
        {
            Conexao.Open();
            comand.CommandText = "call spUpdateProd(@CodigoBarras, @NomeProd, @Cor, @Tamanho, @ValorUnitario, @Qtd)";
            comand.Parameters.Add("@CodigoBarras", MySqlDbType.Int64).Value = produto.CodigoBarras;
            comand.Parameters.Add("@NomeProd", MySqlDbType.VarChar).Value = produto.NomeProd;
            comand.Parameters.Add("@Cor", MySqlDbType.VarChar).Value = produto.Cor;
            comand.Parameters.Add("@Tamanho", MySqlDbType.VarChar).Value = produto.Tamanho;
            comand.Parameters.Add("@ValorUnitario", MySqlDbType.Decimal).Value = produto.ValorUnitario;
            comand.Parameters.Add("@Qtd", MySqlDbType.Int32).Value = produto.Qtd;
            comand.Connection = Conexao;
            comand.ExecuteNonQuery();
            Conexao.Close();
        }

        public Produto SelectProd(Int64 CodBarras)
        {
            Conexao.Open();
            comand.CommandText = "call spSelectProd(@CodBarras)";
            comand.Parameters.Add("@CodBarras", MySqlDbType.Int64).Value = CodBarras;
            comand.Connection = Conexao;

            var readProduto = comand.ExecuteReader();
            var tempProduto  = new Produto();

            if (readProduto.Read())
            {
                tempProduto.CodigoBarras = Convert.ToInt64(readProduto["CodigoBarras"]);
                tempProduto.NomeProd = readProduto["NomeProd"].ToString();
                tempProduto.Cor = readProduto["Cor"].ToString();
                tempProduto.Tamanho = readProduto["Tamanho"].ToString();
                tempProduto.ValorUnitario = Convert.ToDecimal(readProduto["ValorUnitario"]);
                tempProduto.Qtd = Convert.ToInt16(readProduto["Qtd"]);
            }
            readProduto.Close();
            Conexao.Close();

            return tempProduto;
        }


        public Int64 SelectCod(string NomeProd, string Cor, string Tamanho)
        {
            Conexao.Open();
            comand.CommandText  = "select CodigoBarras from vwProduto where NomeProd = @Nome and Cor = @Cor and Tamanho = @Tamanho";
            comand.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = NomeProd;
            comand.Parameters.Add("@Cor", MySqlDbType.VarChar).Value = Cor;
            comand.Parameters.Add("@Tamanho", MySqlDbType.VarChar).Value = Tamanho;
            comand.Connection = Conexao;
            object result = comand.ExecuteScalar();
            Int64 CodBarras = Convert.ToInt64(result);

            return CodBarras;
        }
    }
}