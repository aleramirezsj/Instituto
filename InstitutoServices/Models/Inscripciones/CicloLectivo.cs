using InstitutoServices.Interfaces;

namespace InstitutoServices.Models.Inscripciones
{
    public class CicloLectivo : IEntityIdNombre, IEntityWithId
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public bool Eliminado { get; set; } = false;
        public bool Actual { get; set; } = false;

        public override string ToString()
        {
            return Nombre;
        }
    }
}
