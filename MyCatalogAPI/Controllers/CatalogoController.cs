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
    public class CatalogoController : ControllerBase
    {
        private readonly IRepository repo;
        public CatalogoController(IRepository repo)
        {
            this.repo = repo;
            
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            try
            {
                var result = await this.repo.GetAllCatalogosAsync(true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }            
        }

        [HttpGet("{CatalogoId}")]
        public async Task<IActionResult> GetByCatalogoId(int CatalogoId){
            try
            {
                var result = await this.repo.GetCatalogoAsyncById(CatalogoId,true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }            
        }

        [HttpGet("{CatalogoId}/produtos")]
        public async Task<IActionResult> GetProdutosByCatalogId(int CatalogoId){
            try
            {
                var result = await this.repo.GetProdutosByCatalogId(CatalogoId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }            
        }

        [HttpPost]
        public async Task<IActionResult> Post(Catalogo model){

            try
            {
                this.repo.Add(model);

                if(await this.repo.SaveChangesAsync()){
                    return Ok(model);
                }
                
            }
            catch (Exception ex)
            {                
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{CatalogoId}")]
        public async Task<IActionResult> Put(int CatalogoId, Catalogo model)
        {
            try
            {
                var produto = await this.repo.GetCatalogoAsyncById(CatalogoId, false);
                
                if(produto == null) return NotFound();
                this.repo.Update(model);

                if(await this.repo.SaveChangesAsync())
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

        [HttpDelete("{CatalogoId}")]
        public async Task<IActionResult> Delete(int CatalogoId)
        {
            try
            {
                var produto = await this.repo.GetCatalogoAsyncById(CatalogoId, false);
                if(produto == null) return NotFound();

                this.repo.Delete(produto);

                if(await this.repo.SaveChangesAsync())
                {
                    return Ok( new { message = produto.Nome + " Deletado"} );
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