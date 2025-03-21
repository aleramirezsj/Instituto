using InstitutoServices.Interfaces;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.MesasExamenes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitutoServices.Models.Inscripciones
{
    public class Inscripcion : IEntityWithId
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }
        public int AlumnoId { get; set; }
        public Alumno? Alumno { get; set; }
        public int CarreraId { get; set; }
        public Carrera? Carrera { get; set; }
        public int? PeriodoInscripcionId { get; set; }
        public PeriodoInscripcion? PeriodoInscripcion { get; set; }
        public bool Eliminado { get; set; } = false;

        public List<DetalleInscripcion> detallesInscripciones { get; set; } = new List<DetalleInscripcion>();


        [NotMapped]
        public string? Inscripto
        {
            get { return $"{Alumno?.ApellidoNombre} - {Carrera?.Nombre}" ?? string.Empty; }
        }
    }
}
