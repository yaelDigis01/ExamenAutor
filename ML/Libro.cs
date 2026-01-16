using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ML
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public int FechaPublicacion { get; set; }

        public Autor Autor { get; set; }
        public Editorial Editorial { get; set; }
    }
}
