using InstitutoServices.Interfaces;
using InstitutoServices.Models.Inscripciones;

namespace InstitutoServices.Models.MesasExamenes
{
    public class TurnoExamen : IEntityIdNombre, IEntityWithId
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Actual { get; set; } = false;
        public int? CicloLectivoId { get; set; } = 0;
        public CicloLectivo? CicloLectivo { get; set; }
        public bool InscripcionHabilitada { get; set; } = false;
        public bool TieneLLamado2 { get; set; } = false;
        public bool Eliminado { get; set; } = false;


        public override string ToString()
        {
            return Nombre;
        }
    }
}
