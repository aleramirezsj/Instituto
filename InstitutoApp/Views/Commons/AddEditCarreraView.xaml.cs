using InstitutoApp.ViewModels.Commons;
using InstitutoServices.Models.Commons;
using InstitutoServices.Services.Commons;

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

	public AddEditCarreraView(IMemoryCacheService _memoryCacheService)
	{
		InitializeComponent();
        (BindingContext as AddEditCarreraViewModel)._memoryCacheService = _memoryCacheService;
    }
    
}