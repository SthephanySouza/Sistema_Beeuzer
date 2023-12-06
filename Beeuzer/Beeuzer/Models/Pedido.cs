using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Beeuzer.Models
{
    public class Pedido
    {
        MySqlConnection Conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();

        public Int64 NumPed { get; set; }
        public string NomeCli { get; set; }
        public Int64 CodBarras { get; set; }
        public int Qtd { get; set; }

        public void InsertPed(List<Carrinho> carrinhos, Int64 IdCli)
        {
            Random r = new Random();
            Int64 NumPed = r.Next();
            Conexao.Open();
            foreach (var carrinho in carrinhos)
            {
                comand.CommandText = "call spInsertPedido(@NumPed, @Cliente, @CodBarras, @Qtd)";
                comand.Parameters.Add("@NumPed", MySqlDbType.Int64).Value = NumPed;
                comand.Parameters.Add("@Cliente", MySqlDbType.Int64).Value = IdCli;
                comand.Parameters.Add("@CodBarras", MySqlDbType.Int64).Value = carrinho.CodigoBarras;
                comand.Parameters.Add("@Qtd", MySqlDbType.Int32).Value = carrinho.Qtd;
                comand.Connection = Conexao;
                comand.ExecuteNonQuery();
                comand.Parameters.Clear();
            }
            Conexao.Close();
        }
    }
}