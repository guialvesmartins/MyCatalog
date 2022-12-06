using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCatalogAPI.Data;
using MyCatalogAPI.Models;

namespace MyCatalogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogoProdutoController : ControllerBase
    {
        private readonly IRepository repo;
        public CatalogoProdutoController(IRepository repo)
        {
            this.repo = repo;

        }

        [HttpPost]
        public async Task<IActionResult> Post(CatalogoProduto model)
        {
            try
            {
                this.repo.Add(model);

                if (await this.repo.SaveChangesAsync())
                {
                    return Ok(model);
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

         [HttpDelete("{CatalogoId}/{ProdutoId}")]
        public async Task<IActionResult> Delete(int CatalogoId,int ProdutoId)
        {
            try
            {
                var catProd = await this.repo.GetCatalogoProdByCatProdId(CatalogoId, ProdutoId);

                if(catProd == null) return NotFound();

                this.repo.Delete(catProd);

                if(await this.repo.SaveChangesAsync())
                {
                    return Ok( new { message = catProd.ProdutoId + " Deletado de " + catProd.CatalogoId } );
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

    }
}