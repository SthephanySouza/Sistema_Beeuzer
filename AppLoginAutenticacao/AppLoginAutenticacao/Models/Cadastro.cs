using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AppLoginAutenticacao.Models
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
        public int Cpf { get; set; }

        [Required]
        [MaxLength(250)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Senha { get; set; }

        [Required]
        [MaxLength(9)]
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
            comand.Parameters.Add("@Cpf", MySqlDbType.Decimal).Value = cliente.Cpf;
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
            comand.CommandText = "call spSelectLogin(@Login);";
            comand.Parameters.Add("@Login", MySqlDbType.VarChar).Value = vLogin;
            comand.Connection = Conexao;
            string Login = (string)comand.ExecuteScalar();
            Conexao.Close();

            if (Login == null)
                Login = "";

            return Login;
        }
        /* public Cadastro SelectUsuario(string vLogin)
        {
            Conexao.Open();
            comand.CommandText = "call spSelectUsuario(@Login);";
            comand.Parameters.Add("@Login", MySqlDbType.VarChar).Value = vLogin;
            comand.Connection = Conexao;

            var readUsuario = comand.ExecuteReader();
            var TempUsuario = new Cadastro();

            if (readUsuario.Read())
            {
                TempUsuario.UsuarioID = int.Parse(readUsuario["UsuarioID"].ToString());
                TempUsuario.UsuNome = readUsuario["UsuNome"].ToString();
                TempUsuario.Login = readUsuario["Login"].ToString();
                TempUsuario.Senha = readUsuario["Senha"].ToString();
            }
            readUsuario.Close();
            Conexao.Close();

            return TempUsuario;
        }

        public void UpdateSenha(Cadastro usuario)
        {
            Conexao.Open();
            comand.CommandText = "call spUpdateSenha(@Login, @Senha);";
            comand.Parameters.Add("@Login", MySqlDbType.VarChar).Value = usuario.Login;
            comand.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = usuario.Senha;
            comand.Connection = Conexao;
            comand.ExecuteNonQuery();
            Conexao.Close();
        } */
    }
}