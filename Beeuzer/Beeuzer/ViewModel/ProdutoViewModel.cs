using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beeuzer.ViewModel
{
    public class ProdutoViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int? CodigoBarras { get; set; }

        [Required]
        [Display(Name = "Nome do Produto")]
        public string NomeProd { get; set; }

        [Required]
        [MaxLength(55)]
        public string Cor { get; set; }

        [Required]
        [MaxLength(2)]
        public string Tamanho { get; set; }

        [Required]
        [Display(Name = "Preço")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Valor inválido")]
        public decimal ValorUnitario { get; set; }

        [Required]
        [Display(Name = "Quantidade")]
        public int Qtd { get; set; }
    }
}