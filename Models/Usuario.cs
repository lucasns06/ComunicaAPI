using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComunicaAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public List<Categoria> Categorias { get; set; } = new List<Categoria>();
    }
}