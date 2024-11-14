using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoDesktop.Interfaces.Commons
{
    public interface IPeriodosHorariosViewState : IBaseViewState
    {
        Task LoadComboboxCiclosLectivos();
    }
}
