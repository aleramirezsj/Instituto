using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Interfaces;
using InstitutoDesktop.Util;
using InstitutoDesktop.Views;
using InstitutoServices.Enums;
using InstitutoServices.Models;
using InstitutoServices.Models.Commons;

namespace InstitutoDesktop.States.Instituciones
{
    public class InitialDisplayState : IInstitucionViewState
    {
        private readonly InstitucionView _form;

        public InitialDisplayState(InstitucionView form)
        {
            _form = form;
            _ = LoadData();
        }

        public async Task LoadData()
        {
            ShowInActivity.Show("Cargando datos de la institución...");
            _form.listaInstituciones = await _form._memoryCache.GetAllCacheAsync<Institucion>();
            _form.institucionCurrent = _form.listaInstituciones.FirstOrDefault();
            ShowInActivity.Hide();
            UpdateUI();
        }

        public async void UpdateUI()
        {
            if (_form.institucionCurrent != null)
            { 
                _form.TxtNombreCompleto.Text = _form.institucionCurrent.NombreCompleto;
                _form.TxtNombreCorto.Text = _form.institucionCurrent.NombreCorto;
                _form.TxtDomicilio.Text = _form.institucionCurrent.Direccion;
                _form.TxtTelefono.Text = _form.institucionCurrent.Telefono;
                _form.TxtEmail.Text = _form.institucionCurrent.Email;
                _form.TxtLocalidad.Text = _form.institucionCurrent.Localidad;
                _form.TxtProvincia.Text = _form.institucionCurrent.Provincia;
                _form.TxtCodigoPostal.Text = _form.institucionCurrent.CodigoPostal;
                _form.TxtSigla.Text = _form.institucionCurrent.Sigla;

            }
            _form.tabPageAgregarEditar.Enabled = false;
            _form.btnModificar.Enabled = true;
        }

        public void OnModificar() {
            _form.TransitionTo(new EditionState(_form));
            _form._currentState.OnModificar();
        }

        public Task OnGuardar() => Task.CompletedTask;
        public void OnCancelar() { }
        public void OnSalir() => _form.Close();

    }
}
