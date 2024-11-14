namespace InstitutoServices.Interfaces
{
    public interface IEntityIdNombre : IEntityWithId
    {
        public string Nombre { get; set; }
        public bool Eliminado { get; set; }
    }
}
