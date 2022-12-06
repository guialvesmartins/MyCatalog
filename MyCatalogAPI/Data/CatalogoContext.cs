using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCatalogAPI.Models;

namespace MyCatalogAPI.Data
{
    public class CatalogoContext : DbContext
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options) : base (options) {}
        public DbSet<Produto> Produtos {get; set; }
        public DbSet<GrupoProduto> GrupoProdutos { get; set; }
        public DbSet<Catalogo> Catalogos { get; set; }
        public DbSet<CatalogoProduto> CatalogoProdutos { get; set; }

        public CatalogoContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("ConnStr");
            optionsBuilder.UseSqlite(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CatalogoProduto>()
                .HasKey(CP => new { CP.CatalogoId, CP.ProdutoId });

            builder.Entity<Produto>()
                .HasData(new List<Produto>(){
                    new Produto(1, "X-Tudo","Hambuger, pão com gergelim, carne, presunto, muçarela, bacon, ovo, salsicha, alface, tomate, milho e Catupiry.",19.9m ,true, 1),
                    new Produto(2, "X-Especial","Hambuger, pão com gergelim, carne, presunto, muçarela, bacon, ovo, alface, tomate, milho e Catupiry.",17.9m ,true, 1),
                    new Produto(3, "X-Simples","Hambuger, pão com gergelim, carne, presunto, muçarela, ovo, alface, tomate, milho e Catupiry.",15.9m ,true, 1),
                    new Produto(4, "Misto Quente","Pão Francês, presunto, muçarela e ovo.",11.9m ,true, 1),
                    new Produto(5, "Creme","Creme com leite condensado",9.9m ,true, 3),
                    new Produto(6, "Refrigerante Lata","Refrigerante Lara 350ml",4.5m ,true, 1),
                });
            
            builder.Entity<GrupoProduto>()
                .HasData(new List<GrupoProduto>{
                    new GrupoProduto(1, "Sanduiche"),
                    new GrupoProduto(2, "Bebida"),
                    new GrupoProduto(3, "Sobremesa")                    
                });
            
            builder.Entity<Catalogo>()
                .HasData(new List<Catalogo>(){
                    new Catalogo(1, "Sanduiches Tradicionais", true),
                    new Catalogo(2, "Bebidas", true),
                    new Catalogo(3, "Sobremesas", true),
                    new Catalogo(4, "Promocional", false)
                });

            builder.Entity<CatalogoProduto>()
                .HasData(new List<CatalogoProduto>() {
                    new CatalogoProduto() {CatalogoId = 1, ProdutoId = 1 },
                    new CatalogoProduto() {CatalogoId = 1, ProdutoId = 2 },
                    new CatalogoProduto() {CatalogoId = 1, ProdutoId = 3 },
                    new CatalogoProduto() {CatalogoId = 1, ProdutoId = 4 },
                    new CatalogoProduto() {CatalogoId = 2, ProdutoId = 6 },
                    new CatalogoProduto() {CatalogoId = 3, ProdutoId = 5 }
                });
        }
    }
}