using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Windows.Input;

namespace SistemaBeeuzer.Models
{
    public class Entrar : Cadastro
    {
        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();

        public int IdLogin { get; set; }

        [Required]
        [MaxLength(200)]
        public string Login { get; set; }

        [Required]
        [MaxLength(50)]
        public string TipoAcesso { get; set; }

        [Required]
        [MaxLength(100)]
        public string Senha { get; set; }

        public void InsertCad(Entrar entrar)
        {
            conexao.Open();
            comand.CommandText = "call spInsertCad(@Nome, @Senha, @Cpf, @Email, @Telefone, @Cep, @NumEnd, @CompleEnd, @Logradouro, @NomeBairro, @NomeCidade, @TipoAcesso)";
            comand.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = entrar.Nome;
            comand.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = entrar.Senha;
            comand.Parameters.Add("@Cpf", MySqlDbType.Int64).Value = entrar.Cpf;
            comand.Parameters.Add("@Email", MySqlDbType.VarChar).Value = entrar.Login;
            comand.Parameters.Add("@Telefone", MySqlDbType.Int64).Value = entrar.Telefone;
            comand.Parameters.Add("@Cep", MySqlDbType.Int64).Value = entrar.Cep;
            comand.Parameters.Add("@NumEnd", MySqlDbType.Int64).Value = entrar.NumEnd;
            comand.Parameters.Add("@CompleEnd", MySqlDbType.VarChar).Value = entrar.CompleEnd;
            comand.Parameters.Add("@Logardouro", MySqlDbType.VarChar).Value = entrar.Logradouro;
            comand.Parameters.Add("@NomeBairro", MySqlDbType.VarChar).Value = entrar.NomeBairro;
            comand.Parameters.Add("@NomeCidade", MySqlDbType.VarChar).Value = entrar.NomeCidade;
            comand.Parameters.Add("@TipoAcesso", MySqlDbType.VarChar).Value = entrar.TipoAcesso;
            comand.Connection = conexao;
            conexao.Close();
        }
    }
}