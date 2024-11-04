using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoDesktop.Interfaces.Commons
{
    public interface IDocentesState
    {
        Task LoadData();
        Task LoadGrid();
        Task LoadGridFilter(string filterText);
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
