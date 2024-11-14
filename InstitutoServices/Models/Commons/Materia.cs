using InstitutoServices.Enums;
using InstitutoServices.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitutoServices.Models.Commons
{
    public class Materia : IEntityIdNombre, IEntityWithId
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        [Display(Name = "Año carrera")]
        public int AnioCarreraId { get; set; }
        [Display(Name = "Año carrera")]
        public AnioCarrera? AnioCarrera { get; set; }
        public TipoMateriaEnum TipoMateria { get; set; }
        public bool EsRecreo { get; set; } = false;
        public bool Eliminado { get; set; } = false;


        public override string ToString()
        {
            return Nombre;
        }
    }
}
