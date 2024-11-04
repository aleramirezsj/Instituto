using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoDesktop.Interfaces.Commons.Materias
{
    public interface IMateriasState
    {
        Task ObtenerListasAsync();
        void CargarCboCarreras();
        void CargarCboAnioCarreras();
        Task CargarDatosEnGrillaAsync();
    }
}
