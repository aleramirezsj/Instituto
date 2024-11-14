using InstitutoApp.ViewModels.Commons;
using InstitutoServices.Models.Commons;

namespace InstitutoApp.Views.Commons;

[QueryProperty(nameof(CarreraToEdit), "CarreraAEditar")]
public partial class AddEditCarreraView : ContentPage
{
    public Carrera CarreraToEdit
    {
        set
        {
            var carrera = value;
            var viewmodel = this.BindingContext as AddEditCarreraViewModel;
            viewmodel.Carrera = carrera;
        }
    }
    AddEditCarreraViewModel viewModel;

	public AddEditCarreraView()
	{
		InitializeComponent();
	}
    
}