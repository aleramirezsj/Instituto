using InstitutoDesktop.Interfaces.Commons;

namespace InstitutoDesktop.Interfaces.MesasExamenes
{
    public interface IInscripcionesExamenesViewState : IBaseViewState
    {
        void LoadComboboxTurnosExamenes();
        void LoadComboboxCarreras();
        void LoadComboboxAniosCarreras();
        void OnImprimirTodasPorAlumno();
        void OnImprimirTodasPorMateria();
        void OnImprimirSeleccionadaPorAlumno();
        void OnImprimirSeleccionadaPorMateria();
    }
}
