using Biblioteca.DAO;
using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca.Controllers
{
    public class LivroController : Controller
    {
        // GET: Livro
        [Route("livros", Name = "ListaLivros")]
        public ActionResult Index()
        {
            LivrosDAO dao = new LivrosDAO();
            IList<Livro> livros = dao.Lista();

            return View(livros);
        }

        public ActionResult Form()
        {
            GenerosDAO generosDAO = new GenerosDAO();
            IList<Genero> generos = generosDAO.Lista();

            ViewBag.Generos = generos;
            ViewBag.Livro = new Livro();

            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Livro livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LivrosDAO dao = new LivrosDAO();
                    dao.Adiciona(livro);

                    return RedirectToAction("Index", "Livro");
                }
                else
                {
                    ViewBag.Livro = livro;
                    GenerosDAO generosDAO = new GenerosDAO();
                    ViewBag.Generos = generosDAO.Lista();

                    return View("Form");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar o registro: " + ex.Message);
            }
        }

        public ActionResult Atualiza(Livro livro)
        {
            try
            {
                LivrosDAO dao = new LivrosDAO();
                dao.Atualiza(livro);

                return RedirectToAction("Index", "Livro");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o registro: " + ex.Message);
            }            
        }

        [HttpPost]
        public ActionResult Exclui(int id)
        {
            try
            {
                LivrosDAO dao = new LivrosDAO();
                Livro livro = dao.BuscaPorId(id);
                dao.Exclui(livro);

                return RedirectToAction("Index", "Livro");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir o registro: " + ex.Message);
            }
        }

        [Route("livros/{id}", Name = "VisualizaLivro")]        
        public ActionResult Visualiza(Livro livro, int id)
        {
            GenerosDAO generosDAO = new GenerosDAO();
            IList<Genero> generos = generosDAO.Lista();
            ViewBag.Generos = generos;

            LivrosDAO dao = new LivrosDAO();
            livro = dao.BuscaPorId(id);
            ViewBag.Livro = livro;

            return View();
        }

        public ActionResult DecrementaQtd(int id)
        {
            LivrosDAO dao = new LivrosDAO();
            Livro livro = dao.BuscaPorId(id);
            livro.Quantidade--;
            dao.Atualiza(livro);

            return Json(livro);
        }

        public ActionResult AumentaQtd(int id)
        {
            LivrosDAO dao = new LivrosDAO();
            Livro livro = dao.BuscaPorId(id);
            livro.Quantidade++;
            dao.Atualiza(livro);

            return Json(livro);
        }
    }
}