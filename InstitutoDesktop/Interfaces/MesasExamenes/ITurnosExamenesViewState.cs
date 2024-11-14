using InstitutoDesktop.Interfaces.Commons;

namespace InstitutoDesktop.Interfaces.MesasExamenes
{
    public interface ITurnosExamenesViewState : IBaseViewState
    {
        Task LoadComboboxCiclosLectivos();
    }
}
