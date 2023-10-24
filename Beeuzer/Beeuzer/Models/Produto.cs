using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Beeuzer.Models
{
    public class Produto
    {
        public int CodigoBarras {  get; set; }

        [Required]
        public string NomeProd {  get; set; }

        [Required]
        public string Cor { get; set; }

        [Required]
        public string Tamanho { get; set; }

        [Required]
        public decimal ValorUnitario { get; set; }

        [Required]
        public int Qtd {  get; set; }


    }
}