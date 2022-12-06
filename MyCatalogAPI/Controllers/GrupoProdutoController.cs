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
    public class GrupoProdutoController : ControllerBase
    {
        private readonly IRepository repo;
        public GrupoProdutoController(IRepository repo)
        {
            this.repo = repo;
            
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            try
            {
                var result = await this.repo.GetAllGrupoProdutoAsync(true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }            
        }

        [HttpGet("{GrupoProdutoId}")]
        public async Task<IActionResult> GetByGrupoProdutoId(int GrupoProdutoId){
            try
            {
                var result = await this.repo.GetGrupoProdutoAsyncById(GrupoProdutoId,true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }            
        }

        [HttpPost]
        public async Task<IActionResult> Post(GrupoProduto model){

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

        [HttpPut("{GrupoProdutoId}")]
        public async Task<IActionResult> Put(int GrupoProdutoId, GrupoProduto model)
        {
            try
            {
                var produto = await this.repo.GetGrupoProdutoAsyncById(GrupoProdutoId, false);
                
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

        [HttpDelete("{GrupoProdutoId}")]
        public async Task<IActionResult> Delete(int GrupoProdutoId)
        {
            try
            {
                var produto = await this.repo.GetGrupoProdutoAsyncById(GrupoProdutoId, false);
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