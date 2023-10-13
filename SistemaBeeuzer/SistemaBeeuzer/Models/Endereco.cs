using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaBeeuzer.Models
{
    public class Endereco
    {
        [Required]
        [MaxLength(255)]
        public string Logradouro { get; set; }

        [Required]
        [MaxLength(8)]
        public int Cep { get; set; }

        [Required]
        [MaxLength(200)]
        public string NomeBairro { get; set; }

        [Required]
        [MaxLength(200)]
        public string NomeCidade { get; set; }

        [Required]
        public int NumEnd { get; set; }

        [MaxLength(50)]
        public string CompleEnd { get; set; }
    }
}