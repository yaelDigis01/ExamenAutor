using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRest.Controllers
{
    [RoutePrefix("api/libro")]
    public class LibroController : ApiController
    {

        [HttpPost]
        [Route("")]
        public IHttpActionResult Add(ML.Libro libro)
        {
            var result = BL.LibroBL.Add(
                libro.Autor.IdAutor,
                libro.Titulo,
                libro.FechaPublicacion,
                libro.Editorial.IdEditorial
            );

            if (result.Correct)
                return Ok(result);
            else
                return BadRequest(result.ErrorMessage);
        }

        [HttpGet]
        [Route("autor/{idAutor}")]
        public IHttpActionResult GetByAutor(int idAutor)
        {
            var result = BL.LibroBL.GetByAutor(idAutor);

            if (result.Correct)
                return Ok(result.Objects);
            else
                return NotFound();
        }


        [HttpGet]
        [Route("titulo/{titulo}")]
        public IHttpActionResult GetByTitulo(string titulo)
        {
            var result = BL.LibroBL.GetByTitulo(titulo);

            if (result.Correct)
                return Ok(result.Objects);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("editorial/{idEditorial}")]
        public IHttpActionResult GetByEditorial(int idEditorial)
        {
            var result = BL.LibroBL.GetByEditorial(idEditorial);

            if (result.Correct)
                return Ok(result.Objects);
            else
                return NotFound();
        }


        [HttpGet]
        [Route("autor/{idAutor}/fecha/{fechaPublicacion}")]
        public IHttpActionResult GetByAutorFecha(int idAutor, int fechaPublicacion)
        {
            var result = BL.LibroBL.GetByAutorFecha(idAutor, fechaPublicacion);

            if (result.Correct)
                return Ok(result.Objects);
            else
                return NotFound();
        }


        [HttpDelete]
        [Route("autor/{idAutor}")]
        public IHttpActionResult DeleteByAutor(int idAutor)
        {
            var result = BL.LibroBL.DeleteByAutor(idAutor);

            if (result.Correct)
                return Ok("Libros del autor eliminados correctamente");
            else
                return BadRequest(result.ErrorMessage);
        }
        [HttpDelete]
        [Route("editorial/{idEditorial}")]
        public IHttpActionResult DeleteByEditorial(int idEditorial)
        {
            var result = BL.LibroBL.DeleteByEditorial(idEditorial);

            if (result.Correct)
                return Ok("Libros de la editorial eliminados correctamente");
            else
                return BadRequest(result.ErrorMessage);
        }
    }
}