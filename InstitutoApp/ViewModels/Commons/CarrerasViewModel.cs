using CommunityToolkit.Mvvm.Messaging;
using InstitutoApp.Class;
using InstitutoServices.Models.Commons;
using InstitutoServices.Services;
using InstitutoServices.Services.Commons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InstitutoApp.ViewModels.Commons
{
    public class CarrerasViewModel : NotificationObject
    {

		GenericService<Carrera> carreraService=new GenericService<Carrera>();

		private bool activityStart;
		public bool ActivityStart
		{
			get { return activityStart; }
			set { activityStart = value;
				OnPropertyChanged();
			}
		}

		private ObservableCollection<Carrera> carreras;
		public ObservableCollection<Carrera> Carreras
		{
			get { return carreras; }
			set { carreras = value;
				OnPropertyChanged();
			}
		}

		private Carrera carreraCurrent;
		public Carrera CarreraCurrent
		{
			get { return carreraCurrent; }
			set { carreraCurrent = value;
				OnPropertyChanged();
				EditarCommand.ChangeCanExecute();
				EliminarCommand.ChangeCanExecute();
			}
		}

        //porque hacemos esto, porque lo dijo Gabriel
        //https://chatgpt.com/share/9ab527ab-34a6-426c-b7a7-362c38e460a7
        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }



        public Command AgregarCommand { get; }
        public Command EditarCommand { get; }
        public Command EliminarCommand { get; }
        //public ICommand RefreshCommand => new Command(async () => await RefreshCarreras(this));

        public CarrerasViewModel()
        {
		
			AgregarCommand = new Command(Agregar);
            EditarCommand = new Command(Editar, PermitirEditar);
			EliminarCommand = new Command(Eliminar,PermitirEliminar);

			//RefreshCommand.Execute(null);
			Task.Run(async () => await ObtenerCarreras());
            //ObtenerCarreras();

            WeakReferenceMessenger.Default.Register<MyMessage>(this, (r, m) =>
            {
                AlRecibirMensaje(m);
            });
        }
        private async void AlRecibirMensaje(MyMessage m)
        {
            if (m.Value == "VolverACarreras")
            {
                await RefreshCarreras(this);
            }
        }

        private async Task RefreshCarreras(object obj)
        {
			IsRefreshing = true;
			await ObtenerCarreras();
            IsRefreshing = false;
        }

        private bool PermitirEliminar(object arg)
        {
            return carreraCurrent!=null;
        }

        private async void Eliminar(object obj)
        {
            bool respuesta = await Application.Current.MainPage.DisplayAlert("Eliminar una carrera", $"Está seguro que desea eliminar la carrera {carreraCurrent.Nombre}", "Si", "No");
            if (respuesta)
            {
                ActivityStart = true;
				await carreraService.DeleteAsync(carreraCurrent.Id);
				ObtenerCarreras();
            }
        }

        private bool PermitirEditar(object arg)
        {
            return carreraCurrent != null;
        }

        private async void Editar(object obj)
        {
            //WeakReferenceMessenger.Default.Send(new MyMessage("AbrirAddEditCarreraView") { Carrera=carreraCurrent});
            var navigationParameter = new ShellNavigationQueryParameters
            {
                { "CarreraAEditar", carreraCurrent }
            };
            await Shell.Current.GoToAsync("//AgregarEditarCarrera", navigationParameter);
        }

        private async void Agregar(object obj)
        {
            //WeakReferenceMessenger.Default.Send(new MyMessage("AbrirAddEditCarreraView"));
            var navigationParameter = new ShellNavigationQueryParameters
            {
                { "CarreraAEditar", null }
            };
            await Shell.Current.GoToAsync("//AgregarEditarCarrera", navigationParameter);
        }

        public async Task ObtenerCarreras()
        {
			ActivityStart = true;
            var carreras=await carreraService.GetAllAsync();
            Carreras = new ObservableCollection<Carrera>(carreras); ;
            ActivityStart = false;
			
        }
    }
}
