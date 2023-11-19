using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beeuzer.Models
{
    public class Pedido
    {
        public int NumeroPedido { get; set; }

        public string NomeCli { get; set; }

        public DateTime DataPedido { get; set; }

        public DateTime DataPrazo { get; set; }

        public decimal TotalPedido { get; set; }
    }
}