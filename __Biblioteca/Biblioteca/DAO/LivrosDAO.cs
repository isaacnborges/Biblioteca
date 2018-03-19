using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.DAO
{
    public class LivrosDAO
    {
        public void Adiciona(Livro livro)
        {
            using (var contexto = new BibliotecaContext())
            {
                contexto.Livros.Add(livro);
                contexto.SaveChanges();
            }
        }

        public IList<Livro> Lista()
        {
            using (var contexto = new BibliotecaContext())
            {
                return contexto.Livros.Include("Genero").ToList();
            }
        }

        public Livro BuscaPorId(int id)
        {
            using (var contexto = new BibliotecaContext())
            {
                return contexto.Livros.Include("Genero")
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
            }
        }

        public void Atualiza(Livro livro)
        {
            using (var contexto = new BibliotecaContext())
            {
                contexto.Entry(livro).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            } 
        }

        public void Exclui(Livro livro)
        {
            using (var contexto = new BibliotecaContext())
            {
                contexto.Entry(livro).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}