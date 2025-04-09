using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoDesktop.Interfaces
{
    public interface IInstitucionViewState
    {
        Task LoadData();
        void OnModificar();
        Task OnGuardar();
        void OnCancelar();
        void OnSalir();
        void UpdateUI();
    }
}
