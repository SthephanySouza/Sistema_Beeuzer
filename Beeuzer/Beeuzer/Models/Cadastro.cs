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
    public class Cadastro : Endereco
    {
        MySqlConnection Conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();

        public int IdCad { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required]
        public int NumEnd { get; set; }
        public string CompleEnd { get; set; }

        [Required]
        public int Cpf { get; set; }

        [Required]
        [MaxLength(250)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Senha { get; set; }

        [Required]
        public int Telefone { get; set; }

        [Required]
        [MaxLength(50)]
        public string TipoAcesso { get; set; }

        public void InsertCad(Cadastro cliente)
        {
            Conexao.Open();
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
            comand.Connection = Conexao;
            Conexao.Close();
        }

        public string SelectLogin(string vLogin)
        {
            Conexao.Open();
            comand.CommandText = "call spSelectLogin(@Email);";
            comand.Parameters.Add("@Email", MySqlDbType.VarChar).Value = vLogin;
            comand.Connection = Conexao;
            string Login = (string)comand.ExecuteScalar();
            Conexao.Close();

            if (Login == null)
                Login = "";

            return Login;
        }

        public Cadastro SelectCad(string vLogin)
        {
            Conexao.Open();
            comand.CommandText = "call spSelectCad(@Email);";
            comand.Parameters.Add("@Email", MySqlDbType.VarChar).Value = vLogin;
            comand.Connection = Conexao;

            var readCliente = comand.ExecuteReader();
            var TempCliente = new Cadastro();

            if (readCliente.Read())
            {
                TempCliente.IdCad = int.Parse(readCliente["IdCad"].ToString());
                TempCliente.Nome = readCliente["Nome"].ToString();
                TempCliente.CompleEnd = readCliente["CompleEnd"].ToString();
                TempCliente.NumEnd = int.Parse(readCliente["NumEnd"].ToString());
                TempCliente.Cep = int.Parse(readCliente["Cep"].ToString());
                TempCliente.Cpf = int.Parse(readCliente["Cpf"].ToString());
                TempCliente.Email = readCliente["Email"].ToString();
                TempCliente.Logradouro = readCliente["Logradouro"].ToString();
                TempCliente.NomeBairro = readCliente["NomeBairro"].ToString();
                TempCliente.NomeCidade = readCliente["NomeCidade"].ToString();
                TempCliente.Senha = readCliente["Senha"].ToString();
                TempCliente.Telefone = int.Parse(readCliente["Telefone"].ToString());
            }
            readCliente.Close();
            Conexao.Close();

            return TempCliente;
        }
    }
}