using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Livro
    {
        public int Id { get; set; }

        [Required]
        public String Nome { get; set; }

        [Range(0.0, 10000.0)]
        public float Preco { get; set; }

        public Genero Genero { get; set; }

        public int? GeneroId { get; set; }

        public int Quantidade { get; set; }
    }
}