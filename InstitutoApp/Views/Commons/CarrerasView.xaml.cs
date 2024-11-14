using InstitutoApp.ViewModels.Commons;

namespace InstitutoApp.Views.Commons;

public partial class CarrerasView : ContentPage
{
	public CarrerasView()
	{
		InitializeComponent();
		BindingContext = new CarrerasViewModel();
	}

	protected override void OnAppearing()
    {
        base.OnAppearing();
        var viewModel = BindingContext as CarrerasViewModel;
		viewModel.ObtenerCarreras();
		viewModel.CarreraCurrent = null;
    }

}