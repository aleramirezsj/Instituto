using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Views;
using InstitutoDesktop.Views.Commons;
using InstitutoDesktop.Views.Horarios;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Horarios;

namespace InstitutoDesktop.States.Horarios.Horas
{
    public class EditionState : IBaseViewState
    {
        private readonly HorasView _form;

        public EditionState(HorasView form)
        {
            _form = form;
            UpdateUI();
            _form.dateTimeDesde.Leave += (sender, e) => GetValuesFromScreen();
            _form.dateTimeHasta.Leave += (sender, e) => GetValuesFromScreen();
        }

        public async Task OnGuardar()
        {
            if (string.IsNullOrEmpty(_form.txtNombre.Text))
            {
                MessageBox.Show("Debe definirse el rango desde y hasta de la hora ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GetValuesFromScreen();


            if (_form.horaCurrent.Id == 0)
            {
                await _form._memoryCache.AddCacheAsync<Hora>(_form.horaCurrent);
            }
            else
            {
                await _form._memoryCache.UpdateCacheAsync<Hora>(_form.horaCurrent);
            }

            _form.TransitionTo(new DisplayGridState(_form));
        }

        private void GetValuesFromScreen()
        {
            _form.horaCurrent.Desde = new DateTime(1, 1, 1, _form.dateTimeDesde.Value.Hour, _form.dateTimeDesde.Value.Minute, 0);
            _form.horaCurrent.Hasta = new DateTime(1, 1, 1, _form.dateTimeHasta.Value.Hour, _form.dateTimeHasta.Value.Minute, 0);

            //actualizo el textbox que muestra el detalle del rango de hora definido
            _form.txtNombre.Text=_form.horaCurrent.Nombre ;
        }
        

        public void OnCancelar()
        {
            _form.horaCurrent = null;
            _form.TransitionTo(new DisplayGridState(_form));
        }

        public void UpdateUI()
        {
            _form.tabPageAgregarEditar.Enabled = true;
            _form.tabPageLista.Enabled = false;
            _form.tabControl.SelectTab(_form.tabPageAgregarEditar);

            _form.txtNombre.Text = _form.horaCurrent.Nombre;
            //definimos el valor de la fecha como actual y la hora y minutos como los de la hora
            
            _form.dateTimeDesde.Value = new DateTime(1800, 1, 1, _form.horaCurrent.Desde.Hour, _form.horaCurrent.Desde.Minute, 0);
            _form.dateTimeHasta.Value = new DateTime(1800, 1, 1, _form.horaCurrent.Hasta.Hour, _form.horaCurrent.Hasta.Minute, 0);
        }

        // Estos métodos no aplican en este estado
        public Task LoadData() => Task.CompletedTask;
        public void LoadGrid() {}
        public void LoadGridFilter(string filterText) {}
        public void OnAgregar() { }
        public void OnModificar() { }
        public void OnBuscar() { }
        public Task OnEliminar() => Task.CompletedTask;
        public void OnSalir() => _form.Close();
    }
}
