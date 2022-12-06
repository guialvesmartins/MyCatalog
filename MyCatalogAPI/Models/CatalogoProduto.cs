using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCatalogAPI.Models
{
    public class CatalogoProduto
    {
        public CatalogoProduto(){ }
        
        public CatalogoProduto(int produtoId, int catalogoId) 
        {
            this.ProdutoId = produtoId;
            this.CatalogoId = catalogoId;
        }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int CatalogoId { get; set; }
        public Catalogo Catalogo { get; set; }    

    }
}