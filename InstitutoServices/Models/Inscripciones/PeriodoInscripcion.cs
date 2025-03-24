using InstitutoServices.Interfaces;
using InstitutoServices.Interfaces.MesasExamenes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [NotMapped]
        public bool Es1erCuatrimestre
        {
            get { return !Es2doCuatrimestre; }
        }
        public bool Es2doCuatrimestre { get; set; } = false;
        public bool InscripcionHabilitada { get; set; }
        public bool Eliminado { get; set; } = false;

        public override string ToString()
        {
            return Nombre;
        }
    }
}
