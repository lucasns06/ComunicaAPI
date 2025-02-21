using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using ComunicaAPI.Models.Enuns;

namespace ComunicaAPI.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public BackgroundEnum CorBackground { get; set; }
        public ICollection<Imagem> Imagens { get; set; } = new List<Imagem>(); 
        /*
        public int? UsuarioId { get; set; }
        [JsonIgnore]
        public Usuario? Usuario { get; set; }
        */
    }
}