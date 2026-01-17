using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BL;
using ML;

namespace PL.Controllers
{
    public class GetController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            ViewBag.LibroSeleccionado = null;
            return View(new List<ML.Libro>());
        }


        [HttpPost]
        public ActionResult BuscarPorAutor(int idAutor)
        {
            ML.Result result = LibroBL.GetByAutor(idAutor);
            ViewBag.LibroSeleccionado = null;
            return View("Get", result.Objects.Cast<ML.Libro>().ToList());
        }


        [HttpPost]
        public ActionResult BuscarPorTitulo(string titulo)
        {
            ML.Result result = LibroBL.GetByTitulo(titulo);
            ViewBag.LibroSeleccionado = null;
            return View("Get", result.Objects.Cast<ML.Libro>().ToList());
        }


        [HttpPost]
        public ActionResult Seleccionar(string titulo)
        {
            ML.Result result = LibroBL.GetByTitulo(titulo);
            ViewBag.LibroSeleccionado = result.Objects.Cast<ML.Libro>().FirstOrDefault();

            return View("Get", result.Objects.Cast<ML.Libro>().ToList());
        }

        [HttpPost]
        public ActionResult Add(int idAutor, string titulo, int fechaPublicacion, int idEditorial)
        {
            LibroBL.Add(idAutor, titulo, fechaPublicacion, idEditorial);
            ViewBag.Mensaje = "Libro agregado correctamente";
            ViewBag.LibroSeleccionado = null;

            return View("Get", new List<ML.Libro>());
        }
    }
}



