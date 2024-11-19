using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Views.Commons;
using InstitutoDesktop.Views.MesasExamenes;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Models.MesasExamenes;

namespace InstitutoDesktop.States.Commons.Usuarios
{
    public class ActionsState : IUsuariosViewState
    {
        private readonly UsuariosView _form;

        public ActionsState(UsuariosView form)
        {
            _form = form;
        }

        public void OnAgregar() 
        {
            _form.usuarioCurrent = new Usuario();
            _form.TransitionTo(new EditionState(_form));
        }

        public void OnModificar()
        {
            if (_form.Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _form.usuarioCurrent = (Usuario)_form.Grilla.CurrentRow.DataBoundItem;
            _form.TransitionTo(new EditionState(_form));
        }

        public async Task OnEliminar()
        {
            _form.usuarioCurrent = (Usuario)_form.Grilla.CurrentRow.DataBoundItem;
            var result = MessageBox.Show(
                $"¿Está seguro que desea eliminar al usuario {_form.usuarioCurrent.Nombre}?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                await _form._memoryCache.DeleteCacheAsync<Usuario>(_form.usuarioCurrent.Id);
            }
            _form.usuarioCurrent = null;
            _form.TransitionTo(new InitialDisplayState(_form));
        }


        // Estos métodos no aplican en este estado
        public Task LoadData() => Task.CompletedTask;
        public Task LoadGrid() => Task.CompletedTask;
        public Task LoadGridFilter(string filterText) => Task.CompletedTask;
        public void OnBuscar() { }
        public void UpdateUI() { }
        public Task OnGuardar() => Task.CompletedTask;
        public void OnCancelar() { }
        public void OnSalir() => _form.Close();



    }
}
