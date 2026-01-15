using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class LibroBL
    {
        public static ML.Result Add(int idAutor, string tituloLibro, int fechaPublicacion, int idEditorial)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaEntities context = new DL.BibliotecaEntities())
                {
                    context.LibroInsertar(idAutor, tituloLibro, fechaPublicacion, idEditorial);
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

     
        public static ML.Result GetByAutor(int idAutor)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaEntities context = new DL.BibliotecaEntities())
                {
                    var registros = context.LibroConsultarPorAutor(idAutor).ToList();
                    result.Objects = new List<object>();

                    foreach (var registro in registros)
                    {
                        ML.Libro libro = new ML.Libro();
                        libro.Titulo = registro.Titulo;
                        libro.FechaPublicacion = registro.FechaPublicacion;
                        libro.Editorial = new ML.Editorial();
                        libro.Editorial.NombreEditorial = registro.NombreEditorial;

                        result.Objects.Add(libro);
                    }

                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

    
        public static ML.Result GetByTitulo(string tituloLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaEntities context = new DL.BibliotecaEntities())
                {
                    var registros = context.LibroConsultarPorTitulo(tituloLibro).ToList();
                    result.Objects = new List<object>();

                    foreach (var registro in registros)
                    {
                        ML.Libro libro = new ML.Libro();
                        libro.Titulo = registro.Titulo;
                        libro.FechaPublicacion = registro.FechaPublicacion;
                        libro.Editorial = new ML.Editorial();
                        libro.Editorial.NombreEditorial = registro.NombreEditorial;

                        result.Objects.Add(libro);
                    }

                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

    
        public static ML.Result GetByFecha(int fechaPublicacion)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaEntities context = new DL.BibliotecaEntities())
                {
                    var registros = context.LibroConsultarPorFecha(fechaPublicacion).ToList();
                    result.Objects = new List<object>();

                    foreach (var registro in registros)
                    {
                        ML.Libro libro = new ML.Libro();
                        libro.Titulo = registro.Titulo;
                        libro.Autor = new ML.Autor();
                        libro.Autor.NombreAutor = registro.NombreAutor;
                        libro.Editorial = new ML.Editorial();
                        libro.Editorial.NombreEditorial = registro.NombreEditorial;

                        result.Objects.Add(libro);
                    }

                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

      
        public static ML.Result GetByEditorial(int idEditorial)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaEntities context = new DL.BibliotecaEntities())
                {
                    var registros = context.LibroConsultarPorEditorial(idEditorial).ToList();
                    result.Objects = new List<object>();

                    foreach (var registro in registros)
                    {
                        ML.Libro libro = new ML.Libro();
                        libro.Titulo = registro.Titulo;
                        libro.FechaPublicacion = registro.FechaPublicacion;
                        libro.Autor = new ML.Autor();
                        libro.Autor.NombreAutor = registro.NombreAutor;

                        result.Objects.Add(libro);
                    }

                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

      
        public static ML.Result GetByAutorFecha(int idAutor, int fechaPublicacion)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaEntities context = new DL.BibliotecaEntities())
                {
                    var registros = context.LibroConsultarPorAutorYFecha(idAutor, fechaPublicacion).ToList();
                    result.Objects = new List<object>();

                    foreach (var registro in registros)
                    {
                        ML.Libro libro = new ML.Libro();
                        libro.Titulo = registro.Titulo;
                        libro.Editorial = new ML.Editorial();
                        libro.Editorial.NombreEditorial = registro.NombreEditorial;

                        result.Objects.Add(libro);
                    }

                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

      
        public static ML.Result DeleteByAutor(int idAutor)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaEntities context = new DL.BibliotecaEntities())
                {
                    context.LibroEliminarPorAutor(idAutor);
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

      
        public static ML.Result DeleteByEditorial(int idEditorial)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaEntities context = new DL.BibliotecaEntities())
                {
                    context.LibroEliminarPorEditorial(idEditorial);
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
    }
}
