using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Beeuzer.ViewModel
{
    public class PagamentoViewModel
    {
        [Display(Name = "Nome do titular")]
        public string NomeCli { get; set; }

        [Display(Name = "Data de validade")]
        [Required(ErrorMessage = "Informe a data de validade")]
        // [DataType(DataType.Date)]
        public string DataVali { get; set; }

        [Required(ErrorMessage = "Informe o número do CVV")]
        public string CVV { get; set; }

        [Display(Name = "Número do cartão")]
        [Required(ErrorMessage = "Informe o número do cartão")]
        public string NumCartao { get; set; }

        [Display(Name = "Tipo do cartão")]
        [Required(ErrorMessage = "Informe o número do cartão")]
        public string TipoCartao { get; set; }

        [Required(ErrorMessage = "Informe sua senha")]
        [MinLength(6, ErrorMessage = "A senha deve conter no mínimo 6 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}