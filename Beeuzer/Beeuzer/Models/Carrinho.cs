using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beeuzer.Models
{
    public class Carrinho
    {
        private readonly List<ItemCarrinho> itemCarrinho = new List<ItemCarrinho>();

        public void AdicionarItem(Produto produto, int quantidade)
        {
            ItemCarrinho item = itemCarrinho.FirstOrDefault(p => p.Produto.CodigoBarras == produto.CodigoBarras);

            if (item == null)
            {   
                itemCarrinho.Add(new ItemCarrinho
                {
                    Produto = produto,
                    Qtd = quantidade
                });
            }
            else
            {
                item.Qtd += quantidade;
            }
        }

        public void RemoverItem(Produto produto)
        {
            itemCarrinho.RemoveAll(l => l.Produto.CodigoBarras == produto.CodigoBarras);
        }

        public decimal ValorTotal()
        {
            return itemCarrinho.Sum(e => e.Produto.ValorUnitario * e.Qtd);
        }

        public void LimparCarrinho()
        {
            itemCarrinho.Clear();
        }

        public IEnumerable<ItemCarrinho> ItensCarrinho
        {
            get { return itemCarrinho; }
        }

        public class ItemCarrinho
        {
            public Produto Produto { get; set; }
            public int Qtd { get; set; }
        }
    }
}