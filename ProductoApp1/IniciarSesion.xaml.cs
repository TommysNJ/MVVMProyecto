using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Ejemplo1.Models;
using ProductoApp1.Services;
using ProductoApp1.ViewModels;

namespace ProductoApp1;

public partial class IniciarSesion : ContentPage
{
    public IniciarSesion()
	{
		InitializeComponent();
	}

    private readonly APIService _APIService;
    private readonly IniciarSesionViewModel _viewModel;

    public IniciarSesion(APIService apiservice)
    {  
        InitializeComponent();
        _APIService = apiservice;
        _viewModel = new IniciarSesionViewModel();
        _viewModel.SetApiService(apiservice);
        BindingContext = _viewModel;
    }


    public async void OnClickIniciarSesion(object sender, EventArgs e)
    {
        int result = await _viewModel.OnClickIniciarSesion();
        Usuario user = await _viewModel.OnClickIniciarSesionI();

        if (result == 0)
        {
            await Navigation.PushAsync(new ListaProductos(_APIService, user));
        }
        else if (result == 1)
        {
            var toast = Toast.Make("No se encontró ninguna cuenta, revise sus credenciales.", ToastDuration.Short, 14);
            await toast.Show();
        }
        else
        {
            var toast = Toast.Make("Por favor, ingrese todos los datos solicitados.", ToastDuration.Short, 14);
            await toast.Show();
        }
    }   
}