using InstitutoDesktop.Interfaces.Commons;

namespace InstitutoDesktop.Interfaces.Inscripciones
{
    public interface IInscripcionesMateriasViewState : IBaseViewState
    {
        void LoadComboboxPeriodosInscripciones();
        void LoadComboboxCarreras();
        void LoadComboboxAniosCarreras();
        void OnImprimirTodasPorAlumno();
        void OnImprimirTodasPorMateria();
        void OnImprimirSeleccionadaPorAlumno();
        void OnImprimirSeleccionadaPorMateria();
    }
}
