using InstitutoApp.ViewModels.Commons;
using InstitutoServices.Services.Commons;

namespace InstitutoApp.Views.Commons;

public partial class CarrerasView : ContentPage
{
	public CarrerasView(IMemoryCacheService _memoryCacheService)
	{
		InitializeComponent();
		(BindingContext as CarrerasViewModel)._memoryCacheService = _memoryCacheService;

    }

	protected override void OnAppearing()
    {
        base.OnAppearing();
        var viewModel = BindingContext as CarrerasViewModel;
		viewModel.ObtenerCarreras();
		viewModel.CarreraCurrent = null;
    }

}