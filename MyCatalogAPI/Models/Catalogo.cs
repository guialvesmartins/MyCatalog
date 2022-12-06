using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCatalogAPI.Models
{
    public class Catalogo
    {
        public Catalogo(){ }
        
        public Catalogo(int id, string nome, bool status) 
        {
            this.Id = id;
            this.Nome = nome;
            this.Status = status;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<CatalogoProduto> CatalogosProdutos { get; set; }
        public bool Status { get; set; }
    }
}