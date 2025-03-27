using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Interfaces.MesasExamenes;
using InstitutoDesktop.Views;
using InstitutoDesktop.ViewReports;
using InstitutoDesktop.Views.Inscripciones;
using InstitutoDesktop.Views.MesasExamenes;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Models.MesasExamenes;
using InstitutoDesktop.Interfaces.Inscripciones;

namespace InstitutoDesktop.States.Inscripciones.InscripcionesMaterias
{
    public class ActionsState : IInscripcionesMateriasViewState
    {
        private readonly InscripcionesMateriasView _form;

        public ActionsState(InscripcionesMateriasView form)
        {
            _form = form;
        }

        // Estos métodos no aplican en este estado
        public Task LoadData() => Task.CompletedTask;
        public void LoadGrid(string filterText)  { }
        public void OnBuscar() { }
        public void UpdateUI() { }
        public void OnSalir() => _form.Close();
        public void LoadComboboxPeriodosInscripciones() {}
        public void LoadComboboxCarreras() {}
        public void LoadComboboxAniosCarreras() {}

        public void OnImprimirTodasPorAlumno()
        {
            //necesito filtrar la lista de _form.listaDetallesInscripcionesExamenes dejando solo las que sean de alguna de las inscripciones a exámenes existentes en la lista _form.listaInscripcionesExamene

            Form InscripcionExamenViewReport = new InscripcionMateriasAlumnoViewReport((MenuPrincipalView)_form.MdiParent, _form.listaDetallesInscripciones.Where(d => _form.listaInscripcionesFiltrada.Any(i => i.Id.Equals(d.InscripcionId))).ToList());
            InscripcionExamenViewReport.Show();
            _form.TransitionTo(new InitialDisplayState(_form));

        }

        public void OnImprimirTodasPorMateria()
        {
            if (_form.chkFiltrarPorCarrera.Checked)
            {
                if (_form.chkFiltrarPorAñoCarrera.Checked)
                {
                    Form InscripcionExamenViewReport = new InscripcionPorMateriasViewReport((MenuPrincipalView)_form.MdiParent, _form.listaDetallesInscripciones.Where(d=>d.Materia.Nombre.ToUpper().Contains(_form.txtFiltroPorMateria.Text.ToUpper())&&
                         d.Inscripcion.PeriodoInscripcionId.Equals((int)_form.cboPeriodosInscripciones.SelectedValue) &&
                                      d.Inscripcion.CarreraId.Equals((int)_form.cboCarreras.SelectedValue) &&
                                      d.Materia.AnioCarreraId.Equals((int)_form.cboAniosCarreras.SelectedValue))
                                .OrderBy(x => x.Materia?.Nombre).ThenBy(x => x.Inscripcion?.Alumno?.ApellidoNombre)
                                .ToList());
                    InscripcionExamenViewReport.Show();
                }
                else
                {
                    Form InscripcionExamenViewReport = new InscripcionPorMateriasViewReport((MenuPrincipalView)_form.MdiParent, _form.listaDetallesInscripciones.Where(d => d.Materia.Nombre.ToUpper().Contains(_form.txtFiltroPorMateria.Text.ToUpper()) && d.Inscripcion.PeriodoInscripcionId.Equals((int)_form.cboPeriodosInscripciones.SelectedValue) &&
                        d.Inscripcion.CarreraId.Equals((int)_form.cboCarreras.SelectedValue))
                  .OrderBy(x => x.Materia?.Nombre).ThenBy(x => x.Inscripcion?.Alumno?.ApellidoNombre)
                  .ToList());
                    InscripcionExamenViewReport.Show();
                }
            }
            else
            {
                Form InscripcionExamenViewReport = new InscripcionPorMateriasViewReport((MenuPrincipalView)_form.MdiParent, _form.listaDetallesInscripciones.Where(d => d.Materia.Nombre.ToUpper().Contains(_form.txtFiltroPorMateria.Text.ToUpper()) && d.Inscripcion.PeriodoInscripcionId.Equals((int)_form.cboPeriodosInscripciones.SelectedValue))
                    .OrderBy(x => x.Materia?.Nombre).ThenBy(x => x.Inscripcion?.Alumno?.ApellidoNombre)
                    .ToList());
                InscripcionExamenViewReport.Show();
            }
            _form.TransitionTo(new InitialDisplayState(_form));
        }

