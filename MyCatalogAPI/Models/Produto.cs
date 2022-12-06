using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCatalogAPI.Models
{   
    public class Produto
    {
        public Produto(){ }
        
        public Produto(int id, string nome, string descicao, decimal valor, bool status, int grupoProdutoId) 
        {
            this.Id = id;
            this.Nome = nome;
            this.Descricao = descicao;
            this.Valor = valor;
            this.Status = status;
            this.GrupoProdutoId = grupoProdutoId;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool Status { get; set; }
        public int GrupoProdutoId { get; set; }
        public GrupoProduto GrupoProduto { get; set; }
        public IEnumerable<CatalogoProduto> CatalogosProdutos { get; set; }
    }
}