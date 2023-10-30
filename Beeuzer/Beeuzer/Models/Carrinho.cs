using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beeuzer.Models
{
    public class Carrinho : Produto
    {
        public int IdCar { get; set; }
        public decimal TotalCar { get; set; }
        public decimal TotalProd { get; set; }
        public int IdCli { get; set; }
        public decimal ValorItem { get; set; }
    }
}