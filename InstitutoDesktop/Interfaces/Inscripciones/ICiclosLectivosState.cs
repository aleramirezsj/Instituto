using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoDesktop.Interfaces.Inscripciones
{
    public interface ICiclosLectivosState
    {
        Task LoadData();
        void LoadGrid();
        void LoadGridFilter(string filterText);
        void OnAgregar();
        Task OnGuardar();
        void OnModificar();
        Task OnEliminar();
        void OnCancelar();
        void OnBuscar();
        void OnSalir();
        void UpdateUI();
    }
}
