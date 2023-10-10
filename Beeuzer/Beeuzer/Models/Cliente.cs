using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beeuzer.Models
{
    public class Cliente
    {
        public int IdCli { get; set; }
        public string NomeCli { get; set; }
        public string CPF { get; set; }
        public string NumEnd { get; set; }
        public string CompleEnd { get; set; }
        public string Telefone { get; set; }
        public string CepCli { get; set; }
    }
}