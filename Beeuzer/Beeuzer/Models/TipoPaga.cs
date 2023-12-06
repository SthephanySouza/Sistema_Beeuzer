using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Beeuzer.Models
{
    public class TipoPaga
    {
        readonly MySqlConnection Conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        readonly MySqlCommand comand = new MySqlCommand();

        public string NumCartao { get; set; }
        public string DataValida { get; set; }
        public string TipoCartao { get; set; }
        public string NomeTitular { get; set; }

        public void InsertTipoCart(TipoPaga tipoPaga)
        {
            Conexao.Open();
            comand.CommandText = "call spInsertCart(@Nome, @NumCart, @DataVali, @TipoCart)";
            comand.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = tipoPaga.NomeTitular;
            comand.Parameters.Add("@NumCart", MySqlDbType.VarChar).Value = tipoPaga.NumCartao;
            comand.Parameters.Add("@DataVali", MySqlDbType.VarChar).Value = tipoPaga.DataValida;
            comand.Parameters.Add("@TipoCart", MySqlDbType.VarChar).Value = tipoPaga.TipoCartao;
            comand.Connection = Conexao;
            comand.ExecuteNonQuery();
            Conexao.Close();
        }

        public void InsertCart(Pagamento pagamento)
        {
            Conexao.Open();
            comand.CommandText = "call spInsertPagamento(@Nome, @NumCart)";
            comand.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = pagamento.NomeTitular;
            comand.Parameters.Add("@NumCart", MySqlDbType.VarChar).Value = pagamento.NumCartao;
            comand.Connection = Conexao;
            comand.ExecuteNonQuery();
            Conexao.Close();
        }
    }
}