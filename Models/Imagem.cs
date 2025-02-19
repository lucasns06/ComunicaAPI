using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComunicaAPI.Models
{
    public class Imagem
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;        
        public string CorBackground { get; set; } = string.Empty;
    }
}