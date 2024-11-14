using InstitutoServices.Interfaces;
using InstitutoServices.Interfaces.MesasExamenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoServices.Models.Inscripciones
{
    public class PeriodoInscripcion: IEntityWithId
    {
        public int Id{ get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int? CicloLectivoId { get; set; } = 0;
        public CicloLectivo? CicloLectivo { get; set; }
        public bool InscripcionHabilitada { get; set; }
        public bool Es2doCuatrimestre { get; set; } = false;
        public bool Eliminado { get; set; } = false;

    }
}
