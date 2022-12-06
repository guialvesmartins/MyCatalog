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
    public class ProdutoController : ControllerBase
    {
        private readonly IRepository repo;
        public ProdutoController(IRepository repo)
        {
            this.repo = repo;
            
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            try
            {
                var result = await this.repo.GetAllProdutosAsync(true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }            
        }

        [HttpGet("{ProdutoId}")]
        public async Task<IActionResult> GetByProdutoId(int ProdutoId){
            try
            {
                var result = await this.repo.GetProdutoAsyncById(ProdutoId,true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }            
        }

        [HttpPost]
        public async Task<IActionResult> Post(Produto model){

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

        [HttpPut("{ProdutoId}")]
        public async Task<IActionResult> Put(int ProdutoId, Produto model)
        {
            try
            {
                var produto = await this.repo.GetProdutoAsyncById(ProdutoId, false);
                
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

        [HttpDelete("{ProdutoId}")]
        public async Task<IActionResult> Delete(int ProdutoId)
        {
            try
            {
                var produto = await this.repo.GetProdutoAsyncById(ProdutoId, false);
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