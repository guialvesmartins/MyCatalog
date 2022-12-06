using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCatalogAPI.Models;

namespace MyCatalogAPI.Data
{
    public interface IRepository
    {
        //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //PRODUTO
        Task<Produto[]> GetAllProdutosAsync(bool includeGrupoProduto);        
        Task<Produto> GetProdutoAsyncById(int produtoId, bool includeGrupoProduto);
        Task<Produto[]> GetProdutosByCatalogId(int catalogoId);
        
        //GRUPOPRODUTO
        Task<GrupoProduto[]> GetAllGrupoProdutoAsync(bool includeProduto);
        Task<GrupoProduto> GetGrupoProdutoAsyncById(int grupoProdutoId, bool includeProduto);
    
        //CATALOGO
        Task<Catalogo[]> GetAllCatalogosAsync(bool includeProduto);
        Task<Catalogo> GetCatalogoAsyncById(int catalogoId, bool includeProduto);
        Task<CatalogoProduto> GetCatalogoProdByCatProdId(int catalogoId, int produtoId);
    }
}