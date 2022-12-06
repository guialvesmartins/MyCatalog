using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCatalogAPI.Models;

namespace MyCatalogAPI.Data
{
    public class Repository : IRepository
    {
        private readonly CatalogoContext _context;
        public Repository(CatalogoContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
        public async Task<Produto[]> GetAllProdutosAsync(bool includeGrupoProduto = false)
        {
            IQueryable<Produto> query = _context.Produtos;

            if (includeGrupoProduto)
            {
                query = query.Include(gp => gp.GrupoProduto)
                            .Include(x => x.CatalogosProdutos)
                            .ThenInclude(c => c.Catalogo);
            }

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Produto> GetProdutoAsyncById(int produtoId, bool includeGrupoProduto)
        {
            IQueryable<Produto> query = _context.Produtos;

            if (includeGrupoProduto)
            {
                query = query.Include(gp => gp.GrupoProduto)
                            .Include(x => x.CatalogosProdutos)
                            .ThenInclude(c => c.Catalogo);
            }

            query = query.AsNoTracking()
                         .OrderBy(produto => produto.Id)
                         .Where(produto => produto.Id == produtoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Produto[]> GetProdutosByCatalogId(int catalogoId)
        {
            IQueryable<Produto> query = _context.Produtos;

            query = query.Include(c => c.CatalogosProdutos)
                                .ThenInclude(p => p.Catalogo);

            query = query.AsNoTracking()
                         .OrderBy(p => p.Id)
                         .Where(p => p.CatalogosProdutos.Any( cp => cp.CatalogoId == catalogoId));

            return await query.ToArrayAsync();
        }

        //Busca CatalogoProduto por id de catalogo e id de produto
        public async Task<CatalogoProduto> GetCatalogoProdByCatProdId(int catalogoId, int produtoId)
        {
            IQueryable<CatalogoProduto> query = _context.CatalogoProdutos;

            query = query.Include(c => c.Catalogo)
                    .Include(p => p.Produto);
                    
            query = query.AsNoTracking()
                    .OrderBy(p => p.ProdutoId)
                    .Where(gp =>  gp.CatalogoId == catalogoId)
                    .Where(gp =>  gp.ProdutoId == produtoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<GrupoProduto[]> GetAllGrupoProdutoAsync(bool includeProduto = true)
        {
            IQueryable<GrupoProduto> query = _context.GrupoProdutos;

            if (includeProduto)
            {
                query = query.Include(c => c.Produtos)
                .ThenInclude(x => x.CatalogosProdutos)
                .ThenInclude(c => c.Catalogo);
            }

            query = query.AsNoTracking()
                         .OrderBy(gp => gp.Id);

            return await query.ToArrayAsync();
        }

        public async Task<GrupoProduto> GetGrupoProdutoAsyncById(int grupoProdutoId, bool includeProduto = true)
        {
            IQueryable<GrupoProduto> query = _context.GrupoProdutos;

            if (includeProduto)
            {
                query = query.Include(c => c.Produtos)
                .ThenInclude(x => x.CatalogosProdutos)
                .ThenInclude(c => c.Catalogo);
            }

            query = query.AsNoTracking()
                         .OrderBy(gp => gp.Id)
                         .Where(gp => gp.Id == grupoProdutoId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Catalogo[]> GetAllCatalogosAsync(bool includeProduto = true)
        {
            IQueryable<Catalogo> query = _context.Catalogos;

            if (includeProduto)
            {
                query = query.Include(c => c.CatalogosProdutos)
                                    .ThenInclude(p => p.Produto);
            }

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Catalogo> GetCatalogoAsyncById(int catalogoId, bool includeProduto = true)
        {
            IQueryable<Catalogo> query = _context.Catalogos;

            if (includeProduto)
            {
                query = query = query.Include(c => c.CatalogosProdutos)
                                    .ThenInclude(p => p.Produto);
            }

            query = query.AsNoTracking()
                         .OrderBy(gp => gp.Id)
                         .Where(gp => gp.Id == catalogoId);

            return await query.FirstOrDefaultAsync();
        }

    }
}