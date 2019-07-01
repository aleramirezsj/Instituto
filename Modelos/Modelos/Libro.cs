using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Libro
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Autor { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        public int Paginas { get; set; }
    }
}
