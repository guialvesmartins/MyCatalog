using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCatalogAPI.Models
{
    public class GrupoProduto
    {
        public GrupoProduto(){ }
        
        public GrupoProduto(int id, string nome) 
        {
            this.Id = id;
            this.Nome = nome;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}