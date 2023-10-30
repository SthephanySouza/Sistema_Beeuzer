using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Beeuzer.Models
{
    public class Funcionario
    {
        MySqlConnection Conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();

        public int IdFunc { get; set; }

        [Required]
        [MaxLength(200)]
        public string NomeFunc { get; set; }

        [Required]
        [MaxLength(250)]
        public string EmailFunc { get; set; }

        [Required]
        [MaxLength (100)]
        public string Senha { get; set; }

        [Required]
        public int Telefone { get; set; }

        public void InsertFunc(Funcionario funcionario)
        {
            Conexao.Open();
            comand.CommandText = "call spInsertFunc(@NomeFunc, @Senha, @EmailFunc, @Telefone)";
            comand.Parameters.Add("@NomeFunc", MySqlDbType.VarChar).Value = funcionario.NomeFunc;
            comand.Parameters.Add("@EmailFunc", MySqlDbType.VarChar).Value = funcionario.EmailFunc;
            comand.Parameters.Add("@Senma", MySqlDbType.VarChar).Value = funcionario.Senha;
            comand.Parameters.Add("@Telefone", MySqlDbType.Int64).Value = funcionario.Telefone;
            comand.Connection = Conexao;
            Conexao.Close();
        }

        public string SelectCli(string vLogin)
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

        public Funcionario SelectFuncionario(string vLogin)
        {
            Conexao.Open();
            comand.CommandText = "call spSelectFunc(@Login);";
            comand.Parameters.Add("@Login", MySqlDbType.VarChar).Value = vLogin;
            comand.Connection = Conexao;

            var readFunc = comand.ExecuteReader();
            var TempFunc = new Funcionario();

            if (readFunc.Read())
            {
                TempFunc.IdFunc = int.Parse(readFunc["IdFunc"].ToString());
                TempFunc.NomeFunc = readFunc["NomeFunc"].ToString();
                TempFunc.EmailFunc = readFunc["EmailFunc"].ToString();
                TempFunc.Senha = readFunc["Senha"].ToString();
                TempFunc.Telefone = int.Parse(readFunc["Telefone"].ToString());
            }
            readFunc.Close();
            Conexao.Close();

            return TempFunc;
        }
    }
}