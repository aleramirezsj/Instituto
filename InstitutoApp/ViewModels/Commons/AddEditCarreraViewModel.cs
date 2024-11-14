using CommunityToolkit.Mvvm.Messaging;
using InstitutoApp.Class;
using InstitutoServices.Models.Commons;
using InstitutoServices.Services;
using InstitutoServices.Services.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoApp.ViewModels.Commons
{
    public class AddEditCarreraViewModel: NotificationObject
    {

        private Carrera carrera;

        public Carrera Carrera
        {
            get { return carrera; }
            set { carrera = value;
                if (value != null)
                {
                    Nombre = carrera.Nombre;
                    Sigla = carrera.Sigla;
                    OnPropertyChanged();
                }
                else
                {
                    Nombre = string.Empty;
                    Sigla = string.Empty;
                    OnPropertyChanged();
                }
            }
        }


        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value;
                OnPropertyChanged();
                GuardarCommand.ChangeCanExecute();
            }
        }

        private string sigla;
        public string Sigla
        {
            get { return sigla; }
            set { sigla = value; 
                OnPropertyChanged();
                GuardarCommand.ChangeCanExecute();
            }
        }



        public Command GuardarCommand { get; }
        public Command CancelarCommand { get; }

        public IMemoryCacheService? _memoryCacheService;

        public AddEditCarreraViewModel()
        {
            GuardarCommand = new Command(Guardar, PermitirGuardar);
            CancelarCommand = new Command(Cancelar);
        }

        private async void Cancelar(object obj)
        {
            await Shell.Current.GoToAsync("//ListaCarreras");
        }

        private bool PermitirGuardar(object arg)
        {
            return !string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(Sigla);
        }

        private async void Guardar(object obj)
        {
            if (Carrera == null)
            {
                var carrera = new Carrera() { Nombre = this.Nombre, Sigla = this.Sigla };
                await _memoryCacheService.AddCacheAsync<Carrera>(carrera);
            }
            else
            {
                Carrera.Nombre = this.Nombre;
                Carrera.Sigla = this.Sigla;
                await _memoryCacheService.UpdateCacheAsync<Carrera>(Carrera);
            }
            //WeakReferenceMessenger.Default.Send(new MyMessage("VolverACarreras"));
            await Shell.Current.GoToAsync("//ListaCarreras");
        }
    }
}
