using InstitutoDesktop.Interfaces.Commons;

namespace InstitutoDesktop.Interfaces.MesasExamenes
{
    public interface IMesasExamenesViewState : IBaseViewState
    {
        void LoadComboboxTurnosExamenes();
        void LoadComboboxCarreras();
        void LoadComboboxAniosCarreras();
        void LoadComboboxMaterias();
        void LoadComboboxDocentes();
        void LoadComboboxTipoIntegrante();
        void OnAgregarDocenteADetalle();
        void OnQuitarDocenteDeDetalle();
        void OnEditarDocenteDeDetalle();
    }
}