        public void OnImprimirSeleccionadaPorMateria()
        {
            //tomo la materia seleccionada de la grilla dataGridMaterias
            var idMateria = (int)_form.dataGridMaterias.CurrentRow.Cells[0].Value;

            if (_form.chkFiltrarPorCarrera.Checked)
            {
                if (_form.chkFiltrarPorAñoCarrera.Checked)
                {
                    Form InscripcionExamenViewReport = new InscripcionPorMateriasViewReport((MenuPrincipalView)_form.MdiParent, _form.listaDetallesInscripciones.Where(d => d.Inscripcion.PeriodoInscripcionId.Equals((int)_form.cboPeriodosInscripciones.SelectedValue) &&
                                      d.Inscripcion.CarreraId.Equals((int)_form.cboCarreras.SelectedValue) &&
                                      d.Materia.AnioCarreraId.Equals((int)_form.cboAniosCarreras.SelectedValue) &&
                                      d.Materia.Id.Equals(idMateria))
                                .OrderBy(x => x.Materia?.Nombre).ThenBy(x => x.Inscripcion?.Alumno?.ApellidoNombre)
                                .ToList());
                    InscripcionExamenViewReport.Show();
                }
                else
                {
                    Form InscripcionExamenViewReport = new InscripcionPorMateriasViewReport((MenuPrincipalView)_form.MdiParent, _form.listaDetallesInscripciones.Where(d => d.Materia.Id.Equals(idMateria) && d.Inscripcion.PeriodoInscripcionId.Equals((int)_form.cboPeriodosInscripciones.SelectedValue) &&
                  d.Inscripcion.CarreraId.Equals((int)_form.cboCarreras.SelectedValue))
            .OrderBy(x => x.Materia?.Nombre).ThenBy(x => x.Inscripcion?.Alumno?.ApellidoNombre)
            .ToList());
                    InscripcionExamenViewReport.Show();

                }
            }
            else
            {
                Form InscripcionExamenViewReport = new InscripcionPorMateriasViewReport((MenuPrincipalView)_form.MdiParent, _form.listaDetallesInscripciones.Where(d => d.Materia.Id.Equals(idMateria) && d.Inscripcion.PeriodoInscripcionId.Equals((int)_form.cboPeriodosInscripciones.SelectedValue))
                    .OrderBy(x => x.Materia?.Nombre).ThenBy(x => x.Inscripcion?.Alumno?.ApellidoNombre)
                    .ToList());
                InscripcionExamenViewReport.Show();
            }
            _form.TransitionTo(new InitialDisplayState(_form));


            //        _form.dataGridAlumnos.DataSource = _form.listaDetallesInscripciones
            //.Where(d => d.MateriaId.Equals(idMateria) &&
            //            d.Inscripcion.PeriodoInscripcionId.Equals((int)_form.cboPeriodosInscripciones.SelectedValue) &&
            //            d.Inscripcion.CarreraId.Equals((int)_form.cboCarreras.SelectedValue))
            //.Select(Alumno => new { Alumno = Alumno.Inscripcion.Alumno.ApellidoNombre, Modalidad_cursado = Alumno.ModalidadCursado.ToString() })
            //.OrderBy(x => x.Alumno).ToList();



        }

        public void OnImprimirSeleccionadaPorAlumno()
        {
            //tomo la inscripción seleccionada de la grilla dataGridViewInscripciones
            Inscripcion inscripcionSeleccionada = (Inscripcion)_form.dataGridInscripciones.CurrentRow.DataBoundItem;
            Form InscripcionExamenViewReport = new InscripcionMateriasAlumnoViewReport((MenuPrincipalView)_form.MdiParent, _form.listaDetallesInscripciones.Where(d => d.InscripcionId.Equals(inscripcionSeleccionada.Id)).ToList());
            InscripcionExamenViewReport.Show();
            _form.TransitionTo(new InitialDisplayState(_form));
        }

    }
}
