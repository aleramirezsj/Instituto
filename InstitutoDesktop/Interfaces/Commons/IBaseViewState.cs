using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoDesktop.Interfaces.Commons
{
    public interface IBaseViewState
    {
        Task LoadData();
        void LoadGrid(string filterText);
        void OnBuscar();
        void OnSalir();
        void UpdateUI();
    }
}
