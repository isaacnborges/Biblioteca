using Biblioteca.DAO;
using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca.Controllers
{
    public class GeneroController : Controller
    {
        // GET: Genero
        [Route("generos", Name = "ListaGenero")]
        public ActionResult Index()
        {
            GenerosDAO dao = new GenerosDAO();
            IList<Genero> generos = dao.Lista();

            return View(generos);
        }

        public ActionResult Form()
        {        
            ViewBag.Genero = new Genero();

            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Genero genero)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GenerosDAO dao = new GenerosDAO();
                    dao.Adiciona(genero);

                    return RedirectToAction("Index", "Genero");
                }
                else
                {
                    ViewBag.Generos = genero;

                    return View("Form");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar o registro: " + ex.Message);
            }            
        }

        public ActionResult Atualiza(Genero genero)
        {
            try
            {
                GenerosDAO dao = new GenerosDAO();
                dao.Atualiza(genero);

                return RedirectToAction("Index", "Genero");
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
                GenerosDAO dao = new GenerosDAO();
                Genero genero = dao.BuscaPorId(id);
                dao.Exclui(genero);

                return RedirectToAction("Index", "Genero");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir o registro: " + ex.Message);
            }
        }

        [Route("generos/{id}", Name = "VisualizaGenero")]
        public ActionResult Visualiza(Genero genero, int id)
        {   
            GenerosDAO dao = new GenerosDAO();
            genero = dao.BuscaPorId(id);
            ViewBag.Genero = genero;

            return View();
        }
    }
}