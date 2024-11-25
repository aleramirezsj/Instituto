using InstitutoServices.Enums;
using InstitutoServices.Interfaces;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Horarios;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitutoServices.Models.MesasExamenes
{
    public class MesaExamen: IEntityWithId
    {
        public int Id { get; set; }
        public int MateriaId { get; set; }
        public Materia? Materia { get; set; }
        public DateTime Llamado1 { get; set; } = DateTime.Now;
        public DateTime Llamado2 { get; set; } = DateTime.Now.AddDays(14);
        public string Horario { get; set; } = string.Empty;
        public int TurnoExamenId { get; set; }
        public TurnoExamen? TurnoExamen { get; set; }
        public bool Eliminado { get; set; } = false;

        [NotMapped]
        public string Docentes
        {
            get
            {
                return string.Join(", ", DetallesMesaExamen.Where(d=>d.TipoIntegrante!=TipoIntegranteEnum.Suplente).Select(x => x.Docente?.Nombre));
            }
        }

        [NotMapped]
        public string Suplentes
        {
            get
            {
                return string.Join(", ", DetallesMesaExamen.Where(d => d.TipoIntegrante == TipoIntegranteEnum.Suplente).Select(x => x.Docente?.Nombre));
            }
        }

        public ICollection<DetalleMesaExamen> DetallesMesaExamen { get; set; }

        public MesaExamen()
        {
            DetallesMesaExamen = new List<DetalleMesaExamen>();
        }

        public override string ToString()
        {
            return $"{Materia?.Nombre} {Llamado1.Date} / {Llamado2.Date}" ?? string.Empty;
        }
    }
}
