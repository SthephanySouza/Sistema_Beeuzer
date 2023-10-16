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
    public class Cadastro
    {
        MySqlConnection Conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();

        public int IdCad { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }

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
            comand.CommandText = "call spInsertCad(@Nome, @Senha, @Cpf, @Email, @Telefone, @TipoAcesso)";
            comand.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = cliente.Nome;
            comand.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = cliente.Senha;
            comand.Parameters.Add("@Cpf", MySqlDbType.Int64).Value = cliente.Cpf;
            comand.Parameters.Add("@Email", MySqlDbType.VarChar).Value = cliente.Email;
            comand.Parameters.Add("@Telefone", MySqlDbType.Int64).Value = cliente.Telefone;
            comand.Parameters.Add("@TipoAcesso", MySqlDbType.VarChar).Value = cliente.TipoAcesso;
            comand.Connection = Conexao;
            comand.ExecuteNonQuery();
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
                TempCliente.Cpf = int.Parse(readCliente["Cpf"].ToString());
                TempCliente.Email = readCliente["Email"].ToString();
                TempCliente.Senha = readCliente["Senha"].ToString();
                TempCliente.Telefone = int.Parse(readCliente["Telefone"].ToString());
            }
            readCliente.Close();
            Conexao.Close();

            return TempCliente;
        }
    }
}