using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Biblioteca.DAO
{
    public class BibliotecaContext : DbContext
    {
        public DbSet<Livro> Livros { get; set; }

        public DbSet<Genero> Generos { get; set; }
    }
}