using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beeuzer.Models
{
    public class Endereco
    {
        [Required]
        [MaxLength(8)]
        public int Cep { get; set; }

        [Required]
        [MaxLength(255)]
        public string Logradouro { get; set; }

        [Required]
        [MaxLength(200)]
        public string NomeCidade { get; set; }

        [Required]
        [MaxLength(200)]
        public string NomeBairro { get; set; }
    }
}