using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beeuzer.Models
{
    public class Carrinho : Produto
    {
        public int IdCar { get; set; }
        public string TotalCar { get; set; }
        public int IdCli { get; set; }
    }
}