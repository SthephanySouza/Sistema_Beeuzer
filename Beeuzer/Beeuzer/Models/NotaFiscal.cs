using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Windows.Input;

namespace Beeuzer.Models
{
    public class NotaFiscal
    {
        MySqlConnection Conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();

        public int NF { get; set; }
        public string NomeCli { get; set; }
        public string TotalNota { get; set; }
        public string DataEmissao { get; set; }

        public void InsertNotaFiscal(NotaFiscal notaFiscal)
        {
            Conexao.Open();
            comand.CommandText = "call spInsertPagamento(@Nome)";
            comand.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = notaFiscal.NomeCli;
            comand.Connection = Conexao;
            comand.ExecuteNonQuery();
            Conexao.Close();
        }
    }
}