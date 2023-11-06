using Beeuzer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Beeuzer.Repository
{
    public class ProdutoRepo
    {
        private readonly DbProdContext context = new DbProdContext();

        public IEnumerable<Produto> Produtos
        {
            get { return context.Produtos; }
        }

        public void Salvar(Produto produto)
        {
            if (produto.CodigoBarras == 0)
            {
                context.Produtos.Add(produto);
            }
            else
            {
                Produto prod = context.Produtos.Find(produto.CodigoBarras);

                if (prod != null)
                {
                    prod.NomeProd = produto.NomeProd;
                    prod.Cor = produto.Cor;
                    prod.Tamanho = produto.Tamanho;
                    prod.ValorUnitario = produto.ValorUnitario;
                    prod.Qtd = produto.Qtd;
                }
            }

            context.SaveChanges();
        }

        public Produto Excluir(int codigoBarras)
        {
            Produto prod = context.Produtos.Find(codigoBarras);

            if (prod != null)
            {
                context.Produtos.Remove(prod);
                context.SaveChanges();
            }

            return prod;
        }
    }
}