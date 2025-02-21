using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComunicaAPI.Data;
using ComunicaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComunicaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly DataContext _context;
        public CategoriasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Categoria> listaCategorias = await _context.Categorias.ToListAsync();
                return Ok(listaCategorias);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(Categoria novaCategoria)
        {
            try
            {
                if (novaCategoria.Nome.Length == 0)
                {
                    return BadRequest("Por favor preencha um nome!");
                }
                if (novaCategoria.Nome.Length >= 15)
                {
                    return BadRequest("Limite de caracteres excedido! (15)");
                }
                await _context.Categorias.AddAsync(novaCategoria);
                await _context.SaveChangesAsync();

                return Ok(_context.Categorias);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategoria(Categoria novaCategoria)
        {
            try
            {
                if (novaCategoria.Nome.Length == 0)
                {
                    return BadRequest("Por favor preencha um nome!");
                }
                if (novaCategoria.Nome.Length >= 15)
                {
                    return BadRequest("Limite de caracteres excedido! (15)");
                }

                _context.Categorias.Update(novaCategoria);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok("Atualizado!");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Categoria catRemove = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);

                _context.Categorias.Remove(catRemove);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok("Deletado com sucesso!");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}