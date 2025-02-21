using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComunicaAPI.Models;
using ComunicaAPI.Models.Enuns;
using Microsoft.AspNetCore.Mvc;

namespace ComunicaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasExemploController : ControllerBase
    {
        private static List<Categoria> categorias = new List<Categoria>()
        {
            new Categoria() {Id = 1, Nome = "Social", CorBackground=BackgroundEnum.Azul},
            new Categoria() {Id = 2, Nome = "Roupas", CorBackground=BackgroundEnum.Verde},
        };
        [HttpGet("Get")]
        public IActionResult GetFirst()
        {
            Categoria c = categorias[0];
            return Ok(c);
        }
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(categorias);
        }
        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(categorias.FirstOrDefault(ca => ca.Id == id));
        }
        [HttpPost]
        public IActionResult AddCategoria(Categoria novaCategoria)
        {
            if (novaCategoria.Nome.Length == 0)
            {
                return BadRequest("Por favor preencha um nome!");
            }
            if (novaCategoria.Nome.Length >= 15)
            {
                return BadRequest("Limite de caracteres excedido! (15)");
            }
            categorias.Add(novaCategoria);
            return Ok(categorias);
        }
        [HttpPut]
        public IActionResult UpdateCategoria(Categoria c)
        {
            Categoria categoriaAlterada = categorias.Find(cat => cat.Id == c.Id);
            categoriaAlterada.Nome = c.Nome;
            categoriaAlterada.CorBackground = c.CorBackground;
            categoriaAlterada.Imagens = c.Imagens;
            return Ok(categorias);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            categorias.RemoveAll(cat => cat.Id == id);
            return Ok(categorias);
        }
    }
}