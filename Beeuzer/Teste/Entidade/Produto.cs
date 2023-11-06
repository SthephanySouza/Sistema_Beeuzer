using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Beeuzer.Models
{
    public class Produto
    {
        MySqlConnection Conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();

        public int? CodigoBarras {  get; set; }

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
        public int Qtd {  get; set; }

        /* public void InsertProd(Produto produto)
        {
            Conexao.Open();
            comand.CommandText = "@CodigoBarras, @NomeProd, @Cor, @Tamanho, @ValorUnitario, @Qtd";
            comand.Parameters.Add("@CodigoBarras", MySqlDbType.VarChar).Value = produto.CodigoBarras;
            comand.Parameters.Add("@NomeProd", MySqlDbType.VarChar).Value = produto.NomeProd;
            comand.Parameters.Add("@Cor", MySqlDbType.VarChar).Value = produto.Cor;
            comand.Parameters.Add("@Tamanho", MySqlDbType.VarChar).Value = produto.Tamanho;
            comand.Parameters.Add("@ValorUnitario", MySqlDbType.VarChar).Value = produto.ValorUnitario;
            comand.Parameters.Add("@Qtd", MySqlDbType.VarChar).Value = produto.Qtd;
            comand.Connection = Conexao;
            comand.ExecuteNonQuery();
            Conexao.Close();
        } */
    }
}