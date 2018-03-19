using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.DAO
{
    public class GenerosDAO
    {
        public void Adiciona(Genero genero)
        {
            using (var context = new BibliotecaContext())
            {
                context.Generos.Add(genero);
                context.SaveChanges();
            }
        }

        public IList<Genero> Lista()
        {
            using (var contexto = new BibliotecaContext())
            {
                return contexto.Generos.ToList();
            }
        }

        public Genero BuscaPorId(int id)
        {
            using (var contexto = new BibliotecaContext())
            {
                return contexto.Generos.Find(id);
            }
        }

        public void Atualiza(Genero genero)
        {
            using (var contexto = new BibliotecaContext())
            {
                contexto.Entry(genero).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Exclui(Genero genero)
        {
            using (var contexto = new BibliotecaContext())
            {
                contexto.Entry(genero).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}