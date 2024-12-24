using InstitutoDesktop.Interfaces.Commons;

namespace InstitutoDesktop.Interfaces.MesasExamenes
{
    public interface ITurnosExamenesViewState : ICrudViewState
    {
        Task LoadComboboxCiclosLectivos();
    }
}
