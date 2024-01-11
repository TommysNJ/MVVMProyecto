using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Ejemplo1.Models;
using ProductoApp1.Services;
using ProductoApp1.ViewModels;

namespace ProductoApp1;

public partial class Registrarse : ContentPage
{


    private readonly APIService _APIService;
    private readonly RegistrarseViewModel _viewModel;

    public Registrarse(APIService apiservice)
    {
        InitializeComponent();
        _APIService = apiservice;
        _viewModel = new RegistrarseViewModel();
        _viewModel.SetApiService(apiservice);
        BindingContext = _viewModel;

    }

    private async void OnClickRegistrarse(object sender, EventArgs e)
    {
        int result = await _viewModel.OnClickRegistrarse();

        if (result == 0)
        {
            await Navigation.PushAsync(new ListaProductos(_APIService));
        } else if (result == 1)
        {
            var toast = Toast.Make("Ya existe una cuenta con esas credenciales.", ToastDuration.Short, 14);
            await toast.Show();
        }
        else
        {
            var toast = Toast.Make("Ingrese todos los datos solicitados!!!", ToastDuration.Short, 14);
            await toast.Show();
        }
    }
}