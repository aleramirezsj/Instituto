using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Services;
using InstitutoServices.Interfaces;
using InstitutoServices.Services.Commons;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoDesktop.Interfaces.Views
{
    public interface IBaseView<T> where T : IEntityIdNombre
    {
        List<T>? lista { get; set; }
        T current { get; set; }
        ICrudViewState _currentState { get; set; }
        MemoryCacheServiceWinForms _memoryCache { get; set; }
        TabControl TabControl { get; set; }
        TabPage TabPageLista { get; set; }
        DataGridView Grilla { get; set; }
        TabPage TabPageAgregarEditar { get; set; }
        FontAwesome.Sharp.IconButton BtnCancelar { get; set; }
        FontAwesome.Sharp.IconButton BtnGuardar { get; set; }
        FontAwesome.Sharp.IconButton BtnAgregar { get; set; }
        FontAwesome.Sharp.IconButton BtnModificar { get; set; }
        FontAwesome.Sharp.IconButton BtnEliminar { get; set; }
        FontAwesome.Sharp.IconButton BtnSalir { get; set; }
        FontAwesome.Sharp.IconButton BtnBuscar { get; set; }
        TextBox TxtFiltro { get; set; }
        TextBox TxtNombre { get; set; }
        void TransitionTo(ICrudViewState state);
        void Close();
    }
}
