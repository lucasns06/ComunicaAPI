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

    }
}