using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Beeuzer.ViewModel
{
    public class EnderecoViewModel
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }

        [Display(Name = "Número do endereço")]
        public string NumEndereco { get; set; }

        [Display(Name = "Complemento")]
        public string CompEndereco { get; set; }

        [Display(Name = "Nome da cidade")]
        public string NomeCidade { get; set; }

        [Display(Name = "Nome do bairro")]
        public string NomeBairro { get; set; }
    }
}