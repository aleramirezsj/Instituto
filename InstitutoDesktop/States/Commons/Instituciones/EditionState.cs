using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Interfaces;
using InstitutoDesktop.Util;
using InstitutoDesktop.Views;
using InstitutoServices.Enums;
using InstitutoServices.Models;
using InstitutoServices.Models.Commons;

namespace InstitutoDesktop.States.Instituciones
{
    public class EditionState : IInstitucionViewState
    {
        private readonly InstitucionView _form;

        public EditionState(InstitucionView form)
        {
            _form = form;
            UpdateUI();
        }

        public async Task LoadData() { }

        public async void UpdateUI()
        {
            _form.tabPageAgregarEditar.Enabled = true;
            _form.btnModificar.Enabled = false;

        }

        public void OnModificar() { }

        public async Task OnGuardar() 
        {
            _form.institucionCurrent.NombreCompleto = _form.TxtNombreCompleto.Text;
            _form.institucionCurrent.Direccion = _form.TxtDomicilio.Text;
            _form.institucionCurrent.Telefono = _form.TxtTelefono.Text;
            _form.institucionCurrent.NombreCorto = _form.TxtNombreCorto.Text;
            _form.institucionCurrent.Email = _form.TxtEmail.Text;
            _form.institucionCurrent.Localidad = _form.TxtLocalidad.Text;
            _form.institucionCurrent.Provincia = _form.TxtProvincia.Text;
            _form.institucionCurrent.CodigoPostal = _form.TxtCodigoPostal.Text;
            _form.institucionCurrent.Sigla = _form.TxtSigla.Text;

            
            await _form._memoryCache.UpdateCacheAsync<Institucion>(_form.institucionCurrent);
            _form.TransitionTo(new InitialDisplayState(_form));
        }

        public void OnCancelar() {
            _form.TransitionTo(new InitialDisplayState(_form));
        }
        public void OnSalir() => _form.Close();

    }
}
