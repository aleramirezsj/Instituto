using InstitutoDesktop.Interfaces.Commons;

namespace InstitutoDesktop.Interfaces.Horarios
{
    public interface IHorariosViewState : IBaseViewState
    {
        void LoadComboboxPeriodosHorarios();
        void LoadComboboxCarreras();
        void LoadComboboxAniosCarreras();
        void LoadComboboxMaterias();
        void LoadComboboxDocentes();
        void LoadComboboxAulas();
        void LoadComboboxDias();
        void LoadComboboxHoras();
        void OnAgregarDocenteAIntegrantes();
        void OnQuitarDocenteDeIntegrantes();
        void OnAgregarHoraADetalle();
        void OnEditarHoraDeDetalle();
        void OnQuitarHoraDeDetalle();
    }
}
