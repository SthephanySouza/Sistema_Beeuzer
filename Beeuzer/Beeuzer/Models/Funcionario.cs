using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beeuzer.Models
{
    public class Funcionario
    {
        public int IdFunc { get; set; }
        public string NomeFunc{ get; set; }
        public string CNPJ { get; set; }
        public string NumEnd { get; set; }
        public string CompleEnd { get; set; }
        public string Telefone { get; set; }
        public string CepFunc { get; set; }
    }
}