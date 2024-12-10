using InstitutoServices.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitutoServices.Models.Commons
{
    public class AnioCarrera : IEntityIdNombre, IEquatable<AnioCarrera>
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int CarreraId { get; set; }
        public Carrera? Carrera { get; set; }
        public bool Eliminado { get; set; } = false;

        [NotMapped]
        public string AñoYCarrera
        {
            get { return $"{Nombre} {Carrera?.Nombre}" ?? string.Empty; }
        }
        public override string ToString()
        {
            return AñoYCarrera;
        }

        public bool Equals(AnioCarrera other)
        {
            if (other is null) return false;
            return this.Id == other.Id;
        }

        public override bool Equals(object obj) => Equals(obj as AnioCarrera);
        public override int GetHashCode() => Id.GetHashCode();
    }
}
