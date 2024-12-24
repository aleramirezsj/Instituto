using InstitutoDesktop.Interfaces.Commons;

namespace InstitutoDesktop.Interfaces.MesasExamenes
{
    public interface IInscripcionesMesasExamenesViewState : ICrudViewState
    {
        void LoadComboboxTurnosExamenes();
        void LoadComboboxCarreras();
        void LoadComboboxAniosCarreras();
        void LoadComboboxMaterias();
    }
}
