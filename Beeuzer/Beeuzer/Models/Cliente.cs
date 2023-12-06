using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beeuzer.Models
{
    public class Cliente
    {
        MySqlConnection Conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();

        public int IdCli { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        [MaxLength(250)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Senha { get; set; }

        [Required]
        public string Telefone { get; set; }

        public void InsertCad(Cliente cliente)
        {
            Conexao.Open();
            comand.CommandText = "call spInsertCli(@Nome, @Email, @Senha, @Cpf, @Telefone)";
            comand.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = cliente.Nome;
            comand.Parameters.Add("@Email", MySqlDbType.VarChar).Value = cliente.Email;
            comand.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = cliente.Senha;
            comand.Parameters.Add("@Cpf", MySqlDbType.VarChar).Value = cliente.Cpf;
            comand.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = cliente.Telefone;
            comand.Connection = Conexao;
            comand.ExecuteNonQuery();
            Conexao.Close();
        }

        public string SelectLogin(string vLogin)
        {
            Conexao.Open();
            comand.CommandText = "call spSelectCli(@Email);";
            comand.Parameters.Add("@Email", MySqlDbType.VarChar).Value = vLogin;
            comand.Connection = Conexao;
            string Login = (string)comand.ExecuteScalar();
            Conexao.Close();

            if (Login == null)
                Login = "";

            return Login;
        }

        public Cliente SelectCli(string vLogin)
        {
            Conexao.Open();
            comand.CommandText = "call spSelectCli(@Email);";
            comand.Parameters.Add("@Email", MySqlDbType.VarChar).Value = vLogin;
            comand.Connection = Conexao;

            var readCliente = comand.ExecuteReader();
            var TempCliente = new Cliente();

            if (readCliente.Read())
            {
                TempCliente.IdCli = int.Parse(readCliente["IdCli"].ToString());
                TempCliente.Nome = readCliente["NomeCli"].ToString();
                TempCliente.Cpf = readCliente["Cpf"].ToString();
                TempCliente.Email = readCliente["EmailCli"].ToString();
                TempCliente.Senha = readCliente["Senha"].ToString();
                TempCliente.Telefone = readCliente["Telefone"].ToString();
            }
            readCliente.Close();
            Conexao.Close();

            return TempCliente;
        }

        public Int64 SelectCodCli(string NomeCli)
        {
            Conexao.Open();
            comand.CommandText = "select IdCli from tbl_cliente where NomeCli = @Nome";
            comand.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = NomeCli;
            comand.Connection = Conexao;
            object result = comand.ExecuteScalar();
            Int64 IdCli = Convert.ToInt64(result);
            Conexao.Close();
            return IdCli;
        }
    }
}