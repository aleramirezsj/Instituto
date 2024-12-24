﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoDesktop.Interfaces.Commons
{
    public interface IUsuariosViewState : ICrudViewState
    {
        Task LoadComboboxDocentes();
        Task LoadComboboxAlumnos();
        void LoadComboboxTipoUsuario();
    }
}
