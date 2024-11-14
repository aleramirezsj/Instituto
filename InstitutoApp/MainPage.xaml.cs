using CommunityToolkit.Mvvm.Messaging;
using InstitutoApp.Class;
using InstitutoApp.Views;
using InstitutoApp.Views.Commons;

namespace InstitutoApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            //código para preparar la recepción de mensajes y la llamada al método RecibirMensaje
            //WeakReferenceMessenger.Default.Register<MyMessage>(this, (r, m) =>
            //{
            //    AlRecibirMensaje(m);
            //});
        }

        //private async void AlRecibirMensaje(MyMessage m)
        //{
        //    if (m.Value == "AbrirAddEditCarreraView")
        //    {
        //        await Navigation.PushAsync(new AddEditCarreraView(m.Carrera));
        //    }
        //    if (m.Value == "AbrirCarreras")
        //    {
        //        await Navigation.PushAsync(new CarrerasView());
        //    }
        //    if (m.Value == "VolverACarreras")
        //    {
        //        await Navigation.PopAsync();
        //    }
        //}

        private async void BtnCarreras_Clicked(object sender, EventArgs e)
        {
            WeakReferenceMessenger.Default.Send(new MyMessage("AbrirCarreras"));
        }
    }

}
