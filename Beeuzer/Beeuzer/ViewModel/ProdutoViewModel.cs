using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Beeuzer.ViewModel
{
    public class ProdutoViewModel
    {
        public Int64 CodigoBarras { get; set; }

        public string NomeProd { get; set; }

        public string Cor { get; set; }

        public string Tamanho { get; set; }

        public decimal ValorUnitario { get; set; }

        public int Qtd { get; set; }
    }
}