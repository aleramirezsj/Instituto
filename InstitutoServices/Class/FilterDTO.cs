using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoServices.Class
{
    public class FilterDTO
    {
        public string PropertyName { get; set; } = string.Empty; // Nombre de la propiedad a filtrar
        public string Operation { get; set; } = string.Empty;   // Operación (por ejemplo: "Equals", "Contains", etc.)
        public string? Value { get; set; }                      // Valor del filtro
    }

}
