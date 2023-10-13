using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Beeuzer2.Models
{
    public class Cadastro : Endereco
    {
        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();

        public int IdCad { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(11)]
        public int Cpf { get; set; }

        [Required]
        [MaxLength(9)]
        public int Telefone { get; set; }

        [Required]
        [MaxLength(250)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string TipoAcesso { get; set; }

        [Required]
        [MaxLength(100)]
        public string Senha { get; set; }

        public void InsertCad(Cadastro cliente)
        {
            conexao.Open();
            comand.CommandText = "call spInsertCad(@Nome, @Senha, @Cpf, @Email, @Telefone, @Cep, @NumEnd, @CompleEnd, @Logradouro, @NomeBairro, @NomeCidade, @TipoAcesso)";
            comand.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = cliente.Nome;
            comand.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = cliente.Senha;
            comand.Parameters.Add("@Cpf", MySqlDbType.Int64).Value = cliente.Cpf;
            comand.Parameters.Add("@Email", MySqlDbType.VarChar).Value = cliente.Email;
            comand.Parameters.Add("@Telefone", MySqlDbType.Int64).Value = cliente.Telefone;
            comand.Parameters.Add("@Cep", MySqlDbType.Int64).Value = cliente.Cep;
            comand.Parameters.Add("@NumEnd", MySqlDbType.Int64).Value = cliente.NumEnd;
            comand.Parameters.Add("@CompleEnd", MySqlDbType.VarChar).Value = cliente.CompleEnd;
            comand.Parameters.Add("@Logardouro", MySqlDbType.VarChar).Value = cliente.Logradouro;
            comand.Parameters.Add("@NomeBairro", MySqlDbType.VarChar).Value = cliente.NomeBairro;
            comand.Parameters.Add("@NomeCidade", MySqlDbType.VarChar).Value = cliente.NomeCidade;
            comand.Parameters.Add("@TipoAcesso", MySqlDbType.VarChar).Value = cliente.TipoAcesso;
            comand.Connection = conexao;
            conexao.Close();
        }
    }
}