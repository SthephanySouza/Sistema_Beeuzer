using Beeuzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beeuzer.ViewModel
{
    public class CarrinhoViewModel
    {
        public string ReturnUrl { get; set; }
        public Carrinho Carrinho { get; set; }
    }
}