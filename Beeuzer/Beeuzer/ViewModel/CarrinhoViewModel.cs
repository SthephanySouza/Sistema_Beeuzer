using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beeuzer.ViewModel
{
    public class CarrinhoViewModel
    {
        public string NomeProd { get; set; }
        public int Qtd { get; set; }
        public decimal ValorItem { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal TotalCar { get; set; }
    }
}