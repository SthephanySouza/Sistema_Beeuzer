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
        public int NumEnd { get; set; }
        public string CompleEnd { get; set; }

        [Required]
        [MaxLength(255)]
        public string Logradouro { get; set; }

        [Required]
        [MaxLength(200)]
        public string NomeCidade { get; set; }

        [Required]
        [MaxLength(200)]
        public string NomeBairro { get; set; }
        /* public string UF { get; set; }

        public IEnumerable<SelectListItem> Uf
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem { Text = "SP", Value = "SP" },
                    new SelectListItem { Text = "RJ", Value = "RJ" },
                    new SelectListItem { Text = "RS", Value = "RS" }
                };
            }
        } */
    }
}