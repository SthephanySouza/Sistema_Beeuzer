using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Input;

namespace Beeuzer.Models
{
    public class Endereco
    {
        readonly MySqlConnection Conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        readonly MySqlCommand comand = new MySqlCommand();

        [Required]
        [MaxLength(8)]
        public string Cep { get; set; }

        [Required]
        [MaxLength(255)]
        public string Logradouro { get; set; }

        [Required]
        [MaxLength(200)]
        public string NomeCidade { get; set; }

        [Required]
        [MaxLength(200)]
        public string NomeBairro { get; set; }
        
        [Required]
        public string NumEndereco { get; set; }

        [Required]
        public string CompEndereco { get; set; }

        public void InsertEnd(Endereco endereco)
        {
            Conexao.Open();
            comand.CommandText = "call spInsertEnde(@Cep, @Logradouro, @NumEndereco, @CompEndereco, @NomeBairro, @NomeCidade)";
            comand.Parameters.Add("@Cep", MySqlDbType.VarChar).Value = endereco.Cep;
            comand.Parameters.Add("@Logradouro", MySqlDbType.VarChar).Value = endereco.Logradouro;
            comand.Parameters.Add("@NumEndereco", MySqlDbType.VarChar).Value = endereco.NumEndereco;
            comand.Parameters.Add("@CompEndereco", MySqlDbType.VarChar).Value = endereco.CompEndereco;
            comand.Parameters.Add("@NomeBairro", MySqlDbType.VarChar).Value = endereco.NomeBairro;
            comand.Parameters.Add("@NomeCidade", MySqlDbType.VarChar).Value = endereco.NomeCidade;
            comand.Connection = Conexao;
            comand.ExecuteNonQuery();
            Conexao.Close();
        }
    }
}