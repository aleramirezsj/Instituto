using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Interfaces.MesasExamenes;
using InstitutoDesktop.Views;
using InstitutoDesktop.ViewReports;
using InstitutoDesktop.Views.Inscripciones;
using InstitutoDesktop.Views.MesasExamenes;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Models.MesasExamenes;

namespace InstitutoDesktop.States.MesasExamenes.InscripcionesExamenes
{
    public class ActionsState : IInscripcionesExamenesViewState
    {
        private readonly InscripcionesExamenesView _form;

        public ActionsState(InscripcionesExamenesView form)
        {
            _form = form;
        }

        // Estos métodos no aplican en este estado
        public Task LoadData() => Task.CompletedTask;
        public void LoadGrid(string filterText)  { }
        public void OnBuscar() { }
        public void UpdateUI() { }
        public void OnSalir() => _form.Close();
        public void LoadComboboxTurnosExamenes() {}
        public void LoadComboboxCarreras() {}
        public void LoadComboboxAniosCarreras() {}

        public void OnImprimirTodasPorAlumno()
        {
            //necesito filtrar la lista de _form.listaDetallesInscripcionesExamenes dejando solo las que sean de alguna de las inscripciones a exámenes existentes en la lista _form.listaInscripcionesExamene



            Form InscripcionExamenViewReport = new InscripcionExamenAlumnoViewReport((MenuPrincipalView)_form.MdiParent, _form.listaDetallesInscripcionesExamenes.Where(d => _form.listaInscripcionesExamenesFiltrada.Any(i => i.Id.Equals(d.InscripcionExamenId))).ToList());
            InscripcionExamenViewReport.Show();
            _form.TransitionTo(new InitialDisplayState(_form));

        }

        public void OnImprimirTodasPorMateria()
        {
            Form InscripcionExamenViewReport = new InscripcionExamenMateriaViewReport((MenuPrincipalView)_form.MdiParent, _form.listaDetallesInscripcionesExamenes.Where(d => d.InscripcionExamen.TurnoExamenId.Equals((int)_form.cboTurnosExamenes.SelectedValue) &&
                              d.InscripcionExamen.CarreraId.Equals((int)_form.cboCarreras.SelectedValue) &&
                              d.Materia.AnioCarreraId.Equals((int)_form.cboAniosCarreras.SelectedValue))
                        .OrderBy(x => x.Materia?.Nombre).ThenBy(x => x.InscripcionExamen?.Alumno?.ApellidoNombre)
                        .ToList());
            InscripcionExamenViewReport.Show();
            _form.TransitionTo(new InitialDisplayState(_form));
        }

        public void OnImprimirSeleccionadaPorAlumno()
        {
            //tomo la inscripción seleccionada de la grilla dataGridViewInscripciones
            InscripcionExamen inscripcionSeleccionada = (InscripcionExamen)_form.dataGridInscripciones.CurrentRow.DataBoundItem;
            Form InscripcionExamenViewReport = new InscripcionExamenAlumnoViewReport((MenuPrincipalView)_form.MdiParent, _form.listaDetallesInscripcionesExamenes.Where(d => d.InscripcionExamenId.Equals(inscripcionSeleccionada.Id)).ToList());
            InscripcionExamenViewReport.Show();
            _form.TransitionTo(new InitialDisplayState(_form));
        }

        public void OnImprimirSeleccionadaPorMateria()
        {
            //tomo la materia seleccionada de la grilla dataGridMaterias
            var idMateria = (int)_form.dataGridMaterias.CurrentRow.Cells[0].Value;

            Form InscripcionExamenViewReport = new InscripcionExamenMateriaViewReport((MenuPrincipalView)_form.MdiParent, _form.listaDetallesInscripcionesExamenes.Where(d => d.InscripcionExamen.TurnoExamenId.Equals((int)_form.cboTurnosExamenes.SelectedValue) &&
                              d.InscripcionExamen.CarreraId.Equals((int)_form.cboCarreras.SelectedValue) &&
                              d.Materia.AnioCarreraId.Equals((int)_form.cboAniosCarreras.SelectedValue) &&
                              d.MateriaId.Equals(idMateria))
                        .OrderBy(x => x.InscripcionExamen?.Alumno?.ApellidoNombre)
                        .ToList());
            InscripcionExamenViewReport.Show();
            _form.TransitionTo(new InitialDisplayState(_form));
        }
    }
}
