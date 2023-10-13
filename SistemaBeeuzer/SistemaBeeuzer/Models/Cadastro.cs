using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SistemaBeeuzer.Models
{
    public class Cadastro : Endereco
    {
        public int IdCad { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(11)]
        public int Cpf { get; set; }

        [Required]
        [MaxLength(8)]
        public int Cep { get; set; }

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
    }
}